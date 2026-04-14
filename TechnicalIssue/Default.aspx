<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnicalIssue.Default" %>

<!doctype html>
<html lang="it" data-bs-theme="dark">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Gestione Interventi Tecnici</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">

    <style>
        body {
            background: linear-gradient(135deg, #0d1117, #1c1f26);
            height: 100vh;
            margin: 0;
        }

        .wrapper {
            height: 100vh;
        }

        .main-box {
            background: rgba(33, 37, 41, 0.9);
            padding: 50px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.6);
            width: 100%;
            max-width: 900px; /* 👈 largo */
        }

        .btn-custom {
            padding: 20px;
            font-size: 1.2rem;
            border-radius: 10px;
            transition: 0.2s;
        }

        .btn-custom:hover {
            transform: scale(1.03);
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container wrapper d-flex justify-content-center align-items-center">

            <div class="main-box text-center">

                <h2 class="mb-5">🛠️ Gestione Interventi Tecnici</h2>

                <div class="row g-4">
                    <div class="col-md-6">
                        <a href="Clienti.aspx" class="btn btn-primary w-100 btn-lg btn-custom">
                            👤 Clienti
                        </a>
                    </div>

                    <div class="col-md-6">
                        <a href="ListaInterventi.aspx" class="btn btn-primary w-100 btn-lg btn-custom">
                            📋 Interventi
                        </a>
                    </div>
                </div>

            </div>

        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
