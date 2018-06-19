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
   
    public partial class Regine : Form
    {
        public Regine()
        {
            InitializeComponent();
        }
        int n;
        int x = 0;
        int[] v;
        bool first = true;
        string exepath = Application.StartupPath + "\\Regine\\";
        PictureBox[] reg;
        PictureBox[,] loc;
        
        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            n = int.Parse(textBox1.Text);
         v=new int[n+1];
            if (n < 3 || n > 7) MessageBox.Show("Value not valid");
            else
            {
                doit();
            }
            
        }
        private void doit()
        {
            
            if (!first)
            {
                for (int i = 1; i < Math.Sqrt(loc.Length) ; i++)
                {
                    for (int j = 1; j < Math.Sqrt(loc.Length); j++)
                    {
                        loc[i, j].Dispose();
                    }
                    reg[i].Dispose();
                }
            }
            reg = new PictureBox[n + 1];
            loc = new PictureBox[n + 1, n + 1];
            first = false;
            for (int i = 1; i <= n; i++)
            {
                reg[i] = new PictureBox();
                reg[i].Load(exepath+"regina.gif");
                reg[i].Left =  80 * i;
                reg[i].Top = 70;
                reg[i].Size = new Size(80, 80);
                reg[i].Visible = true;
                this.Controls.Add(reg[i]);
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    loc[i, j] = new PictureBox();

                    if ((i + j) % 2 == 0) loc[i, j].Load(exepath + "alb.gif");
                    else loc[i, j].Load(exepath + "negru.gif");
                    loc[i, j].Left = 80 * i;
                    loc[i, j].Top = 150+80*j;
                    loc[i, j].Height = 80;
                    loc[i, j].Width = 80;
                    loc[i, j].Name = i.ToString();
                    this.Controls.Add(loc[i, j]);
                    loc[i, j].Click += new EventHandler(aseaza);
                    
                }
            }
            this.Size = new Size(150+80 * n + 50,150+ 80 * n + 50);
        }
        private void aseaza(object sender, EventArgs e)
        {
            if (x <= n)
            {
                PictureBox aux = (PictureBox)sender;
                aux.Load(exepath + "regina.gif");
                v[x+1] = int.Parse(aux.Name.ToString());
                x++;
                reg[x].Dispose();
            }
            if(x==n)
            {
                bool corect=true;
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        if (v[i] == v[j])
                            corect = false;
                        if (Math.Abs(v[i] - v[j]) == j - i) corect = false;


                    }
               
            }
                if (corect == true) MessageBox.Show("Corect");
                else MessageBox.Show("Incorect");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a incepe, alege numarul de regine pe care vrei sa il asezi. Scopul jocului este sa asezi reginele pe tabla de sah, astfel incat niciuna sa nu se atace intre ele. Atentie, pentru numere mari jocul este imposibil de rezolvat");
        }
    }
}
