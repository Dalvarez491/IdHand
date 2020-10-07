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
    public partial class FmrUsuario_Contacto : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FmrUsuario_Contacto()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Contacto_Load(object sender, EventArgs e)
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
            txtDocUsuario.Enabled = false;
            txtIdContacto.Enabled = false;
            txtFechaContact.Enabled = false;
        }

        private void Activar()
        {
            txtDocUsuario.Enabled = true;
            txtIdContacto.Enabled = true;
            txtFechaContact.Enabled = true;
            txtDocUsuario.Focus();
        }

        private void LimpiarPantalla()
        {
            txtDocUsuario.Text = "";
            txtIdContacto.Clear();
            txtFechaContact.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_Usuario_Contacto_E";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuario_Contacto.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_Usuario_Contacto_E (Documento_U, Id_Contacto_E, Fecha_Contacto) VALUES ('" + txtDocUsuario.Text + "', '" + txtIdContacto.Text + "', '" + txtFechaContact.Text + "')", conexion);

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

            if (txtIdContacto.Text == "")
            {
                MessageBox.Show("Digite el id del contacto");
                txtIdContacto.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Id_Contacto_E", txtIdContacto);
            }

            if (txtFechaContact.Text == "")
            {
                MessageBox.Show("Digite la fecha de modificación");
                txtFechaContact.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Fecha_Contacto", txtFechaContact);
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
            string cadena = "SELECT * FROM Tbl_Usuario_Contacto_E WHERE Documento_U =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtDocUsuario.Text = registro["Documento_U"].ToString();
                txtIdContacto.Text = registro["Id_Contacto_E"].ToString();
                txtFechaContact.Text = registro["Fecha_Contacto"].ToString();
                txtDocUsuario.Enabled = true;
                txtIdContacto.Enabled = true;
                txtFechaContact.Enabled = true;
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
            string cadena = "UPDATE Tbl_Usuario_Contacto_E SET Documento_U = @Documento_U, Id_Contacto_E = @Id_Contacto_E,  Fecha_Contacto = @Fecha_Contacto WHERE Documento_U = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Documento_U", txtDocUsuario.Text);
            comando.Parameters.AddWithValue("@Id_Contacto_E", txtIdContacto.Text);
            comando.Parameters.AddWithValue("@Fecha_Contacto", txtFechaContact.Text);
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
            string queryd = "DELETE FROM Tbl_Usuario_Contacto_E WHERE Documento_U = @id";
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
