using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    public static class AutomatoUtils
    {
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

        private static void VerificaTransicao(string funcT)
        {
            if (funcT[0] != '(' && funcT[funcT.Length-1] != ')')
            {
                throw new Exception("Função de transição mal escrita, deve inicar e terminar " +
                                    "com parentesis");
            }

            //Verifricar se a funcao de transição esta no formato correto

        }

        public static void VerificaTipo(string tipo)
        {
            if (tipo != EnumTipo.AFN.ToString() || 
                tipo != EnumTipo.AFNe.ToString())
            {
                throw new Exception("Tipo de automato incorreto. Deve ser AFN ou AFNe.");
            }
        }
    }
}
