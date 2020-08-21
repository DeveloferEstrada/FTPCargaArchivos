<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FTPCargaArchivos.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Carga de archivos vía FTP</h1>
            <asp:FileUpload ID="ftpFileUpload" runat="server" />
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Cargar Archivo" />
        </div>
    </form>
</body>
</html>
