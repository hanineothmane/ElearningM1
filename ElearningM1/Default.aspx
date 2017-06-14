<%@ Page Language="C#" %>
<html>
<head>
  <title>Authentification</title>
</head>

<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    Response.Redirect("Home");
  }
</script>

<body>
  <h3>
    Veuillez vous déconnecter</h3>
  <asp:Label ID="Welcome" runat="server" />
  <form id="Form1" runat="server">
    <asp:Button ID="Submit1" OnClick="Signout_Click" 
       Text="Sign Out" runat="server" /><p>
  </form>
</body>
</html>