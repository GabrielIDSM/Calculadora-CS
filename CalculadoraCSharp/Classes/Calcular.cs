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
            Console.WriteLine("Operando1: " + operando1);
            Console.WriteLine("Operando2: " + operando2);
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
                    case 4: //Potenciação
                        return Math.Pow(op1, op2);
                    case 5: //Radiciação
                        return Math.Pow(op2, 1 / op1);
                    case 6:
                        double resultado = op1;
                        for(double i = 1.0; i < op1; i++)
                        {
                            resultado *= i;
                        }
                        return resultado;
                    case 7: //Logaritmo natural
                        return Math.Log(op1);
                    case 8: //Logaritmo
                        return Math.Log10(op1);
                    default:
                        Console.WriteLine("Erro: Operador inválido");
                        return 0.0;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erro (Linha 51): " + e.Message);
                return 0.0;
            }
        }
        private Boolean VerificaOperador(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == 'R' || c == '!' || c == 'L' || c == 'l');
        }
        private void CalculaFat()
        {
            char[] array = getExpressao().ToCharArray();
            int i = 0;
            while (i < array.Length)
            {
                if (array[i] == '!')
                {
                    //Definir operandos
                    String operando = DefineOperandoAntSinal(i);
                    //Definir resultado
                    double resultado = EfetuaCalculo(operando, "0.0", 6);
                    //Substituir expressão original
                    SubstituiExpressao(i, resultado);
                    //Atualiza o Array
                    array = getExpressao().ToCharArray();
                    //reiniciar a variável i
                    i = 0;
                }
                i++;
            }
        }
        private void CalculaPorOperador(char operador1, char operador2)
        {
            char[] array = getExpressao().ToCharArray();
            int i = 0;
            if (array[0] == '+' && array[0] == operador1
                || array[0] == '+' && array[0] == operador2
                || array[0] == '-' && array[0] == operador1
                || array[0] == '-' && array[0] == operador2) i++;
            while (i < array.Length)
            {
                if (array[i] == operador1 || array[i] == operador2)
                {
                    //Definir operandos
                    String[] operandos = null;
                    String operando = null;
                    if (operador1 == 'l' || operador1 == 'L' && operador2 == 'l' || operador2 == 'L')
                    {
                        operando = DefineOperandoDepSinal(i);
                    }
                    else
                    {
                        operandos = DefineOperandos(i);
                    }    
                    //Definir resultado
                    int operadorInt = -1;
                    double resultado = 0.0;
                    if (array[i] == operador1)
                    {
                        if (operador1 == '+') operadorInt = 0;
                        if (operador1 == '-') operadorInt = 1;
                        if (operador1 == '*') operadorInt = 2;
                        if (operador1 == '/') operadorInt = 3;
                        if (operador1 == '^') operadorInt = 4;
                        if (operador1 == 'R') operadorInt = 5;
                        if (operador1 == 'l') operadorInt = 7;
                        if (operador1 == 'L') operadorInt = 8;
                    }
                    else
                    {
                        if (operador2 == '+') operadorInt = 0;
                        if (operador2 == '-') operadorInt = 1;
                        if (operador2 == '*') operadorInt = 2;
                        if (operador2 == '/') operadorInt = 3;
                        if (operador2 == '^') operadorInt = 4;
                        if (operador2 == 'R') operadorInt = 5;
                        if (operador2 == 'l') operadorInt = 7;
                        if (operador2 == 'L') operadorInt = 8;
                    }
                    if(operador1 == 'l' || operador1 == 'L' && operador2 == 'l' || operador2 == 'L')
                    {
                        resultado = EfetuaCalculo(operando, "0.0", operadorInt);
                    }
                    else
                    {
                        resultado = EfetuaCalculo(operandos[0], operandos[1], operadorInt);
                    }
                    //Substituir expressão original
                    SubstituiExpressao(i, resultado);
                    //Atualiza o Array
                    array = getExpressao().ToCharArray();
                    //reiniciar a variável i
                    i = 0;
                }
                i++;
            }
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
                    int operadorInt = -1;
                    if (operador == '+') operadorInt = 0;
                    if (operador == '-') operadorInt = 1;
                    if (operador == '*') operadorInt = 2;
                    if (operador == '/') operadorInt = 3;
                    if (operador == '^') operadorInt = 4;
                    if (operador == 'R') operadorInt = 5;
                    double resultado = EfetuaCalculo(operandos[0], operandos[1], operadorInt);
                    //Substituir expressão original
                    SubstituiExpressao(i, resultado);
                    //Atualiza o Array
                    array = getExpressao().ToCharArray();
                    //reiniciar a variável i
                    i = 0;
                }
                i++;
            }
        }
        private String DefineOperandoDepSinal(int index)
        {
            char[] array = getExpressao().ToCharArray();
            String operando = "";
            for (int i = index + 1; i < array.Length; i++)
            {
                if (VerificaOperador(array[i]) && !(i == index + 1 && (array[index + 1] == '+' || array[index + 1] == '-')))
                {
                    break;
                }
                operando += array[i];
            }
            return operando;
        }
        private String DefineOperandoAntSinal(int index)
        {
            char[] array = getExpressao().ToCharArray();
            String operando = "";
            for (int i = index - 1; i >= 0; i--)
            {
                if (VerificaOperador(array[i]) && !(i == 0 && array[0] == '-'))
                {
                    break;
                }
                operando += array[i];
            }
            return new string(operando.Reverse().ToArray());
        }
        private String[] DefineOperandos(int index)
        {
            char[] array = getExpressao().ToCharArray();
            //Define operando1
            String operando1 = "";
            for(int i = index - 1; i >= 0; i--)
            {
                if (VerificaOperador(array[i]) && !(i == 0 && array[0] == '-'))
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
                if (VerificaOperador(array[i]) && !(i == index + 1 && (array[index + 1] == '+' || array[index + 1] == '-' )))
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
                String aux = "";
                for (int i = 0; i < array.Length; i++) aux += array[i];
                Console.WriteLine("String atual: " + aux);
                aux = "";
                for (int i = index - 1; i >= 0; i--)
                {
                    if (VerificaOperador(array[i]) && !(i == 0 && array[0] == '-'))
                    {
                        break;
                    }
                    array[i] = 'X';
                }
                for (int i = index + 1; i < array.Length; i++)
                {
                    if (VerificaOperador(array[i]) && !(i == index + 1 && (array[index + 1] == '+' || array[index + 1] == '-')))
                    {
                        break;
                    }
                    array[i] = 'X';
                }
                array[index] = 'X';
                for (int i = 0; i < array.Length; i++) aux += array[i];
                Console.WriteLine("String atual: " + aux);
                aux = "";
                //Define o primeiro caractere a ser substituido
                for (int i = 0; i < array.Length; i++)
                {
                    if(array[i] == 'X')
                    {
                        array[i] = 'S';
                        break;
                    }
                }
                for (int i = 0; i < array.Length; i++) aux += array[i];
                Console.WriteLine("String atual: " + aux);
                aux = "";
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
                array = auxExpressao.ToCharArray();
                for (int i = 0; i < array.Length; i++) aux += array[i];
                Console.WriteLine("String atual: " + aux);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Erro (Linha 160): " + e.Message );
                return false;
            }
        }

        private void SubstituiDuploSinal()
        {
            String expressao = "";
            char[] array = getExpressao().ToCharArray();
            int i = 0;
            while(i < array.Length - 1)
            {
                if(array[i] == '+' && array[i+1] == '+')
                {
                    expressao += array[i];
                    i += 2;
                } 
                else if (array[i] == '+' && array[i + 1] == '-')
                {
                    expressao += array[i];
                    i += 2;
                }
                else if (array[i] == '-' && array[i + 1] == '+')
                {
                    expressao += array[i];
                    i += 2;
                }
                else
                {
                    expressao += array[i];
                    i++;
                }
            }
            expressao += array[array.Length - 1];
            setExpressao(expressao);
        }

        public double CalculaExpressao()
        {
            try
            {
                SubstituiDuploSinal();
                CalculaFat();
                SubstituiDuploSinal();
                CalculaPorOperador('L', 'l');
                SubstituiDuploSinal();
                CalculaPorOperador('^', 'R');
                SubstituiDuploSinal();
                CalculaPorOperador('*', '/');
                SubstituiDuploSinal();
                CalculaPorOperador('+', '-');
                SubstituiDuploSinal();
                return Convert.ToDouble(getExpressao());
            }catch(Exception e)
            {
                return Double.NaN;
            } 
        }
    }
}
