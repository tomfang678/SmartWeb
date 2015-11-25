using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UntilTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDesc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtdesStr.Text.Trim()))
            {
                this.txtascStr.Text = Encrypt.Encode(this.txtdesStr.Text.Trim());
            }
        }

        private void btnAsc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtascStr.Text.Trim()))
            {
                this.txtdesStr.Text = Encrypt.Decode(this.txtascStr.Text.Trim());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str = "";
            var img = new ValidateCode_Style1().CreateImage(out str);
            this.pictureBox1.Image = StreamHelper.BytToImg(img);
        }
    }
}
