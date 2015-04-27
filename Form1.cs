using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace calTeleAddr
{
    public partial class Form1 : Form
    {
        private DateTime dt1, dt2;
        private TimeSpan deltat;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            long storeTime, block, hang, kuai, block2, hang2, kuai2;
            long storeByte,haveByte;
            if (txtTime1.Text == "")
            {
                MessageBox.Show("日期不能留空!", "确定");
            }
            if (txtTime2.Text == "")
            {
                MessageBox.Show("日期不能留空!", "确定");
            }
            if ((txtBlock.Text == "") && (txtHang.Text == "") && (txtKuai.Text == ""))
            {
                MessageBox.Show("地址不能留空!", "确定");
            }
            block = int.Parse(txtBlock.Text.ToString());
            block2 = block;
            hang = int.Parse(txtHang.Text.ToString());
            kuai = int.Parse(txtKuai.Text.ToString());
            dt1 = Convert.ToDateTime(txtTime1.Text.ToString());
            dt2 = Convert.ToDateTime(txtTime2.Text.ToString());
            if (dt2 > dt1)
            {
                deltat = dt2 - dt1;
                storeTime = (long)deltat.TotalMinutes / 3;
                storeByte = 768 * storeTime;
                haveByte = hang * 2048 + kuai;
                haveByte += storeByte;
                kuai2 = haveByte % 2048;
                hang2 = haveByte / 2048;
                if (hang2 > 32768)
                {
                    hang2 -= 32768;
                }
            }
            else
            {
                deltat = dt1 - dt2;
                storeTime = (long)deltat.TotalMinutes / 3;
                storeByte = 768 * storeTime;
                haveByte = hang * 2048 + kuai;
                if (haveByte < storeByte)
                {
                    haveByte = haveByte + 32768 * 2048;
                }
                haveByte = haveByte - storeByte;
                kuai2 = haveByte % 2048;
                hang2 = haveByte / 2048;
            }
            txtBlock2.Text = block2.ToString();
            txtHang2.Text = hang2.ToString();
            txtKuai2.Text = kuai2.ToString();
        }
    }
}
