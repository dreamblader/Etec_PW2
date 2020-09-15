using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace site
{
    public class MySqlDatabase: IDisposable
    {
        public MySqlConnection connection;

        public MySqlDatabase() 
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "uid=root;pwd=root;database=locais_db";
            connection.Open();
        }

        public List<Local> getLocais()
        {
            List<Local> list = new List<Local>();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM locais";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Local novoLocal = new Local();
                novoLocal.nome = reader.GetString(reader.GetOrdinal("nome"));
                novoLocal.cidade = reader.GetString(reader.GetOrdinal("cidade"));
                novoLocal.pais = reader.GetString(reader.GetOrdinal("pais"));
                novoLocal.linkMaps = reader.GetString(reader.GetOrdinal("link_maps"));
                novoLocal.descricao = reader.GetString(reader.GetOrdinal("descricao"));
                novoLocal.foiRevisado = reader.GetBoolean(reader.GetOrdinal("foi_revisado"));

                list.Add(novoLocal);
            }

            return list;
        }

        public void Dispose()
        {
           connection.Close();
        }
    }
}

