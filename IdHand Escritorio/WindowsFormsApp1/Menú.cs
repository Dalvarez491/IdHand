using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menú : Form
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Usuario = new IdHand.FrmUsuario();
            Usuario.Show();
        }

        private void padecimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Padecimiento = new FrmPadecimiento();
            Padecimiento.Show();
        }

        private void enfermedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Enfermedad = new FrmEnfermedad();
            Enfermedad.Show();
        }

        private void centroDeRemisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form CentroRemision = new FrmCentroR();
            CentroRemision.Show();
        }

        private void alergiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Alergia = new FrmAlergia();
            Alergia.Show();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Administrador = new FrmAdministrador();
            Administrador.Show();
        }

        private void administradorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Administrador_Usuario = new FrmAdmin_Usuario();
            Administrador_Usuario.Show();
        }

        private void usuarioContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Usuario_Contacto = new FmrUsuario_Contacto();
            Usuario_Contacto.Show();
        }

        private void usuarioPadecimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Usuario_Padecimiento = new FrmUsuario_Padecimiento();
            Usuario_Padecimiento.Show();
        }

        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Contacto = new FrmContacto();
            Contacto.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir de la aplicación?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
