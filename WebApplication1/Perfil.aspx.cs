using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;

namespace WebApplication1
{
    public partial class Perfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuarioLogueado"].ToString());
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("Perfil", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tbNombres.Text = dr["Nombres"].ToString();
                        tbApellidos.Text = dr["Apellidos"].ToString();
                        tbFecha.Text = dr["Fecha"].ToString();
                        tbUsuario.Text = dr["Usuario"].ToString();
                        con.Close();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                        con.Close();
                    }
                }
            }
            
            
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SP_Eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Login.aspx");
                    con.Close();
                }
            }
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            mostrarControles();
        }

        private void mostrarControles()
        {
            if(contrasenia.Visible == false)
            {
                contrasenia.Visible = true;
                BtnGuardar.Visible = true;
                BtnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasenia.Visible = false;
                BtnGuardar.Visible = false;
                BtnCambiar.Text = "Cambiar seña";
                lblErrorClave.Text = "";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string contraseñaAChequear = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

            if (string.IsNullOrEmpty(tbClave.Text) || string.IsNullOrEmpty(tbClave2.Text))
            {
                lblErrorClave.Text = "Debe colocar las nuevas claves";
            }
            else if (tbClave.Text != tbClave2.Text)
            {
                lblErrorClave.Text = "No coinciden las claves!!";
            }
            else if (!letras.IsMatch(contraseñaAChequear))
            {
                lblErrorClave.Text = "La nueva clave debe tener letras";
            }
            else if (!numeros.IsMatch(contraseñaAChequear))
            {
                lblErrorClave.Text = "La nueva clave debe tener números";
            }
            else if (!especiales.IsMatch(contraseñaAChequear))
            {
                lblErrorClave.Text = "La nueva clave debe tener caracteres especiales";
            }
            else
            {

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_CambiarSeña", con))
                    {
                        string patron = "caipiriña";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.AddWithValue("@Patron", patron);

                        con.Open();
                        int filasafectadas = cmd.ExecuteNonQuery();
                        if (filasafectadas > 0)
                        {
                            lblErrorClave.Text = "Contraseña cambiada exitosamente!!!";
                        }
                        else
                        {
                            lblErrorClave.Text = "No se pudo realizar el cambio!";
                        }
                        con.Close();

                    }

                }
            }
        }
    }
}