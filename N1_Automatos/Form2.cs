using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N1_Automatos
{
    public partial class Form2 : Form
    {
        public Form2(Automato a, List<List<Estado>> estados)
        {
            try
            {
                InitializeComponent();
                AutomatoUtils.CreateGrid(estados, a, dataGridView1);
                this.Height = dataGridView1.Height + 38;
            }
            catch (Exception ignore)
            {

            }
        }
    }
}
