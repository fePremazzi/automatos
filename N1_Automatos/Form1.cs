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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                EnumTipo tipo = EnumTipo.AFD;
                for (int i = 0; i < lines.Length; i++)
                {
                    //TODO Verificaçoes
                }
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

                
            }
        }
    }
}
