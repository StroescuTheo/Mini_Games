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
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }



        string exepath = Application.StartupPath + "\\Screen\\";
        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            PlusMinus PlusMinus = new PlusMinus();
            PlusMinus.Show();
            pictureBox6.Load(exepath + "plus si minus.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }
        

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            Tantari Tantari = new Tantari();
            Tantari.Show();
            pictureBox5.Load(exepath + "mosquito.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            Mere Mere = new Mere();
            Mere.Show();
            pictureBox4.Load(exepath + "apples.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            Regine Regine = new Regine();
            Regine.Show();
            pictureBox3.Load(exepath + "Queen.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {

            DouaCulori DouaCulori = new DouaCulori();
            DouaCulori.Show();
            pictureBox2.Load(exepath + "2colors.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Robot Robot = new Robot();
            Robot.Show();
            pictureBox1.Load(exepath + "robot.png"); pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
            pictureBox1.Load(exepath + "robotp.png");
        }

        private void Screen_Click(object sender, EventArgs e)
        {
            pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Load(exepath + "2colorsp.png");
            pictureBox1.Load(exepath + "robot.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Load(exepath + "Queenp.png");
            pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Load(exepath + "applesp.png"); 
            pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox5.Load(exepath + "mosquito.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Load(exepath + "mosquitop.png");
            pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox6.Load(exepath + "plus si minus.png");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Load(exepath + "plus si minusp.png");
            pictureBox1.Load(exepath + "robot.png");
            pictureBox2.Load(exepath + "2colors.png");
            pictureBox3.Load(exepath + "Queen.png");
            pictureBox4.Load(exepath + "apples.png");
            pictureBox5.Load(exepath + "mosquito.png");
            
        }
     
       
    }
}
