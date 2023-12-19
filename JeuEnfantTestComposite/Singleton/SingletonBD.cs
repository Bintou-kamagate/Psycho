using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEnfantTestComposite
{
    class SingletonBD
    {

        private static string StrConnexion = @"Data Source=DESKTOP-VCFQC2J\SQLEXPRESS;Initial Catalog=JeuEnfant;Integrated Security=True";
        private static SqlConnection Connection = new SqlConnection(StrConnexion);
        private static SingletonBD myInstance = new SingletonBD();

        public Guid InstanceConn
        {
            get;
            set;
        }

        public Guid InstanceId
        {
            get;
            private set;
        }

        private SingletonBD()
        {
            this.InstanceId = Guid.NewGuid();
        }

        public static SingletonBD getInstance()
        {
            return myInstance;
        }

        //Ouverture de la connection
        private bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        //Fermeture de la connection
        private bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Ecriture
        public int FunctionToWrite(SqlCommand CommandRequest)
        {

            int NumberOfRows = 0;
            Object Obj = null;

            try
            {
                //pour eviter l'acces à un d'acceder à connection si un autre thread l'utilise
                lock (Connection)
                {
                    if (OpenConnection() == true)
                    {
                        //creation de la commande et affectation a query et la connection du constructor
                        CommandRequest.Connection = Connection;

                        //execution de la commande 

                        Obj = CommandRequest.ExecuteScalar();

                        if (Obj != null)
                        {
                            NumberOfRows = (Int32)Obj;
                        }

                    }
                    else
                    {
                        NumberOfRows = -2;
                    }
                }

            }
            catch (Exception e)
            {
                NumberOfRows = -2;
                throw e;
            }
            finally
            {
                //fermeture de la connextion
                CloseConnection();
            }
            return NumberOfRows;

        }

        //lecture
        public DataTable FunctionToRead(SqlCommand CommanReqRead)
        {

            DataTable dt = new DataTable();


            try
            {
                lock (Connection)
                {
                    if (OpenConnection() == true)
                    {

                        CommanReqRead.Connection = Connection;
                        //execution de la commande 
                        SqlDataReader dre = CommanReqRead.ExecuteReader();

                        dt.Load(dre);

                        //fermeture de la connextion
                        InstanceConn = Connection.ClientConnectionId;
                        
                        CloseConnection();

                    }
                }
            }
            catch (Exception e)
            {
                dt = null;
            }
            finally
            {
                //fermeture de la connextion
                CloseConnection();
            }
            return dt;

        }

    }
}