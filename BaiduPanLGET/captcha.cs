using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanLGET
{
    public partial class captcha : Form
    {
        public captcha()
        {
            InitializeComponent();
        }

        private void captcha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Main.captcha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
