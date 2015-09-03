<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTaskManager.aspx.cs" Inherits="TaskProject.UserTaskManager" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Building Page Data Managerment</h1>
    <h4 style="color: red">Message :
        <asp:Literal runat="server" ID="ltMessage" />
    </h4>
    <div class="row">
        <div class="col-md-4">
            <div class="form-user-task">
                <fieldset>
                    <legend>Manager UserTask</legend>
                    <div class="form-group">
                        <label>User Name: </label>
                        <asp:DropDownList runat="server" ID="ddlUserName" CssClass="form-control" Width="280">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rqUserName" ControlToValidate="ddlUserName"
                            ErrorMessage="* UserName is not requited"
                            Display="Dynamic" ForeColor="red" ValidationGroup="validaUserTask" InitialValue="none">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Task Name: </label>
                        <asp:DropDownList runat="server" ID="ddlTaskName" CssClass="form-control" Width="280">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rqTaskUser" ControlToValidate="ddlTaskName"
                            ValidationGroup="validaUserTask" ErrorMessage="* TaskName is not requited"
                            Display="Dynamic" ForeColor="red" InitialValue="none">
                        </asp:RequiredFieldValidator>
                    </div>
                    <asp:Button runat="server" CssClass="btn btn-primary" ValidationGroup="validaUserTask" Text="Submit" ID="btnUserTask" OnClick="btnUserTask_OnClick" />
                    <br />
                </fieldset>
            </div>
        </div>
        <%--End col-md-4--%>

        <div class="col-md-8">
            <h4>View User Task Managermment</h4>
            <div class="view-data">
                <asp:GridView runat="server" ID="gvUserTask" CssClass="table table-hover"
                    OnRowEditing="gvUserTask_OnRowEditing" OnRowCancelingEdit="gvUserTask_OnRowCancelingEdit"
                    OnRowUpdating="gvUserTask_OnRowUpdating" OnRowDeleting="gvUserTask_OnRowDeleting"
                    AutoGenerateColumns="False" OnRowDataBound="gvUserTask_OnRowDataBound" 
                    OnPageIndexChanging="gvUserTask_OnPageIndexChanging"
                    PageSize="2" AllowPaging="True">
                    <Columns>
                        <%--Begin ID--%>
                        <asp:TemplateField HeaderText="ID" SortExpression="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbUserTask" Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--End ID--%>

                        <%--Begin UserID--%>
                        <asp:TemplateField HeaderText="UserID" SortExpression="UserID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbAddUserID" Text='<%#DataBinder.Eval(Container.DataItem,"UserID") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlUser_ID" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlUserID_OnSelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--end UserID--%>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />

                        <%--Begin TaskID--%>
                        <asp:TemplateField HeaderText="TaskID" SortExpression="TaskID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbAddTaskID" Text='<%#DataBinder.Eval(Container.DataItem,"TaskID") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlTask_ID" CssClass="form-control" runat="server"
                                    OnSelectedIndexChanged="ddlTask_ID_OnSelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <%--End TaskID--%>

                        <asp:BoundField DataField="TaskName" HeaderText="TaskName" ReadOnly="True" SortExpression="TaskName"/>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <%--end col-md-8--%>
    </div>
    <%--End row--%>
</asp:Content>
