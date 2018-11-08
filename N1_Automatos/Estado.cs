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
        private Dictionary<string, List<Estado>> map;
        private bool inicial;
        private bool final;

        public Estado()
        {
            this.map = new Dictionary<string, List<Estado>>();
        }

        public Estado(string nome)
        {
            this.nome = nome;
            this.map = new Dictionary<string, List<Estado>>();
        }

        public string Nome { get => nome; set => nome = value; }
        public bool Inicial { get => inicial; set => inicial = value; }
        public bool Final { get => final; set => final = value; }
        internal Dictionary<string, List<Estado>> Map { get => map; set => map = value; }

        public override string ToString()
        {
            return this.nome;
        }
    }
    
}
