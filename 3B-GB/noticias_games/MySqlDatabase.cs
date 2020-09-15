using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class MySqlDatabase: IDisposable
    {
        public MySqlConnection connection;

        public MySqlDatabase() 
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "uid=root;pwd=root;database=noticias_db";
            connection.Open();
        }

        public List<Noticia> getNoticias()
        {
            //todo
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
