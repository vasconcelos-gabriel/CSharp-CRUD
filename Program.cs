using ProjetoAula05.Controllers;

namespace ProjetoAula05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var produtoController = new ProdutoController();

           
            Console.WriteLine("DIGITE A OPÇÃO DESEJADA:");
            Console.WriteLine($" (1) PARA CADASTRAR UM PRODUTO \n (2) PARA ATUALIZAR UM PRODUTO \n (3) PARA EXCLUIR UM PRODUTO \n (4) CONSULTAR UM PRODUTO");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    produtoController.CadastrarProduto();
                    break;
                case 2:
                    produtoController.AtualizarProduto();
                    break;
                case 3:
                    produtoController.ExcluirProduto();
                    break;
                case 4:
                    produtoController.ConsultarProdutos();
                    break;
                default:
                    break;

            }
            Console.WriteLine("\n Deseja continuar? (S,N)..:");    
            var escolha = Console.ReadLine();       

            if (escolha == "S")
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("FIM DO PROGRAMA");
            }




            Console.ReadKey();

        }
    }
}