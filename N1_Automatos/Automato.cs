using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    class Automato
    {
        private EnumTipo tipo;
        private List<Estado> listEstados;
        private List<string> alfabeto;

        public Automato()
        {
            listEstados = new List<Estado>();
            alfabeto = new List<string>();
        }

        public EnumTipo Tipo { get => tipo; set => tipo = value; }
        public List<Estado> ListEstados { get => listEstados; set => listEstados = value; }
        public List<string> Alfabeto { get => alfabeto; set => alfabeto = value; }

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
                        if (est.Map.ContainsKey("@"))
                        {
                            estadosToAdd.AddRange(est.Map["@"]);
                        }
                    }
                    if (estadosToAdd.Count > 0)
                        estado.Map[letra].AddRange(estadosToAdd);
                }

            }

            foreach (var item in ListEstados)
            {
                if (item.Map.ContainsKey("@"))
                    item.Map.Remove("@");
            }
        }

        public bool LePalavra(string palavra, List<Estado> estados)
        {
            List<Estado> estadosProxs = new List<Estado>();
            char letra = palavra[0];
            string palavraNova = palavra.Remove(0, 1);
            foreach (var item in estados)
            {
                if (item.Map.ContainsKey(letra.ToString()))
                    estadosProxs.AddRange(item.Map[letra.ToString()]);
            }
            if (estadosProxs.Count == 0 || palavraNova.Length == 0)
                return estadosProxs.Find(x => x.Final) != null;
            return LePalavra(palavraNova, estadosProxs);
            
        }

        public Automato ConvertToAFD()
        {
            Estado estadoInicial = ListEstados.Find(x => x.Inicial);
            Automato AFD = new Automato();
            AFD.Alfabeto.AddRange(Alfabeto);
            AFD.ListEstados.Add(estadoInicial);

            IncluirEstados(AFD, AFD.ListEstados);
            return AFD;
        }

        private void IncluirEstados(Automato AFD, List<Estado> estadoList)
        {
            if (estadoList.Count > 0)
            {
                List<Estado> estadosRecursive = new List<Estado>();
                List<Estado> estadosToAdd = new List<Estado>();
                foreach (var estado in estadoList)
                {
                    List<string> nomesEstadosAFD = new List<string>();
                    foreach (var item in AFD.ListEstados)
                    {
                        string aux = item.Nome;
                        nomesEstadosAFD.Add(aux);
                    }
                    Estado estadoComposto = null;
                    foreach (var estadosProxs in estado.Map.Values)
                    {
                        estadoComposto = new Estado();
                        string nomeProx = "";
                        foreach (var proxEstado in estadosProxs)
                        {
                            nomeProx += proxEstado.Nome;
                        }
                        foreach (var estadoProx in estadosProxs)
                        {
                            bool contains = false;
                            foreach (var a in nomesEstadosAFD)
                            {
                                if (a.Equals(nomeProx))
                                {
                                    contains = true;
                                    break;
                                }
                            }
                            if (!contains)
                            {
                                estadoComposto.Nome += estadoProx.Nome;
                                if (!estadoComposto.Inicial)
                                    estadoComposto.Inicial = estadoProx.Inicial;
                                if (!estadoComposto.Final)
                                    estadoComposto.Final = estadoProx.Final;
                                foreach (var kvp in estadoProx.Map)
                                {
                                    if (!estadoComposto.Map.ContainsKey(kvp.Key))
                                        estadoComposto.Map[kvp.Key] = new List<Estado>();
                                    estadoComposto.Map[kvp.Key].AddRange(kvp.Value);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(estadoComposto.Nome) && !estadosToAdd.Contains(estadoComposto))
                            estadosToAdd.Add(estadoComposto);
                    }
                    if (!string.IsNullOrEmpty(estadoComposto.Nome))
                        estadosRecursive.Add(estadoComposto);
                }
                AFD.ListEstados.AddRange(estadosToAdd);
                IncluirEstados(AFD, estadosRecursive);
            }
        }
    }
}
