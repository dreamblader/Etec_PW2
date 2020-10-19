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
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM noticias";

            MySqlDataReader reader = command.ExecuteReader();

            
            return ReaderToNoticia(reader);
        }

        public List<Noticia> getHomeNoticias()
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM noticias ORDER BY id_noticias DESC LIMIT 5";

            MySqlDataReader reader = command.ExecuteReader();

            return ReaderToNoticia(reader);
        }

        public void addNoticia(Noticia noticia)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO noticias(titulo, jogo, image, descricao, id_categoria)"+
            "VALUES(@titulo, @jogo, @imagem, @descricao, 01)";

            command.Parameters.AddWithValue("@titulo",noticia.titulo);
            command.Parameters.AddWithValue("@jogo",noticia.jogo);
            command.Parameters.AddWithValue("@imagem",noticia.imagem);
            command.Parameters.AddWithValue("@descricao",noticia.descricao);

            command.ExecuteNonQuery();
        }

        private List<Noticia> ReaderToNoticia(MySqlDataReader reader)
        {
            List<Noticia> lista = new List<Noticia>();

            while(reader.Read())
            {
                Noticia novaNoticia = new Noticia();
                novaNoticia.titulo = reader.GetString(reader.GetOrdinal("titulo"));
                novaNoticia.jogo = reader.GetString(reader.GetOrdinal("jogo"));
                novaNoticia.imagem = reader.GetString(reader.GetOrdinal("image"));
                novaNoticia.descricao = reader.GetString(reader.GetOrdinal("descricao"));

                lista.Add(novaNoticia);
            }

            reader.Close();

            return lista;
        }

        public void Dispose()
        {
            instance.connection.Close();
            instance = null;
        }

        
    }
}

// Fibonacci - Método Recursivo

