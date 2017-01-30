<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OrderManagement.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>

    
    <form id="form1" runat="server">
    <div>
    <asp:gridview ID="grvOrder" runat="server" AutoGenerateColumns="false" OnRowCommand="grvOrder_RowCommand" OnSelectedIndexChanged="grvOrder_SelectedIndexChanged">
        <Columns>
            <asp:BoundField  HeaderText="OrderId" DataField="OrderID"/>
            <asp:BoundField  HeaderText="ProductName" DataField="ProductName"/>
            <asp:BoundField  HeaderText="Order Date" DataField="OrderDate"/>
           <asp:TemplateField>
               <ItemTemplate>
                   <asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandName="cmdEdit" CommandArgument='<%#Eval("OrderID") %>'/>
               </ItemTemplate>
           </asp:TemplateField>
             <asp:TemplateField>
               <ItemTemplate>
                   <asp:Button ID="btnDelete" runat="server" Text="delte"  CommandName="cmdDelete" CommandArgument='<%#Eval("OrderID") %>'/>
               </ItemTemplate>
           </asp:TemplateField>
        </Columns>

    </asp:gridview>
    </div>
    </form>
</body>
</html>
