<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificaIntervento.aspx.cs" Inherits="TechnicalIssue.ModificaIntervento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Modifica Intervento</h2>
        <div class="card shadow">
            <div class="card-body">

                <div class="mb-3">
                    <label for="ddlClienti" class="form-label">Cliente</label>
                    <asp:DropDownList ID="ddlClienti" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtData" class="form-label">Data Intervento</label>
                    <asp:TextBox ID="txtData" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtDescrizione" class="form-label">Descrizione</label>
                    <asp:TextBox ID="txtDescrizione" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="ddlTecnico" class="form-label">Tecnico</label>
                    <asp:DropDownList ID="ddlTecnico" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="ddlStato" class="form-label">Stato</label>
                    <asp:DropDownList ID="ddlStato" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Aperto" Value="Aperto" />
                        <asp:ListItem Text="Chiuso" Value="Chiuso" />
                        <asp:ListItem Text="In lavorazione" Value="In lavorazione" />
                    </asp:DropDownList>
                </div>

                <asp:Button ID="btnSalva" runat="server" Text="Salva Modifiche" CssClass="btn btn-primary" OnClick="btnSalva_Click" />
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" CssClass="btn btn-secondary ms-2" OnClick="btnAnnulla_Click" />

            </div>
        </div>
    </div>
</form>
</body>
</html>
