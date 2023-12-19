using System;
using System.Drawing;

namespace JeuEnfantTestComposite.Products
{

    class Triangle : IForme
    {

        Point[] CurrentTriangle;
        Point P1, P2, P3;

        Pen pen = new Pen(Color.Blue);
        SolidBrush fillColor = new SolidBrush(Color.Blue);
        bool colored = false;
        

        public Triangle()
        {

        }

        public Triangle(int FirstX, int FirstY, int SecondX, int SecondY, int ThirdX, int ThirdY)
        {
            P1 = new Point(FirstX, FirstY);
            P2 = new Point(SecondX, SecondY);
            P3 = new Point(ThirdX, ThirdY);
            CurrentTriangle = new Point[] { P1, P2, P3 };

        }

        public Triangle(Point[] AllPoints)
        {
            if (AllPoints.Length >= 3)
            {
                P1 = new Point(AllPoints[0].X, AllPoints[0].Y);
                P2 = new Point(AllPoints[1].X, AllPoints[1].Y);
                P3 = new Point(AllPoints[2].X, AllPoints[2].Y);
                CurrentTriangle = new Point[] { P1, P2, P3 };
            }
        }

        public Point getP1() { return P1; }

        public Point getP2() { return P2; }

        public Point getP3() { return P3; }

        public Point[] GetTriangle()
        {
            return CurrentTriangle;
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
            graphics.FillPolygon(fillColor, GetTriangle());
            colored = true;
        }


        public void Dessiner(Graphics graphics)
        {
            graphics.DrawPolygon(pen, GetTriangle());

            if (colored)
            {
                Colorer(graphics);
            }
        }

        public float Surface()
        {
            throw new NotImplementedException();
        }

        public void Deplacer(Graphics graphics, string direction)
        {


            Triangle currentTriangle = new Triangle(CurrentTriangle);
            switch (direction)
            {
                case "haut":
                    CurrentTriangle = new Point[] {
                        new Point(currentTriangle.getP1().X, currentTriangle.getP1().Y - 10),
                        new Point(currentTriangle.getP2().X, currentTriangle.getP2().Y - 10),
                        new Point(currentTriangle.getP3().X, currentTriangle.getP3().Y - 10) };
                    break;

                case "bas":
                    CurrentTriangle = new Point[] {
                        new Point(currentTriangle.getP1().X, currentTriangle.getP1().Y + 10),
                        new Point(currentTriangle.getP2().X, currentTriangle.getP2().Y + 10),
                        new Point(currentTriangle.getP3().X, currentTriangle.getP3().Y + 10)};
                    break;

                case "gauche":
                    CurrentTriangle = new Point[] {
                        new Point(currentTriangle.getP1().X - 10, currentTriangle.getP1().Y),
                        new Point(currentTriangle.getP2().X - 10, currentTriangle.getP2().Y),
                        new Point(currentTriangle.getP3().X - 10, currentTriangle.getP3().Y)};
                    break;

                case "droite":
                    CurrentTriangle = new Point[] {
                        new Point(currentTriangle.getP1().X + 10, currentTriangle.getP1().Y),
                        new Point(currentTriangle.getP2().X + 10, currentTriangle.getP2().Y),
                        new Point(currentTriangle.getP3().X + 10, currentTriangle.getP3().Y)};
                    break;

                default:
                    CurrentTriangle = new Point[] {
                        new Point(currentTriangle.getP1().X + 10, currentTriangle.getP1().Y),
                        new Point(currentTriangle.getP2().X + 10, currentTriangle.getP2().Y),
                        new Point(currentTriangle.getP3().X + 10, currentTriangle.getP3().Y) };
                    break;
            }
            this.parameterTriangle(CurrentTriangle);
            Dessiner(graphics);
        }

        private void parameterTriangle(Point[] triangle)
        {

            P1 = new Point(triangle[0].X, triangle[0].Y);
            P2 = new Point(triangle[1].X, triangle[1].Y);
            P3 = new Point(triangle[2].X, triangle[2].Y);
            CurrentTriangle = new Point[] { P1, P2, P3 };
        }

        public string toString()
        {
            return "triangle " + P1.X + "/" + P1.Y + " :: " + P2.X + "/" + P2.Y;
        }

    }
}
