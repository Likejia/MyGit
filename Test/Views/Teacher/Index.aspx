<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Courses>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="menucontainer">
        <ul id="menu">
            <li>
                <%= Html.ActionLink("开课列表", "Index", "Teacher")%></li>
            <li>
                <%= Html.ActionLink("上传资料", "UpLoadFile", "Student")%></li>
            <li>
                <%= Html.ActionLink("审核论文", "AuI", "Teacher")%></li>
            <li>
                <%= Html.ActionLink("下载资料", "DownLoadFile", "Student")%></li>
        </ul>
    </div>
    <h2>开课列表</h2>

    <table>
        <tr>
            <th></th>
<%--            <th>
                CID
            </th>--%>
            <th>
                CName
            </th>
            <th>
                Teacher
            </th>
            <th>
                Flag
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
<%--            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.CID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.CID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.CID })%>
            </td>--%>
            <td>
               <%-- <%: item.CID %>--%>
            </td>
            <td>
                <%: item.CName %>
            </td>
            <td>
                <%: item.Teacher %>
            </td>
            <td>
                <%: item.Flag %>
            </td>
        </tr>
    
    <% } %>

    </table>

<%--    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>--%>

</asp:Content>

