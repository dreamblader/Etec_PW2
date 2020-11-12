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

        public void addUsuario(Usuario usuario, string username, string password)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO usuarios(username, password, image, name)"+
            "VALUES(@username, @password, @image, @name)";

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@image", usuario.image);
            command.Parameters.AddWithValue("@name", usuario.name);

            command.ExecuteNonQuery();
        }

        public Usuario login(string username, string password)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE username=@username AND password= SHA1(@password)";

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = command.ExecuteReader();

            List<Usuario> lista = ReaderToUsuarios(reader);

            if(lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                return null;
            }
            
        }

        public Usuario getUsuario(int id)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE id_usuarios=@id";
            command.Parameters.AddWithValue("@id",id);

            MySqlDataReader reader = command.ExecuteReader();
            List<Usuario> lista = ReaderToUsuarios(reader);

            if(lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                return null;
            }

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

        private List<Usuario> ReaderToUsuarios(MySqlDataReader reader)
        {
            List<Usuario> lista = new List<Usuario>();

            while(reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = reader.GetInt32(reader.GetOrdinal("id_usuarios"));
                usuario.name = reader.GetString(reader.GetOrdinal("name"));
                usuario.image = reader.GetString(reader.GetOrdinal("image"));

                lista.Add(usuario);
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

