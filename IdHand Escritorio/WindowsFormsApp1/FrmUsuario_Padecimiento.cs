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
    public partial class FrmUsuario_Padecimiento : Form
    {
        MySqlCommand comando;
        MySqlDataReader dt;
        DataSet registro;
        MySqlDataAdapter adaptador;
        MySqlConnection conexion;


        public FrmUsuario_Padecimiento()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Padecimiento_Load(object sender, EventArgs e)
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
            txtDocuUsuario.Enabled = false;
            txtIdPadecimiento.Enabled = false;
            txtFechaPadecimiento.Enabled = false;
        }

        private void Activar()
        {
            txtDocuUsuario.Enabled = true;
            txtIdPadecimiento.Enabled = true;
            txtFechaPadecimiento.Enabled = true;
            txtDocuUsuario.Focus();
        }

        private void LimpiarPantalla()
        {
            txtDocuUsuario.Text = "";
            txtIdPadecimiento.Clear();
            txtFechaPadecimiento.Clear();
        }

        private void MostrarTodo()
        {
            String consulta = "SELECT * FROM Tbl_Usuario_Padecimiento";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuario_Padecimiento.DataSource = tabla;
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
            comando = new MySqlCommand("INSERT INTO Tbl_Usuario_Padecimiento (Documento_U, Id_Padecimiento, Fecha_Padecimiento) VALUES ('" + txtDocuUsuario.Text + "', '" + txtIdPadecimiento.Text + "', '" + txtFechaPadecimiento.Text + "')", conexion);

            if (txtDocuUsuario.Text == "")
            {
                MessageBox.Show("Digite el documento del usuario");
                txtDocuUsuario.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Documento_U", txtDocuUsuario);
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

            if (txtFechaPadecimiento.Text == "")
            {
                MessageBox.Show("Digite la fecha de modificación");
                txtFechaPadecimiento.Focus();
                return;
            }

            else
            {
                comando.Parameters.AddWithValue("@Fecha_Padecimiento", txtFechaPadecimiento);
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
            string cadena = "SELECT * FROM Tbl_Usuario_Padecimiento WHERE Documento_U =" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtDocuUsuario.Text = registro["Documento_U"].ToString();
                txtIdPadecimiento.Text = registro["Id_Padecimiento"].ToString();
                txtFechaPadecimiento.Text = registro["Fecha_Padecimiento"].ToString();
                txtDocuUsuario.Enabled = true;
                txtIdPadecimiento.Enabled = true;
                txtFechaPadecimiento.Enabled = true;
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
            string cadena = "UPDATE Tbl_Usuario_Padecimiento SET Documento_U = @Documento_U, Id_Padecimiento = @Id_Padecimiento,  Fecha_Padecimiento = @Fecha_Padecimiento WHERE Documento_U = @id";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Documento_U", txtDocuUsuario.Text);
            comando.Parameters.AddWithValue("@Id_Padecimiento", txtIdPadecimiento.Text);
            comando.Parameters.AddWithValue("@Fecha_Padecimiento", txtFechaPadecimiento.Text);
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
            string queryd = "DELETE FROM Tbl_Usuario_Padecimiento WHERE Documento_U = @id";
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
