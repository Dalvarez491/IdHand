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
    public partial class FrmContacto : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FrmContacto()
        {
            InitializeComponent();
        }


        private void FrmContacto_Load(object sender, EventArgs e)
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
            txtCel.Enabled = false;
            txtParentesco.Enabled = false;
        }

        private void Activar()
        {
            txtCel.Enabled = true;
            txtParentesco.Enabled = true;
            txtCel.Focus();
        }

        private void LimpiarPantalla()
        {
            txtCel.Text = "";
            txtParentesco.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_contacto_E";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvContacto.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_contacto_E (Celular_Contacto_E, Parentesco_Contacto_E) VALUES ('" + txtCel.Text + "', '" + txtParentesco.Text + "')", conexion);

            if (txtCel.Text == "")
            {
                MessageBox.Show("Digite el celular del contacto");
                txtCel.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Celular_Contacto_E", txtCel);
            }

            if (txtParentesco.Text == "")
            {
                MessageBox.Show("Digite el parentesco");
                txtParentesco.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Parentesco_Contacto_E", txtParentesco);
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
            string cadena = "SELECT * FROM Tbl_contacto_E WHERE Id_Contacto_E  =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtCel.Text = registro["Celular_Contacto_E"].ToString();
                txtParentesco.Text = registro["Parentesco_Contacto_E"].ToString();
                txtCel.Enabled = true;
                txtParentesco.Enabled = true;
            }
            else
            {

                MessageBox.Show("No existe el id del contacto");
            }
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtBuscar.Text;
            string cadena = "UPDATE Tbl_contacto_E SET Celular_Contacto_E = @Celular_Contacto_E, Parentesco_Contacto_E = @Parentesco_Contacto_E  WHERE Id_Contacto_E = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Celular_Contacto_E", txtCel.Text);
            comando.Parameters.AddWithValue("@Parentesco_Contacto_E", txtParentesco.Text);
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
            string queryd = "DELETE FROM Tbl_contacto_E WHERE Id_Contacto_E  = @id";
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
