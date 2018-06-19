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
    public partial class Mere : Form
    {
        public Mere()
        {
            InitializeComponent();
        }
        int x;
        PictureBox []p;
        int copy=0;
        bool done = false;
        string exepath = Application.StartupPath + "\\Mere\\";
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.Width = 1000;
                x = int.Parse(textBox1.Text.ToString());
                if (x % 2 == 0) MessageBox.Show("Te rog introdu un numar impar");
                else if (radioButton1.Checked == false && radioButton2.Checked == false) MessageBox.Show("Te rog alege un nivel de dificulate");
                else
                {
                    if (copy > 0)
                        for (int i = 1; i <= copy; i++)

                            this.Controls.Remove(p[i]);
                    copy = x;
                    p = new PictureBox[x + 1];

                    int wide = this.Width / x;
                    for (int i = 1; i <= x; i++)
                    {
                        p[i] = new PictureBox();
                        p[i].Load(exepath + "1.Jpg");
                        p[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        p[i].Size = new Size(wide, wide);
                        p[i].Top = 100;
                        p[i].Left = wide * (i - 1);
                        p[i].MouseUp += new MouseEventHandler(click);
                        p[i].Tag = "F";
                        this.Controls.Add(p[i]);
                    }
                    this.Height = 60 + p[1].Top + p[1].Height;

                    //Miscarea Calculatorului
                    MessageBox.Show("Este Randul Calculatorului");
                    Random r = new Random();
                    int y = r.Next(1, x);
                    p[y].Load(exepath + "4.JPG");
                    p[y].Tag = "D";
                    p[y].Enabled = false;

                    //------------------------
                    MessageBox.Show("Este randul tau");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Te rog introdu un numar");
            }
           
        }

        private void click(object sender, MouseEventArgs e)
        {
            PictureBox aux = (PictureBox)sender;
            int misc = 0;
            if (aux.Enabled == true)
            {
                //Miscarea jucatorului

                if (e.Button == MouseButtons.Right && aux.Tag.ToString() == "F")
                {
                    aux.Load(exepath + "3.Jpg");
                    aux.Tag = "D";
                    misc = 3;
                }
                else if (e.Button == MouseButtons.Left && aux.Tag.ToString() == "F")
                {
                    aux.Tag = "J";
                    aux.Load(exepath + "2.Jpg");
                    misc = 2;
                }
                else if (e.Button == MouseButtons.Left && aux.Tag.ToString() == "J")
                {
                    aux.Tag = "D";
                    aux.Load(exepath + "4.Jpg");
                    misc = 4;
                }
                if (misc > 0)
                {
                    if (radioButton2.Checked == true)
                    {
                        //---------------------
                        MessageBox.Show("Este randul calculatorului");
                        //miscarea calculatorului
                        Random r = new Random();
                        int y = r.Next(1, x + 1);
                        if (misc == 2 || misc == 3)
                        {
                            while (p[y].Tag.ToString() != "F" || p[y] == aux)
                                y = r.Next(1, x + 1);

                            if (misc == 2) p[y].Tag = "J";
                            else if (misc == 3) { p[y].Tag = "D"; p[y].Enabled = false; }
                        }
                        else if (misc == 4)
                        {
                            while (p[y].Tag.ToString() != "J" || p[y] == aux)
                                y = r.Next(1, x + 1);

                            p[y].Tag = "D"; p[y].Enabled = false;
                        }
                        p[y].Load(exepath + misc + ".JPG");
                        if (p[y].Tag.ToString() == "D") p[y].Enabled = false;

                        bool gata = true;
                        for (int i = 1; i <= x; i++)
                        {
                            if (p[i].Tag.ToString() != "D") gata = false;
                        }
                        if (gata == true)
                        {
                            MessageBox.Show("Ai pierdut");
                        }
                        else MessageBox.Show("Este randul tau");
                    }
                        //EASY
                    else
                        if (radioButton1.Checked == true)
                        {
                            MessageBox.Show("Este randul calculatorului");
                            Random r = new Random();
                            int poz = r.Next(1, x + 1);
                            int tip = r.Next(2, 5);
                            bool gata = true;
                            for (int i = 1; i <= x; i++)
                                if (p[i].Tag.ToString() != "D") gata = false;
                            if (gata == true)
                            {
                                MessageBox.Show("Calulatorul a pierdut");
                                done = true;
                            }
                            else
                            {

                                while (p[poz].Tag.ToString() == "D") poz = r.Next(1, x + 1);

                                if (p[poz].Tag.ToString() == "J") tip = 4;

                                else while (tip == 4) tip = r.Next(2, 5);

                                p[poz].Load(exepath + tip + ".JPG");
                                if (tip == 2) p[poz].Tag = "J";
                                else p[poz].Tag = "D";
                            }
                          if(!done)  MessageBox.Show("Este randul tau");
                        }

                }

            }
            if (done == false)
            {
                bool gata = true;
                for (int i = 1; i <= x; i++)
                    if (p[i].Tag.ToString() != "D") gata = false;
                if (gata == true)
                {
                    MessageBox.Show("Ai pierdut");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a incepe trebuie sa alegi un numar impar de mere. Scopul jocului este sa fi ultimul care reuseste sa taie un mar. Marul se poate taia in 3 moduri: Jumatate(Click) Jumatate din Jumatate(Click pe jumatate) sau o Treime(ClickDreapta). Vei juca impreuna cu calculatorul. Vei fi anuntat cand este randul tau.");
        }
    }
}
