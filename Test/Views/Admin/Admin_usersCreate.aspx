<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Users>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin_usersCreate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <p>
        密码的长度至少为
        <%: ViewData["PasswordLength"] %>
        个字符。
    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true,"帐户创建不成功。请更正错误并重试。") %>

        <fieldset>
            <legend>Fields</legend>
 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PassWord) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PassWord) %>
                <%: Html.ValidationMessageFor(model => model.PassWord) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserType) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model=>model.UserType, (List<SelectListItem>)ViewData["listID"]) %>
                <%: Html.ValidationMessageFor(model => model.UserType) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Admin_users") %>
    </div>

</asp:Content>

