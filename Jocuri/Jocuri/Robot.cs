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
    public partial class Robot : Form
    {
        public Robot()
        {
            InitializeComponent();
        }

       
        int[,] matrice = new int[50, 50];
        int xIesire, yIesire;
        int xRobot, yRobot, nrPiese, t;
        int n;
        int ord_buton;
        int nrbutoane = 0;
        int [] butx,buty;
        string nume_robot = "robot13.png";
        string exepath = Application.StartupPath + "\\Robot\\";
        string linie = "";
        StreamReader sr;
        PictureBox[,] poze = new PictureBox[50, 50];
        

        private void deseneazaLabirint()
        {
            n = int.Parse(sr.ReadLine());
            linie= sr.ReadLine();
            for (int i = 0; i < linie.Length; i++)
                for (int j = 0; j < linie.Length; j++)
                {
                    poze[i, j] = new PictureBox();
                    poze[i, j].Height = 50;
                    poze[i, j].Width = 50;
                    poze[i, j].Top = 30 + i * 50;
                    poze[i, j].Left = 70 + j * 50;
                }
            bool first = true;
            for (int i = 0; i < linie.Length; i++)
            {

                if (!first) linie = sr.ReadLine();
                first = false;
                for (int j = 0; j < linie.Length; j++)
                    switch (linie[j])
                    {
                        case 'x': matrice[i, j] = 1;
                            puneMarcaj(i, j, exepath + "zid.jpg");
                            break;
                        case ' ': matrice[i, j] = 2;
                            puneMarcaj(i, j, exepath + "liber.jpg");
                            break;
                        case 'R': matrice[i, j] = 3;
                            puneMarcaj(i, j, exepath + nume_robot);
                            xRobot = i; yRobot = j;
                            break;
                        case 'P': matrice[i, j] = 4;
                            puneMarcaj(i, j, exepath + "piesa.jpg");
                            nrPiese++;
                            break;
                        case 'u': matrice[i, j] = 6;
                            puneMarcaj(i, j, exepath + "buton.jpg");
                            nrbutoane++;
                            
                            break;
                        case 'd': matrice[i, j] = 7;
                            puneMarcaj(i, j, exepath + "usa.jpg");
                          
                            break;
                        case 'I': matrice[i, j] = 5;
                            xIesire = i;
                            yIesire = j;
                            puneMarcaj(i, j, exepath + "iesire.jpg");
                            break;
                    }
            }
            butx=new int [nrbutoane+1];
            buty=new int[nrbutoane+1];
            for (int i = 1; i <= nrbutoane; i++)
            {
                butx[i] = int.Parse(sr.ReadLine().ToString());
                buty[i] = int.Parse(sr.ReadLine().ToString());
            }
        }
        private void puneMarcaj(int i, int j, string fisier)
        {
            try
            {
                poze[i, j].Load(fisier);
                this.Controls.Add(poze[i, j]);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Nu exista fisierul imagine" +@"
" +ex.Message);
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)// Drum liber
            {
                case (char)'w':
                    if (matrice[xRobot - 1, yRobot] != 1 && matrice[xRobot - 1, yRobot] != 7) 
                    {
                        puneMarcaj(xRobot - 1, yRobot,exepath+ nume_robot);
                        puneMarcaj(xRobot, yRobot, exepath+"liber.jpg");
                        xRobot--; t++;
                    }
                    break;

                case (char)'a':
                    if (matrice[xRobot, yRobot - 1] != 1 && matrice[xRobot , yRobot-1] != 7)
                    {
                        puneMarcaj(xRobot, yRobot - 1, exepath+nume_robot);
                        puneMarcaj(xRobot, yRobot, exepath+"liber.jpg");
                        yRobot--; t++;
                    }
                    break;

                case (char)'d':
                    if (matrice[xRobot, yRobot + 1] != 1 && matrice[xRobot , yRobot+1] != 7)
                    {
                        puneMarcaj(xRobot, yRobot + 1, exepath + nume_robot);
                        puneMarcaj(xRobot, yRobot, exepath + "liber.jpg");
                        yRobot++; t++;
                    }
                    break;

                case (char)'s':
                    if (matrice[xRobot + 1, yRobot] != 1 && matrice[xRobot +1, yRobot] != 7)
                    {
                        puneMarcaj(xRobot + 1, yRobot, exepath + nume_robot);
                        puneMarcaj(xRobot, yRobot, exepath + "liber.jpg");
                        xRobot++; t++;
                    }
                    break;

            }
           if( matrice[xRobot,yRobot]==4)
                    {
                        puneMarcaj(xRobot, yRobot, exepath + nume_robot);
                      
                        nrPiese--;
                    }
           if (matrice[xRobot, yRobot] == 6)
           {
               ord_buton++;
               matrice[xRobot,yRobot] = 2;
               puneMarcaj(butx[ord_buton], buty[ord_buton], exepath + "liber.jpg");
               matrice[butx[ord_buton], buty[ord_buton]] = 2;
           }
                   

            if (matrice[xRobot, yRobot] == 5)
            {
                if (nrPiese == 0)
                {
                    if (t >n) MessageBox.Show("Ai rezolvat problema in " + t + "  miscari. Numarul maxim de miscari este"+ n);
                    else MessageBox.Show("Ai rezolvat problema eficient");
                }
                else
                {
                    
                    MessageBox.Show("Nu ai adunat toate piesele");
                    puneMarcaj(xRobot,yRobot, exepath+"iesire.jpg");
                }
            }
            puneMarcaj(xIesire, yIesire, exepath + "iesire.jpg");
        
        }
        private void restartgame()
        {
            t = 0;
            nrbutoane = 0;
            ord_buton = 0;
            nrPiese = 0;
            for (int i = 0; i < linie.Length; i++)
                for (int j = 0; j < linie.Length ; j++)
                    poze[i, j].Dispose();
        }
        private void joc1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartgame();
           sr = new StreamReader(exepath + "joc1.txt");
            deseneazaLabirint();
            sr.Close();

        }
        private void joc2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartgame();
            sr = new StreamReader(exepath + "joc2.txt");
            deseneazaLabirint();
            sr.Close();
        }
        private void joc3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartgame();
            sr = new StreamReader(exepath + "joc3.txt");
            deseneazaLabirint();
            sr.Close();
        }
        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nume_robot = "robot13.png";
            puneMarcaj(xRobot, yRobot, exepath + nume_robot);
        }
        private void lolyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nume_robot = "robot23.png";
            puneMarcaj(xRobot, yRobot, exepath + nume_robot);
        }
        private void tedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nume_robot = "robot33.png";
            puneMarcaj(xRobot, yRobot, exepath + nume_robot);
        }
        private void fredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nume_robot = "robot43.png";
            puneMarcaj(xRobot, yRobot, exepath + nume_robot);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scopul acestui joc este sa folosesti robotul pentru a aduna toate piesele intr-un mod cat mai eficient. Pentru a controla robotul, foloseste tastele W,A,S,D Unele pasaje sunt blocate si necesita un buton pentru a le deschide");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
