using System;
using System.Drawing;

namespace JeuEnfantTestComposite.Products
{

    class Circle : IForme
    {
        Pen pen = new Pen(Color.Black);
        SolidBrush fillColor = new SolidBrush(Color.Black);
        bool colored = false;


        Rectangle ConvertToRectangle;
        int CenterValueX, CenterValueY;
        Point TopLeft, TopRight, BottomLeft, BottomRight;
        double Rayon;
        
        public Circle()
        {

        }

        public Circle(int X, int Y, double R)
        {
            CenterValueX = X;
            CenterValueY = Y;
            Rayon = R;

            TopLeft = new Point(X - (int)R, Y - (int)R);
            TopRight = new Point(X + (int)R, Y - (int)R);


            BottomLeft = new Point(X - (int)R, Y + (int)R);
            BottomRight = new Point(X + (int)R, Y + (int)R);

            ConvertToRectangle = new Rectangle(X - (int)R, Y - (int)R, (int)Math.Sqrt(3 * R * R), (int)Math.Sqrt(3 * R * R));
        }

        public Circle(Rectangle Rect)
        {
            Rayon = Rect.Height / 2;

            CenterValueX = Rect.X + (int)Rayon;
            CenterValueY = Rect.Y + (int)Rayon;
            ConvertToRectangle = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);

            TopLeft = new Point(Rect.X, Rect.Y);
            TopRight = new Point(Rect.X + Rect.Width, Rect.Y);
            BottomRight = new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            BottomLeft = new Point(Rect.X, Rect.Y + Rect.Height);

        }

        public double GetRayon()
        {
            return Rayon;
        }

        public Rectangle GetRectangle()
        {
            return ConvertToRectangle;
        }

        public Point GetCenter()
        {
            return new Point(CenterValueX, CenterValueY);
        }

        public Point GetTopLeft() { return TopLeft; }

        public Point GetBottomRight() { return BottomRight; }

        public void SetTopLeft(Point P) { TopLeft = new Point(P.X, P.Y); }

        public void SetBottomRight(Point P) { BottomRight = new Point(P.X, P.Y); }

        public Point GetTopRight() { return TopRight; }

        public Point GetBottomLeft() { return BottomLeft; }

        public void SetTopRight(Point P) { TopRight = new Point(P.X, P.Y); }

        public void SetBottomLeft(Point P) { BottomLeft = new Point(P.X, P.Y); }


        public bool getColored()
        {
            return colored;
        }

        public void setColored(bool color)
        {
            colored = color;
        }

        public void Deplacer(Graphics graphics, string direction)
        {
            Rectangle currentRect = ConvertToRectangle;
            switch (direction)
            {
                case "haut":
                    ConvertToRectangle = new Rectangle(currentRect.X, currentRect.Y - 10, currentRect.Width, currentRect.Height);
                    break;
                case "bas":
                    ConvertToRectangle = new Rectangle(currentRect.X, currentRect.Y + 10, currentRect.Width, currentRect.Height);
                    break;
                case "gauche":
                    ConvertToRectangle = new Rectangle(currentRect.X - 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
                case "droite":
                    ConvertToRectangle = new Rectangle(currentRect.X + 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
                default:
                    ConvertToRectangle = new Rectangle(currentRect.X + 10, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
            }
            this.ParameterCircle(ConvertToRectangle);

            this.Dessiner(graphics);
        }

        public void Colorer(Graphics graphics)
        {
            graphics.FillEllipse(fillColor, GetRectangle());
            colored = true;
        }

        public void Dessiner(Graphics graphics)
        {

            graphics.DrawEllipse(pen, GetRectangle());
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
            return "X : " + CenterValueX + " Y : " + CenterValueY + " ray " + Rayon;
        }

        public void ParameterCircle(Rectangle Rect)
        {
            Rayon = Rect.Height / 2;

            CenterValueX = Rect.X + (int)Rayon;
            CenterValueY = Rect.Y + (int)Rayon;
            ConvertToRectangle = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);

            TopLeft = new Point(Rect.X, Rect.Y);
            TopRight = new Point(Rect.X + Rect.Width, Rect.Y);
            BottomRight = new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            BottomLeft = new Point(Rect.X, Rect.Y + Rect.Height);
        }
    }
}
