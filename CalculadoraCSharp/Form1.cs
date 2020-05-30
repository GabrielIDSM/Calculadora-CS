using CalculadoraCSharp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraCSharp
{
    public partial class MainFrame : Form
    {
        //Atributos
        String expressao = "";
        //Getters e Setters
        public String getExpressao()
        {
            return this.expressao;
        }
        public void setExpressao(String expressao)
        {
            this.expressao = expressao;
        }
        //Método construtor
        public MainFrame()
        {
            InitializeComponent();
        }
        //Métodos
        private void AtualizaLabelExpressao()
        {
            txtbxExpressao.Text = getExpressao();
        }
        private void AdicionaAExpressao(char c)
        {
            String auxExpressao = getExpressao();
            auxExpressao += c;
            setExpressao(auxExpressao);
            AtualizaLabelExpressao();
        }
        private void AdicionaAExpressao(String s)
        {
            String auxExpressao = getExpressao();
            auxExpressao += s;
            setExpressao(auxExpressao);
            AtualizaLabelExpressao();
        }
        //Métodos Automáticos
        private void button1_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('9');
        }

        private void button0_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('0');
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('.');
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('+');
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            char[] array = getExpressao().ToCharArray();
            if (getExpressao().Length > 1) if (array[getExpressao().Length - 1] == '-')
                {
                    AdicionaAExpressao("(-");
                }
                else AdicionaAExpressao('-');
            else AdicionaAExpressao('-');
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('*');
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('/');
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('^');
        }

        private void buttonRad_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao("R(");
        }

        private void buttonFat_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('!');
        }

        private void buttonOpPar_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao('(');
        }

        private void buttonClPar_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao(')');
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao("l(");
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            AdicionaAExpressao("L(");
        }
        private void buttonResultado_Click(object sender, EventArgs e)
        {
            Expressoes E = new Expressoes(getExpressao());
            double resultado = E.CalculaExpressao();
            if (!Double.IsNaN(resultado)) txtbxResultado.Text = Convert.ToString(resultado);
            else txtbxResultado.Text = "Erro";
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            setExpressao("");
            AtualizaLabelExpressao();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if((getExpressao().Length - 1) > 0)
            {
                setExpressao(getExpressao().Substring(0, getExpressao().Length - 1));
            }
            else
            {
                setExpressao("");
            }
            AtualizaLabelExpressao();
        }

        private void buttonCResult_Click(object sender, EventArgs e)
        {
            txtbxResultado.Text = "";
        }
    }
}
