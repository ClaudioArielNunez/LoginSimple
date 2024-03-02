<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplication1.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--metaname--%>
    <meta name="viewport" content="width-device-width, initial-scale=1.0" />
    <%--bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Registro de Usuario</title>
</head>
<body>

    <form id="Registro" class=" d-flex justify-content-center align-items-center " runat="server">
        <div class="container ">
            <div class="mt-2">
                <h3>Registro de Usuario</h3>
            </div>
            <div class="row mt-4">
                <div class=" col-6">
                    <h4>Datos Personales</h4>
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="ej.claudio"  runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="ej.nunez"  runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Fecha</label>
                        <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date"  runat="server" />
                    </div>
                    <h4>Datos de Usuario:</h4>
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Usuario</label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="User"  runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <asp:TextBox ID="txtClave" CssClass="form-control" placeholder="Password"  runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputPassword1" class="form-label">Repetir Password</label>
                        <asp:TextBox ID="txtClave2" CssClass="form-control" placeholder="Repetir Password"  runat="server" />
                    </div>
                    <br />
                    <asp:Label Text="" ID="lblError" CssClass="mb-3 text-danger " runat="server" />
                    <br />
                    <div class="mb-3">
                        <asp:Button Text="Registrarse" ID="Reg" OnClick="Reg_Click"   CssClass="btn btn-primary" runat="server" />
                        <asp:Button Text="Cancelar" ID="Cancela" OnClick="Cancela_Click"  CssClass="btn btn-warning" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

