using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdHand

{
    public partial class FrmUsuario : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmEstudio_Load(object sender, EventArgs e)
        {
            conexion = new MySqlConnection("server=localhost;user id=root;database=idhand;persistsecurityinfo=False");
            MessageBox.Show("Se abrió la conexión con Mysql");
            conexion.Open();
            DasactivarPantalla();
            BtnGuardar.Enabled = false;
            MostrarTodo();
        }

        private void DasactivarPantalla()
        {
            txtDocum.Enabled = false;
            txtEmail.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtContraseñaUsu.Enabled = false;
            txtTipoSangre.Enabled = false;
            txtEPS.Enabled = false;
            txtARL.Enabled = false;
            txtIdCentroR.Enabled = false;
        }

        private void Activar()
        {
            txtDocum.Enabled = true;
            txtEmail.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtContraseñaUsu.Enabled = true;
            txtTipoSangre.Enabled = true;
            txtEPS.Enabled = true;
            txtARL.Enabled = true;
            txtIdCentroR.Enabled = true;
            txtDocum.Focus();
        }

        private void LimpiarPantalla()
        {
            txtDocum.Clear();
            txtEmail.Clear();
            txtNombreUsuario.Clear();
            txtContraseñaUsu.Clear();
            txtTipoSangre.Clear();
            txtEPS.Clear();
            txtARL.Clear();
            txtIdCentroR.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_Usuario";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuario.DataSource = tabla;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir del formulario?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Activar();
            BtnGuardar.Enabled = true;
            BtnNuevo.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            comando = new MySqlCommand("INSERT INTO Tbl_Usuario (Documento_U, Correo_U, Nombre_U, Contraseña_U, TipoSangre_U, NombreEps_U, NombreARL_U, Id_CentroR) VALUES ('" + txtDocum.Text + "', '" + txtEmail.Text + "',  '" + txtNombreUsuario.Text + "', '" + txtContraseñaUsu.Text + "' , '" + txtTipoSangre.Text + "',  '" + txtEPS.Text + "',  '" + txtARL.Text + "',  '" + txtIdCentroR.Text + "')", conexion);

            if (txtDocum.Text == "")
            {
                MessageBox.Show("Digite el documento del usuario");
                txtDocum.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Documento_U", txtDocum);
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Digite el correo del usuario");
                txtEmail.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Correo_U", txtEmail);
            }

            if (txtNombreUsuario.Text == "")
            {
                MessageBox.Show("Digite el nombre del usuario");
                txtNombreUsuario.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Nombre_U", txtNombreUsuario);
            }

            if (txtContraseñaUsu.Text == "")
            {
                MessageBox.Show("Digite la contraseña del usuario");
                txtContraseñaUsu.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Contraseña_U", txtContraseñaUsu);
            }

            if (txtTipoSangre.Text == "")
            {
                MessageBox.Show("Digite la contraseña del usuario");
                txtTipoSangre.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@TipoSangre_U", txtTipoSangre);
            }

            if (txtEPS.Text == "")
            {
                MessageBox.Show("Digite la EPS del usuario");
                txtEPS.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@NombreEps_U", txtEPS);
            }

            if (txtARL.Text == "")
            {
                MessageBox.Show("Digite la ARL del usuario");
                txtARL.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@NombreARL_U", txtARL);
            }

            if (txtIdCentroR.Text == "")
            {
                MessageBox.Show("Digite el id del centro de remisión");
                txtIdCentroR.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Id_CentroR", txtIdCentroR);
            }

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");
                LimpiarPantalla();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MostrarTodo();
            LimpiarPantalla();
            BtnGuardar.Enabled = false;
            DasactivarPantalla();
            BtnNuevo.Enabled = true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtBuscar.Text;
            string cadena = "SELECT * FROM Tbl_Usuario WHERE Documento_U  =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtDocum.Text = registro["Documento_U"].ToString();
                txtEmail.Text = registro["Correo_U"].ToString();
                txtNombreUsuario.Text = registro["Nombre_U"].ToString();
                txtContraseñaUsu.Text = registro["Contraseña_U"].ToString();
                txtTipoSangre.Text = registro["TipoSangre_U"].ToString();
                txtEPS.Text = registro["NombreEps_U"].ToString();
                txtARL.Text = registro["NombreARL_U"].ToString();
                txtIdCentroR.Text = registro["Id_CentroR"].ToString();
                txtDocum.Enabled = false;
                txtEmail.Enabled = true;
                txtNombreUsuario.Enabled = true;
                txtContraseñaUsu.Enabled = true;
                txtTipoSangre.Enabled = true;
                txtEPS.Enabled = true;
                txtARL.Enabled = true;
                txtIdCentroR.Enabled = true;
            }
            else
            {

                MessageBox.Show("No existe el id del administrador");
            }
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtDocum.Text;
            string cadena = "UPDATE Tbl_Usuario SET  Correo_U = @Correo_U, Nombre_U = @Nombre_U,  Contraseña_U = @Contraseña_U, TipoSangre_U = @TipoSangre_U, NombreEps_U = @NombreEps_U, NombreARL_U = @NombreARL_U, Id_CentroR = @Id_CentroR WHERE Documento_U = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Documento_U", txtDocum.Text);
            comando.Parameters.AddWithValue("@Correo_U", txtEmail.Text);
            comando.Parameters.AddWithValue("@Nombre_U", txtNombreUsuario.Text);
            comando.Parameters.AddWithValue("@Contraseña_U", txtContraseñaUsu.Text);
            comando.Parameters.AddWithValue("@TipoSangre_U", txtTipoSangre.Text);
            comando.Parameters.AddWithValue("@NombreEps_U", txtEPS.Text);
            comando.Parameters.AddWithValue("@NombreARL_U", txtARL.Text);
            comando.Parameters.AddWithValue("@Id_CentroR", txtIdCentroR.Text);
            comando.Parameters.AddWithValue("@id", txtDocum.Text);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados correctamente");
                MostrarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string queryd = "DELETE FROM Tbl_Usuario WHERE Documento_U = @id";
            MySqlCommand comando = new MySqlCommand(queryd, conexion);
            comando.Parameters.AddWithValue("id", txtBuscar.Text);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Se elimino correctamente el usuario");
                MostrarTodo();
                LimpiarPantalla();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
