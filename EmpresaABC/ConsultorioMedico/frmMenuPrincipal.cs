using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioMedico
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            frmConsulta abrir = new frmConsulta();
            abrir.Show();
            this.Hide();
        }
    }
}
