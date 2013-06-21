<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.NewList<Test.Models.newapplyNewCourse>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin_applyNewCourse
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
        课程审核</h2>
    <table border="1" cellpadding="5" cellspacing="0" style="border: thin solid #0066FF;
                                border-spacing: 0px; empty-cells: show; table-layout: auto; width :750px">
        <tr>
            <th style="width:128px">
                待审核课程编号
            </th style="width:120px">
            <th>
                申请者
            </th>
            <th>
                课程名
            </th>
            <th>
                申请时间
            </th>
        </tr>
        <%if (Model.Count <= 0)
          { %>
        <tr>
            <td colspan="4" style="text-align:center; height: 200px; width: 100%">
                暂时无课程审核记录！
            </td>
        </tr>
        <%} %>
        <%else
            { %>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: item.AI%>
            </td>
            <td>
                <%: item.applyerName%>
            </td>
            <td>
                <%: item.courseName%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.applyTime)%>
            </td>
            <td>
                <%: Html.ActionLink("Pass", "Pass", new { id = item.AI })%>
                |
                <%: Html.ActionLink("Delete", "applyNewCourseDelete", new { id = item.AI })%>
            </td>
        </tr>
        <% } %>
    </table>
    <%=Html.RouteLink("首页", "UpcomingNewCourse", new { page=0})%>|
    <%if (Model.HasPreviousPage)
      {%>
    <% =Html.RouteLink("上一页", "UpcomingNewCourse", new { page = (Model.PageIndex - 1) })%>|
    <%} %>
    <%if (Model.HasNextPage)
      { %>
    <%=Html.RouteLink("下一页", "UpcomingNewCourse", new { page = (Model.PageIndex + 1) })%>|
    <%} %>
    <%=Html.RouteLink("尾页", "UpcomingNewCourse", new { page = (Model.TotalPages - 1) })%>
    <%} %>
</asp:Content>
