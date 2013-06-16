﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWeb.Models.Teacher>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <table style="margin-top:30px;width:700px" align="center">
        <tr style="font-family:@黑体; font-size:20px;  height:30px; background-color:#F5DEB3" align="center" valign="middle">
            <td>学号</td>
            <td>姓名</td>
            <td>密码</td>
            <td>性别</td>
            <td>学院</td>
            <td>操作</td>
        </tr>

        

    <% foreach (var item in Model) { %>
    
        <tr align="center">
            
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Password %>
            </td>
            <td>
                <%: item.Sex %>
            </td>
            <td>
                <%: item.Academic %>
            </td>
            <td>
                <%: Html.ActionLink("更新", "AdminTeacherEdit", new { id=item.ID }) %> |
                <%: Html.ActionLink("删除", "AdminTeacherDelete", new { id=item.ID })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p style="margin-left:200px">
        <%: Html.ActionLink("创建", "AdminTeacherCreate") %>
    </p>

</asp:Content>

