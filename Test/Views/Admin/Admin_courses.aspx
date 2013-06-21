<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.NewList<Test.Courses>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    课程管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="menucontainer">
        <ul id="menu">
            <li>
                <%= Html.ActionLink("用户管理", "Admin_users", "Admin")%></li>
            <li>
                <%= Html.ActionLink("课程管理", "Admin_courses", "Admin")%></li>
            <li>
                <%= Html.ActionLink("资料管理", "Admin_files", "Admin")%></li>
            <li>
                <%= Html.ActionLink("课程审核", "Admin_applyNewCourse", "Admin")%></li>
        </ul>
    </div>
    
    
    <h2>
        课程管理</h2>
    <table>
        <tr>
            <th>
                课程编号
            </th>
            <th>
                课程名
            </th>
            <th>
                授课老师
            </th>
            <th>
                标签
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: item.CID %>
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
            <td>
                <%: Html.ActionLink("Edit", "Admin_coursesEdit", new { id=item.CID }) %>
                |
                <%: Html.ActionLink("Delete", "Admin_coursesDelete", new { id=item.CID })%>
            </td>
        </tr>
        <% } %>
    </table>
        <hr />
    <%=Html.RouteLink("首页", "UpcomingCourses", new { page=0})%>|
    <%if (Model.HasPreviousPage)
      {%>
    <% =Html.RouteLink("上一页", "UpcomingCourses", new { page = (Model.PageIndex - 1) })%>|
    <%} %>
    <%if (Model.HasNextPage)
      { %>
    <%=Html.RouteLink("下一页", "UpcomingCourses", new { page = (Model.PageIndex + 1) })%>|
    <%} %>
    <%=Html.RouteLink("尾页", "UpcomingCourses", new { page = (Model.TotalPages - 1) })%>

</asp:Content>
