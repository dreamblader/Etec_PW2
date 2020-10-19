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
            command.CommandText = "INSERT INTO curiosidades(titulo, descricao)" +
                "VALUES(@titulo, @descricao)";

            command.Parameters.Add("@titulo", MySqlDbType.VarChar).Value = novaCuriosidade.titulo;
            command.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = novaCuriosidade.descricao;

            command.ExecuteNonQuery();


        }

        public List<Usuario> getUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios;";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.nome = reader.GetString(reader.GetOrdinal("nome"));
                novoUsuario.imagem = reader.GetString(reader.GetOrdinal("imagem"));
                novoUsuario.bio = reader.GetString(reader.GetOrdinal("bio"));
                novoUsuario.pontos = reader.GetInt32(reader.GetOrdinal("pontos"));

                lista.Add(novoUsuario);
            }

            reader.Close();

            return lista;
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


        public void Dispose()
        {
            connection.Close();
            instance = null;
        }
    }
}

//fopen(Nome do arquivo) ---> Memoria --> Resource Leak <--- fclose
