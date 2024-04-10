using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {

        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();


            comboEC.Items.Add("Casado(a)");
            comboEC.Items.Add("Solteiro(a)");
            comboEC.Items.Add("Viuvo(a)");
            comboEC.Items.Add("Separado(a)");

            comboEC.SelectedIndex = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeículo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtnome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeículo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtnome.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == txtnome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }
            if (txtnome.Text =="")
            {
                MessageBox.Show("Preencha o campo nome!");
                txtnome.Focus();
                return;
            }

            if(txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo telefone!");
                txtTelefone.Focus();
                return ;
            }

            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtnome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeículo.Checked;
            p.Sexo = sexo;

            if(index < 0 )
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);
            Listar();


        }

        private void Listar()
        {
            Lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);
            }
        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtnome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeículo.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
