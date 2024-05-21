using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaDeBebidas
{
    public partial class FormMaquinaDeBebidas : Form
    {


        // Dicionário para mapear o valor de cada bebida
        Dictionary<string, double> precos = new Dictionary<string, double>()
        {
            { "Café", 0.25 },
            { "Cappuccino", 0.30 },
            { "Chocolate", 0.35 },
            { "Chá", 0.20 }
        };

        // Dicionário para mapear o valor de cada moeda
        Dictionary<double, int> moedas = new Dictionary<double, int>()
        {
            { 0.05, 10 },
            { 0.10, 10 },
            { 0.20, 10 },
            { 0.50, 10 },
            { 1.00, 10 },
            { 2.00, 10 }
        };

        // Variável para armazenar o valor total inserido
        double totalInserido = 0;

        public FormMaquinaDeBebidas()
        {
            InitializeComponent();
        }

        // Método para atualizar o display do total inserido
        private void AtualizarDisplay()
        {
            lblTotalInserido.Text = totalInserido.ToString("C");
        }

        // Método para processar a inserção de moedas
        private void InserirMoeda(double valorMoeda)
        {
            totalInserido += valorMoeda;
            AtualizarDisplay();
        }

        // Método para processar a compra de uma bebida
        private void ComprarBebida(string bebida, double preco)
        {
            if (totalInserido >= preco)
            {
                // Calcula o troco
                double troco = totalInserido - preco;
                totalInserido = 0;

                // Mostra o troco
                MessageBox.Show($"Aqui está sua bebida: {bebida}. Troco: {troco.ToString("C")}");

                // Calcula e exibe as moedas do troco
                var moedasOrdenadas = moedas.Keys.OrderByDescending(v => v);
                foreach (var valorMoeda in moedasOrdenadas)
                {
                    int quantidade = (int)(troco / valorMoeda);
                    troco -= quantidade * valorMoeda;
                    if (quantidade > 0)
                    {
                        MessageBox.Show($"Troco: {quantidade} moeda(s) de {valorMoeda.ToString("C")}");
                    }
                }

                AtualizarDisplay();
            }
            else
            {
                MessageBox.Show("Dinheiro insuficiente.");
            }
            
        }

        // Eventos dos botões de moedas
        private void btnMoeda05_Click(object sender, EventArgs e)
        {
            InserirMoeda(0.05);
        }

        private void btnMoeda10_Click(object sender, EventArgs e)
        {
            InserirMoeda(0.10);
        }

        private void btnMoeda20_Click(object sender, EventArgs e)
        {
            InserirMoeda(0.20);
        }

        private void btnMoeda50_Click(object sender, EventArgs e)
        {
            InserirMoeda(0.50);
        }

        private void btnMoeda1_Click(object sender, EventArgs e)
        {
            InserirMoeda(1.00);
        }

        private void btnMoeda2_Click(object sender, EventArgs e)
        {
            InserirMoeda(2.00);
        }

        // Eventos dos botões de bebidas
        private void btnCafe_Click(object sender, EventArgs e)
        {
            ComprarBebida("Café", precos["Café"]);
        }

        private void btnCappuccino_Click(object sender, EventArgs e)
        {
            ComprarBebida("Cappuccino", precos["Cappuccino"]);
        }

        private void btnChocolate_Click(object sender, EventArgs e)
        {
            ComprarBebida("Chocolate", precos["Chocolate"]);
        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            ComprarBebida("Chá", precos["Chá"]);
        }

        
        }
}

