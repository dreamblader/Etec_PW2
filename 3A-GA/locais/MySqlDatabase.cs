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

        public List<Local> getLocais(Boolean revisado)
        {
            int flagRevisado = revisado ? 1 : 0;

            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM locais WHERE foi_revisado = @revisado";

            command.Parameters.AddWithValue("@revisado",flagRevisado);

            return ReaderToLocalList(command.ExecuteReader());
        }

        public Local getLocal(int id)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM locais WHERE id_locais=@id";

            command.Parameters.AddWithValue("@id", id);

            List<Local> list = ReaderToLocalList(command.ExecuteReader());

            if(list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }

        }

        public Usuario login (string username,string password)
        {
            MySqlCommand command = instance.connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE username= @username AND password= SHA(@password)";

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            List<Usuario> lista = ReaderToUserList(command.ExecuteReader());

            if(lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                return null;
            }
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
                novoLocal.id = reader.GetInt32(reader.GetOrdinal("id_locais"));
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

        private List<Usuario> ReaderToUserList (MySqlDataReader reader)
        {
            List<Usuario> list = new List<Usuario>();

            while(reader.Read())
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.id = reader.GetInt32(reader.GetOrdinal("id_usuarios"));
                novoUsuario.nome = reader.GetString(reader.GetOrdinal("nome"));
                novoUsuario.imagem = reader.GetString(reader.GetOrdinal("imagem"));
                novoUsuario.bio = reader.GetString(reader.GetOrdinal("bio"));
       
                list.Add(novoUsuario);
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

