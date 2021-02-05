using Girls.Gama2.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Geladeira : Produto//, ICalculoProduto
    {
        private const double DescontoGerente = 100.00;

        public Geladeira(string nome,
                           string marca,
                           double valor,
                           bool frossFree,
                           int litros,
                           bool duplex)
            : base (nome, marca, valor)
        {
            FrossFree = frossFree;
            Litros = litros;
            Duplex = duplex;
        }
        public bool FrossFree { get; set; }
        public int Litros { get; set; }
        public bool Duplex { get; set; }

        public override void CalcularPreco()
        {
            base.CalcularPreco();
            Valor = Valor - DescontoGerente;
        }

        //public void CalcularPreco()
        //{
        //    var valorDescontado = Valor * Desconto;
        //    Valor = (Valor - valorDescontado) - DescontoGerente;
        //}
    }
}
