using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://localhost:40123/Lab7/Feed1/" + textBox1.Text + "?format=rss");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            string content = new StreamReader(res.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://localhost:40123/Lab7/Feed1/" + textBox1.Text + "?format=atom");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            string content = new StreamReader(res.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;
        }
    }
}
