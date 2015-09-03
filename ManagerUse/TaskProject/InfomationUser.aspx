<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfomationUser.aspx.cs" Inherits="TaskProject.InfomationUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="width: 722px">Data Building Infomation Users</h1>
    <h4 style="color: red">Message: 
        <asp:Literal runat="server" ID="ltError" />
    </h4>
    <br />
    <fieldset>
        <legend>Add New Infomation User</legend>
        <div class="form-group">
            <label>Name: </label>
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter name" />
            <asp:RequiredFieldValidator runat="server" ID="rqName"
                ControlToValidate="txtName" ErrorMessage="* Name is required" ValidationGroup="validateUser" Display="Dynamic" ForeColor="red" />
        </div>
        <div class="form-group">
            <label>Email: </label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Enter email" />
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ValidationGroup="validateUser"
                ErrorMessage="* Invalid Email Format"
                Display="Dynamic" ForeColor="red">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" ID="rqEmail"
                ValidationGroup="validateUser" ControlToValidate="txtEmail"
                ErrorMessage="* Email is requited" Display="Dynamic" ForeColor="red" />
        </div>
        <div class="form-group">
            <label>Password: </label>
            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" placeholder=" Enter Password" />
            <asp:RequiredFieldValidator runat="server" ID="rqPassword" ValidationGroup="validateUser" ErrorMessage="* Password do not match." ControlToValidate="txtPass"
                ForeColor="red" Display="Dynamic" />
            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPass"
                ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,8}$" runat="server"
                ErrorMessage="Maximum 8 characters allowed." ForeColor="red" ValidationGroup="validateUser"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label>Address: </label>
            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address" />
            <asp:RequiredFieldValidator runat="server" ID="rqAddress" ValidationGroup="validateUser" ControlToValidate="txtAddress" ErrorMessage="* Address is requited"
                ForeColor="red" Display="Dynamic" />
        </div>
        <div class="form-group">
            <label>Role: </label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRole" Width="280">
                <asp:ListItem Text="-- select --" Value="none" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqrole" runat="server" ControlToValidate="ddlRole"
                ErrorMessage="Value Required!" Display="Dynamic" ValidationGroup="validateUser" 
                ForeColor="red" InitialValue="none">
            </asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <asp:Button runat="server" ID="btnAddRow" Text="Add New User"
                ValidationGroup="validateUser" CssClass="btn btn-danger"
                OnClick="btnAddRow_OnClick" />
        </div>
    </fieldset>
    <br />
    <%--Begin view data--%>
    <div class="row  ">
        <asp:GridView runat="server" CssClass="table table-hover" ID="gvInfomationUser" DataKeyNames="UserID"
            OnRowEditing="InfomationUser_OnRowEditing" OnRowCancelingEdit="InfomationUser_OnRowCancelingEdit"
            OnRowUpdating="InfomationUser_OnRowUpdating" OnRowDeleting="InfomationUser_OnRowDeleting"
            AutoGenerateColumns="False" AllowPaging="True" PageSize="5" >
            <Columns>
                <asp:TemplateField HeaderText="UserID" SortExpression="UserID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbUserID" Text='<%#DataBinder.Eval(Container.DataItem,"UserID")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"/>
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"/>
                <asp:BoundField DataField="RoleID" HeaderText="Role" SortExpression="Role"/>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"/>
            </Columns>
        </asp:GridView>
        <%--end view data--%>
    </div>

</asp:Content>
