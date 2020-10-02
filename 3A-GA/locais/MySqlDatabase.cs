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
        private static MySqlDatabase instance;
        public MySqlConnection connection;

        public MySqlDatabase() 
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "uid=user;pwd=1234abcd;database=locais_db";
            connection.Open();
        }

        public static MySqlDatabase getInstance()
        {
            if(instance == null)
            {
                instance = new MySqlDatabase();
            }

            return instance;
        }

        public List<Local> getLocalHome()
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM locais WHERE foi_revisado = 1 ORDER BY id_locais DESC LIMIT 5";

            return ReaderToLocalList(command.ExecuteReader());
        }

        public List<Local> getLocais()
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM locais";

            return ReaderToLocalList(command.ExecuteReader());
        }

        public void addLocal(Local local) 
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "INSERT INTO " +
                "locais(nome,cidade,pais,imagem,link_maps,descricao,foi_revisado) " +
                "VALUES (@nome, @cidade, @pais, @imagem, @linkMaps , @descricao, @foiRevisado)";

            command.Parameters.Add("@nome",MySqlDbType.VarChar).Value = local.nome;
            command.Parameters.Add("@cidade",MySqlDbType.VarChar).Value = local.cidade;
            command.Parameters.Add("@pais",MySqlDbType.VarChar).Value = local.pais;
            command.Parameters.Add("@imagem",MySqlDbType.VarChar).Value = local.imagem;
            command.Parameters.Add("@linkMaps",MySqlDbType.VarChar).Value = local.linkMaps;
            command.Parameters.Add("@descricao",MySqlDbType.VarChar).Value = local.descricao;
            command.Parameters.Add("@foIRevisado",MySqlDbType.Int32).Value = local.foiRevisado;

            command.ExecuteNonQuery();
        }

        private List<Local> ReaderToLocalList (MySqlDataReader reader)
        {
            List<Local> list = new List<Local>();

            while(reader.Read())
            {
                Local novoLocal = new Local();
                novoLocal.nome = reader.GetString(reader.GetOrdinal("nome"));
                novoLocal.cidade = reader.GetString(reader.GetOrdinal("cidade"));
                novoLocal.pais = reader.GetString(reader.GetOrdinal("pais"));
                novoLocal.imagem = reader.GetString(reader.GetOrdinal("imagem"));
                novoLocal.linkMaps = reader.GetString(reader.GetOrdinal("link_maps"));
                novoLocal.descricao = reader.GetString(reader.GetOrdinal("descricao"));
                novoLocal.foiRevisado = reader.GetBoolean(reader.GetOrdinal("foi_revisado"));

                list.Add(novoLocal);
            }

            reader.Close();

            return list;
        }

        public void Dispose()
        {
           connection.Close();
            instance = null;
        }
    }
}

