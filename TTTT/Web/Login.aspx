<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TTTT.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
    <h2>會員登入</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <hr>
    <form class="form-horizontal">
        <div class="form-group">    
            <label class="control-label col-sm-2" for="TextBox1">用戶名稱:</label>
            <div class="col-sm-10">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="輸入用戶名稱"></asp:TextBox>
            </div>
        </div>
         <div class="form-group">    
            <label2 class="control-label col-sm-2" for="TextBox2">密碼:</label2>
            <div class="col-sm-10">
            <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="輸入密碼"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">        
            <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="Button1" runat="server" Text="登入" class="btn btn-default" OnClick="Button1_Click" />
            </div>
        </div>


    </form>
</div>





</asp:Content>
