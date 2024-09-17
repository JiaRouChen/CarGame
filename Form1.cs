using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace car_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            {

                for (int i = 0; i < 5; i++)

                {
                    PictureBox p = new PictureBox();
                    p.BringToFront();
                    p.Tag = "line";
                    p.Size = new System.Drawing.Size(20, 100);
                    p.BackColor = Color.White;
                    p.BorderStyle = BorderStyle.None;
                    p.Visible = true;
                    p.Location = new Point(this.Width / 2 - p.Width / 2, i * (p.Height + 50));
                    this.Controls.Add(p);
                }
            }

            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "line")
                {
                    x.Top += 10;
                    if (x.Top >= this.Height)
                        x.Top = 0 - x.Height;

                }
                if (x.Tag == "coin")
                {
                    x.Top += 10;
                    if (x.Top >= this.Height)
                        x.Top = 0 - x.Height;

                }
                if (x.Tag == "stone")
                {
                    x.Top += 10;
                    if (x.Top >= this.Height)
                        x.Top = 0 - x.Height;
                }
                if (x.Tag == "stone" || x.Tag == "coin")
                {
                    x.Top += 10;
                    if (x.Top >= this.Height)
                    {
                        Random r = new Random();
                        x.Top = 0 - x.Height;
                        x.Left = r.Next(0 + pictureBox8.Width, this.Width - pictureBox9.Width - x.Width);
                    }

                }


            
            }

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            int score = 0;
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "coiin")
                {
                    if (pictureBox7.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        label1.Text = score.ToString();
                    }
                }

            }
   
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pictureBox7.Left -= 10;
            }

            if (e.KeyCode == Keys.Right)
            {
                pictureBox7.Left += 10;
            }

            foreach (Control x in this.Controls)
            {
                if (x.Tag == "stone")
                {
                    if (pictureBox7.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer1.Stop();
                        label2.Visible = true;
                        label2.Text = "game over";
                        timer2.Stop();


                    }
                }
            }

            
            int score = 0;   
            void IncreaseScore(int amount)
            {
                foreach (Control x in this.Controls)
            {
                if (x.Tag == "coin")
                {
                        score += amount;
                        if (pictureBox7.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1; 
                            Console.WriteLine("score" + score);
                        label1.Text = score.ToString();
                          

                    }
                }

            }
            }
            IncreaseScore(1);
        }
    }
}
