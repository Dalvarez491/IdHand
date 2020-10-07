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
    public partial class FrmEnfermedad : Form
    {

        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;

        public FrmEnfermedad()
        {
            InitializeComponent();
        }

        private void FrmEnfermedad_Load(object sender, EventArgs e)
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
            txtNombreEnfermedad.Enabled = false;
            txtIdPadecimiento.Enabled = false;
        }

        private void Activar()
        {
            txtNombreEnfermedad.Enabled = true;
            txtIdPadecimiento.Enabled = true;
            label.Focus();
        }

        private void LimpiarPantalla()
        {
            txtNombreEnfermedad.Text = "";
            txtIdPadecimiento.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_Enfermedad";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvEnfermedad.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_Enfermedad (Nombre_Enfermedad, Id_Padecimiento) VALUES ('" + txtNombreEnfermedad.Text + "', '" + txtIdPadecimiento.Text + "')", conexion);

            if (txtNombreEnfermedad.Text == "")
            {
                MessageBox.Show("Digite el nombre de la enfermedad");
                txtNombreEnfermedad.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Nombre_Enfermedad", txtNombreEnfermedad);
            }

            if (txtIdPadecimiento.Text == "")
            {
                MessageBox.Show("Digite el id del padecimiento");
                txtIdPadecimiento.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Id_Padecimiento", txtIdPadecimiento);
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
            string cadena = "SELECT * FROM Tbl_Enfermedad WHERE Id_Enfermedad =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtNombreEnfermedad.Text = registro["Nombre_Enfermedad"].ToString();
                txtIdPadecimiento.Text = registro["Id_Padecimiento"].ToString();
                txtNombreEnfermedad.Enabled = true;
                txtIdPadecimiento.Enabled = true;
            }
            else
            {

                MessageBox.Show("No existe el id de la enfermedad");
            }
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtBuscar.Text;
            string cadena = "UPDATE Tbl_Enfermedad SET Nombre_Enfermedad = @Nombre_Enfermedad, Id_Padecimiento = @Id_Padecimiento WHERE Id_Enfermedad  = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Nombre_Enfermedad", txtNombreEnfermedad.Text);
            comando.Parameters.AddWithValue("@Id_Padecimiento", txtIdPadecimiento.Text);
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
            string queryd = "DELETE FROM Tbl_Enfermedad WHERE Id_Enfermedad = @id";
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
