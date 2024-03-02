<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de Sesión</title>
    <%--metaname--%>
    <meta name="viewport" content="width-device-width, initial-scale=1.0" />
    <%--bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <form id="form1" class=" d-flex justify-content-center align-items-center " runat="server">
       <div class="container ">
           <div class="mt-2">
               <h3>Inicio de sesión</h3>
           </div>
        <div class="row mt-4">
            <div class=" col-6">
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Usuario</label>
                    <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="User"  runat="server" />
                    
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <asp:TextBox ID="txtClave" CssClass="form-control" placeholder="Password" runat="server" />
                </div>
                <div class="mt-4">
                    <%--boton para entrar--%>
                    <asp:Button ID="btnIniciar" OnClick="btnIniciar_Click" Text ="LOG IN" CssClass="form-control btn btn-primary " runat="server" />
                </div>
                <br />
                <br />
                <br />
                <div   >
                    <asp:Label ID="lblError" Text="" cssClass="text-danger"  runat="server" />
                    <br />
                    <br />
                    <%--boton Link para registrarse por primera vez--%>
                    <asp:Label Text="¿No tienes una cuenta?, Regístrate" runat="server" />
                    <asp:LinkButton Text="Aquí" ID="Link" OnClick="Link_Click" runat="server" />
                </div>
                
            </div>
        </div>
      </div>
    </form>
    <%--js--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
