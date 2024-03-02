using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Link_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || (string.IsNullOrEmpty(txtClave.Text)))
            {
                lblError.Text = "Es necesario usuario y clave!!";
            }
            else
            {
                using (con)
                {
                    using (SqlCommand usuario = new SqlCommand("SP_Validar", con))
                    {
                        string patron = "caipiriña";
                        usuario.CommandType = CommandType.StoredProcedure;
                        usuario.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                        usuario.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = txtClave.Text;
                        usuario.Parameters.AddWithValue("@Patron", patron);

                        
                        
                            con.Open();
                            SqlDataReader dr = usuario.ExecuteReader();
                            if (dr.Read())
                            {
                                Session["usuarioLogueado"] = dr["Id"].ToString();
                                Response.Redirect("Index.aspx");
                            }
                            else
                            {
                                lblError.Text = "Usuario o Contraseña incorrectos!!";
                                
                            }                    
                        
                            con.Close();
                        
                    }
                }
            }

        }
    }
}