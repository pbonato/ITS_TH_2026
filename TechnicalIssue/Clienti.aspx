<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clienti.aspx.cs" Inherits="TechnicalIssue.Clienti" %>

<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Elenco Clienti</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
  </head>
  <body>
    <form runat="server">
      <div class="container mt-4">
        <h1>CLIENTI</h1>

        <asp:GridView ID="gvClienti" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
          <Columns>
            <asp:BoundField DataField="IdCliente" HeaderText="ID" />
            <asp:BoundField DataField="RagioneSociale" HeaderText="Ragione Sociale" />
            <asp:BoundField DataField="Citta" HeaderText="Città" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Email" HeaderText="Email" />

            <asp:TemplateField HeaderText="Azioni">
              <ItemTemplate>
                <asp:Button ID="btnDettagli" runat="server" Text="Dettagli"
                    PostBackUrl='<%# "DettagliCliente.aspx?IdCliente=" + Eval("IdCliente") %>'
                    CssClass="btn btn-primary btn-sm" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>

        <asp:Button ID="btnTornaHome" runat="server" OnClick="btnTornaHome_Click" Text="TORNA ALLA HOME PAGE" CssClass="btn btn-secondary mt-3" />
      </div>
    </form>
  </body>
</html>
