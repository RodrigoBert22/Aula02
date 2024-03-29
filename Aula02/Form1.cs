﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula02
{

   
    public partial class Form1 : Form
    {

        private decimal Altura;
        private decimal Peso;
        private int[] Dias;
        private List<int> Anos;
        private Dictionary<int, string> Meses;

        public Form1()
        {
            InitializeComponent();

            Altura = (decimal)1.72;
            Peso = 0;

            //Dias = new int[30];

            Dias = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };

            Anos = new List<int>()
            {
                1996,
                1997,
                1998,
                1999,
                2000,
                2001,
                2002,
                2003,
                2004,
                2005,
                2006,
                2007,
                2008,
                2009,
                2010,
                2011,
                2012,
                2013,
                2014,
                2015,
                2016,
                2017,
                2018,
                2019
            };

            Meses = new Dictionary<int, string>()
            {

                {1, "Janeiro" },
                {2, "Fevereiro" },
                {3, "Março"},
                {4, "Abril"},
                {5, "Maio"},
                {6, "Junho"},
                {7, "Julho"},
                {8, "Agosto"},
                {9, "Setembro"},
                {10, "Outubro"},
                {11, "Novembro"},
                {12, "Dezembro"}

            };

            // Meses.Add(7, "Julho);

            int indice = 0;
            /*
            while(indice < Dias.Length)
            {
                cbxDias.Items.Add(Dias[indice]);
                indice++;
            }
            */
            for(int i = 0; i < Dias.Length; i++)
            {
                cbxDias.Items.Add(Dias[i]);
            }
            foreach (int ano in Anos)
            {
                cbxAnos.Items.Add(ano);
            }

            cbxMeses.DataSource = new BindingSource(Meses, null);
            cbxMeses.DisplayMember = "Value";
            cbxMeses.ValueMember = "Key";

        }

        private string VerificarImc(decimal peso, decimal altura, out decimal imc)
        {
            imc = peso / (altura * altura);
            if (imc < (decimal)18.5)
            {
                return "Abaixo do peso";
            }
            else if (imc >= (decimal)18.5 && imc < 25)
            {
                return "Peso normal";
            }
            else if (imc >= 25 && imc < 30)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc < 35)
            {
                return "Obesidade grau 1";
            }
            else if (imc >= 35 && imc < 39)
            {
                return "Obesidade grau 2";
            }
            else
            {
                return "Obesidade grau 3";
            }
        }


        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            //Altura = decimal.Parse(txtAltura.Text);
            if (!decimal.TryParse(txtAltura.Text.Replace(".",","), out Altura))
            {
                MessageBox.Show("Altura Inválida");
            }

            if (!decimal.TryParse(txtPeso.Text, out Peso))
            {
                MessageBox.Show("Peso Inválido");
            }

            var descricao = VerificarImc(Peso, Altura, out var imc);
            MessageBox.Show($"Nome: {nome}\nNascimento: {cbxDias.Text} de {cbxMeses.Text} de {cbxAnos.Text}\nIMC: {imc.ToString("N2")}\n\n{descricao}");


        }

       


    }
}
