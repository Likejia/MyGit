<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.MangerReModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MangerRe
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        MangerRe</h2>

    <%:ViewData["Message"] %>
    <% using (Html.BeginForm())
       { %>
            筛选器：
            <%=Html.DropDownListFor(m=>m.ElementAt(0).Fitter,  (List<SelectListItem>)ViewData[ "fitter"])%>
            <input type="submit" name="Submit" id="Submit1" value="确定" />
    <% } %>

    <p></p>

    <table>
        <tr>
            <th>
            </th>
            <th>
                资料名称
            </th>
            <th>
                上传时间
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Delete", "Delete","Student", new { id=item.UID ,fitter = item.Fitter },null)%>
            </td>
            <td>
                <%: item.FName %>
            </td>
            <td>
                <%:  @String.Format("{0:d}", item.Updatetime) %>
            </td>
        </tr>
        <% } %>

    </table>
</asp:Content>
