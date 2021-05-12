<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="TTTT.Web.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="productDetail" runat="server" ItemType="TTTT.Modles.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <div>
                            <h1><%#:Item.ProductName %></h1>
                        </div>
                        
                        <br />
                        <span><h3>價格:&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></h3></span>
                        <br />
                        <br />
                        <a href="AddToCart.aspx?productID=<%#:Item.ProductID %>"><asp:Label ID="Label1" runat="server" class="btn btn-default" text="下單" />
                        <br />

                    </td>
                </tr>
            </table>

            <ul class="nav nav-tabs">
                <li class=""><a href="#home" data-toggle="tab" aria-expanded="false">商品介紹</a></li>
                <li class="active"><a href="#profile" data-toggle="tab" aria-expanded="true">Q&A</a></li>
            </ul>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade" id="home">
                    <b>Description:</b><br /><%#:Item.Description %></div>
                <div class="tab-pane fade active in" id="profile">
                    <p> farm-tomo nostrud bore aesthetic magna delectus mollit.</p>
                </div>
            </div>




        </ItemTemplate>
    </asp:FormView>


</asp:Content>
