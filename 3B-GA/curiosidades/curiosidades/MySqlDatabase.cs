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
            connection.ConnectionString = "database=curiosidades_db;user id=root; pwd=root";
            connection.Open();
        }

        public List<Curiosidade> getCuriosidades()
        {
            List<Curiosidade> lista = new List<Curiosidade>();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM curiosidades;";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Curiosidade novaCuriosidade = new Curiosidade();
                novaCuriosidade.titulo = reader.GetString(reader.GetOrdinal("titulo"));
                novaCuriosidade.descricao = reader.GetString(reader.GetOrdinal("descricao"));
                
                lista.Add(novaCuriosidade);
            }

            return lista;
        }

        public List<Usuario> getUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            MySqlCommand command = connection.CreateCommand();
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

            return lista;
        }


        public void Dispose()
        {
            connection.Close();
        }
    }
}

//fopen(Nome do arquivo) ---> Memoria --> Resource Leak <--- fclose
