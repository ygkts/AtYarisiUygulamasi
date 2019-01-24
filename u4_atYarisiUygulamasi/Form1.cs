using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace u4_atYarisiUygulamasi
{
    public partial class Form1 : Form
    {
        int skorAt3 = 0;
        int skorAt4 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();     //  veya =  timer1.Enabled = true;      
            label1.Text = "YARIŞ BAŞLADI.";
            pcbAt1.Left = 0;
            pcbAt2.Left = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;       // program çalışırken form tam ekran açılsın
            // butonun otomatik boyutlandırılması.
            button1.AutoSizeMode = AutoSizeMode.GrowOnly;
            button1.AutoSize = true;        // otomatik boyutlandırma aktif
            button1.Dock = DockStyle.Top;   // yatayda sabitle
            //label1.Dock = DockStyle.Top;

            pcbAt1.Hide();
            pcbAt2.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pcbAt1.Show();
            pcbAt2.Show();
            Random rnd = new Random();
            int sayi1 = rnd.Next(10, 50);
            int sayi2 = rnd.Next(10, 50);
            
            pcbAt1.Left += sayi1;   // pictureBox'ın(atın) sola olan uzaklığını sayi1 kadar arttır. Bu sayede at, random uzaklıklarla hareket ediyor.
            pcbAt2.Left += sayi2;

            if (pcbAt1.Right >= this.Width || pcbAt2.Right >= this.Width)     // atlardan herhangi birinin sağa olan yakınlığı, form2un genişliğini geçtiyse
            {
                timer1.Stop();  // veya = timer1.Enabled = false;  --> timer durdur.
                label1.Text = "YARIŞ BİTTİ.";
                if (pcbAt1.Right > pcbAt2.Right)
                {
                    MessageBox.Show("3 numaralı at KAZANDI...");
                    skorAt3++;
                    label2.Text = "3 Nolu At:  "+ skorAt3;
                    
                }
                else
                {
                    MessageBox.Show("4 numaralı at KAZANDI...");
                    skorAt4++;
                    label3.Text = "4 Nolu At:  " + skorAt4;
                    
                }
            }
        }
    }
}
