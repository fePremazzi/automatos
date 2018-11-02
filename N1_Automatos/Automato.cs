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
    }
}
