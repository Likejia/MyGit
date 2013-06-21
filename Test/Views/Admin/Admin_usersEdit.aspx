<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Users>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin_usersEdit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin_usersEdit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
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
                <%: Html.DropDownList("Usertype")%>
                <%: Html.ValidationMessageFor(model => model.UserType) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Admin_users") %>
    </div>

</asp:Content>

