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

        public void ConvertToAFD()
        {
            foreach (var estado in ListEstados)
            {
                foreach (var item in estado.Map)
                {
                    if (item.Value.Count > 1)
                    {
                        Estado estadoNovo = new Estado();
                        foreach (var estadoProx in item.Value)
                        {
                            estadoNovo.Nome += estadoProx.Nome;
                            foreach (var kvp in estadoProx.Map)
                            {
                                if (!estadoNovo.Map.ContainsKey(kvp.Key))
                                    estadoNovo.Map[kvp.Key] = new List<Estado>();
                                estadoNovo.Map[kvp.Key].AddRange(kvp.Value);
                            }
                        }
                        ListEstados.Add(estadoNovo);
                    }
                }
            }
        }
    }
}
