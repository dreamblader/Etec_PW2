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

        public List<Curiosidade> getCuriosidades()
        {
            List<Curiosidade> lista = new List<Curiosidade>();

            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM curiosidades;";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Curiosidade novaCuriosidade = new Curiosidade();
                novaCuriosidade.titulo = reader.GetString(reader.GetOrdinal("titulo"));
                novaCuriosidade.descricao = reader.GetString(reader.GetOrdinal("descricao"));
                
                lista.Add(novaCuriosidade);
            }

            reader.Close();

            return lista;
        }

        public void addCuriosidade(Curiosidade novaCuriosidade)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO curiosidades(titulo, descricao)" +
                "VALUES(?novaCuriosidade.titulo, ?novaCuriosidade.descricao)";

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


        public void Dispose()
        {
            connection.Close();
            instance = null;
        }
    }
}

//fopen(Nome do arquivo) ---> Memoria --> Resource Leak <--- fclose
