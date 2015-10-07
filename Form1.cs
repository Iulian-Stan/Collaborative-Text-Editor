using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Editor_Text_Colaborativ
{
    public partial class Form1 : Form
    {
        Server s;
        Client c;
        Thread t;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBold_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text
            oldFont = this.richTextBoxText.SelectionFont;
            // If the font is using bold style now, we should remove the
            // Formatting.
            if (oldFont.Bold)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
                toolStripStatusLabelBold.Enabled = false;
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
                toolStripStatusLabelBold.Enabled = true;
            }
            // Insert the new font and return focus to the RichTextBox.
            this.richTextBoxText.SelectionFont = newFont;
            this.richTextBoxText.Focus();
        }

        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text.
            oldFont = this.richTextBoxText.SelectionFont;
            // If the font is using Underline style now, we should remove it.
            if (oldFont.Underline)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
                toolStripStatusLabelUnderline.Enabled = false;
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
                toolStripStatusLabelUnderline.Enabled = true;
            }
            // Insert the new font.
            this.richTextBoxText.SelectionFont = newFont;
            this.richTextBoxText.Focus();
        }

        private void buttonItalic_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text.
            oldFont = this.richTextBoxText.SelectionFont;

            // If the font is using Italic style now, we should remove it.
            if (oldFont.Italic)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
                toolStripStatusLabelItalic.Enabled = false;
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
                toolStripStatusLabelItalic.Enabled = true;
            }
            // Insert the new font.
            this.richTextBoxText.SelectionFont = newFont;
            this.richTextBoxText.Focus();
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            if (this.richTextBoxText.SelectionAlignment == HorizontalAlignment.Center)
                this.richTextBoxText.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.richTextBoxText.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBoxText.Focus();
        }

        private void textBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Remove all characters that are not numbers, backspace, or enter.
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                // Apply size if the user hits enter
                TextBox txt = (TextBox)sender;
                if (txt.Text.Length > 0)
                    ApplyTextSize(txt.Text);
                e.Handled = true;
                this.richTextBoxText.Focus();
            }
        }

        private void textBoxSize_Validated(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            ApplyTextSize(txt.Text);
            this.richTextBoxText.Focus();
        }

        private void ApplyTextSize(string textSize)
        {
            // Convert the text to a float because we’ll be needing a float shortly.
            float newSize = Convert.ToSingle(textSize);
            FontFamily currentFontFamily;
            Font newFont;
            // Create a new font of the same family but with the new size.
            currentFontFamily = this.richTextBoxText.SelectionFont.FontFamily;
            newFont = new Font(currentFontFamily, newSize);
            // Set the font of the selected text to the new font.
            this.richTextBoxText.SelectionFont = newFont;
        }

        private void richTextBoxText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            String myIP = "127.0.0.1";
            if (MessageBox.Show("\tIP Server\nYes = localhost / No = IPv4", "IP", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                string myHost = System.Net.Dns.GetHostName();
                for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
                {
                    if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6LinkLocal == false &&
                        System.Net.Dns.GetHostEntry(myHost).AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                        break;
                    }
                }
            }
            MessageBox.Show("A fost setat " + myIP);
            s = new Server(this.richTextBoxText, myIP);
            Thread t = new Thread(new ThreadStart(s.StartServer));
            t.Start();
            connect(false);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\tAtentie !\nToate datele nesalvate vor fi sterse.", "Conectare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                richTextBoxText.ResetText();
                String sIP = "127.0.0.1";
                sIP = InputBoxDialog.InputBox("\tIP Server", "IP", "127.0.0.1");
                c = new Client(this.richTextBoxText, sIP);
                Thread t = new Thread(new ThreadStart(c.StartClient));
                t.Start();
                connect(false);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            this.richTextBoxText.ResetText();
            this.textBoxSize.Text = richTextBoxText.Font.Size.ToString();
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(s.OpenFile());
                writer.Write(richTextBoxText.Text);
                writer.Close();
            }
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                Stream file = o.OpenFile();
                StreamReader reader = new StreamReader(file);
                char[] data = new char[file.Length];
                reader.ReadBlock(data, 0, (int)file.Length);
                richTextBoxText.Text = new String(data);
                reader.Close();
            }
        }

        private void close()
        {
            if (s != null)
                s.CloseServer();
            if (c != null)
                c.CloseClient();
        }

        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editor text colaborativ by Stan Iulian");
        }

        private void textChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Number of characters: " + richTextBoxText.Text.Length;
        }

        private void connect(bool b)
        {
            this.buttonServer.Enabled = b;
            this.buttonClient.Enabled = b;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            close();
            connect(true);
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            if ((sender as RichTextBox).SelectionLength != 0)
                (sender as RichTextBox).SelectionLength = 0;
        }
    }
}