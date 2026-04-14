<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificaInterventi.aspx.cs" Inherits="TechnicalIssue.ModificaInterventi" %>

<!doctype html>
<html lang="it">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Elimina Intervento Tecnico</title>


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>

<body class="bg-light">

    <form id="form1" runat="server" class="container mt-5">

        <h3 class="mb-4">Elimina Intervento Tecnico</h3>

       <asp:GridView ID="gvInterventi" runat="server"
    CssClass="table table-bordered table-striped"
    AutoGenerateColumns="False"
    DataKeyNames="IdIntervento"
    OnRowCommand="gvInterventi_RowCommand">

    <Columns>

        <asp:BoundField DataField="IdIntervento" HeaderText="ID" />
        <asp:BoundField DataField="DataIntervento" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
        <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" />
        <asp:BoundField DataField="Stato" HeaderText="Stato" />

        <asp:TemplateField HeaderText="Azione">
            <ItemTemplate>
                <asp:Button ID="btnElimina" runat="server"
                    Text="Elimina"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Elimina"
                    CommandArgument='<%# Eval("IdIntervento") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>

        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 fw-bold"></asp:Label>

    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
