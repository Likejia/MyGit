<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.AuIModels>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AuI
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

    <h2>审核论文</h2>

    <table>
        <tr>
            <th></th>
            <th>
                学生姓名
            </th>
            <th>
                论文名
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("通过审核", "PassAuI",  "Teacher", new { username = item.stuname,furl =item.fUrl ,auid = item.auid ,filename = item.filename },null)%>
                
            </td>
            <td>
                <%: item.stuname %>
            </td>
            <td>
                 <%: Html.ActionLink(item.filefrontname, "ReturnFile",  "Teacher", new { filename = item.filename },null)%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

