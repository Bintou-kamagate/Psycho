using System;
using System.Collections.Generic;
using System.Drawing;

namespace JeuEnfantTestComposite.Products
{

    class MyRectangles : IForme
    {
        Pen pen = new Pen(Color.Red);
        SolidBrush fillColor = new SolidBrush(Color.Red);
        bool colored = false;
        
        Rectangle rectangle;
        public int X
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = value;
            }
        }
        public int Y
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = value;
            }
        }
        public int Width
        {
            get
            {
                return rectangle.Width;
            }
            set
            {
                rectangle.Width = value;
            }
        }
        public int Height
        {
            get
            {
                return rectangle.Height;
            }
            set
            {
                rectangle.Height = value;
            }
        }

        public MyRectangles()
        {
            rectangle = new Rectangle();
        }

        public MyRectangles(int x, int y, int width, int heigh)
        {
            rectangle = new Rectangle(x, y, width, heigh);
        }

        public MyRectangles(MyRectangles Rect)
        {
            rectangle = new Rectangle(Rect.getRectangle().X, Rect.getRectangle().Y, Rect.getRectangle().Width, Rect.getRectangle().Height);
        }

        public Rectangle getRectangle()
        {
            return rectangle;
        }

        public bool getColored()
        {
            return colored;
        }

        public void setColored(bool color)
        {
            colored = color;
        }

        public void Colorer(Graphics graphics)
        {
            graphics.FillRectangle(fillColor, getRectangle());
            colored = true;
        }

        public void Deplacer(Graphics graphics, string direction)
        {
            Rectangle currentRect = rectangle;
            switch (direction)
            {
                case "haut":
                    currentRect = new Rectangle(currentRect.X, currentRect.Y - 10, currentRect.Width, currentRect.Height);
                    break;

                case "bas":
                    currentRect = new Rectangle(currentRect.X, currentRect.Y + 10, currentRect.Width, currentRect.Height);
                    break;

                case "gauche":
                    currentRect = new Rectangle(currentRect.X - 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;

                case "droite":
                    currentRect = new Rectangle(currentRect.X + 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;

                default:
                    currentRect = new Rectangle(currentRect.X + 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
            }
            rectangle = currentRect;
            Dessiner(graphics);
        }

        public void Dessiner(Graphics graphics)
        {
            graphics.DrawRectangle(pen, rectangle);
            if (colored)
            {
                Colorer(graphics);
            }
        }

        public float Surface()
        {
            throw new NotImplementedException();
        }
        public string toString()
        {
            return " rectangle " + rectangle.X +"/"+rectangle.Y + " w: " + rectangle.Width + " h: " + rectangle.Height;
        }
    }
}
