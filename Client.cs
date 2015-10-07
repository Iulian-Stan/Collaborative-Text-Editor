using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Editor_Text_Colaborativ
{
    class Client
    {
        byte[] buffer = new byte[128];
        public AsyncCallback DataReceiveCallBack;
        public Socket socClient;
        //delegate necesar pentru accesarea text box-ului de afisare
        private Action<string> DelegateShowText;
        private RichTextBox rt;
        private string IP;
        private int len = 0;

        public Client(RichTextBox rt, string IP)
        {
            this.rt = rt;
            this.IP = IP;
        }

        public void StartClient()
        {
            try
            {
                //creez un nou soclu
                socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //creez un endpoint 
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(IP), 8888);
                //se incearca stabilirea unei conexiuni cu serverul
                socClient.Connect(ipEnd);
                //creez delegatul pentru afisarea mesajelor
                DelegateShowText = new Action<string>(ShowText);
                //asignez un handler modificarilor textulu
                rt.TextChanged += new System.EventHandler(textChanged);
                //incep ascultarea asincrona a mesajelor
                WaitForData();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ShowText(string text)
        {
            rt.TextChanged -= new System.EventHandler(textChanged);
            int poz = 0;
            int l, p, poz2;
            while ((poz = text.IndexOf(' ')) != -1)
            {
                if (text.IndexOf('-') == 0)
                {
                    l = Convert.ToInt32(text.Substring(1, poz++));
                    l *= -1;
                }
                else
                    l = Convert.ToInt32(text.Substring(0, poz++));
                poz2 = text.IndexOf(' ', poz);
                p = Convert.ToInt32(text.Substring(poz, (poz2++) - poz));
                if (l > 0)
                    rt.Text = rt.Text.Insert(p - l + 1, text.Substring(poz2, l));
                else
                {
                    rt.Text = rt.Text.Substring(0, ++p) + rt.Text.Substring(++p);
                    l = 0;
                }
                len = rt.Text.Length;
                text = text.Substring(poz2 + l);
            }
            rt.TextChanged += new System.EventHandler(textChanged);
        }

        private void WaitForData()
        {
            if (socClient == null || !socClient.Connected) return;
            try
            {
                if (DataReceiveCallBack == null)
                {
                    //preluarea mesajelor este realizata de metoda OnDataReceived
                    DataReceiveCallBack = new AsyncCallback(OnDataReceived);
                }
                // incep ascultare mesajelor
                socClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceiveCallBack, null);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void OnDataReceived(IAsyncResult asyn)
        {
            if (socClient == null || !socClient.Connected) return;
            try
            {
                int iRx = 0;
                iRx = socClient.EndReceive(asyn);
                if (iRx == 0) return;
                char[] chars = new char[iRx + 1];
                Decoder d = Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                String szData = new String(chars);
                rt.Invoke(DelegateShowText, new object[] { szData });
                //astept primirea unui nou mesaj
                WaitForData();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void CloseClient()
        {
            if (socClient != null)
            {
                try
                {
                    socClient.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException se)
                {
                }
                socClient.Close();
                socClient = null;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (socClient != null && socClient.Connected)
            {
                try
                {
                    RichTextBox rtb = sender as RichTextBox;
                    byte[] msg = Encoding.ASCII.GetBytes((rtb.Text.Length - len) + " " + (rtb.SelectionStart - 1).ToString() + " " +
                         (len < rtb.Text.Length ? rtb.Text.Substring(rtb.SelectionStart - rtb.Text.Length + len, rtb.Text.Length - len) : ""));
                    len = rtb.Text.Length;
                    socClient.Send(msg);
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }
    }
}