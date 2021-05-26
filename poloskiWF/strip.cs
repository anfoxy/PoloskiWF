using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace poloskiWF
{
    class strip
    {
       
        int n=0;
        int x1, y1,y2,x2;//положение
        int x, y;//положение
        int width, height;//размеры 
        Color color; //цвет
        public  strip()
        {
        
            Random rand = new Random();
            int i = rand.Next(6);
            if (i > 2)
            {
                width = 100;
                height = 25;
            } else {
                width = 25;
                height = 100;
            }
            y1= rand.Next(13, 100);
            y2 = rand.Next(300,370);
            x1 = rand.Next(0,100);
            x2 = rand.Next(600,750);
            x = rand.Next(x1,x2);
            y = rand.Next(y1,y2);
            color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
            n++;
        
        }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(Pens.Black, x, y, width, height);
           
        }
        public bool Over(strip s)
        {
            Rectangle r1 = new Rectangle(x, y, width, height);
            Rectangle r2 = new Rectangle(s.x, s.y, s.width, s.height);
            return r1.IntersectsWith(r2);

        }
        public bool Click(int xm, int ym)

        {

            if (xm < x || xm > x + width)

                return false;

            if (ym < y || ym > y + height)

                return false;

            return true;

        }
    }
}
