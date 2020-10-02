using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class MySqlDatabase: IDisposable
    {
        static MySqlDatabase instance;

        public MySqlConnection connection;

        public MySqlDatabase() 
        {    
            connection = new MySqlConnection();
            connection.ConnectionString = "uid=user;pwd=1234abcd;database=noticias_db";
            connection.Open();
        }

        public static MySqlDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new MySqlDatabase();
            }
          
            return instance;   
        }

        public List<Noticia> getNoticias()
        {
            List<Noticia> lista = new List<Noticia>();

            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM noticias";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Noticia novaNoticia = new Noticia();
                novaNoticia.titulo = reader.GetString(reader.GetOrdinal("titulo"));
                novaNoticia.jogo = reader.GetString(reader.GetOrdinal("jogo"));
                novaNoticia.imagem = reader.GetString(reader.GetOrdinal("image"));
                novaNoticia.descricao = reader.GetString(reader.GetOrdinal("descricao"));

                lista.Add(novaNoticia);
            }

            return lista;
        }

        public void Dispose()
        {
            instance.connection.Close();
            instance = null;
        }
    }
}
