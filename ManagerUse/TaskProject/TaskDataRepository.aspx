<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDataRepository.aspx.cs" Inherits="TaskProject.TaskDataRepository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Data Building Tasks Managermant</h1>
    <h4 style="color:rgb(255, 0, 0)">
        Message:   <asp:Literal runat="server" ID="ltError" />
    </h4>
    <div class="row">
        <div class="col-md-4">
            <div class="form-task">
                <fieldset>
                    <legend>Add New Task</legend>
                    <div class="form-group">
                        <label>Task Name: </label>  
                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                        <%--<asp:RequiredFieldValidator runat="server" ID="rqName" ControlToValidate="txtName" ForeColor="red" ErrorMessage="* Name is required." CssClass="bg-error" Display="Dynamic" />--%>
                    </div>
                    <div class="form-group">
                        <label>Description: </label>
                        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" Width="280" runat="server" CssClass="form-control" />
                        <%--<asp:RequiredFieldValidator runat="server" ID="rqDescription" ControlToValidate="txtDescription" ForeColor="red" ErrorMessage="* Description is required." Display="Dynamic" />--%>
                    </div>
                    <div class="form-group">
                        <label>Task Type: </label>
                        <asp:TextBox runat="server" ID="txtType" CssClass="form-control" />
                        <%--<asp:RequiredFieldValidator runat="server" ID="rqType" ControlToValidate="txtType" ErrorMessage=" * Type is required" Display="Dynamic" ForeColor="red" CssClass="bg-error" />--%>
                        <%--<asp:RangeValidator runat="server" ControlToValidate="txtType" ID="rvType" Type="Integer" ForeColor="red" MinimumValue="1" MaximumValue="200" ErrorMessage="Please enter Type again." Display="Dynamic" />--%>
                    </div>
                    <div class="form-group">
                        <label>State Type: </label>
                        <asp:TextBox runat="server" ID="txtState" CssClass="form-control" />
                        <%--<asp:RequiredFieldValidator runat="server" ID="rqState" ControlToValidate="txtComplate" ForeColor="red" ErrorMessage=" * State is required" Display="Dynamic" CssClass="bg-error" />--%>
                        <%--<asp:RangeValidator runat="server" ControlToValidate="txtState" ID="rvState" Type="Integer" ForeColor="red" MinimumValue="1" MaximumValue="200" ErrorMessage="Please enter fild State again." Display="Dynamic" />--%>
                    </div>
                    <div class="form-group">
                        <label>Complate Type: </label>
                        <asp:TextBox runat="server" ID="txtComplate" CssClass="form-control" />
                        <%--<asp:RequiredFieldValidator runat="server" ID="rqComplate" ControlToValidate="txtComplate" ForeColor="red" ErrorMessage=" * Complate is required" Display="Dynamic" CssClass="bg-error" />--%>
                        <%--<asp:RangeValidator runat="server" ControlToValidate="txtComplate" ID="rvComplate" Type="Integer" ForeColor="red" MinimumValue="1" MaximumValue="200" ErrorMessage="Please enter fild Complate again." Display="Dynamic" />--%>
                    </div>
                    <br />
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Add New Task" ID="btnTask" OnClick="btnTask_OnClick" />
                </fieldset>
            </div>
        </div>
        <div class="col-md-8" style="margin-top: 5px;">
            <h4>
                View Data Task
            </h4>
            <asp:GridView runat="server" ID="gvTaskRepository" CssClass="table table-hover" DataKeyNames="TaskID"
                OnRowEditing="gvTaskRepository_OnRowEditing" OnRowCancelingEdit="gvTaskRepository_OnRowCancelingEdit"
                OnRowUpdating="gvTaskRepository_OnRowUpdating" OnRowDeleting="gvTaskRepository_OnRowDeleting"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdnTaskID" Value='<%#DataBinder.Eval(Container.DataItem,"TaskID")%>' />
                    </ItemTemplate>
                </asp:TemplateField> 
                    <asp:BoundField HeaderText="Name" DataField="Name"/>
                    <asp:BoundField HeaderText="Description" DataField="Description"/>
                    <asp:BoundField HeaderText="Type" DataField="Type"/>
                    <asp:BoundField HeaderText="State" DataField="State"/>
                    <asp:BoundField HeaderText="Complate" DataField="ComplatedPercent"/>
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True"/>
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
