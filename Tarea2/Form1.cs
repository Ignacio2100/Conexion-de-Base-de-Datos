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

namespace Tarea2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCod_comunidad.Text = "";
            txtComunidad.Text = "";
            txtCod_departamento.Text = "";
            txtCod_municipio.Text = "";
            txtCod_distrito.Text = "";
            txtCod_categoria.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cod_comunidad = Convert.ToInt32(txtCod_comunidad.Text);
            string comunidad = txtComunidad.Text;
            int cod_departamento = Convert.ToInt32(txtCod_departamento.Text);
            int cod_municipio = Convert.ToInt32(txtCod_municipio.Text);
            int cod_distrito = Convert.ToInt32(txtCod_distrito.Text);
            int cod_categoria = Convert.ToInt32(txtCod_categoria.Text);


           // string query = "INSERT INTO tbl_comunidades VALUES('"+ cod_comunidad + "','" + comunidad + "','"+ cod_departamento + "','"+ cod_municipio + "','"+ cod_distrito + "','"+ cod_categoria + "');";  
            string query = "CALL Insertar('" + cod_comunidad + "','" + comunidad + "','" + cod_departamento + "','" + cod_municipio + "','" + cod_distrito + "','" + cod_categoria + "');";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query,conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Exitoso");
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error de Registro: "+ex.Message);
            }


            finally
            {
                conexionBD.Close();
            }

            txtCod_comunidad.Text = "";
            txtComunidad.Text = "";
            txtCod_departamento.Text = "";
            txtCod_municipio.Text = "";
            txtCod_distrito.Text = "";
            txtCod_categoria.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cod_comunidad = Convert.ToInt32(txtCod_comunidad.Text);

            MySqlDataReader reader = null;

            //string query = "SELECT * FROM tbl_comunidades WHERE cod_comunidad='"+cod_comunidad+"';";
            string query = "call Buscar('"+cod_comunidad+"');";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtComunidad.Text = reader.GetString(1);
                        txtCod_departamento.Text = reader.GetString(2);
                        txtCod_municipio.Text = reader.GetString(3);
                        txtCod_distrito.Text = reader.GetString(4);
                        txtCod_categoria.Text = reader.GetString(5);
                    }

                }
                else
                {
                    MessageBox.Show("No se encontraron Registros");
                }

                MessageBox.Show("Exito");
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error de Buscar: " + ex.Message);
            }


            finally
            {
                conexionBD.Close();
            }

          
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int cod_comunidad = Convert.ToInt32(txtCod_comunidad.Text);
            string comunidad = txtComunidad.Text;
            int cod_departamento = Convert.ToInt32(txtCod_departamento.Text);
            int cod_municipio = Convert.ToInt32(txtCod_municipio.Text);
            int cod_distrito = Convert.ToInt32(txtCod_distrito.Text);
            int cod_categoria = Convert.ToInt32(txtCod_categoria.Text);


            //string query = "UPDATE tbl_comunidades SET comunidad = '"+comunidad+"', cod_departamento = '"+cod_departamento+"', cod_municipio='"+cod_municipio+"', cod_distrito= '"+cod_distrito+"', cod_categoria= '"+cod_categoria+"' WHERE cod_comunidad= '"+cod_comunidad+"';";  
            string query = "call Actualizar ('"+cod_comunidad+"','"+comunidad+"','"+cod_departamento+"','"+cod_municipio+"','"+cod_distrito+"','"+cod_categoria+"');";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Actualizado");
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error de Actualizar: " + ex.Message);
            }


            finally
            {
                conexionBD.Close();
            }
            txtCod_comunidad.Text = "";
            txtComunidad.Text = "";
            txtCod_departamento.Text = "";
            txtCod_municipio.Text = "";
            txtCod_distrito.Text = "";
            txtCod_categoria.Text = "";


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod_comunidad = Convert.ToInt32(txtCod_comunidad.Text);

            //string query = "DELETE FROM tbl_comunidades WHERE cod_comunidad='"+cod_comunidad+"' ;";
            string query =" CALL Eliminar('"+cod_comunidad+"')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error de Eliminar: " + ex.Message);
            }


            finally
            {
                conexionBD.Close();
            }
            txtCod_comunidad.Text = "";
            txtComunidad.Text = "";
            txtCod_departamento.Text = "";
            txtCod_municipio.Text = "";
            txtCod_distrito.Text = "";
            txtCod_categoria.Text = "";

        }
    }
}
