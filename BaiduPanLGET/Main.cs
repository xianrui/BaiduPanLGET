using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using BaiduPanLGET.Core;

namespace BaiduPanLGET
{
    public partial class Main : Form
    {
        public static Image captcha;
        public static string dlink;
        public static string md5;
        public static string filename;
        public Main()
        {
            InitializeComponent();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PAN pan = new PAN();
            if (urlText.Text != "")
            {
                pan.parse_url(urlText.Text);
                if (pan.parse_result != true)
                {
                    pan.parse_url(urlText.Text);
                }
                else
                {
                    pan.get_dllink();
                }
            }
            else
            {
                MessageBox.Show("Url must not be empty.");
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {

            }
            else
            {
                dlText.Text = dlink;
                md5Text.Text = md5;
                filenameText.Text = filename;
                label3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dlText.Text);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}