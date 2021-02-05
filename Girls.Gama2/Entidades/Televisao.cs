using Girls.Gama2.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Televisao : Produto//, ICalculoProduto
    {
        //private const double Desconto = 0.15;

        public Televisao(string nome,
                           string marca,
                           double valor,
                           int polegadas,
                           string tipoTela,
                           bool smartTv,
                           int qtdEntradasHdmi)
            :base(nome, marca, valor)
        {
            Polegadas = polegadas;
            TipoTela = tipoTela;
            SmartTv = smartTv;
            QtdEntradasHDMI = qtdEntradasHdmi;
        }
        public int Polegadas { get; set; }
        public string TipoTela { get; set; }
        public bool SmartTv { get; set; }
        public int QtdEntradasHDMI { get; set; }

        //public void CalcularPreco()
        //{
        //    var valorDescontado = Valor * Desconto;
        //    Valor = Valor - valorDescontado;
        //}
    }
}
