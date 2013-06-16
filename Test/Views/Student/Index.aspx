<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.NewSelCourse>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%:ViewData["Message"] %>
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
        我的选课信息</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                已选的课程
            </th>
            <th>
                任课教师
            </th>
            <th>
                课程分类标签
            </th>
            <th>
                选课时间
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
            </td>
            <td>
                <%:item.CName%>
            </td>
            <td>
                <%: item.Teacher %>
            </td>
            <td>
                <%: item.Flag %>
            </td>
            <td>
                <%: @String.Format("{0:d}", item.Seltime) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
