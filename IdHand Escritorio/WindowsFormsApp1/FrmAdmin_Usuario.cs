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

namespace WindowsFormsApp1
{
    public partial class FrmAdmin_Usuario : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FrmAdmin_Usuario()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Usuario_Load(object sender, EventArgs e)
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
            txtIdAdmin.Enabled = false;
            txtDocUsuario.Enabled = false;
            txtNomAdmin.Enabled = false;
            txtFechaAdmistracion.Enabled = false;
        }

        private void Activar()
        {
            txtIdAdmin.Enabled = true;
            txtDocUsuario.Enabled = true;
            txtNomAdmin.Enabled = true;
            txtFechaAdmistracion.Enabled = true;
            txtIdAdmin.Focus();
        }

        private void LimpiarPantalla()
        {
            txtIdAdmin.Clear();
            txtDocUsuario.Clear();
            txtNomAdmin.Clear();
            txtFechaAdmistracion.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM tbl_administrador_usuario";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAdmin_Usuario.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_Administrador_Usuario (Id_A, Documento_U, Nombre_A, Fecha_Admi) VALUES ('" + txtIdAdmin.Text + "', '" + txtDocUsuario.Text + "', '" + txtNomAdmin.Text + "', '" + txtFechaAdmistracion.Text + "')", conexion);

            if (txtIdAdmin.Text == "")
            {
                MessageBox.Show("Digite el id del administrador");
                txtIdAdmin.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Id_A", txtIdAdmin);
            }

            if (txtDocUsuario.Text == "")
            {
                MessageBox.Show("Digite el documento del usuario");
                txtDocUsuario.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Documento_U", txtDocUsuario);
            }

            if (txtNomAdmin.Text == "")
            {
                MessageBox.Show("Digite el nombre del administrador que modificó");
                txtNomAdmin.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Nombre_A", txtNomAdmin);
            }

            if (txtFechaAdmistracion.Text == "")
            {
                MessageBox.Show("Digite la fecha de modificación");
                txtFechaAdmistracion.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Fecha_Admi", txtFechaAdmistracion);
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
            string cadena = "SELECT * FROM Tbl_Administrador_Usuario WHERE Id_A =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtIdAdmin.Text = registro["Id_A"].ToString();
                txtDocUsuario.Text = registro["Documento_U"].ToString();
                txtNomAdmin.Text = registro["Nombre_A"].ToString();
                txtFechaAdmistracion.Text = registro["Fecha_Admi"].ToString();
                txtIdAdmin.Enabled = true;
                txtDocUsuario.Enabled = true;
                txtNomAdmin.Enabled = true;
                txtFechaAdmistracion.Enabled = true;
            }
            else
            {

                MessageBox.Show("No existe el id");
            }
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtBuscar.Text;
            string cadena = "UPDATE Tbl_Administrador_Usuario SET Id_A = @Id_A, Documento_U = @Documento_U, Nombre_A = @Nombre_A, Fecha_Admi = @Fecha_Admi  WHERE Id_A = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Id_A", txtIdAdmin.Text);
            comando.Parameters.AddWithValue("@Documento_U", txtDocUsuario.Text);
            comando.Parameters.AddWithValue("@Nombre_A", txtNomAdmin.Text);
            comando.Parameters.AddWithValue("@Fecha_Admi", txtFechaAdmistracion.Text);
            comando.Parameters.AddWithValue("@id", txtBuscar.Text);

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
            string queryd = "DELETE FROM Tbl_Administrador_Usuario WHERE Id_A = @id";
            MySqlCommand comando = new MySqlCommand(queryd, conexion);
            comando.Parameters.AddWithValue("id", txtBuscar.Text);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Se elimino correctamente");
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
