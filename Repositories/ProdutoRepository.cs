using Dapper;
using ProjetoAula05.Configurations;
using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    public class ProdutoRepository
    {
        //function para criar um produto no bd
        public void Create(Produto produto)
        {
            //comando SQL para inserir o produto no banco de dados
            var sql = @"
                INSERT INTO PRODUTO(
                IDPRODUTO,
                NOME, 
                PRECO,
                QUANTIDADE,
                DATACADASTRO)

                VALUES(
                   @IdProduto,
                   @Nome,
                   @Preco,
                   @Quantidade,
                   @DataCadastro)         
            ";

            //conectar no banco de dados
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                connection.Execute(sql, produto);


            }
        }


        //function para atualizar um produto no bd
        public void Update(Produto produto)
        {
            var sql = @"
                UPDATE PRODUTO 
                SET
                    NOME = @Nome,
                    PRECO = @Preco,
                    QUANTIDADE  = @Quantidade
               WHERE
                    IDPRODUTO = @IdProduto
             ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }
        //function para excluir um produto no bd
        public void Delete(Produto produto)
        {
            var sql = @"        
               DELETE FROM PRODUTO
               WHERE IDPRODUTO = @IdProduto
               ";

        using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }




        }

        //function para listrar os produtos do bd
        public List <Produto> GetAll()
        {
            var sql = @"
                SELECT * FROM PRODUTO
                ORDER BY NOME
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql).ToList();
            }
        }

        // function para retornar um produto atraves do ID

        public Produto GetById(Guid idProduto)
        {
            var sql = @"
                SELECT * FROM PRODUTO
                WHERE IDPRODUTO = @IdProduto
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql,new { idProduto }).FirstOrDefault();
            }

        }

    }
}
