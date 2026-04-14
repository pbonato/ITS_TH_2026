<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DettagliCliente.aspx.cs" Inherits="GestioneInterventiTecniciWeb.DettagliCliente" %>

<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dettaglio Cliente</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
  </head>
  <body>
    <form runat="server">
      <div class="container mt-4">
        <h1>DETTAGLI CLIENTE</h1>

        <div class="card mb-4">
          <div class="card-body">
            <h5 class="card-title"><asp:Label ID="lblRagioneSociale" runat="server" /></h5>
            <p class="card-text">
              <strong>Città:</strong> <asp:Label ID="lblCitta" runat="server" /><br />
              <strong>Telefono:</strong> <asp:Label ID="lblTelefono" runat="server" /><br />
              <strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" />
            </p>
          </div>
        </div>

        <h3>INTERVENTI ASSOCIATI AL CLIENTE</h3>
        <asp:GridView ID="gvInterventiCliente" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
          <Columns>
            <asp:BoundField DataField="IdIntervento" HeaderText="ID" />
            <asp:BoundField DataField="DataIntervento" HeaderText="Data" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
            <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" />
            <asp:BoundField DataField="Stato" HeaderText="Stato" />
          </Columns>
        </asp:GridView>

        <asp:Button ID="btnTornaClienti" runat="server" Text="TORNA A CLIENTI" CssClass="btn btn-secondary mt-3" OnClick="btnTornaClienti_Click" />

      </div>
    </form>
  </body>
</html>