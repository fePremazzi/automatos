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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (openAutomato.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openAutomato.FileName);
                    EnumTipo tipo = EnumTipo.AFD;//mudar isso para pegar do arquivo

                    //TODO Verificaçoes
                    AutomatoUtils.TamanhoMinimo(lines);
                    AutomatoUtils.UltimaLinha(lines);
                    AutomatoUtils.VerificaQuintupla(lines);
                    AutomatoUtils.VerificaTipo(lines[0]);
                    AutomatoUtils.VerificaEstados(lines[1]);//precisa vir antes do que VerificaEstadoInicial
                    AutomatoUtils.VerificaAlfabeto(lines[2]);
                    AutomatoUtils.VerificaEstadoInicial(lines[3]);


                    Automato automato = new Automato();
                    automato.Tipo = tipo;
                    string[] estados = lines[1].Split(',');
                    for (int i = 0; i < estados.Length; i++)
                    {
                        Estado estado = new Estado(estados[i]);
                        automato.ListEstados.Add(estado);
                    }

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
                    Automato automatoBreak = automato;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Não foi possível carregar seu automato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadIN_Click(object sender, EventArgs e)
        {
            if (openIN_File.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
