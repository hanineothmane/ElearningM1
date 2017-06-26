<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="ElearningM1.BD" %>

<!DOCTYPE html>
<html>
<head>
    <title>Authentification</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="Content/css/materialize.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/materialize.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/style.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<script src="Scripts/modernizr-2.6.2.js" type="text/javascript"></script>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="Logon.aspx" class="navbar-brand">MyPlateformMIAGE</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                </ul>
            </div>
        </div>
    </div>



<script runat="server">

    void Logon_Click(object sender, EventArgs e)
    {

        if (BDD.ConnexionRP(UserEmail.Text, UserPass.Text)!=null)
        {
            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
            var utilisateur = BDD.ConnexionRP(UserEmail.Text, UserPass.Text);
            Session["id_utilisateur"] = utilisateur.Id;
            Session["nom_utilisateur"] = utilisateur.Nom;
            Session["prenom_utlisateur"] = utilisateur.Prenom;
            Session["telephone_utilisateur"] = utilisateur.Telephone;
            Session["adresse_utilisateur"] = utilisateur.Adresse;
            Session["datenaissance_utilisateur"] = utilisateur.DateNaiss;
            Session["email_utilisateur"] = utilisateur.Email;
            Session["typeUtilisateur"] = "RP";
            Response.Redirect("Home/Index");
        }
        else if(BDD.ConnexionTE(UserEmail.Text, UserPass.Text)!= null)
        {
            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
             var utilisateur = BDD.ConnexionTE(UserEmail.Text, UserPass.Text);
            Session["id_utilisateur"] = utilisateur.Id;
            Session["nom_utilisateur"] = utilisateur.Nom;
            Session["prenom_utlisateur"] =utilisateur.Prenom;
            Session["telephone_utilisateur"] = utilisateur.Telephone;
            Session["adresse_utilisateur"] = utilisateur.Adresse;
            Session["datenaissance_utilisateur"] = utilisateur.DateNaiss;
            Session["email_utilisateur"] = utilisateur.Email;
            Session["typeUtilisateur"] = "TE";

            Response.Redirect("Home/Index");
        }
        else if(BDD.ConnexionAdministration(UserEmail.Text, UserPass.Text)!= null)
        {
            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
             var utilisateur = BDD.ConnexionAdministration(UserEmail.Text, UserPass.Text);
            Session["id_utilisateur"] = utilisateur.Id;
            Session["nom_utilisateur"] = utilisateur.Nom;
            Session["prenom_utlisateur"] = utilisateur.Prenom;
            Session["telephone_utilisateur"] = utilisateur.Telephone;
            Session["adresse_utilisateur"] = utilisateur.Adresse;
            Session["datenaissance_utilisateur"] =utilisateur.DateNaiss;
            Session["email_utilisateur"] = utilisateur.Email;
            Session["typeUtilisateur"] = "Admin";
            Response.Redirect("Home/Index");
        }
        else
        {
            Msg.Text = "Identifiant ou mot de passe invalide. Veuillez réessayer.";
        }
    }
</script>

<div class="container body-content">
  <form id="form1" runat="server">
    <h3>
      Page de connexion</h3>
    <table>
      <tr>
        <td>
          Identifiant :</td>
        <td>
          <asp:TextBox ID="UserEmail" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserEmail"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Mot de passe :</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
             runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
          <asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button class="btn btn-default" ID="Submit1" OnClick="Logon_Click" Text="Se connecter" 
       runat="server" />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
  </form>
    <img src="C:\Users\wassi\Desktop\Projet MIAGE\emiage.png">
    <img src="C:\Users\wassi\Desktop\Projet MIAGE\miage.png" height="84" width="240">
    
</body>


</html>
