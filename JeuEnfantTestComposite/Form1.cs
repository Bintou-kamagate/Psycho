using JeuEnfantTestComposite.Composites;
using JeuEnfantTestComposite.Factorys;
using JeuEnfantTestComposite.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace JeuEnfantTestComposite
{
    public partial class Form1 : Form
    {
        public static object currentForm = null;
        Graphics graphics = null;
        bool CanCreate = true;
        FactoryForme factoryForme = new FactoryForme();
        CompositeForme compositeForme = new CompositeForme();

        List<ActionForm> AllActions = new List<ActionForm>();

        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        private void BtnCreer_Click(object sender, EventArgs e)
        {
            if (CanCreate)
            {
                createForme();
            }
            else
            {
                MessageBox.Show("vous ne pouvez pas creer de nouvelle forme");
            }
        }
        
        public void createForme()
        {
            ActionForm currAction = null;
            if (RbRectangle.Checked)
            {

                IForme rectangle = factoryForme.createForme("rectangle");

                if (rectangle != null)
                {
                    if(currentForm != null)
                    {
                        graphics.Clear(DefaultBackColor);
                        compositeForme.addForm(rectangle);
                        compositeForme.Dessiner(graphics);
                    }
                    else
                    {
                        rectangle.Dessiner(graphics);
                        compositeForme.addForm(rectangle);
                    }
                    currAction = new ActionForm();
                    currAction.forme = "rectangle";
                }
                else
                    MessageBox.Show("Erreur creation, svp essayer encore");

            }
            else if (RbTriangle.Checked)
            {
                IForme triangle = factoryForme.createForme("triangle");
                if (triangle != null)
                {
                    if (currentForm != null)
                    {
                        graphics.Clear(DefaultBackColor);
                        compositeForme.addForm(triangle);
                        compositeForme.Dessiner(graphics);
                    }
                    else
                    {
                        triangle.Dessiner(graphics);
                        compositeForme.addForm(triangle);
                    }
                    currAction = new ActionForm();
                    currAction.forme = "triangle";
                }
                else
                    MessageBox.Show("Erreur creation, svp essayer encore");
            }
            else if (RbCercle.Checked)
            {
  
                IForme cercle = factoryForme.createForme("cercle");
                if (cercle != null)
                {
                    if (currentForm != null)
                    {
                        graphics.Clear(DefaultBackColor);
                        compositeForme.addForm(cercle);
                        compositeForme.Dessiner(graphics);
                    }
                    else
                    {
                        cercle.Dessiner(graphics);
                        compositeForme.addForm(cercle);
                    }
                    currAction = new ActionForm();
                    currAction.forme = "cercle";
                }
                else
                    MessageBox.Show("Erreur creation, svp essayer encore");
            }

            if(currAction != null)
            {
                currAction.date = DateTime.Now;
                currAction.action = "creation";

                AllActions.Add(currAction);
            }
            
        }


        private void BtnUp_Click(object sender, EventArgs e)
        {
            deplacerForme("haut");
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            deplacerForme("gauche");
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            deplacerForme("droite");
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            deplacerForme("bas");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (AllActions.Count != 0)
            {
                SingletonBD singletonBD = SingletonBD.getInstance();
                string text = "";
                foreach (ActionForm row in AllActions)
                {
                    text += row.ToString() + "\n";
                    SqlCommand MySqlCommand = new SqlCommand("insert into actions (action, forme, date)" +
                                          "values (@action, @forme, @Date)");

                    MySqlCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = row.action;

                    MySqlCommand.Parameters.Add("@forme", SqlDbType.VarChar).Value = row.forme;

                    MySqlCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = (row.date != null) ? row.date : Convert.DBNull;

                    singletonBD.FunctionToWrite(MySqlCommand);
                }
                AllActions.Clear();
                MessageBox.Show(text);
            }
            else
            {
                MessageBox.Show("Creer une nouvelle forme");
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (compositeForme.getAllForme().Count != 0)
            {
                if (CanCreate != false)
                {
                    compositeForme.Colorer(graphics);
                    ActionForm currAction = new ActionForm("colorer", "composite", DateTime.Now);
                    AllActions.Add(currAction);
                    CanCreate = false;
                }
                else
                    MessageBox.Show("Deja colorer");
            }
            else
            {
                MessageBox.Show("Creer une forme");
            }
            
        }


        private void deplacerForme(string direction)
        {

            if (compositeForme.getAllForme().Count != 0)
            {
                graphics.Clear(DefaultBackColor);
                compositeForme.Deplacer(graphics, direction);
                ActionForm currAction = new ActionForm("deplacer", "composite", DateTime.Now);
                AllActions.Add(currAction);
                
            }
            else
            {
                MessageBox.Show("Creer une nouvelle forme");
            }

        }
        
    }
}
