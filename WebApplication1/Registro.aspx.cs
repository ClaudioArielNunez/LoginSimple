using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services.Discovery;

namespace WebApplication1
{
    public partial class Registro : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            string contraseniaSinVerificar = txtClave.Text;
            //Creamos regex
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtFecha.Text) || string.IsNullOrEmpty(txtUsuario.Text) )
            {
                lblError.Text = "Debes completar todos los datos!";
            }
            else if (!letras.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "La clave debe tener letras";
            }
            else if (!numeros.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "La clave debe tener números";
            }
            else if (!especiales.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "La clave debe tener algún caracter especial (Ejemplo: @, ñ, #, $, %, &)";
            }
            else if (txtClave.Text != txtClave2.Text )
            {
                lblError.Text = "La claves deben ser iguales!!";
            }
            else
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ContarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                        con.Open();
                        int user =int.Parse(cmd.ExecuteScalar().ToString());
                        if (user >=1)
                        {
                            lblError.Text = "No pueden existir usuarios con el mismo nombre!!";
                        }
                        else
                        {
                            using (con)
                            {
                                using (SqlCommand comando = new SqlCommand("SP_Registrar", con))
                                {
                                    string patron = "caipiriña";

                                    comando.CommandType = CommandType.StoredProcedure;
                                    comando.Parameters.AddWithValue("Nombres", SqlDbType.VarChar).Value = txtNombre.Text;
                                    comando.Parameters.AddWithValue("Apellidos", SqlDbType.VarChar).Value = txtApellido.Text;
                                    comando.Parameters.AddWithValue("Fecha", SqlDbType.Date).Value = txtFecha.Text;
                                    comando.Parameters.AddWithValue("Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                                    comando.Parameters.AddWithValue("Clave", SqlDbType.VarChar).Value = txtClave.Text;
                                    comando.Parameters.AddWithValue("Patron", patron);

                                   
                                    int filasAfectadas = comando.ExecuteNonQuery();
                                    if(filasAfectadas > 0)
                                    {
                                        Response.Redirect("Login.aspx");
                                    }
                                    else
                                    {
                                        lblError.Text = "No se pudo registrar al usuario";
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}