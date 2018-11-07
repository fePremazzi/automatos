using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N1_Automatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            openAutomato.Filter = "Arquivos Texto|*.txt";
            openIN_File.Filter = "Arquivos IN|*.in";
        }
        Automato automato;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openAutomato.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openAutomato.FileName);
                EnumTipo tipo = EnumTipo.AFD;

                //Verificações
                for (int i = 0; i < lines.Length; i++)
                {
                    //TODO Verificaçoes
                }


                automato = new Automato();
                automato.Tipo = tipo;

                //Estados
                string[] estados = lines[1].Split(',');
                for (int i = 0; i < estados.Length; i++)
                {
                    Estado estado = new Estado(estados[i]);
                    automato.ListEstados.Add(estado);
                }

                //Alfabeto
                string[] simbolosAlfabeto = lines[2].Split(',');
                for (int i = 0; i < simbolosAlfabeto.Length; i++)
                {
                    automato.Alfabeto.Add(simbolosAlfabeto[i]);
                }

                automato.ListEstados.Find(x => x.Nome == lines[3]).Inicial = true;

                string[] estadosFinais = lines[4].Split(',');
                for (int i = 0; i < estadosFinais.Length; i++)
                {
                    automato.ListEstados.Find(x => x.Nome == estadosFinais[i]).Final = true;
                }

                //Transição
                for (int i = 5; i < lines.Length; i++)
                {
                    if (lines[i].Contains("#"))
                        break;
                    string linha = AutomatoUtils.RemoveParenteses(lines[i]);
                    string[] linhaSplit = linha.Split(',');
                    Estado estadoPartida = automato.ListEstados.Find(x => x.Nome == linhaSplit[0]);
                    List<Estado> estadoList;
                    if (estadoPartida.Map.ContainsKey(linhaSplit[1]))
                    {
                        estadoList = estadoPartida.Map[linhaSplit[1]];
                        estadoList.Add(automato.ListEstados.Find(x => x.Nome == linhaSplit[2]));
                    }
                    else
                    {
                        estadoList = new List<Estado>
                        {
                            automato.ListEstados.Find(x => x.Nome == linhaSplit[2])
                        };
                        estadoPartida.Map[linhaSplit[1]] = estadoList;
                    }
                }

                MergirComFechoE();
                string parou = "stop";
            }
        }

        private void MergirComFechoE()
        {
            for (int i = 0; i < automato.ListEstados.Count; i++)
            {
                Estado estado = automato.ListEstados[i];
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

            for (int i = 0; i < automato.ListEstados.Count; i++)
            {
                Estado estado = automato.ListEstados[i];

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

            foreach (var item in automato.ListEstados)
            {
                if (item.Map.ContainsKey("@"))
                    item.Map.Remove("@");
            }
        }

        private void loadIN_Click(object sender, EventArgs e)
        {
            if (openIN_File.ShowDialog() == DialogResult.OK)
            {
                //TODO método de ler palavras
                string[] linesWords = File.ReadAllLines(openIN_File.FileName);
                Estado estado = automato.ListEstados.Find(x => x.Inicial);
                for (int i = 0; i < linesWords.Length; i++)
                {
                    char[] lettersWord = linesWords[i].ToCharArray();
                    for (int j = 0; j < lettersWord.Length; j++)
                    {
                        List<Estado> estadosProximos = estado.Map[lettersWord[j].ToString()];
                    }
                }
                File.WriteAllLines("words.out", linesWords);

            }
        }
    }
}
