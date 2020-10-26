using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp.Common
{
    public static class Database
    {
        public static void Create()
        {
            string connectionString = "Server= localhost; Database= EGO; Integrated Security=True;";
            string CreationQuery = File.ReadAllText(@"C:\Users\mgrandiere.COMMANDALKON\Source\Repos\mimi270188\EGOFormsApp\DAL\SQLCreation.sql", Encoding.GetEncoding("iso-8859-1"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(CreationQuery, con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static void Drop()
        {
            string connectionString = "Server= localhost; Database= EGO; Integrated Security=True;";
            string DropQuery = File.ReadAllText(@"C:\Users\mgrandiere.COMMANDALKON\Source\Repos\mimi270188\EGOFormsApp\DAL\SQLDrop.sql");

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(DropQuery, con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
