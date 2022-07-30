using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    public class ProdutoController
    {
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\n ======= CADASTRO DE PRODUTOS ======= \n");
                var produto = new Produto();

                produto.IdProduto = Guid.NewGuid();
                produto.DataCadastro = DateTime.Now;

                Console.WriteLine("DIGITE O NOME DO PRODUTO............: ");
                produto.Nome = Console.ReadLine();

                Console.WriteLine("DIGITE O PREÇO DO PRODUTO...........: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.WriteLine("DIGITE A QUANTIDADE DO PRODUTO......: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

          

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(produto);

                Console.WriteLine("PRODUTO CADASTRADO COM SUCESSO!!!!");


            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha:  {e.Message}");
            }
      

        }
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\n *** ATUAALIZAÇÃO DE PRODUTO: ***\n");

                Console.WriteLine("ENTRE COM O ID DO PRODUTO DESEJADO...........: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if(produto != null)
                {
                    Console.WriteLine("DIGITE O NOVO NOME DO PRODUTO............: ");
                    produto.Nome = Console.ReadLine();

                    Console.WriteLine("DIGITE O NOVO PREÇO DO PRODUTO...........: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("DIGITE A NOVA QUANTIDADE DO PRODUTO......: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    produtoRepository.Update(produto);

                    Console.WriteLine("\n PRODUTO ATUALIZADO COM SUCESSO!!");

                }
                else
                {
                    Console.WriteLine("\n PRODUTO NÃO ENCONTRADO, VERIFIQUE O ID INFORMADO.");
                }



            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha:  {e.Message}");
            }
        }
        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\n *********** EXCLUSÃO DE PRODUTO: **********\n");

                Console.WriteLine("ENTRE COM O ID DO PRODUTO DESEJADO...........: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if(produto != null)
                {
                    produtoRepository.Delete(produto);
                    Console.WriteLine("\n PRODUTO EXCLUIDO COM SUCESSO. ");

                }
                else
                {
                    Console.WriteLine("\n PRODUTO NÃO ENCONTRADO, VERIFIQUE O ID INFORMADO. ");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha:  {e.Message}");
            }

        }
        public void ConsultarProdutos()
        {
            try
            {
                Console.WriteLine("\n *********** CONSULTA DE PRODUTOS: **********\n");

              
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"ID DO PRODUTO.......................: {item.IdProduto}");
                    Console.WriteLine($"NOME DO PRODUTO.....................: {item.Nome}");
                    Console.WriteLine($"PREÇO DO PRODUTO....................: {item.Preco}");
                    Console.WriteLine($"QUANTIDADE DO PRODUTO...............: {item.Quantidade}");
                    Console.WriteLine($"DATA DE CADASTRO DO PRODUTO.........: {item.DataCadastro}");
                    Console.WriteLine("...");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha:  {e.Message}");
            }
        }

    }
}
