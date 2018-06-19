using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Jocuri
{
    public partial class DouaCulori : Form
    {
        public DouaCulori()
        {
            InitializeComponent();
        }
        int n;
        int Col1 = 0, Col2 = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            //Verificare n
            n = int.Parse(textBox1.Text);
            if (n < 3 || n > 9)
            {
                MessageBox.Show("Numarul introdus nu este bun. Te rog introdu un numar intre 3 si 9");
                textBox1.Focus();

            }
            else
            {
                jocToolStripMenuItem.Enabled = true;
                button1.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
            }
            ///
            ///
        }
        Button[,] b;
        int [,]mat=new int[100,100];
        
        //Coloreaza butoanele
        private void coloreaza()
        {
            Random r = new Random();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    mat[i, j] = r.Next(2);
                    if (mat[i, j] == 0) { Col1++; b[i, j].BackColor = Color.Black; }

                    else
                    {
                        Col2++; b[i, j].BackColor = Color.Aqua;
                    }
                    b[i, j].Click += new EventHandler(apasa);
                }

            }
        }

        private void apasa(object sender, EventArgs e)
        {
            Button aux = (Button)sender;
            int i, j;
            i = int.Parse(aux.Name);
            j = int.Parse(aux.Tag.ToString());

            if (mat[i, j] == 0)
            {
                b[i, j].BackColor = Color.Aqua;
                mat[i, j] = 1;
                Col2++; Col1--;
            }
            else
            {
                mat[i, j] = 0;
                b[i, j].BackColor = Color.Black;
                Col2--; Col1++;
            }
            if (i - 1 > 0)
            {
                if (mat[i - 1, j] == 0)
                {
                    b[i - 1, j].BackColor = Color.Aqua;
                    mat[i - 1, j] = 1;
                    Col2++; Col1--;
                }
                else
                {
                    mat[i - 1, j] = 0;
                    b[i - 1, j].BackColor = Color.Black;
                    Col2--; Col1++;
                }
            }
            if (i + 1 <= n)
            {
                if (mat[i + 1, j] == 0)
                {
                    b[i + 1, j].BackColor = Color.Aqua;
                    mat[i + 1, j] = 1;
                    Col2++; Col1--;
                }
                else
                {
                    mat[i + 1, j] = 0;
                    b[i + 1, j].BackColor = Color.Black;
                    Col2--; Col1++;
                }
            }
            if (j - 1 > 0)
            {
                if (mat[i, j - 1] == 0)
                {
                    b[i, j - 1].BackColor = Color.Aqua;
                    mat[i, j - 1] = 1;
                    Col2++; Col1--;
                }
                else
                {
                    mat[i, j - 1] = 0;
                    b[i, j - 1].BackColor = Color.Black;
                    Col2--; Col1++;
                }
            }
            if (j + 1 <= n)
            {
                if (mat[i, j + 1] == 0)
                {
                    b[i, j + 1].BackColor = Color.Aqua;
                    mat[i, j + 1] = 1;
                    Col2++; Col1--;
                }
                else
                {
                    mat[i, j + 1] = 0;
                    b[i, j + 1].BackColor = Color.Black;
                    Col2--; Col1++;
                }
            }
            if (Col2 == 0 || Col1 == 0) MessageBox.Show("Ai castigat");

        }
        bool first = true;
        private void jocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creaza butoane
            Col1 = 0;
            Col2 = 0;
            if (!first)
            {
                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                        b[i, j].Dispose();
            }
            b = new Button[n + 1, n + 1];
            first = false;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    mat[i, j] = 2;
                    b[i, j] = new Button();
                    b[i, j].Size = new Size(50, 50);
                    b[i, j].Left = 10 + i * 50;
                    b[i, j].Top = 10 + j * 50;
                    b[i, j].Enabled = true;
                    b[i, j].Visible = true;
                    b[i, j].Name = i.ToString();
                    b[i, j].Tag = j.ToString();
                    this.Controls.Add(b[i, j]);

                }

            coloreaza();
        }

      
      

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Scopul jocului este sa faci toate butoanele aceeasi culoare. Daca vei apasa pe unul dintre butoane,acesta isi va schimba culoarea iar cele din jurul lui isi vor schimba culoarea opusa de asemenea. Pentru a incepe alege un numar care reprezinta marimea matricii de butoane si apasa pe butonul `joc` ");
        }
    }
}
