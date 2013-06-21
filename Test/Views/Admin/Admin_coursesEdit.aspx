<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Courses>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin_coursesEdit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>课程信息修改</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CName) %>
                <%: Html.ValidationMessageFor(model => model.CName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Teacher) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Teacher) %>
                <%: Html.ValidationMessageFor(model => model.Teacher) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Flag) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Flag) %>
                <%: Html.ValidationMessageFor(model => model.Flag) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Admin_courses") %>
    </div>

</asp:Content>

