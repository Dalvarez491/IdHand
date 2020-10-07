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
    public partial class FrmCentroR : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FrmCentroR()
        {
            InitializeComponent();
        }

        private void FrmCentroR_Load(object sender, EventArgs e)
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
            txtDirecc.Enabled = false;
            txtTelef.Enabled = false;
        }

        private void Activar()
        {
            txtDirecc.Enabled = true;
            txtTelef.Enabled = true;
            txtDirecc.Focus();
        }

        private void LimpiarPantalla()
        {
            txtDirecc.Text = "";
            txtTelef.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_CentroRemision";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvCentroR.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_CentroRemision (Dirrecion_CentroR, Telefono_CentroR) VALUES ('" + txtDirecc.Text + "', '" + txtTelef.Text + "')", conexion);

            if (txtDirecc.Text == "")
            {
                MessageBox.Show("Digite la dirección del centro de remisión");
                txtDirecc.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Dirrecion_CentroR", txtDirecc);
            }

            if (txtTelef.Text == "")
            {
                MessageBox.Show("Digite el télefono del centro de remisión");
                txtTelef.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Telefono_CentroR", txtTelef);
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
            string cadena = "SELECT * FROM Tbl_CentroRemision WHERE Id_CentroR =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtDirecc.Text = registro["Dirrecion_CentroR"].ToString();
                txtTelef.Text = registro["Telefono_CentroR"].ToString();
                txtDirecc.Enabled = true;
                txtTelef.Enabled = true;
            }
            else
            {

                MessageBox.Show("No existe el id del centro de remisión");
            }
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtBuscar.Text;
            string cadena = "UPDATE Tbl_CentroRemision SET Dirrecion_CentroR = @Dirrecion_CentroR, Telefono_CentroR = @Telefono_CentroR  WHERE Id_CentroR = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Dirrecion_CentroR", txtDirecc.Text);
            comando.Parameters.AddWithValue("@Telefono_CentroR", txtTelef.Text);
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
            string queryd = "DELETE FROM Tbl_CentroRemision WHERE Id_CentroR  = @id";
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
