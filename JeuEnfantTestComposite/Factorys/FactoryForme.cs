using JeuEnfantTestComposite.Products;
using System;
using System.Drawing;

namespace JeuEnfantTestComposite.Factorys
{

    class FactoryForme
    {

        int[] CadreX = new int[] { 10, 500 };
        int[] CadreY = new int[] { 100, 350 };

        public IForme createForme(string choice)
        {
            switch (choice)
            {
                case "rectangle":
                    //on teste pour savoir si un objet a ete deja cree d'abord
                    //si oui on cree une forme à l'interieur de cette forme
                    if (Form1.currentForm != null)
                        Form1.currentForm = createNewForm("rectangle");
                    //sinon on cree une nouvelle forme qui sera la premiere forme
                    else
                    {

                        Form1.currentForm = new MyRectangles(
                        CadreX[0] + 5, CadreY[0] + 5,
                        CadreX[1] - 5,
                        CadreY[1] - 5);
                    }
                    break;

                case "cercle":
                    //on teste pour savoir si un objet a ete deja cree d'abord
                    //si oui on cree une forme à l'interieur de cette forme
                    if (Form1.currentForm != null)
                        Form1.currentForm = createNewForm("cercle");
                    //sinon on cree une nouvelle forme qui sera la premiere forme
                    else
                    {
                        int Heigh = CadreY[1] - 5;
                        int widtLeft = CadreX[1] - Heigh - CadreX[0];

                        Form1.currentForm = new Circle(new Rectangle(CadreX[0] + 5 + (widtLeft / 2), CadreY[0] + 5, Heigh, Heigh));

                    }
                    break;

                case "triangle":
                    //on teste pour savoir si un objet a ete deja cree d'abord
                    //si oui on cree une forme à l'interieur de cette forme
                    if (Form1.currentForm != null)
                        Form1.currentForm = createNewForm("triangle");
                    //sinon on cree une nouvelle forme qui sera la premiere forme
                    else
                    {

                        Form1.currentForm = ObtainTrangleEquilateral(
                            new Point(CadreX[0] + 10, CadreY[1] - 5),
                            new Point(CadreX[1] - 10, CadreY[1] - 5),
                            new Point((CadreX[1] - CadreX[0]) / 2, CadreY[0] + 5));
                    }
                    break;
            }
            
            return (IForme)Form1.currentForm;
        }

        public IForme createNewForm(string formeTxt)
        {
            IForme newForm = null;

            //verifier le type de la forme existante qui va recevoir la nouvelle forme

            if (Form1.currentForm.GetType() == typeof(Triangle))
            {
                switch (formeTxt)
                {
                    case "rectangle":
                        newForm = ObtainRectangleInCurrentTriangle();
                        break;

                    case "cercle":
                        newForm = ObtainCircleInCurrentTriangle();
                        break;

                    case "triangle":
                        newForm = ObtainTriangleInCurrentTriangle();
                        break;
                }
            }

            else if (Form1.currentForm.GetType() == typeof(Circle))
            {
                switch (formeTxt)
                {
                    case "rectangle":
                        newForm = ObtainRectangleInCurrentCercle();
                        break;

                    case "cercle":
                        newForm = ObtainCircleInCurrentCercle();
                        break;

                    case "triangle":
                        newForm = ObtainTriangleInCurrentCercle();
                        break;
                }
            }

            else if (Form1.currentForm.GetType() == typeof(MyRectangles))
            {
                switch (formeTxt)
                {
                    case "rectangle":
                        newForm = ObtainRectangleInCurrentRectangle();
                        break;

                    case "cercle":
                        newForm = ObtainCircleInCurrentRectangle();
                        break;

                    case "triangle":
                        newForm = ObtainTriangleInCurrentRectangle();
                        break;
                }
            }

            return newForm;
        }
        



        //Ces fonctions suivantes servent uniquement pour creer des formes specifique comme un triangle equilaterial
        //ou encore un cercle inscrit dans un triangle

