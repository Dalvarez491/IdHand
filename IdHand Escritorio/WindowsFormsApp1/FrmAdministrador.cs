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
    public partial class FrmAdministrador : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;


        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
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
            txtNombre.Enabled = false;
            txtEmail.Enabled = false;
            txtContraseña.Enabled = false;
        }

        private void Activar()
        {
            txtNombre.Enabled = true;
            txtEmail.Enabled = true;
            txtContraseña.Enabled = true;
            txtNombre.Focus();
        }

        private void LimpiarPantalla()
        {
            txtNombre.Text = "";
            txtEmail.Clear();
            txtContraseña.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM tbl_administrador";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvAdmin.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO tbl_administrador (Nombre_A, Correo_A, Contraseña_A) VALUES ('" + txtNombre.Text + "', '" + txtEmail.Text + "', '" + txtContraseña.Text + "')", conexion);

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Digite el nombre del administrador");
                txtNombre.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Nombre_A", txtNombre);
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Digite el e-mail del administrador");
                txtEmail.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Correo_A", txtEmail);
            }

            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Digite la contraseña del administrador");
                txtContraseña.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Contraseña_A", txtContraseña);
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
            string cadena = "SELECT * FROM tbl_administrador WHERE Id_A  =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtNombre.Text = registro["Nombre_A"].ToString();
                txtEmail.Text = registro["Correo_A"].ToString();
                txtContraseña.Text = registro["Contraseña_A"].ToString();
                txtNombre.Enabled = true;
                txtEmail.Enabled = true;
                txtContraseña.Enabled = true;
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
            string id = txtBuscar.Text;
            string cadena = "UPDATE tbl_administrador SET Nombre_A = @Nombre_A, Correo_A = @Correo_A,  Contraseña_A = @Contraseña_A WHERE Id_A = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Nombre_A", txtNombre.Text);
            comando.Parameters.AddWithValue("@Correo_A", txtEmail.Text);
            comando.Parameters.AddWithValue("@Contraseña_A", txtContraseña.Text);
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
            string queryd = "DELETE FROM tbl_administrador WHERE Id_A = @id";
            MySqlCommand comando = new MySqlCommand(queryd, conexion);
            comando.Parameters.AddWithValue("id", txtBuscar.Text);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Se elimino correctamente el administrador");
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
