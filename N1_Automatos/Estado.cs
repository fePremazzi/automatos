using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    class Estado
    {
        private string nome;
        private Dictionary<string, Estado> map;
        private bool inicial;
        private bool final;

        public Estado() {}

        public Estado(string nome)
        {
            this.nome = nome;
        }

        public string Nome { get => nome; set => nome = value; }
        public bool Inicial { get => inicial; set => inicial = value; }
        public bool Final { get => final; set => final = value; }
        internal Dictionary<string, Estado> Map { get => map; set => map = value; }
    }
}
