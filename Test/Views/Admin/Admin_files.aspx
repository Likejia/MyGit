<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.NewList<Test.Models.newUpLoadFiles>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin_files
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
    <h2>文件管理</h2>

    <table>
        <tr>
            <th>
                文件编号
            </th>
            <th>
                上传者
            </th>
            <th>
                课程名
            </th>
            <th>
                文件名
            </th>
            <th>
                上传时间
            </th>
            <th>
                下载次数
            </th>
        </tr>
        <%if (Model.Count <= 0)
          { %>
        <tr>
            <td colspan="6" style="text-align:center; height: 200px; width: 750px">
                暂时无课程审核记录！
            </td>
        </tr>
        <%} %>
        <%else
            { %>

    <% foreach (var item in Model) { %>
    
        <tr>
 
            <td>
                <%: item.UID  %>
            </td>
            <td>
                <%: item.UName%>
            </td>
            <td>
                <%:item.CName  %>
            </td>
            <td>
                <%=Html.ActionLink(item.FileName, "ReturnFile", "Admin",new {fileName =item.FileName},null) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.UploadTime) %>
            </td>
            <td>
                <%:item.DownloadCount%>
            </td>
             <td>
                <%: Html.ActionLink("Delete", "Admin_filesDelete", new { id=item.UID })%>
            </td>
        </tr>
    
    <% } %>

    </table>
      <%=Html.RouteLink("首页", "UpcomingFiles", new { page=0})%>|
    <%if (Model.HasPreviousPage)
      {%>
    <% =Html.RouteLink("上一页", "UpcomingFiles", new { page = (Model.PageIndex - 1) })%>|
    <%} %>
    <%if (Model.HasNextPage)
      { %>
    <%=Html.RouteLink("下一页", "UpcomingFiles", new { page = (Model.PageIndex + 1) })%>|
    <%} %>
    <%=Html.RouteLink("尾页", "UpcomingFiles", new { page = (Model.TotalPages - 1) })%>
       <%} %>

    <p>
        <%: Html.ActionLink("上传文件", "Admin_UpLoadFile") %>
    </p>

</asp:Content>

