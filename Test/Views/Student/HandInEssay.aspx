<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.HandInEssayModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    HandInEssay
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="menucontainer">
        <ul id="menu">
            <li>
                <%= Html.ActionLink("资料管理", "MangerRe", "Student")%></li>
            <li>
                <%= Html.ActionLink("上传资料", "UpLoadFile", "Student")%></li>
            <li>
                <%= Html.ActionLink("上交论文", "HandInEssay", "Student")%></li>
            <li>
                <%= Html.ActionLink("下载资料", "DownLoadFile", "Student")%></li>
        </ul>
    </div>
    <h2>
        HandInEssay</h2>
    <% using (Html.BeginForm("HandInEssay", "Student", FormMethod.Post, new { enctype = "multipart/form-data" }))
       { %>
    <%= Html.ValidationSummary(true, "上传失败。请更正错误并重试。") %>
    <div>
        <fieldset>
            <input id="File2" type="file" name="FileUpload1" /><br />
            <div class="editor-label">
                <%= Html.LabelFor(m => m.CName) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(m => m.CName, (List<SelectListItem>)ViewData["CourseName"])%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(m => m.Teacher) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(m => m.Teacher, (List<SelectListItem>)ViewData["TeacherName"])%>
            </div>
            <p>
            </p>
            <input type="submit" name="Submit" id="Submit1" value="Upload" />
        </fieldset>
    </div>
    <% } %>
</asp:Content>
