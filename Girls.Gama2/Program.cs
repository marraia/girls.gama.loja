
using Girls.Gama2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("1-Compra | 2-Pagamento | 3-Relatório");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Comprar();
                        break;
                    case 2:
                        Pagamento();
                        break;
                    case 3:
                        Relatorio();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Comprar()
        {
            Console.WriteLine("Digite o valor da compra:");
            var valor = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o CPF do cliente:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Preeencha uma descrição caso necessário");
            var descricao = Console.ReadLine();

            var boleto = new Boleto(cpf, valor, descricao);
            boleto.GerarBoleto();

            Console.WriteLine($"Boleto gerado com sucesso com o número {boleto.CodigoBarra} com data de vencimento para o dia {boleto.DataVencimento} ");

            listaBoletos.Add(boleto);
        }

        public static void Pagamento()
        {
            Console.WriteLine("Digite o código de barras:");
            var numero = Guid.Parse(Console.ReadLine());

            var boleto = listaBoletos
                            .Where(item => item.CodigoBarra == numero)
                            .FirstOrDefault();

            if(boleto is null)
            {
                Console.WriteLine($"Boleto de código {numero} não encontrado!");
                return;
            }

            if(boleto.EstaPago())
            {
                Console.WriteLine($"Boleto já foi pago no dia {boleto.DataPagamento}");
                return;
            }

            if (boleto.EstaVencido())
            {
                boleto.CalcularJuros();
                Console.WriteLine($"Boleto está vencido, terá acrescimo de 10% === R$ {boleto.Valor}");
            }

            boleto.Pagar();
            Console.WriteLine($"Boleto de código {numero} foi pago com sucesso");
        }

        public static void Relatorio()
        {
            Console.WriteLine("Qual opção de relatório:");
            Console.WriteLine("1-Pagos | 2-À pagar | 3-Vencidos");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    BoletosPagos();
                    break;
                case 2:
                    BoletosAPagar();
                    break;
                case 3:
                    BoletosVencidos();
                    break;
                default:
                    break;
            }
        }

        public static void BoletosPagos()
        {
            Console.WriteLine("========== Boletos pagos ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos pagos ============ \n");
        }

        public static void BoletosAPagar()
        {
            Console.WriteLine("========== Boletos à pagar ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao == false
                                    && item.DataVencimento > DateTime.Now)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos à pagar ============ \n");
        }

        public static void BoletosVencidos()
        {
            Console.WriteLine("========== Boletos vencidos ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao == false
                                    && item.DataVencimento < DateTime.Now)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos vencidos ============ \n");
        }
    }
}

