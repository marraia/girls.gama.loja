using Girls.Gama2.Entidades.Interfaces;
using System;

namespace Girls.Gama2.Entidades
{
    public class Dinheiro : Pagamento
    {
        private const double Desconto = 0.05;
        public Dinheiro(double valor)
        {
            Valor = valor;
        }

        public override void Pagar()
        {
            var valorDesconto = Valor * Desconto;
            Valor = Valor - valorDesconto;

            base.Pagar();
        }
    }
}
