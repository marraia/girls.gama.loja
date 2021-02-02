
using Girls.Gama2.Entidades;
using System;
using System.Collections.Generic;

namespace Girls.Gama2
{
    class Program
    {
        private static List<Boleto> listaBoletos;
        static void Main(string[] args)
        {
            listaBoletos = new List<Boleto>();

            while (true)
            {
                Console.WriteLine("================== Loja das meninas da Gama Academy ============================");
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1-Compra | 2- Pagamento");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Comprar();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Comprar()
        {
            Console.WriteLine("Digite o valor da compra:");
            var valor = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite o CPF do cliente:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Preeencha uma descrição caso necessário");
            var descricao = Console.ReadLine();

            var boleto = new Boleto(cpf, valor, descricao);
            boleto.GerarBoleto();

            Console.WriteLine($"Boleto gerado com sucesso com o número {boleto.CodigoBarra} com data de vencimento para o dia {boleto.DataVencimento} ");

            listaBoletos.Add(boleto);
        }
    }
}

