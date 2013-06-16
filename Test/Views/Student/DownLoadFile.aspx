<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.UpLoadFile>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DownLoadFile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
               <%= Html.ActionLink(item.FileName, "ReturnFile", "Student", new { filename = item.FileName },null)%>
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
