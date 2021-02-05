﻿using Girls.Gama2.Entidades.Interfaces;
using System;

namespace Girls.Gama2.Entidades
{
    public class Boleto : Pagamento
    {
        private const int DiasVencimento = 15;
        private const double Juros = 0.10;

        public Boleto(string cpf,
                        double valor,
                        string descricao)
            : base(cpf, valor)
        {
            Descricao = descricao;
            DataEmissao = DateTime.Now;
        }

        public Guid CodigoBarra { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }

        public void GerarBoleto()
        {
            CodigoBarra = Guid.NewGuid();
            DataVencimento = DataEmissao.AddDays(DiasVencimento);
        }

        public bool EstaPago()
        {
            return Confirmacao;
        }

        public bool EstaVencido()
        {
            return DataVencimento < DateTime.Now;
        }

        public void CalcularJuros()
        {
            var taxa = Valor * Juros;
            var caculoValor = Valor + taxa;
            ConfirmarValor(caculoValor);
        }

        //public void Pagar()
        //{
        //    DataPagamento = DateTime.Now;
        //    Confirmacao = true;
        //}
    }
}
