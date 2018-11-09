using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1_Automatos
{
    public class Estado
    {
        public Estado()
        {
            this.Map = new Dictionary<string, List<Estado>>();
        }

        public Estado(string nome)
        {
            this.Nome = nome;
            this.Map = new Dictionary<string, List<Estado>>();
        }

        public string Nome { get; set; }

        public bool Inicial { get; set; }

        public bool Final { get; set; }

        public Dictionary<string, List<Estado>> Map { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
    
}
