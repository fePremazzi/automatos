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
        string automatoFileNameSave;
        string automatoFilePath;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (openAutomato.ShowDialog() == DialogResult.OK)
                {
                    automatoFileNameSave = openAutomato.FileName.Substring(0, openAutomato.FileName.IndexOf(".txt", StringComparison.Ordinal));
                    automatoFilePath = Path.GetDirectoryName(openAutomato.FileName);
                    string[] lines = File.ReadAllLines(openAutomato.FileName);

                    //Verificações
                    AutomatoUtils.TamanhoMinimo(lines);
                    AutomatoUtils.UltimaLinha(lines);
                    AutomatoUtils.VerificaQuintupla(lines);
                    AutomatoUtils.VerificaTipo(lines[0]);
                    AutomatoUtils.VerificaEstados(lines[1]);//precisa vir antes do que VerificaEstadoInicial
                    AutomatoUtils.VerificaAlfabeto(lines[2]);
                    AutomatoUtils.VerificaEstadoInicial(lines[3]);
                    for (int i = 5; i < lines.Length - 1; i++)
                    {
                        AutomatoUtils.VerificaTransicao(lines[i]);
                    }

                    EnumTipo tipo = (EnumTipo)Enum.Parse(typeof(EnumTipo), lines[0], true);
                    automato = new Automato();
                    automato.Tipo = tipo;

                    //Estados
                    string[] estados = lines[1].Split(',');
                    for (int i = 0; i < estados.Length; i++)
                    {
                        if (string.IsNullOrEmpty(estados[i]))
                            continue;
                        Estado estado = new Estado(estados[i].Trim());
                        automato.ListEstados.Add(estado);
                    }

                    //Alfabeto
                    string[] simbolosAlfabeto = lines[2].Split(',');
                    for (int i = 0; i < simbolosAlfabeto.Length; i++)
                    {
                        automato.Alfabeto.Add(simbolosAlfabeto[i].Trim());
                    }

                    automato.ListEstados.Find(x => x.Nome == lines[3]).Inicial = true;

                    string[] estadosFinais = lines[4].Split(',');
                    for (int i = 0; i < estadosFinais.Length; i++)
                    {
                        automato.ListEstados.Find(x => x.Nome == estadosFinais[i].Trim()).Final = true;
                    }

                    //Transição
                    for (int i = 5; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("#"))
                            break;
                        string linha = AutomatoUtils.RemoveParenteses(lines[i].Trim());
                        string[] linhaSplit = linha.Split(',');
                        Estado estadoPartida = automato.ListEstados.Find(x => x.Nome == linhaSplit[0].Trim());
                        List<Estado> estadoList;
                        if (estadoPartida.Map.ContainsKey(linhaSplit[1].Trim()))
                        {
                            estadoList = estadoPartida.Map[linhaSplit[1].Trim()];
                            estadoList.Add(automato.ListEstados.Find(x => x.Nome == linhaSplit[2].Trim()));
                        }
                        else
                        {
                            estadoList = new List<Estado>
                        {
                            automato.ListEstados.Find(x => x.Nome == linhaSplit[2].Trim())
                        };
                            estadoPartida.Map[linhaSplit[1].Trim()] = estadoList;
                        }
                    }

                    //Autômato pronto
                    automato.MergirComFechoE();

                    //Conversão
                    List<List<Estado>> a = new List<List<Estado>>();
                    if (automato.Tipo.Equals(EnumTipo.AFNE))
                    {
                        a = automato.ConvertToAfd();
                        string nomeConvertido = automatoFileNameSave + " convertido.txt";
                        File.WriteAllLines(nomeConvertido, AutomatoUtils.geraTxtConvertido(a, automato));
                    }
                    loadIN.Enabled = true;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Não foi possível carregar seu automato", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void loadIN_Click(object sender, EventArgs e)
        {
            if (openIN_File.ShowDialog() == DialogResult.OK)
            {
                string[] linesWords = File.ReadAllLines(openIN_File.FileName);
                List<bool> listBool = new List<bool>();
                for (int i = 0; i < linesWords.Length; i++)
                {
                    List<Estado> estadosIniciais = new List<Estado>();
                    Estado estadoInicial = automato.ListEstados.Find(x => x.Inicial);
                    estadosIniciais.Add(estadoInicial);
                    if (estadoInicial.Map.ContainsKey("@"))
                        estadosIniciais.AddRange(estadoInicial.Map["@"]);
                    listBool.Add(automato.LePalavra(linesWords[i], estadosIniciais));
                }
                for (int i = 0; i < linesWords.Length; i++)
                {
                    linesWords[i] = linesWords[i] + " " + (listBool[i] ? "ACEITO" : "REJEITADO");
                }
                File.WriteAllLines(automatoFilePath + "\\words.out", linesWords);
            }
        }
    }
}
