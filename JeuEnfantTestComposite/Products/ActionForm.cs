using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEnfantTestComposite.Products
{

    class ActionForm
    {
        public string action { get; set; }
        public string forme { get; set; }
        public DateTime? date { get; set; }

        public ActionForm()
        {

        }

        public ActionForm(string nomAction, string nomForme, DateTime? dateAction)
        {
            action = nomAction;
            forme = nomForme;
            date = dateAction;
        }

        public ActionForm(ActionForm NewAction)
        {
            action = NewAction.action;
            forme = NewAction.forme;
            date = NewAction.date;

        }

        public string ToString()
        {
            return " Action " + action + " Forme " + forme + " date " + date;
        }


    }
}
