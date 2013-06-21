<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.UpLoadFile>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DownLoadFile
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
        DownLoadFile</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                文件名
            </th>
            <th>
                上传时间
            </th>
            <th>
                已经下载的次数
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
            </td>
            <td>
                <%= Html.ActionLink(item.FileName, "ReturnFile", "Student", new { filename = item.FileName,furl =item.FUrl },null)%>
            </td>
            <td>
                <%: @String.Format("{0:d}", item.UpLoadTime) %>
            </td>
            <td>
                <%: item.DownLoadCount %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
