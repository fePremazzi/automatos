using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    public static class AutomatoUtils
    {
        static string[] aEstados = null;

        public static string RemoveParenteses(string texto)
        {
            return texto.Substring(1, texto.Length - 2);
        }

        public static void TamanhoMinimo(string[] linhas)
        {
            if (linhas.Length < 7)
            {
                throw new Exception("Automato nao possui o minimo de parâmetros.");
            }
        }

        public static void UltimaLinha(string[] linhas)
        {
            if (!linhas[linhas.Length - 1].Contains("#"))
            {
                throw new Exception("Função de transição sem critério de parada. Adicione \"####\"" +
                                    " no final do arquivo de seu automato");
            }
        }

        public static void VerificaQuintupla(string[] linhas)
        {
            int count = 0;
            //Vai até length -1 pra nao pegar o ####
            for (int i = 0; i < linhas.Length - 1; i++)
            {
                if (!linhas[i].Contains("("))                
                    count++;                
            }

            if (count != 5)
                throw new Exception("Quintupla nao contém os 5 parametros");
        }

        public static void VerificaTipo(string tipo)
        {
            if (tipo.Trim() != EnumTipo.AFN.ToString() && 
                tipo.Trim() != EnumTipo.AFNe.ToString())
            {
                throw new Exception("Tipo de automato incorreto. Deve ser AFN ou AFNe.");
            }
        }

        public static void VerificaEstados(string conteudo)
        {
            aEstados = conteudo.Trim().Split(',');
            VerificaRepetido(aEstados, "Estado repetido, insira apenas estados distintos um do outro.");
        }

        public static void VerificaAlfabeto(string conteudo)
        {
            string[] alfabeto = conteudo.Trim().Split(',');
            VerificaRepetido(alfabeto, "Simbolos do alfabeto repetidos, insira apenas simbolos distintos um do outro.");
        }

        public static void VerificaEstadoInicial(string inicial)
        {
            string[] aInicial = inicial.Trim().Split(',');
            if (aInicial.Length > 1)            
                throw new Exception("Só deve existir apenas 1 estado inicial");
            
            Boolean existe = false;
            for (int i = 0; i < aEstados.Length; i++)
            {
                if (aInicial[0] == aEstados[i])                
                    existe = true;                
            }
            if (existe == false)            
                throw new Exception("Estado inicial não existe. Não está dentre os o conjunto de estados existentes.");
            
        }


        private static void VerificaTransicao(string funcT)
        {
            if (funcT[0] != '(' && funcT[funcT.Length - 1] != ')')
            {
                throw new Exception("Função de transição mal escrita, deve inicar e terminar " +
                                    "com parentesis");
            }

            //Verifricar se a funcao de transição esta no formato correto

        }

        private static void VerificaRepetido(string[] array, string errorMessage)
        {
            string comparador = "";
            for (int i = 0; i < array.Length; i++)
            {
                comparador = array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j)
                    {
                        if (comparador == array[j])
                            throw new Exception(errorMessage);
                    }
                }
            }
        }
    }
}
