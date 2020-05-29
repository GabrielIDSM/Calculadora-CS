using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCSharp.Classes
{
    public class Calcular
    {
        //Atributos
        private String expressao;
        //Getters e Setters
        private String getExpressao()
        {
            return this.expressao;
        }
        private void setExpressao(String expressao)
        {
            this.expressao = expressao;

        }
        //Método construtor
        public Calcular(String expressao)
        {
            setExpressao(expressao);
        }
        //Métodos
        private double EfetuaCalculo(String operando1, String operando2, int operador)
        {
            try
            {
                double op1 = Convert.ToDouble(operando1);
                double op2 = Convert.ToDouble(operando2);
                switch (operador)
                {
                    case 0: //Soma
                        return op1 + op2;
                    case 1: //Subtração
                        return op1 - op2;
                    case 2: //Multiplicação
                        return op1 * op2;
                    case 3: //Divisão
                        return op1 / op2;
                    default:
                        Console.WriteLine("Erro: Operador inválido");
                        return 0.0;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return 0.0;
            }
        }
        private Boolean VerificaOperador(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/');
        }
        private void CalculaPorOperador(char operador)
        {
            char[] array = getExpressao().ToCharArray();
            int i = 0;
            while(i < array.Length)
            {
                if(array[i] == operador)
                {
                    //Definir operandos
                    String[] operandos = DefineOperandos(i);
                    //Definir resultado
                    double resultado = EfetuaCalculo(operandos[1], operandos[2], Convert.ToInt32(operador));
                    //Substituir expressão original
                    SubstituiExpressao(i, resultado);
                    //reiniciar a variável i
                    i = 0;
                }
                i++;
            }
        }
        private String[] DefineOperandos(int index)
        {
            char[] array = getExpressao().ToCharArray();
            //Define operando1
            String operando1 = "";
            for(int i = index - 1; i >= 0; i--)
            {
                if (VerificaOperador(array[i]))
                {
                    break;
                }
                operando1 += array[i];
            }
            operando1 = new string(operando1.Reverse().ToArray());
            //Define operando2
            String operando2 = "";
            for (int i = index + 1; i < array.Length; i++)
            {
                if (VerificaOperador(array[i]))
                {
                    break;
                }
                operando2 += array[i];
            }
            //Define return
            return new string[] { operando1, operando2 };
        }
        private Boolean SubstituiExpressao(int index, double valor)
        {
            try
            {
                String auxExpressao = getExpressao();
                //Substituir caracteres na expressão
                char[] array = auxExpressao.ToCharArray();
                for (int i = index - 1; i >= 0; i--)
                {
                    if (VerificaOperador(array[i]))
                    {
                        break;
                    }
                    array[i] = 'X';
                }
                for (int i = index + 1; i < array.Length; i++)
                {
                    if (VerificaOperador(array[i]))
                    {
                        break;
                    }
                    array[i] = 'X';
                }
                array[index] = 'X';
                //Define o primeiro caractere a ser substituido
                for(int i = 0; i < array.Length; i++)
                {
                    if(array[i] == 'X')
                    {
                        array[i] = 'S';
                        break;
                    }
                }
                //Substitui todos os outros caracteres e adiciona o valor
                auxExpressao = "";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'X')
                    {
                        continue;
                    } else if(array[i] == 'S')
                    {
                        auxExpressao += Convert.ToString(valor);
                    }
                    else
                    {
                        auxExpressao += array[i];
                    }                    
                }
                //Substitui a Expressão original
                setExpressao(auxExpressao);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
        }
        public double CalculaExpressao()
        {
            CalculaPorOperador('*');
            CalculaPorOperador('/');
            CalculaPorOperador('-');
            CalculaPorOperador('+');
            return Convert.ToDouble(getExpressao());
        }
    }
}