        public Triangle ObtainTriangleInCurrentCercle()
        {

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Circle))
            {
                Circle CurrentCircle = (Circle)Form1.currentForm;
                bool senschanged = false;
                Point BtLeft = new Point();
                Point BtRight = new Point();

                Point BottomLeft = new Point(CurrentCircle.GetBottomLeft().X, CurrentCircle.GetBottomLeft().Y);
                Point BottomRight = new Point(CurrentCircle.GetBottomRight().X, CurrentCircle.GetBottomRight().Y);
                Point Sommet = new Point(CurrentCircle.GetCenter().X, CurrentCircle.GetTopLeft().Y);

                for (int y = BottomRight.Y; y > CurrentCircle.GetCenter().Y; y--)
                {
                    if (calculdistance(BottomRight, CurrentCircle.GetCenter()) < CurrentCircle.GetRayon())
                    {
                        senschanged = true;
                        if (BtLeft.X == 0 && BtLeft.Y == 0)
                        {
                            BtLeft = new Point(BottomLeft.X, BottomLeft.Y);
                            BtRight = new Point(BottomRight.X, BottomRight.Y);
                        }
                    }
                    else
                    {
                        senschanged = false;
                    }
                    if (senschanged)
                    {
                        BottomLeft.X -= 1;
                        BottomLeft.Y -= 1;
                        BottomRight.X += 1;
                        BottomRight.Y -= 1;
                    }
                    else
                    {
                        BottomLeft.X += 1;
                        BottomLeft.Y -= 1;
                        BottomRight.X -= 1;
                        BottomRight.Y -= 1;
                    }

                    if (calculdistance(BottomLeft, BottomRight) == calculdistance(Sommet, BottomRight))
                    {
                        return new Triangle(new Point[] { BottomLeft, BottomRight, Sommet });
                    }
                }
                return new Triangle(new Point[] { BtLeft, BtRight, Sommet });
            }
            return null;
        }

        public MyRectangles ObtainRectangleInCurrentCercle()
        {

            MyRectangles Curr = new MyRectangles(0, 0, 0, 0);

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Circle))
            {
                Circle CurrentCircle = (Circle)Form1.currentForm;

                bool senschanged = false;

                Point TopLeft = new Point(CurrentCircle.GetTopLeft().X, CurrentCircle.GetTopLeft().Y);
                Point TopRight = new Point(CurrentCircle.GetTopRight().X, CurrentCircle.GetTopRight().Y);
                Point Center = new Point(CurrentCircle.GetCenter().X, CurrentCircle.GetCenter().Y);
                Point Sommet = new Point(CurrentCircle.GetCenter().X, CurrentCircle.GetBottomRight().Y);

                for (int y = TopLeft.Y; y < Center.Y; y++)
                {
                    if (calculdistance(TopLeft, Center) < CurrentCircle.GetRayon())
                    {
                        senschanged = true;
                    }
                    else
                    {
                        senschanged = false;
                    }
                    if (!senschanged)
                    {
                        TopLeft.X += 1;
                        TopLeft.Y += 1;
                        TopRight.X -= 1;
                        TopRight.Y += 1;
                    }
                    else
                    {
                        TopLeft.X -= 1;
                        TopLeft.Y += 1;
                        TopRight.X += 1;
                        TopRight.Y += 1;
                    }

                    if (calculdistance(TopLeft, TopRight) == (calculdistance(Sommet, TopRight) + 1)
                        || calculdistance(TopLeft, TopRight) == (calculdistance(Sommet, TopRight) - 1)
                        || calculdistance(TopLeft, TopRight) == calculdistance(Sommet, TopRight))
                    {
                        Point P3 = new Point(TopLeft.X, 2 * (Center.Y - TopLeft.Y) + TopLeft.Y);
                        Point P4 = new Point(TopRight.X, 2 * (Center.Y - TopLeft.Y) + TopLeft.Y);
                        return new MyRectangles(TopLeft.X, TopLeft.Y, P4.X - TopLeft.X, P3.Y - TopRight.Y);
                    }

                }
            }

            return Curr;
        }

        public Circle ObtainCircleInCurrentCercle()
        {
            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Circle))
            {
                Circle CurrentCircle = (Circle)Form1.currentForm;

                Rectangle Rect = CurrentCircle.GetRectangle();

                Rect.Width = Rect.Width - 10;
                Rect.Height = Rect.Height - 10;
                Rect.X = Rect.X + 5;
                Rect.Y = Rect.Y + 5;

                return new Circle(Rect);
            }
            return null;
        }


        public Triangle ObtainTriangleInCurrentTriangle()
        {

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Triangle))
            {
                Triangle CurrentTriangle = (Triangle)Form1.currentForm;

                Point PSommet = new Point(CurrentTriangle.getP3().X, CurrentTriangle.getP3().Y + 5);
                Point SommetDefault = new Point();
                SommetDefault.Y = PSommet.Y;
                SommetDefault.X = PSommet.X;
                Point FirstPoint = new Point(CurrentTriangle.getP1().X + 10, CurrentTriangle.getP1().Y - 5);
                Point SecondPoint = new Point(CurrentTriangle.getP2().X - 10, CurrentTriangle.getP2().Y - 5);
                for (int i = FirstPoint.X; i < SecondPoint.X; i++)
                {
                    SommetDefault.X = i;
                    if (calculdistance(FirstPoint, SommetDefault) == calculdistance(SommetDefault, SecondPoint)
                        && calculdistance(SommetDefault, SecondPoint) == calculdistance(SecondPoint, FirstPoint))
                    {
                        return new Triangle(new Point[] { FirstPoint, SecondPoint, SommetDefault });
                    }
                }

                SommetDefault.X = FirstPoint.X + (calculdistance(FirstPoint, SecondPoint) / 2);
                return new Triangle(new Point[] { FirstPoint, SecondPoint, SommetDefault });
            }
            return null;
        }

        public MyRectangles ObtainRectangleInCurrentTriangle()
        {

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Triangle))
            {
                Triangle CurrentTriangle = (Triangle)Form1.currentForm;

                int h = CurrentTriangle.getP1().Y - CurrentTriangle.getP3().Y;
                int a = CurrentTriangle.getP3().X - CurrentTriangle.getP1().X;
                int x = a / 2;

                int y = h / 2;

                int b = calculdistance(CurrentTriangle.getP1(), CurrentTriangle.getP2());

                int xPrim = (a + b) / 2;

                return new MyRectangles(CurrentTriangle.getP1().X + x, CurrentTriangle.getP1().Y - y, xPrim - x, y);
            }
            return new MyRectangles(0, 0, 0, 0);
        }

        public Circle ObtainCircleInCurrentTriangle()
        {

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(Triangle))
            {
                Triangle CurrentTriangle = (Triangle)Form1.currentForm;

                Point PointA = new Point(CurrentTriangle.getP1().X, CurrentTriangle.getP1().Y);
                Point PointB = new Point(CurrentTriangle.getP2().X, CurrentTriangle.getP2().Y);
                Point PointC = new Point(CurrentTriangle.getP3().X, CurrentTriangle.getP3().Y);

                double aEqualsDtP2P3 = calculdistance(PointB, PointC);
                double bEqualsDtP3P1 = calculdistance(PointC, PointA);
                double cEqualsDtP1P2 = calculdistance(PointA, PointB);

                int SommeTotalDistance = (int)(aEqualsDtP2P3 + bEqualsDtP3P1 + cEqualsDtP1P2);

                int numerateurX = (int)((aEqualsDtP2P3 * PointA.X) + (bEqualsDtP3P1 * PointB.X) + (cEqualsDtP1P2 * PointC.X));
                int ValueX = (numerateurX / SommeTotalDistance);

                int numerateurY = (int)((aEqualsDtP2P3 * PointA.Y) + (bEqualsDtP3P1 * PointB.Y) + (cEqualsDtP1P2 * PointC.Y));
                int ValueY = (numerateurY / SommeTotalDistance);

                Point PointCenter = new Point(ValueX, ValueY);

                double average = SommeTotalDistance / 2;

                double Rayon = Math.Sqrt((((average - aEqualsDtP2P3) * (average - bEqualsDtP3P1) * (average - cEqualsDtP1P2)) / average));

                return new Circle(new Rectangle(ValueX - (int)Rayon, ValueY - (int)Rayon, (int)Rayon * 2, (int)Rayon * 2));

            }
            return null;
        }



        public Triangle ObtainTriangleInCurrentRectangle()
        {

            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(MyRectangles))
            {
                MyRectangles CurrentRectangle = (MyRectangles)Form1.currentForm;
                Point PSommet = new Point(CurrentRectangle.X, CurrentRectangle.Y + 5);
                Point SommetDefault = new Point();
                SommetDefault.Y = PSommet.Y;
                SommetDefault.X = PSommet.X;
                Point FirstPoint = new Point(CurrentRectangle.X + 10, CurrentRectangle.Y + CurrentRectangle.Height - 5);
                Point SecondPoint = new Point(CurrentRectangle.X + CurrentRectangle.Width - 10, CurrentRectangle.Y + CurrentRectangle.Height - 5);
                for (int i = FirstPoint.X; i < SecondPoint.X; i++)
                {
                    SommetDefault.X = i;
                    if (calculdistance(FirstPoint, SommetDefault) == calculdistance(SommetDefault, SecondPoint)
                        && calculdistance(SommetDefault, SecondPoint) == calculdistance(SecondPoint, FirstPoint))
                    {
                        return new Triangle(new Point[] { FirstPoint, SecondPoint, SommetDefault });
                    }
                }

                SommetDefault.X = FirstPoint.X + (calculdistance(FirstPoint, SecondPoint) / 2);
                return new Triangle(new Point[] { FirstPoint, SecondPoint, SommetDefault });
            }
            return null;
        }

        public MyRectangles ObtainRectangleInCurrentRectangle()
        {
            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(MyRectangles))
            {
                MyRectangles CurrentRectangle = (MyRectangles)Form1.currentForm;

                return new MyRectangles(CurrentRectangle.X + 5, CurrentRectangle.Y + 5, CurrentRectangle.Width - 10, CurrentRectangle.Height - 10);
            }
            return new MyRectangles(0, 0, 0, 0);
        }

        public Circle ObtainCircleInCurrentRectangle()
        {
            if (Form1.currentForm != null && Form1.currentForm.GetType() == typeof(MyRectangles))
            {
                MyRectangles Rect = new MyRectangles(((MyRectangles)Form1.currentForm));

                int cote = Rect.Height - 10;
                int left = Rect.Width - cote;
                Rect.Width = cote;
                Rect.Height = cote;
                Rect.X = (left / 2) + Rect.X;
                Rect.Y = Rect.Y + 5;

                return new Circle(Rect.getRectangle());

            }
            return null;
        }


        public Triangle ObtainTrangleEquilateral(Point P1, Point P2, Point PSommet)
        {
            Point P3 = new Point();
            P3.Y = PSommet.Y;
            P3.X = PSommet.X;
            for (int i = P1.X; i < P2.X; i++)
            {
                P3.X = i;
                if (calculdistance(P1, P3) == calculdistance(P3, P2) && calculdistance(P3, P2) == calculdistance(P2, P1))
                {
                    return new Triangle(new Point[] { P1, P2, P3 });
                }
            }

            P3.X = P1.X + (calculdistance(P1, P2) / 2);
            return new Triangle(new Point[] { P1, P2, P3 });
        }

        public int calculdistance(Point P1, Point P2)
        {
            return (int)Math.Sqrt(((P2.X - P1.X) * (P2.X - P1.X)) + ((P2.Y - P1.Y) * (P2.Y - P1.Y)));
        }
    }
}
