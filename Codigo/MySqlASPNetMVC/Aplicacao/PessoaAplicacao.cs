using System.ComponentModel.DataAnnotations;
using System.Linq;
using MySqlASPNetMVC.Models;
using MySqlASPNetMVC.Repositorio;
using System.Collections.Generic;

namespace MySqlASPNetMVC.Aplicacao
{
    public class PessoaAplicacao
    {
        private readonly Contexto contexto ;

        public PessoaAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Pessoa> ListarTodos()
        {
            var pessoas = new List<Pessoa>();
            const string strQuery = "SELECT Id, Nome FROM Pessoa";
            
            var rows = contexto.ExecutaComandoComRetorno(strQuery, null);
            foreach (var row in rows)
            {
                var tempPessoa = new Pessoa
                {
                    Id = int.Parse( !string.IsNullOrEmpty(row["Id"])?row["Id"]:"0" ), 
                    Nome = row["Nome"]
                };
                pessoas.Add(tempPessoa);
            }

            return pessoas;
        }


        private int Inserir(Pessoa pessoa)
        {
            const string commandText = " INSERT INTO Pessoa (Nome) VALUES (@Nome) ";

            var parameters = new Dictionary<string, object>
            {
                {"Nome", pessoa.Nome}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        private int Alterar(Pessoa pessoa)
        {
            var commandText = " UPDATE Pessoa SET ";
            commandText += " Nome = @Nome ";
            commandText += " WHERE Id = @Id ";

            var parameters = new Dictionary<string, object>
            {
                {"Id", pessoa.Id},
                {"Nome", pessoa.Nome}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Pessoa pessoa)
        {
            if (pessoa.Id > 0)
                Alterar(pessoa);
            else
                Inserir(pessoa);
        }

        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM Pessoa WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                {"Id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }

        public Pessoa ListarPorId(int id)
        {
            var pessoas = new List<Pessoa>();
            const string strQuery = "SELECT Id, Nome FROM Pessoa WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                {"Id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempPessoa = new Pessoa
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["Id"]) ? row["Id"] : "0"),
                    Nome = row["Nome"]
                };
                pessoas.Add(tempPessoa);
            }

            return pessoas.FirstOrDefault();
        }


    }
}