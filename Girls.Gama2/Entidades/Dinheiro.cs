using System;

namespace Girls.Gama2.Entidades
{
    public class Dinheiro
    {
        public Dinheiro(double valor)
        {
            Id = Guid.NewGuid();
            Valor = valor;
        }

        public Guid Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }

        public void Pagar()
        {
            DataPagamento = DateTime.Now;
        }
    }
}
