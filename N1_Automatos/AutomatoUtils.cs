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
    }
}
