<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreaIntervento.aspx.cs" Inherits="InterventiTecnici_RUSSO.CreaIntervento" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Crea Intervento</title>
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet"/>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
   </head>
   <body class="bg-light">
      <form id="formCreaIntervento" runat="server">
         <div class="container mt-5">
            <div class="card shadow">
               <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                  <h4 class="mb-0">Crea Intervento</h4>
               </div>
               <div class="card-body">
                  <div class="row g-3">
                     <div class="col-md-4">
                        <label for="txtDataIntervento" class="form-label">Data Intervento</label>
                        <asp:TextBox ID="txtDataIntervento" runat="server" CssClass="form-control" TextMode="Date" />
                     </div>
                     <div class="col-md-4">
                        <label for="txtTecnico" class="form-label">Tecnico</label>
                        <asp:TextBox ID="txtTecnico" runat="server" CssClass="form-control" />
                     </div>
                     <div class="col-md-4">
                        <label for="ddlStato" class="form-label">Stato</label>
                        <asp:DropDownList ID="ddlStato" runat="server" CssClass="form-select">
                           <asp:ListItem Text="Aperto" Value="Aperto" Selected="True" />
                           <asp:ListItem Text="In lavorazione" Value="In lavorazione" />
                           <asp:ListItem Text="Chiuso" Value="Chiuso" />
                        </asp:DropDownList>
                     </div>
                     <div class="col-12">
                        <label for="txtDescrizione" class="form-label">Descrizione</label>
                        <asp:TextBox ID="txtDescrizione" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" /> 
                     </div>
                     <div class="col-md-6">
                        <label for="ddlRagioneSociale" class="form-label">Ragione Sociale (Cliente)</label>
                        <asp:DropDownList ID="ddlRagioneSociale" runat="server" CssClass="form-select"></asp:DropDownList>
                     </div>
                  </div>

                  <div class="mt-4 text-end">
                     <asp:Button ID="btnSalva" CssClass="btn btn-primary me-2" runat="server" Text="Salva" OnClick="btnSalva_Click" />
                     <asp:Button ID="btnAnnulla" CssClass="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
                  </div>
               </div>
            </div>
         </div>
      </form>
   </body>
</html>
