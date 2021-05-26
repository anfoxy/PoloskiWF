using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poloskiWF
{
    public partial class Form1 : Form
    {
       
        List<strip> list = new List<strip>();
        int n=0,r=0;
        public Form1()
        {
            
            InitializeComponent();
            MessageBox.Show("Правила игры: 1)когда на экране появится 10 полосок вы сможете их убирать. 2) чтобы убрать полоску кликните по ней левой кнопкой мыши. 3)вы победите когда не останется полосок.4)Вы проиграете если на экране окажется 35 полосок. ПРИЯТНОЙ ИГРЫ");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
           
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((r == 1) &&(n==0))
            {
                timer1.Stop();
                toolStripLabel1.Text = "0";
                MessageBox.Show("ПОБЕДА ");

            }
            else {
                toolStripLabel1.Text = "" + n;
                n++;
                //обработка сигналов таймера
                list.Add(new strip());
                Invalidate();
                if (n > 35)
                {
                    timer1.Stop();
                    MessageBox.Show("ВЫ ПОГИБЛИ ");
                }
            }
        }
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (r == 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Click(e.X, e.Y))
                    {
                        bool over = false;
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Over(list[i]))
                            {
                              
                                over = true;
                                break;
                            }

                        }
                        if (over == false)
                        {
                            n--;
                            list.RemoveAt(i);
                            Invalidate();
                            return;
                        }
                    }
                }
            }
           
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (n > 10)
            {
                r = 1;
                timer1.Interval = 700;
            }
            
            Graphics g = this.CreateGraphics();
           
            for (int i = 0; i < list.Count; i++)
            {
                
                list[i].Draw(g);
            }
            
        }
        
    }
}
