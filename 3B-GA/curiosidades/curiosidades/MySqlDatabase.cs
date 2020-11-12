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

        private static MySqlDatabase instance;

        public static MySqlDatabase getInstance()
        {
            if(instance == null)
            {
                instance = new MySqlDatabase();
            }

            return instance;
        }

        public MySqlDatabase()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "database=curiosidades_db;user id=user; pwd=1234abcd";
            connection.Open();
        }

        public Curiosidade getCuriosidade(int id)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM curiosidades WHERE id_curiosidades=@id;";

            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();

            List<Curiosidade> lista = readerCuriosidades(reader);
        
            if(lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                return null;
            }
            
        }

        public List<Curiosidade> getCuriosidades(Boolean avaliado)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            int avaliadoFlag = avaliado ? 1 : 0;
            command.CommandText = "SELECT * FROM curiosidades WHERE avaliado = @avaliado;";

            command.Parameters.AddWithValue("@avaliado", avaliadoFlag);

            MySqlDataReader reader = command.ExecuteReader();

            return readerCuriosidades(reader);
        }

        public List<Curiosidade> getHomeCuriosidades(Boolean avaliado)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            int avaliadoFlag = avaliado ? 1 : 0;

            command.CommandText = "SELECT * FROM curiosidades WHERE avaliado = @avaliado ORDER BY id_curiosidades DESC LIMIT 5";
            command.Parameters.AddWithValue("@avaliado", avaliadoFlag);

            MySqlDataReader reader = command.ExecuteReader();

            return readerCuriosidades(reader);
        }

        public void addCuriosidade(Curiosidade novaCuriosidade)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO curiosidades(titulo, descricao, id_usuarios)" +
                "VALUES(@titulo, @descricao, @id)";

            command.Parameters.AddWithValue("@titulo", novaCuriosidade.titulo);
            command.Parameters.AddWithValue("@descricao", novaCuriosidade.descricao);
            command.Parameters.AddWithValue("@id", novaCuriosidade.usuarioId);

            command.ExecuteNonQuery();


        }

        public void addUsuario(Usuario usuario, string username, string password)
        {
             MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO usuarios(nome, imagem, bio, nome_usuario, senha)" +
                "VALUES(@nome, @imagem, @bio, @username, SHA1(@password))";

            command.Parameters.AddWithValue("@nome", usuario.nome);
            command.Parameters.AddWithValue("@imagem", usuario.imagem);
            command.Parameters.AddWithValue("@bio", usuario.bio);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            command.ExecuteNonQuery();
        }

        public List<Usuario> getUsuarios()
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios;";

            MySqlDataReader reader = command.ExecuteReader();

            return readerUsuario(reader);
        }

        public Usuario getUsuario(int id)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE id_usuarios = @id;";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();

           List<Usuario> lista = readerUsuario(reader);

           if(lista.Count > 0)
           {
               return lista[0];
           }
           else
           {
               return null;
           }
        }

        private List<Curiosidade> readerCuriosidades(MySqlDataReader reader)
        {
            List<Curiosidade> lista = new List<Curiosidade>();

            while(reader.Read())
            {
                Curiosidade novaCuriosidade = new Curiosidade();
                novaCuriosidade.id = reader.GetInt32(reader.GetOrdinal("id_curiosidades"));
                novaCuriosidade.titulo = reader.GetString(reader.GetOrdinal("titulo"));
                novaCuriosidade.descricao = reader.GetString(reader.GetOrdinal("descricao"));
                
                lista.Add(novaCuriosidade);
            }

            reader.Close();
            
            return lista;
        }

        private List<Usuario> readerUsuario(MySqlDataReader reader)
        {
            List<Usuario> lista = new List<Usuario>();

            while (reader.Read())
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.id = reader.GetInt32(reader.GetOrdinal("id_usuarios"));
                novoUsuario.nome = reader.GetString(reader.GetOrdinal("nome"));
                novoUsuario.imagem = reader.GetString(reader.GetOrdinal("imagem"));
                novoUsuario.bio = reader.GetString(reader.GetOrdinal("bio"));
                novoUsuario.pontos = reader.GetInt32(reader.GetOrdinal("pontos"));

                lista.Add(novoUsuario);
            }

            reader.Close();

            return lista;
        }

        public Usuario login(string user, string pass)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE nome_usuario = @user AND senha= SHA1(@pass);";
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@pass", pass);

            MySqlDataReader reader = command.ExecuteReader();

            List<Usuario> lista = readerUsuario(reader);

            if(lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                return null;
            }
        }


        public void Dispose()
        {
            connection.Close();
            instance = null;
        }
    }
}

//fopen(Nome do arquivo) ---> Memoria --> Resource Leak <--- fclose
