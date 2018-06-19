using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jocuri
{
    public partial class Tantari : Form
    {
        public Tantari()
        {
            InitializeComponent();
        }
        int x=5;
        int y=6;
        int z=60;
        int niv = 0;
        int sec = 0;
        int totalsec = 0;
        int puncte = 0;
        int[] speedx = new int[100];
        int[] speedy = new int[100];
        int[] pozy = new int[100];
        int[] pozx = new int[100];
        string exepath = Application.StartupPath + "\\Tantari\\";
        bool iesidreapta = true;
        bool start = true;
        PictureBox [] flut=new PictureBox[100];

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize= this.Size;    
            groupBox1.Left = this.Width;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

        }
        private void punefluturi()
        {
           
            if (niv == 1)
            {
                x = 5;
                y = 25;
                z = 30;
            }
            else if (niv == 2)
            {
                x = 15;
                y = 20;
                z = 30;
            }
            else if (niv == 3)
            {
                x = 30;
                y = 15;
                z = 60;
                timer3.Enabled = true;
            }
            Random r = new Random();
            for (int i = 1; i <= x; i++)
            {
                flut[i] = new PictureBox();
                flut[i].SizeMode = PictureBoxSizeMode.StretchImage;
                flut[i].Load(exepath+"Alivebutterfly.png");
                flut[i].Name = "A";
                flut[i].Visible = true;
                flut[i].Size = new Size(30, 30);
                flut[i].Tag = 1;    
                flut[i].Left = r.Next(0, this.Width - flut[i].Width-30);
                flut[i].Top = r.Next(0, this.Height - flut[i].Height-30);
                flut[i].Click += new EventHandler(moare);
                pozx[i] = flut[i].Left;
                pozy[i] = flut[i].Top;
                this.Controls.Add(flut[i]);
            }
            timer2.Enabled = true;
        }
        private void moare(object sender, EventArgs e)
        {
            PictureBox aux = (PictureBox)sender;
            aux.Name = "D";
            aux.Load(exepath + "Deadbutterfly.png");
            aux.Tag = 0;
            bool totimorti=true;
            for (int i = 1; i <= x; i++)
                if (flut[i].Name == "A") totimorti = false;
            if (totimorti)
            {
                for (int i = 1; i <= x; i++)
                {
                    flut[i].Visible = false;
                }
                puncte += (10 * x);
                sec = 0;
                punefluturi();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            groupBox1.Enabled = false;
            
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (iesidreapta)
            {
                groupBox1.Left--;
                if (groupBox1.Left <= this.Width-groupBox1.Width-5) { timer1.Enabled = false; iesidreapta = false; groupBox1.Enabled = true; }
            }
            else
            {
                groupBox1.Left++;
                if (groupBox1.Left >= this.Width) { timer1.Enabled = false; iesidreapta = true; }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            niv = 1;
            timer1.Enabled = true;
            groupBox1.Enabled = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            totalsec++;
            if (totalsec == z)
            {
                MessageBox.Show(puncte + " puncte");
                this.Close();
            }
            if (sec == y)
            {
                timer2.Enabled = false;
                sec = 0;
                for (int i = 1; i <= x; i++)
                {
                    if (flut[i].Name == "A") puncte += 20;
                    else puncte -= 5;
                    flut[i].Visible = false;
                } 
               
                punefluturi();
            }
        }
        private void muta()
        {
            for (int i = 1; i <= x; i++)
            {
                if (flut[i].Tag.ToString() == "0") pozy[i] += Math.Abs(speedy[i])+10;
                flut[i].Top = pozy[i] += speedy[i];
                flut[i].Left = pozx[i] += speedx[i];
                if (flut[i].Top <= 0 || flut[i].Top >= this.Height - flut[i].Height - 50)
                { if (flut[i].Tag.ToString() != "0")  speedy[i] *= (-1); }
                if (flut[i].Left <= 0 || flut[i].Left >= this.Width - flut[i].Width)
                { if (flut[i].Tag.ToString() != "0") speedx[i] *= (-1); }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            niv = 2;
            timer1.Enabled = true;
            groupBox1.Enabled = false;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            niv = 3;
            timer1.Enabled = true;
            groupBox1.Enabled = false;
        }
        private void Form1_Click(object sender, EventArgs e)
        {

            if (start) { punefluturi(); start = false; 
            for (int i = 1; i <= x; i++)
            {
                Random r = new Random();
                speedx[i] = 3;
                speedy[i] = 3;
            }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            muta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a incepe jocul apasa pe butonul cu sageata ( < ) si alege un nivel de dificultate. Apasa apoi pe partea alba pentru a incepe. Scopul jocului este sa omori tantarii de pe ecran( Click pe ei ). Atentie, daca se scurge timpul rundei nu vei primii punctele pentru tantarii ramasi in viata");
        }

       

    }
}
