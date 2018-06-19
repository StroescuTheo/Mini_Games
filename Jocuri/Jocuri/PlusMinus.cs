using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Jocuri
{
    public partial class PlusMinus : Form
    {
        public PlusMinus()
        {
            InitializeComponent();
        }

        int ScorMax = 60;//Introdu scorul maxim
        int rez = 0, level = 1, score = 0;
        int puncte = 0;
        int sec = 0, secr = 0, milisecr = 0;
        int[] rezultat = new int[60];
        int milisec = -1, minute, ora; 
        int b1t, b1l, b2t, b2l, fw, fh;
        bool Admin = false;
        bool level3 = false;
        bool level2 = false;
        Random cul = new Random();       
        Random r = new Random();     
        Random re = new Random();
        string Ecuatia; bool effect = true;
        string[] semn_bun = new string[65];
        string[] greseala = new string[65];
        string[] semn_rau = new string[65];
        string Win_text = "Jocul s-a sfarsit.Ai";
        string text_puncte = " puncte";
        string Help_text = @" 
                                                            Bine ai venit la jocul ''Plus şi Minus''! 
                                                      Scopul acestui Joc este să raspunzi la o intrebare simplă:  
                                                                    Care este Semnul Operaţiei?  
Click pe primul buton de sus şi pe submeniul Joc te va duce la meniul jocului.Aici iţi vei introduce numele  
şi vei apăsa pe butonul 'Începe'.Vor apărea 2 butoane +(Plus) şi respectiv -(Minus)  
Deasupra acestora va apărea o formulă matematică.Trebuie să răspunzi la intrebarea  
jocului apăsând unul din cele 2 butoane.Operaţiile pot conţine şi modul.
După terminarea jocului vor apărea 2 butoane care iţi vor permite fie inceperea unui joc nou.
Alegeţi limba din meniul Limba.Meniul Ajutor te va aduce aici";



        private void newgame()
        {

            timer2.Enabled = false;
            timer3.Enabled = false;

            if (Admin == false) button3.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            Lab4Score.Visible = true;
            label2.Visible = true;
            Hint.Visible = true;
          
            timer1.Enabled = true;
            //---------Level 1---------
            int a, b, co;
            string c = "+-*";
            a = r.Next(10);
            b = r.Next(10);
            co = r.Next(3);
            switch (co)
            {
                case 0: rez = a + b; break;
                case 1: rez = a - b; break;
                case 2: rez = a * b; break;
            }
            label1.Text = a + " " + c[co] + " " + b;
            //------------------------

        }
        private void button3_Click(object sender, EventArgs e)
        {
            newgame();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (puncte >= 40 && puncte <= 44)
            {
                Random poz = new Random();
                int x = poz.Next(101);
                if (x % 3 == 0) x = 1;
                else x = 0;
                if (x == 1)
                {
                    int swap = button1.Left;
                    button1.Left = button2.Left;
                    button2.Left = swap;
                }
            }
            if (puncte >= 45 && puncte <= 49)
            {
                Random poz = new Random();
                int x = poz.Next(101);
                if (x % 2 == 0) x = 1;
                else x = 0;
                if (x == 1)
                {
                    int swap = button1.Left;
                    button1.Left = button2.Left;
                    button2.Left = swap;
                }
            }
            if (puncte >= 50)//Kill Screen
            {
                timer4.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            if (score < puncte) puncte = score;
            try
            {

                score++;
                //---------------Level 1----------
                if (level == 1)
                {
                    if (rez >= 0) puncte++;
                    else {  puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score;
                    if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    switch (co)
                    {
                        case 0: rez = a + b; break;
                        case 1: rez = a - b; break;
                        case 2: rez = a * b; break;
                    }
                    if (a >= 0 && b >= 0) label1.Text = a + " " + c[co] + " " + b;
                    else if (a <= 0 && b >= 0) label1.Text = "(" + a + ")" + " " + c[co] + " " + b;
                    else if (a >= 0 && b <= 0) label1.Text = a + " " + c[co] + " " + "(" + b + ")";
                    else label1.Text = "(" + a + ")" + " " + c[co] + " " + "(" + b + ")";
                    if (puncte % 10 == 0 && puncte > 9) level++;
                    Ecuatia = label1.Text;
                }
                //----------End of level 1-------------------
                //---------------Level 2--------------------
                else if (level == 2)
                {
                    if (level2 == false)
                    {
                        if (rez >= 0) puncte++;
                        else {  puncte--; }
                        level2 = true;
                    }
                    if (rez >= 0) { puncte++; }
                    else {  puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score; if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    while (co == 3) co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    int modulec = r.Next(2);
                    int modula = r.Next(2);
                    int modulb = r.Next(2);
                    while (modulec == 2) modulec = r.Next(2);
                    while (modula == 2) modula = r.Next(2);
                    while (modulb == 2) modulb = r.Next(2);
                    char[] semn_modul = { ' ', '|' };
                    if (a >= 0 && b >= 0)
                    {
                        label1.Text = a + " " + c[co] + " " + b;
                        switch (co)
                        {
                            case 0: rez = a + b; break;
                            case 1: rez = a - b; break;
                            case 2: rez = a * b; break;
                        }
                    }
                    else if (a <= 0 && b >= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + b + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) + b;
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) - b;
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) * b;
                                    }

                                } break;
                        }
                    }
                    else if (a >= 0 && b <= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + a + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a + Math.Abs(b);
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a - Math.Abs(b);
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a * Math.Abs(b);
                                    }

                                } break;
                        }
                    }
                    else if (a <= 0 && b <= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) + Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) + b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a + Math.Abs(b);
                                        }
                                    }
                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1 && modulb == 1)
                                    {
                                        rez = Math.Abs(a) - Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) - b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a - Math.Abs(b);
                                        }
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) * Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) * b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a * Math.Abs(b);
                                        }
                                    }

                                } break;
                        }
                    }
                    Ecuatia = label1.Text;
                    if (puncte % 10 == 0 && puncte > 19) level++;
                }
                else if (level >= 3)
                {

                    if (level3 == false)
                    {
                        if (rez >= 0) puncte++;
                        else {  puncte--; }
                        level3 = true;
                    }

                    if (rez >= 0) { puncte++; }
                    else {  puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score; if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    while (co == 3) co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    int modulec = r.Next(999);
                    int modula = r.Next(2);
                    int modulb = r.Next(2);
                    int minus = r.Next(100);
                    while (modulec == 0) modulec = r.Next(999);
                    if (modulec % 72 == 0) modulec = 1;
                    else modulec = 0;
                    while (minus == 0) minus = r.Next(100);
                    if (minus % 5 == 0) minus = 2;
                    else minus = 0;
                    while (modula == 2) modula = r.Next(2);
                    while (modulb == 2) modulb = r.Next(2);
                    char[] semn_modul = { ' ', '|' };
                    string[] smn_minus = { " ", " ", "-(", ")" };
                    if (a >= 0 && b >= 0)
                    {
                        label1.Text = smn_minus[minus] + a + " " + c[co] + " " + b + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (minus == 2) rez *= (-1);
                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (minus == 2) rez *= (-1);
                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (minus == 2) rez *= (-1);
                                } break;
                        }
                    }
                    else if (a <= 0 && b >= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + b + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) + b;
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) - b;
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) * b;
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    else if (a >= 0 && b <= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + a + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a + Math.Abs(b);
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a - Math.Abs(b);
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a * Math.Abs(b);
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    else if (a <= 0 && b <= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) + Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) + b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a + Math.Abs(b);
                                        }
                                    }
                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1 && modulb == 1)
                                    {
                                        rez = Math.Abs(a) - Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) - b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a - Math.Abs(b);
                                        }
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) * Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) * b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a * Math.Abs(b);
                                        }
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    Ecuatia = label1.Text;
                    if (puncte % 10 == 0 && puncte > 29) level++;
                }
                //------------Level 3--------------------

                //---------End of level 3-----------------
                secr += sec;
                milisecr += milisec;
                if (milisecr >= 100) { milisecr = 0; secr++; }
                sec = 0;
                milisec = 0;
                minute = 0;
                ora = 0;
                if (Admin == false)
                    if (score >= ScorMax)
                    {
                        timer4.Enabled = false;
                        button4.Visible = true;
                        button1.Visible = false;
                        button2.Visible = false;


                        timer2.Enabled = false;
                        timer1.Enabled = false;
                        timer3.Enabled = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;

                        
                        MessageBox.Show(Win_text + " " + puncte + text_puncte);
                        label1.Visible = false;
                        Hint.Visible = false;
                        string dataDeAzi = DateTime.Today.ToShortDateString();
                    }

                if (score < puncte) puncte = score;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (puncte >= 40 && puncte <= 44)
            {
                Random poz = new Random();
                int x = poz.Next(101);
                if (x % 3 == 0) x = 1;
                else x = 0;
                if (x == 1)
                {
                    int swap = button1.Left;
                    button1.Left = button2.Left;
                    button2.Left = swap;
                }
            }
            if (puncte >= 45 && puncte <= 49)
            {
                Random poz = new Random();
                int x = poz.Next(101);
                if (x % 2 == 0) x = 1;
                else x = 0;
                if (x == 1)
                {
                    int swap = button1.Left;
                    button1.Left = button2.Left;
                    button2.Left = swap;
                }
            }
            if (puncte >= 50)//kill screen
            {
                timer4.Enabled = true;

                timer2.Enabled = true;
                timer3.Enabled = true;
            }

            if (score < puncte) puncte = score;
            try
            {
                score++;
                //---------------Level 1----------
                if (level == 1)
                {
                    if (rez <= 0) puncte++;
                    else {  puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score; if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    switch (co)
                    {
                        case 0: rez = a + b; break;
                        case 1: rez = a - b; break;
                        case 2: rez = a * b; break;
                    }
                    if (a >= 0 && b >= 0) label1.Text = a + " " + c[co] + " " + b;
                    else if (a <= 0 && b >= 0) label1.Text = "(" + a + ")" + " " + c[co] + " " + b;
                    else if (a >= 0 && b <= 0) label1.Text = a + " " + c[co] + " " + "(" + b + ")";
                    else label1.Text = "(" + a + ")" + " " + c[co] + " " + "(" + b + ")";
                    Ecuatia = label1.Text;
                    if (puncte % 10 == 0 && puncte > 9) level++;
                }
                //-----------End of level 1-------------------
                //---------------Level 2--------------------
                else if (level == 2)
                {
                    if (level2 == false)
                    {
                        if (rez <= 0) puncte++;
                        else {  puncte--; }
                        level2 = true;
                    }
                    if (rez <= 0) { puncte++; }
                    else {  puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score; if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    while (co == 3) co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    int modulec = r.Next(2);
                    int modula = r.Next(2);
                    int modulb = r.Next(2);
                    while (modulec == 2) modulec = r.Next(2);
                    while (modula == 2) modula = r.Next(2);

                    while (modulb == 2) modulb = r.Next(2);
                    char[] semn_modul = { ' ', '|' };
                    if (a >= 0 && b >= 0)
                    {
                        label1.Text = a + " " + c[co] + " " + b;
                        switch (co)
                        {
                            case 0: rez = a + b; break;
                            case 1: rez = a - b; break;
                            case 2: rez = a * b; break;
                        }
                    }
                    else if (a <= 0 && b >= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + b + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) + b;
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) - b;
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) * b;
                                    }

                                } break;
                        }
                    }
                    else if (a >= 0 && b <= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + a + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a + Math.Abs(b);
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a - Math.Abs(b);
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a * Math.Abs(b);
                                    }

                                } break;
                        }
                    }
                    else if (a <= 0 && b <= 0)
                    {
                        label1.Text = semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + b + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) + Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) + b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a + Math.Abs(b);
                                        }
                                    }
                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1 && modulb == 1)
                                    {
                                        rez = Math.Abs(a) - Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) - b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a - Math.Abs(b);
                                        }
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) * Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) * b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a * Math.Abs(b);
                                        }
                                    }

                                } break;
                        }
                    }
                    Ecuatia = label1.Text;
                    if (puncte % 10 == 0 && puncte > 19) level++;
                }
                //------------Level 3--------------------
                else if (level >= 3)
                {
                    if (level3 == false)
                    {

                        if (rez <= 0) puncte++;
                        else {   puncte--; }
                        level3 = true;
                    }
                    if (rez <= 0) { puncte++; }
                    else {   puncte--; }
                    int abs = -1; int absran;
                    label2.Text = puncte + "/" + score; if (puncte > score) puncte = score;
                    int a, b, co;
                    string c = "+-*";
                    a = r.Next(10);
                    b = r.Next(10);
                    co = r.Next(3);
                    while (co == 3) co = r.Next(3);
                    absran = r.Next(100);
                    if (absran % 2 == 0) a *= abs;
                    absran = r.Next(100);
                    if (absran % 3 == 0) b *= abs;
                    int modulec = r.Next(999);
                    int modula = r.Next(2);
                    int modulb = r.Next(2);
                    int minus = r.Next(100);
                    while (modulec == 0) modulec = r.Next(999);
                    if (modulec % 7 == 0) modulec = 1;
                    else modulec = 0;
                    while (minus == 0) minus = r.Next(100);
                    if (minus % 5 == 0) minus = 2;
                    else minus = 0;
                    while (modula == 2) modula = r.Next(2);
                    while (modulb == 2) modulb = r.Next(2);
                    char[] semn_modul = { ' ', '|' };
                    string[] smn_minus = { " ", " ", "-(", ")" };
                    if (a >= 0 && b >= 0)
                    {
                        label1.Text = smn_minus[minus] + a + " " + c[co] + " " + b + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0: rez = a + b; break;
                            case 1: rez = a - b; break;
                            case 2: rez = a * b; break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    else if (a <= 0 && b >= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + b + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) + b;
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) - b;
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1)
                                    {
                                        rez = Math.Abs(a) * b;
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    else if (a >= 0 && b <= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + a + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + "" + b + "" + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a + Math.Abs(b);
                                    }

                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a - Math.Abs(b);
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1)
                                    {
                                        rez = a * Math.Abs(b);
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    else if (a <= 0 && b <= 0)
                    {
                        label1.Text = smn_minus[minus] + semn_modul[modulec] + " " + semn_modul[modula] + "" + "(" + "" + a + "" + ")" + "" + semn_modul[modula] + " " + c[co] + " " + semn_modul[modulb] + "" + "(" + b + ")" + "" + semn_modul[modulb] + " " + semn_modul[modulec] + smn_minus[minus + 1];
                        switch (co)
                        {
                            case 0:
                                {
                                    rez = a + b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) + Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) + b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a + Math.Abs(b);
                                        }
                                    }
                                } break;
                            case 1:
                                {
                                    rez = a - b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modula == 1 && modulb == 1)
                                    {
                                        rez = Math.Abs(a) - Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) - b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a - Math.Abs(b);
                                        }
                                    }

                                } break;
                            case 2:
                                {
                                    rez = a * b;
                                    if (modulec == 1)
                                    {
                                        rez = Math.Abs(rez);
                                    }
                                    else if (modulb == 1 && modula == 1)
                                    {
                                        rez = Math.Abs(a) * Math.Abs(b);
                                    }
                                    else
                                    {
                                        if (modula == 1)
                                        {
                                            rez = Math.Abs(a) * b;
                                        }
                                        if (modulb == 1)
                                        {
                                            rez = a * Math.Abs(b);
                                        }
                                    }

                                } break;
                        }
                        if (minus == 2) rez *= (-1);
                    }
                    Ecuatia = label1.Text;
                    if (puncte % 10 == 0 && puncte > 29) level++;
                }

                //---------End of level 3-----------------
                secr += sec;
                milisecr += milisec;
                if (milisecr >= 100) { secr++; milisecr = 0; }
                sec = 0;
                milisec = 0;
                minute = 0;
                ora = 0;
            
                    if (score >= ScorMax)
                    {
                        timer4.Enabled = false;

                        button2.Visible = false;
                        button1.Visible = false;
                        timer4.Enabled = false;//may god have mercy
                        timer2.Enabled = false;
                        timer1.Enabled = false;
                        timer3.Enabled = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;
                        MessageBox.Show(Win_text + " " + puncte + text_puncte);
                        label1.Visible = false;
                        Hint.Visible = false;
                        string dataDeAzi = DateTime.Today.ToShortDateString();

                    }
                if (score < puncte) puncte = score;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 25;
            // int x=cul.Next(3);
            if (milisec < 100)
            {
                milisec += 2;
                if (milisec >= 100)
                {
                    milisec = -1;
                    sec++;
                    if (sec >= 60)
                    {
                        sec = 0;
                        minute++;
                        if (minute >= 60)
                            ora++;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
            b1l = button1.Left;
            b1t = button1.Top;
            b2l = button2.Left;
            b2t = button2.Top;
            fw = this.Width;
            fh = this.Height;

            textBox2.Text = Help_text;

    
        }
        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            panel1.Height = fh;
            panel1.Width = fw;
            panel1.Top = toolStrip1.Height;
            panel1.Left = 0;
            panel4.Height = 10;
            panel4.Width = 10;
           
            panel1.Visible = true;
          
            panel4.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button1.Left = b1l;
            button1.Top = b1t;
            button2.Left = b2l;
            button2.Top = b2t;
            newgame();
            score = 0;
            puncte = 0;
            sec = 0;
            secr = 0;
            milisec = 0;
            milisecr = 0;
            label2.Text = "";
            label1.Visible = true;
            Hint.Visible = true;
            button4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Kill SCREEN
            Random r = new Random();
            int xs = r.Next(panel1.Size.Width);
            int ys = r.Next(panel1.Size.Height);
            while (xs == 0 || xs + button1.Width >= panel1.Size.Width) xs = r.Next(panel1.Size.Width);
            while (ys == 0 || ys + button1.Height >= panel1.Size.Height) ys = r.Next(panel1.Size.Height);
            button2.Location = new Point(xs, ys);

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //Kill SCREEN

            Random r = new Random();
            int xs = r.Next(panel1.Size.Width);
            int ys = r.Next(panel1.Size.Height);
            while (xs == 0 || xs + button1.Width >= panel1.Size.Width) xs = r.Next(panel1.Size.Width);
            while (ys == 0 || ys + button1.Height >= panel1.Size.Height) ys = r.Next(panel1.Size.Height);
            button1.Location = new Point(xs, ys);
        }
        private void button7_Click(object sender, EventArgs e)
        {

          
        }
        private void timer4_Tick(object sender, EventArgs e)
        {

            if (puncte >= 50)
            {
                int rez = 456;
                if (effect == true)
                {

                    label5.Visible = effect;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;

                    label6.Visible = effect;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;

                    label7.Visible = effect;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;

                    label8.Visible = effect;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;

                    label9.Visible = effect;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;

                    effect = false;
                    while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                }
                else
                {
                    label5.Visible = effect; while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                    label6.Visible = effect; while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                    label7.Visible = effect; while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                    label8.Visible = effect; while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                    label9.Visible = effect; while (rez == 0) rez = re.Next(800);
                    timer4.Interval = rez;
                    effect = true;
                    timer4.Interval = re.Next(800);
                }
            }
            label5.Location = new Point(re.Next(panel1.Width), re.Next(panel1.Height));
            label6.Location = new Point(re.Next(panel1.Width), re.Next(panel1.Height));
            label7.Location = new Point(re.Next(panel1.Width), re.Next(panel1.Height));
            label8.Location = new Point(re.Next(panel1.Width), re.Next(panel1.Height));
            label9.Location = new Point(re.Next(panel1.Width), re.Next(panel1.Height));
            int x = re.Next(4);
            switch (x)
            {
                case 0:
                    {
                        label5.ForeColor = System.Drawing.Color.Red;
                        label6.ForeColor = System.Drawing.Color.Indigo;
                        label7.ForeColor = System.Drawing.Color.LightGray;
                        label8.ForeColor = System.Drawing.Color.OldLace;
                        label9.ForeColor = System.Drawing.Color.WhiteSmoke;
                    } break;
                case 1:
                    {
                        label5.ForeColor = System.Drawing.Color.Green;
                        label6.ForeColor = System.Drawing.Color.MediumSlateBlue;
                        label7.ForeColor = System.Drawing.Color.LightGreen;
                        label8.ForeColor = System.Drawing.Color.DarkSlateBlue;
                        label9.ForeColor = System.Drawing.Color.Gainsboro;
                    } break;
                case 3:
                    {
                        label5.ForeColor = System.Drawing.Color.Gold;
                        label6.ForeColor = System.Drawing.Color.LightSalmon;
                        label7.ForeColor = System.Drawing.Color.DarkTurquoise;
                        label8.ForeColor = System.Drawing.Color.Honeydew;
                        label9.ForeColor = System.Drawing.Color.HotPink;
                    } break;
            }
        }
        private void românăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hint.Text = "Semnul operaţiei este";
            label5.Text = "Ecranul morții";
            label6.Text = "Ecranul morţii";
            label7.Text = "Ecranul morţii";
            label8.Text = "Ecranul morţii";
            label9.Text = "Ecranul morţii";
            button3.Text = "Începe";
            button4.Text = "Joc Nou";
          
            Lab4Score.Text = "Scorul tău este";
          
            checkBox3.Text = "Ajutor în timpul jocului";
         
            toolStripDropDownButton2.Text = "Limbă";
            gameToolStripMenuItem.Text = "Joc";
          
            
            this.Text = "Plus și Minus";
        
          
           
            Win_text = "Jocul s-a sfârşit.Ai";
            text_puncte = " puncte";
            textBox2.Text = @"
                                    Bine ai venit la jocul ''Plus şi Minus''! 
                                                      Scopul acestui Joc este să raspunzi la o intrebare simplă:  
                                                                    Care este Semnul Operaţiei?  
Click pe primul buton de sus şi pe submeniul Joc te va duce la meniul jocului.Aici iţi vei introduce numele  
şi vei apăsa pe butonul 'Începe'.Vor apărea 2 butoane +(Plus) şi respectiv -(Minus)  
Deasupra acestora va apărea o formulă matematică.Trebuie să răspunzi la intrebarea  
jocului apăsând unul din cele 2 butoane.Operaţiile pot conţine şi modul.
După terminarea jocului vor apărea 2 butoane care iţi vor permite fie inceperea unui joc nou.
Alegeţi limba din meniul Limba.Meniul Ajutor te va aduce aici";

        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hint.Text = "The operation sign is";
           
            label5.Text = "Kill screen";
            label6.Text = "Kill screen";
            label7.Text = "Kill screen";
            label8.Text = "Kill screen";
            label9.Text = "Kill screen";
            button3.Text = "Start";
            button4.Text = "New Game";
           
            Lab4Score.Text = "Your score is:";
           
            checkBox3.Text = "Help during the game";
            gameToolStripMenuItem.Text = "Game";
            
            toolStripDropDownButton2.Text = "Language";
           this.Text = "Plus and minus";
           
          Win_text = "The game ended. You have:";
            text_puncte = " points";
            textBox2.Text=@"
                                Welcome to the ''Plus and Minus'' Game !
                                The purpose of the game is answering one question:
                                        What’s the sign of the operation?
If you click the first button above and on the submenu Game it will bring up the game menu. Here you will enter 
your name and press on the Start button. Two buttons will appear +(Plus) and –(Minus).Above them, there will be
a mathematical operation. You have to answer the games question by pressing one of the two buttons. ATTENTION! 
In case of a zero you can press either buttons. The operations can contain modules. After the game ends two more 
buttons will appear that will allow you to start a new game.  
Pick your language from the Language menu. The Help button will bring you back here.";
        }
        private void francaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hint.Text = "Le signe de operation est";
            label5.Text = "L'écran de la mort";
            label6.Text = "L'écran de la mort";
            label7.Text = "L'écran de la mort";
            label8.Text = "L'écran de la mort";

            label9.Text = "L'écran de morte";
            checkBox3.Text = "Aider pendant le jeu";
            button3.Text = "Début";
            button4.Text = "Nouveau jeu";
          
            Lab4Score.Text = "Ton score est:";
         
            gameToolStripMenuItem.Text = "Jeu";
            toolStripDropDownButton2.Text = "Langue";
            
            this.Text = "Plus et moins";
          
            Win_text = " Le jeu s’est fini. Tu as";
            text_puncte = " points";

            textBox2.Text =
            @" 
                                    Soyez les bienvenus au jeu ,,Plus et moins’’!
                                    Le but de ce jeu est de répondre à une question simple :
                                             Quel est le Signe de l’operation ?
Click sur le premier bouton d’en haut et sur le sousmenu Jeu et on arrive au menu du jeu. Ici on introduit le nom 
et on appuye sur le bouton ,,Commence’’. Deux boutons vont apparaître :  +(plus),  respectivement –(moins).
Au dessus on va apparaître une operation mathématique. Il faut répondre à la question du jeu en appuyant un 
des deux boutons. ATTENTION ! au cas où le résultat est 0, on peut appuyer aussi Plus ou Moins. Les formules 
peuvent contenir aussi le modul.Après la fin du jeu, deux boutons vont apparaître ; ceux-ci permettront soit 
le début d’un nouveau jeu On choisit la langue du menu Langue. Le menu Aide montrera comment faire.";
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel4.Height =fh;;
            panel4.Width =fw;

            panel4.Top = toolStrip1.Height;
            panel4.Left = 0;
            textBox2.Size = this.Size;
            panel1.Visible = false;
    
            panel4.Visible = true;

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
            panel1.Height = 10;
            panel1.Width = 10;
         
            panel4.Height = 10;
            panel4.Width = 10;

            panel1.Visible = false;
          panel4.Visible = false;
           
        }
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }

}
