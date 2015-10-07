using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Editor_Text_Colaborativ
{
    public partial class Server
    {
        private AsyncCallback DataReceiveCallBack;
        private byte[] buffer = new byte[128];
        //soclu folosit pentru ascultat cereri de conectare
        private Socket listener = null;
        //soclu folosit pentru comunicare
        private Socket communicator = null;
        //delegate necesar pentru accesarea text box-ului de afisare
        private Action<string, Socket> DelegateShowText;
        private Action<Socket> DelegateSendText;
        //editorul de text
        private RichTextBox rt;
        private string IP;
        private ArrayList list;
        private int len = 0;

        public Server(RichTextBox rt, String IP)
        {
            this.rt = rt;
            this.IP = IP;
        }

        public void StartServer()
        {
            try
            {
                //creez un soclu
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //se creeza un endpoint pentru server
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Parse(IP), 8888);
                //setez endpoint-ul creat
                listener.Bind(ipLocal);
                //soclul trece in starea de ascultare;coada de asteptare este de 4 clienti
                listener.Listen(4);
                list = new ArrayList(4);
                //incep ascultarea neblocanta a conexiunilor
                //orice incercare de conectare va fi tratata de metoda OnClientConnect
                listener.BeginAccept(new AsyncCallback(OnClientConnect), null);
                //creez delegatul pentru afisarea mesajelor
                DelegateShowText = new Action<string, Socket>(ShowText);
                //atashez un handler pt schimbarea textului
                rt.TextChanged += new System.EventHandler(textChanged);
                DelegateSendText = new Action<Socket>(SendText);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ShowText(string text, Socket s)
        {
            rt.TextChanged -= new System.EventHandler(textChanged);
            int poz = text.IndexOf(' ');
            int p = Convert.ToInt32(text.Substring(0, poz++));
            lock (rt)
            {
                if (poz != text.Length - 1)
                    rt.Text = rt.Text.Insert(p - text.Length + poz + 2, text.Substring(poz, text.Length - poz - 1));
                else
                    rt.Text = rt.Text.Substring(0, ++p) + rt.Text.Substring(++p);
                len = rt.Text.Length;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != s)
                    try
                    {
                        (list[i] as Socket).Send(Encoding.ASCII.GetBytes(text.Substring(0, text.Length - 1)));
                    }
                    catch (SocketException se)
                    {
                        list.RemoveAt(i--);
                    }
            }
            rt.TextChanged += new System.EventHandler(textChanged);
        }

        private void OnClientConnect(IAsyncResult asyn)
        {
            if (listener == null || list.Count == 4)
                return;
            try
            {
                //conexiunea a fost acceptata 
                communicator = listener.EndAccept(asyn);
                list.Add(communicator);
                rt.Invoke(DelegateSendText, new object[] { communicator });
                //se incepe ascultarea mesajelor
                WaitForData(communicator);
                //incep ascultarea neblocanta a conexiunilor
                //orice incercare de conectare va fi tratata de metoda OnClientConnect
                listener.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void WaitForData(Socket soc)
        {
            if (soc == null || !soc.Connected)
                return;
            try
            {
                if (DataReceiveCallBack == null)
                {
                    //preluarea mesajelor este realizata de metoda OnDataReceived
                    DataReceiveCallBack = new AsyncCallback(OnDataReceived);
                }
                soc.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceiveCallBack, soc);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void OnDataReceived(IAsyncResult asyn)
        {
            Socket com = asyn.AsyncState as Socket;
            try
            {
                int iRx = 0;
                iRx = com.EndReceive(asyn);
                if (iRx == 0)
                    return;
                char[] chars = new char[iRx + 1];
                Decoder d = Encoding.ASCII.GetDecoder();
                int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                String szData = new String(chars);
                rt.Invoke(DelegateShowText, new object[] { szData, com });
                //astept primirea unui nou mesaj
                WaitForData(com);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void CloseServer()
        {
            if (listener != null)
            {
                listener.Close();
                listener = null;
            }
            if (communicator != null)
            {
                if (communicator.Connected)
                    communicator.Shutdown(SocketShutdown.Both);
                communicator.Close();
                communicator = null;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                try
                {
                    RichTextBox rtb = sender as RichTextBox;
                    byte[] msg = Encoding.ASCII.GetBytes((rtb.SelectionStart - 1).ToString() + " " +
                        (len < rtb.Text.Length ? rtb.Text.Substring(rtb.SelectionStart - rtb.Text.Length + len, rtb.Text.Length - len) : ""));
                    len = rtb.Text.Length;
                    for (int i = 0; i < list.Count; i++)
                    {
                        try
                        {
                            (list[i] as Socket).Send(msg);
                        }
                        catch (SocketException se)
                        {
                            list.RemoveAt(i--);
                        }
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        private void SendText(Socket c)
        {
            if (rt.Text.Length != 0)
            {
                byte[] msg = Encoding.ASCII.GetBytes((rt.TextLength - 1) + " " + rt.Text);
                c.Send(msg);
            }
        }
    }
}