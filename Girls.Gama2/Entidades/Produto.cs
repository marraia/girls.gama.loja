using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Produto
    {
        private const double Desconto = 0.15;

        public Produto(string nome,
                        string marca,
                        double valor)
        {
            Id = Guid.NewGuid();

            Nome = nome;
            Marca = marca;
            Valor = valor;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Valor { get; set; }

        public virtual void CalcularPreco()
        {
            var valorDescontado = Valor * Desconto;
            Valor = Valor - valorDescontado;
        }
    }
}
