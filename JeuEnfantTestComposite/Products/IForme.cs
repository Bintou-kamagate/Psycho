using System;
using System.Drawing;

namespace JeuEnfantTestComposite.Products
{
    interface IForme
    {
        void Dessiner(Graphics graphics);

        void Colorer(Graphics graphics);

        void Deplacer(Graphics graphics, string direction);

        float Surface();

        void setColored(bool colored);

        bool getColored();

        string toString();
    }
}
