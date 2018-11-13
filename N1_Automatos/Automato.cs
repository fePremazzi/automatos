using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    public class Automato
    {
        public Automato()
        {
            ListEstados = new List<Estado>();
            Alfabeto = new List<string>();
            contador = 0;
        }

        private int contador;

        public EnumTipo Tipo { get; set; }

        public List<Estado> ListEstados { get; set; }

        public List<string> Alfabeto { get; set; }

        public void MergirComFechoE()
        {
            for (int i = 0; i < ListEstados.Count; i++)
            {
                Estado estado = ListEstados[i];
                if (!estado.Map.ContainsKey("@"))
                    continue;
                
                List<Estado> estados2 = estado.Map["@"];
                int count = estados2.Count;
                for (int j = 0; j < count; j++)
                {
                    foreach (var item in estados2[j].Map)
                    {
                        if (item.Key.Equals("@"))
                            continue;
                        if (!estado.Map.ContainsKey(item.Key))
                            estado.Map[item.Key] = new List<Estado>();

                        estado.Map[item.Key].AddRange(item.Value);
                    }
                }
            }

            for (int i = 0; i < ListEstados.Count; i++)
            {
                Estado estado = ListEstados[i];

                foreach (var item in estado.Map)
                {
                    string letra = item.Key;
                    List<Estado> estadosProxs = item.Value;
                    List<Estado> estadosToAdd = new List<Estado>();
                    foreach (var est in estadosProxs)
                    {
                        if (est == null)
                            continue;
                        if (est.Map.ContainsKey("@"))
                        {
                            estadosToAdd.AddRange(est.Map["@"]);
                        }
                    }
                    if (estadosToAdd.Count > 0)
                        estado.Map[letra].AddRange(estadosToAdd);
                }
            }
           
        }

        public bool LePalavra(string palavra, List<Estado> estados)
        {
            if (palavra.Equals(""))
            {
                estadosConversao(estados);
                return estados.Find(x => x.Final) != null;
            }
            List<Estado> estadosProxs = new List<Estado>();
            char letra = palavra[0];
            string palavraNova = palavra.Remove(0, 1);
            foreach (var item in estados)
            {
                if (item == null)
                    continue;
                if (item.Map.ContainsKey(letra.ToString()))
                    estadosProxs.AddRange(item.Map[letra.ToString()]);
            }
            if (estadosProxs.Count == 0 || palavraNova.Length == 0)
                return estadosProxs.Find(x => x.Final) != null;
            return LePalavra(palavraNova, estadosProxs);
        }

        public List<Estado> estadosConversao(List<Estado> estados)
        {
            int count = estados.Count;
            List<Estado> estadosToAdd = new List<Estado>();
            foreach (var estado in estados)
            {
                if (estado.Map.ContainsKey("@"))
                    estadosToAdd.AddRange(estado.Map["@"]);
            }
            foreach (var estado in estadosToAdd)
            {
                if (!estados.Contains(estado))
                    estados.Add(estado);
            }
            if (count != estados.Count)
                estadosConversao(estados);
            return estados;
            
        }

        public List<List<Estado>> ConvertToAfd()
        {
            List<List<Estado>> estadosNovos = new List<List<Estado>>();
            List<Estado> estadosParaIniciar = new List<Estado>();
            Estado estadoInicial = ListEstados.Find(x => x.Inicial);
            estadosParaIniciar.Add(estadoInicial);
            if (estadoInicial.Map.ContainsKey("@"))
                estadosConversao(estadosParaIniciar);
            estadosNovos.Add(estadosParaIniciar);
            
            while (contador + 1 <= estadosNovos.Count)
            {
                List<Estado> estadoAfd = estadosNovos[contador];
                contador++;
                foreach (var letra in Alfabeto)
                {
                    List<Estado> estadoUsandoLetra = new List<Estado>();
                    foreach (var estado in estadoAfd)
                    {
                        if (estado.Map.ContainsKey(letra))
                        {
                            foreach (var b in estado.Map[letra])
                            {
                                if (!estadoUsandoLetra.Contains(b))
                                    estadoUsandoLetra.Add(b);
                            }
                        }
                    }
                    estadosConversao(estadoUsandoLetra);
                    bool allOfList1IsInList2 = false;
                    foreach (var a in estadosNovos)
                    {
                        if (a.Count != estadoUsandoLetra.Count)
                            continue;
                        allOfList1IsInList2 = estadoUsandoLetra.Intersect(a).Count() == estadoUsandoLetra.Count();
                        if (allOfList1IsInList2)
                            break;
                    }
                    if (!allOfList1IsInList2)
                        estadosNovos.Add(estadoUsandoLetra);
                }
            }
            return estadosNovos;
        }

    }
}