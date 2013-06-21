<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.NewList<Test.Users>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin_users
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
        用户管理</h2>
    <table>
        <tr>
            <th>
                用户编号
            </th>
            <th>
                用户名
            </th>
            <th>
                密码
            </th>
            <th>
                用户类型
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.PassWord %>
            </td>
            <td>
                <%: item.UserType %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Admin_usersEdit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Admin_usersDelete", new { id=item.ID })%>
            </td>
        </tr>
        <% } %>
    </table>
    <hr />
    <%=Html.RouteLink("首页", "UpcomingUsers", new { page = 0 })%>|
    <%if (Model.HasPreviousPage)
      {%>
    <% =Html.RouteLink("上一页", "UpcomingUsers", new { page = (Model.PageIndex - 1) })%>|
    <%} %>
    <%if (Model.HasNextPage)
      { %>
    <%=Html.RouteLink("下一页", "UpcomingUsers", new { page=(Model.PageIndex+1)})%>|
    <%} %>
    <%=Html.RouteLink("尾页", "UpcomingUsers", new { page=(Model.TotalPages-1)})%>
    <p>
        <%: Html.ActionLink("Create New", "Admin_usersCreate") %>
    </p>
</asp:Content>
