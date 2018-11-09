using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public static string[] geraTxtConvertido(List<List<Estado>> estadosAfd, Automato a)
        {
            List<string> retorno = new List<string>();
            //1ª linha (tipo)
            retorno.Add("AFD");
            //2ª linha (estados)
            string linha = "";
            foreach (var estadoList in estadosAfd)
            {
                if (estadoList.Count == 0)
                    continue;
                if (!string.IsNullOrEmpty(linha))
                    linha += ",";
                foreach (var estado in estadoList)
                {
                    linha += estado.Nome;
                }
            }
            retorno.Add(linha);
            //3ª linha (alfabeto)
            linha = "";
            foreach (var letra in a.Alfabeto)
            {
                if (!string.IsNullOrEmpty(linha))
                    linha += ",";
                linha += letra;
            }
            retorno.Add(linha);
            //4ª linha (estado inicial)
            linha = a.ListEstados.Find(x => x.Inicial).Nome;
            retorno.Add(linha);
            //5ª linha (estados finais)
            linha = "";
            foreach (var estadoList in estadosAfd)
            {
                if (estadoList.Find(x => x.Final)!= null)
                {
                    if (!string.IsNullOrEmpty(linha))
                        linha += ",";
                    foreach (var estado in estadoList)
                    {
                        linha += estado.Nome;
                    }
                }
            }
            retorno.Add(linha);
            //6ª linha (funções de transição (FODEU))
            foreach (var estadoList in estadosAfd)
            {
                if (estadoList.Count == 0)
                    continue;
                foreach (var letra in a.Alfabeto)
                {
                    linha = "(";
                    string primeiroNome = "";
                    string segundoNome = "";
                    bool le = false;
                    foreach (var estado in estadoList)
                    {
                        if (estado.Map.ContainsKey(letra))
                        {
                            le = true;
                            break;
                        }
                    }
                    if (le)
                    {
                        foreach (var estado in estadoList)
                        {
                            primeiroNome += estado.Nome;
                            foreach (var kvp in estado.Map)
                            {
                                if (kvp.Key.Equals(letra))
                                {
                                    foreach (var muitosEstados in kvp.Value)
                                    {
                                        if (!segundoNome.Contains(muitosEstados.Nome))
                                            segundoNome += muitosEstados.Nome;
                                    }
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(primeiroNome))
                    {
                        linha += primeiroNome + "," + letra + "," + segundoNome;
                        linha += ")";
                        retorno.Add(linha);    
                    }
                }
            }
            //linha ACABOOOOOOU É TETRA
            linha = "####";
            retorno.Add(linha);
            return retorno.ToArray();
        }
    }
}
