using Girls.Gama2.Entidades.Interfaces;
using System;

namespace Girls.Gama2.Entidades
{
    public class Dinheiro : Pagamento, IPagar
    {
        private const double Desconto = 0.05;
        public Dinheiro(double valor)
        {
            Valor = valor;
        }

        public void Pagar()
        {
            var valorDesconto = Valor * Desconto;
            Valor = Valor - valorDesconto;

            DataPagamento = DateTime.Now;
            Confirmacao = true;
        }

        //public override void Pagar()
        //{
        //    var valorDesconto = Valor * Desconto;
        //    Valor = Valor - valorDesconto;

        //    base.Pagar();
        //}

    }
}
