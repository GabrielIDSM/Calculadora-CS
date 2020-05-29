using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCSharp.Classes
{
    class Expressoes
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
        //Construtor
        public Expressoes(String expressao)
        {
            setExpressao(expressao);
        }
        //Métodos
        private Boolean TemParentesis()
        {
            char[] array = getExpressao().ToCharArray();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == '(' || array[i] == ')') return true;
            }
            return false;
        }
        public double CalculaExpressao()
        {
            if (TemParentesis())
            {
                int i = 0, j = 0, l = 0, m = 0;
                String aux = "";
                char par;
                char[] array = getExpressao().ToCharArray();
                while(i < array.Length)
                {
                    if (array[i] == '(')
                    {
                        par = array[i];
                        for(j = i + 1; j < array.Length; j++)
                        {
                            if (array[j] == '(')
                            {
                                aux = "";
                                break;
                            }
                            else if (array[j] == ')')
                            {
                                array[i] = 'S';
                                array[j] = 'S';
                                Calcular auxC = new Calcular(aux);
                                double auxResult = auxC.CalculaExpressao();
                                aux = "";
                                while (l < array.Length)
                                {
                                    if(array[l] == 'S')
                                    {
                                        aux += Convert.ToString(auxResult);
                                        for(m = l + 1; m < array.Length; m++)
                                        {
                                            if (array[m] == 'S')
                                            {
                                                l = m;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        aux += array[l];
                                    }
                                    l++;
                                }
                                i = 0;
                                l = 0;
                                setExpressao(aux);
                                array = getExpressao().ToCharArray();
                                Console.WriteLine("String: " + aux);
                                aux = "";
                                break;
                            }
                            aux += array[j];
                        }
                    }
                    i++;
                }
                Calcular C = new Calcular(getExpressao());
                return C.CalculaExpressao();
            }
            else
            {
                Calcular C = new Calcular(getExpressao());
                return C.CalculaExpressao();
            }
        }
    }
}
