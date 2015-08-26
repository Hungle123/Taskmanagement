<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfomationUser.aspx.cs" Inherits="TaskProject.InfomationUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Data Building Infomation Users</h1>
    <h4>
        <asp:Literal runat="server" ID="ltError" />
    </h4>
    <br />
    <fieldset>
        <legend>Add New Infomation User</legend>
        <div  class="form-group">
            <label>Name: </label>
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Email: </label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
        </div>
        <div class="row">
            <asp:Button runat="server" ID="btnAddRow" Text="Add New User" CssClass="btn btn-danger" OnClick="btnAddRow_OnClick" />
        </div>
    </fieldset>
    <br />
    <div class="row  ">
        <asp:GridView runat="server" CssClass="table table-hover" ID="gvInfomationUser" DataKeyNames="UserID"
            OnRowEditing="InfomationUser_OnRowEditing" OnRowCancelingEdit="InfomationUser_OnRowCancelingEdit"
            OnRowUpdating="InfomationUser_OnRowUpdating" OnRowDeleting="InfomationUser_OnRowDeleting"
            AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="UserID">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdnUserID" Value='<%#DataBinder.Eval(Container.DataItem,"UserID")%>' />
                    </ItemTemplate>
                </asp:TemplateField>    
                <asp:BoundField DataField="Name" HeaderText="Name"  />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
