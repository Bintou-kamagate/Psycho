using JeuEnfantTestComposite.Products;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace JeuEnfantTestComposite.Composites
{
    class CompositeForme : IForme
    {
        List<IForme> AllForme = new List<IForme>();


        public List<IForme> getAllForme()
        {
            return AllForme;
        }

        public void Colorer(Graphics graphics)
        {
            IForme lastForm = getLastForm();

            if (lastForm != null)
                lastForm.Colorer(graphics);
        }

        public void Deplacer(Graphics graphics, string direction)
        {

            foreach (IForme row in AllForme)
            {
                if (row != null)
                {
                    row.Deplacer(graphics, direction);
                }
            }
            Form1.currentForm = getLastForm();
            
        }

        public void Dessiner(Graphics graphics)
        {
            foreach (IForme row in AllForme)
            {
                if(row != null)
                    row.Dessiner(graphics);
            }
            
        }

        public bool getColored()
        {
            IForme lastForm = getLastForm();

            if (lastForm != null)
              return lastForm.getColored();
            return false;
        }

        public void setColored(bool colored)
        {

            IForme lastForm = getLastForm();

            if (lastForm != null)
                lastForm.setColored(colored);
        }

        public float Surface()
        {
            throw new NotImplementedException();
        }

        public void addForm(IForme newForme)
        {
            AllForme.Add(newForme);
        }

        public void clearList()
        {
            AllForme.Clear();
        }

        public void setAllForme(List<IForme> NewAllForme)
        {
            AllForme = NewAllForme;
        }

        public IForme getLastForm()
        {
            IForme lastForm = null;
            foreach (IForme row in AllForme)
            {
                if (row != null)
                    lastForm = row;
            }

            return lastForm;
        }

        public string toString()
        {
            throw new NotImplementedException();
        }
    }
}
