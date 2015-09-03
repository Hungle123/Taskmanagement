<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDataRepository.aspx.cs" Inherits="TaskProject.TaskDataRepository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Data Building Tasks Managermant</h1>
    <h4 style="color: rgb(255, 0, 0)">Message:  
        <asp:Literal runat="server" ID="ltError" />
    </h4>
    <div class="row">
        <div class="col-md-4">
            <div class="form-task">
                <fieldset>
                    <legend>Add New Task</legend>
                    <div class="form-group">
                        <label>Task Name: </label>
                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter Task name" />
                        <asp:RequiredFieldValidator runat="server" ID="rqName" ValidationGroup="insertTask" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage=" * Name is required."  Display="Dynamic" />
                    </div>
                    <div class="form-group">
                        <label>Description: </label>
                        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" Width="280" runat="server" CssClass="form-control" placeholder="Do something ..." />
                        <asp:RequiredFieldValidator runat="server" ID="rqDescription" ValidationGroup="insertTask" ControlToValidate="txtDescription" CssClass="text-danger" ErrorMessage=" * Description is required." Display="Dynamic" />
                    </div>
                    <div class="form-group">
                        <label>Task Type: </label>
                        <asp:DropDownList ID="ddlType" runat="server" Width="280" CssClass="form-control" data-style="btn-info">
                            <asp:ListItem Value="none" Selected="True" Text="-- select --"></asp:ListItem>
                            <asp:ListItem Value="1">Bug</asp:ListItem>
                            <asp:ListItem Value="2">Feature</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqType" runat="server" ControlToValidate="ddlType"
                            ErrorMessage="Value Required!" Display="Dynamic" ValidationGroup="insertTask" CssClass="text-danger" InitialValue="none">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>State Type: </label>
                        <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" data-style="btn-primary" Width="280">
                            <asp:ListItem Text="-- select --" Selected="True" Value="none"></asp:ListItem>
                            <asp:ListItem Value="1">To Do</asp:ListItem>
                            <asp:ListItem Value="2">Doing</asp:ListItem>
                            <asp:ListItem Value="3">Done</asp:ListItem>
                            <asp:ListItem Value="4">Tested</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqState" runat="server" ControlToValidate="ddlState"
                            ErrorMessage="Value Required!" Display="Dynamic" ValidationGroup="insertTask" CssClass="text-danger" InitialValue="none">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Complate Type: </label>
                        <asp:TextBox runat="server" ID="txtComplate" CssClass="form-control" placeholder="Enter % complate" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="insertTask" ID="rqComplate" ControlToValidate="txtComplate"  ErrorMessage=" * Complate is required" Display="Dynamic" CssClass="text-danger" />
                        <asp:RangeValidator runat="server" ValidationGroup="insertTask" ControlToValidate="txtComplate" ID="rvComplate" Type="Integer" CssClass="text-danger" MinimumValue="1" MaximumValue="100" ErrorMessage=" * Please enter fild Complate again." Display="Dynamic" />
                    </div>
                    <br />
                    <asp:Button runat="server" ValidationGroup="insertTask" CssClass="btn btn-primary" Text="Add New Task" ID="btnTask" OnClick="btnTask_OnClick" />
                </fieldset>
            </div>
        </div>
        <div class="col-md-8" style="margin-top: 5px;">
            <h4>View Data Task
            </h4>
            <asp:GridView runat="server" ID="gvTaskRepository" CssClass="table table-hover" DataKeyNames="TaskID"
                OnRowEditing="gvTaskRepository_OnRowEditing" OnRowCancelingEdit="gvTaskRepository_OnRowCancelingEdit"
                OnRowUpdating="gvTaskRepository_OnRowUpdating" OnRowDeleting="gvTaskRepository_OnRowDeleting"
                AutoGenerateColumns="False" AllowSorting="True" OnSorting="gvTaskRepository_OnSorting">
                <Columns>
                    <asp:TemplateField HeaderText="taskID" SortExpression="taskID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTaskID" Text='<%#DataBinder.Eval(Container.DataItem,"TaskID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name"/>
                    <asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description" />
                    <asp:BoundField HeaderText="Type" DataField="Type" SortExpression="Type"/>
                    <asp:BoundField HeaderText="State" DataField="State" SortExpression="State" />
                    <asp:BoundField HeaderText="Complate" DataField="ComplatedPercent" SortExpression="ComplatedPercent" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
