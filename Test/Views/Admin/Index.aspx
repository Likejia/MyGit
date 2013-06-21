<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
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

    <table>
        <tr>
            <td style="width: 450px; vertical-align: top;">
                <table>
                    <tr>
                        <td>
                            <table border="1" cellpadding="5" cellspacing="0" style="border: thin solid #0066FF;
                                border-spacing: 0px; empty-cells: show; table-layout: auto;">
                                <tr>
                                    <td colspan="4" style="font-family: 华文行楷; background-color: #6666FF;">
                                        用户管理
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 72px;">
                                        用户编号
                                    </th>
                                    <th style=" width: 72px;">
                                        用户名
                                    </th>
                                    <th >
                                        密码
                                    </th>
                                    <th >
                                        用户类别
                                    </th>
                                </tr>
                                <% foreach (var item in ((List<Test.Users>)ViewData["users"]))
                                   { %>
                                <tr>
                                    <td >
                                        <%=item.ID %>
                                    </td>
                                    <td >
                                        <%=item.Name %>
                                    </td>
                                    <td >
                                        <%=item.PassWord %>
                                    </td>
                                    <td >
                                        <%=item.UserType %>
                                    </td>
                                </tr>
                                <% } %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="1" cellpadding="5" cellspacing="0" style="border: thin solid #0066FF;
                                border-spacing: 0px; empty-cells: show; table-layout: auto;">
                                <tr>
                                    <td colspan="4" style="font-family: 华文行楷; background-color: #6666FF;">
                                        课程管理
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        课程编号
                                    </td>
                                    <td>
                                        课程名
                                    </td>
                                    <td>
                                        开课老师
                                    </td>
                                    <td>
                                        标签
                                    </td>
                                </tr>
                                <%foreach (var item in ((List<Test.Courses>)ViewData["courses"]))
                                  { %>
                                <tr>
                                    <td>
                                        <%=item.CID%>
                                    </td>
                                    <td>
                                        <%=item.CName %>
                                    </td>
                                    <td>
                                        <%=item.Teacher %>
                                    </td>
                                    <td>
                                        <%=item.Flag %>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 750px; vertical-align: top;">
                <table>
                    <tr>
                        <td>
                            <table border="1" cellpadding="5" cellspacing="0" style="border: thin solid #0066FF;
                                border-spacing: 0px; empty-cells: show; table-layout: auto;">
                                <tr>
                                    <td colspan="7"style="font-family: 华文行楷; background-color: #6666FF;">
                                        资料管理
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:82px; text-align:center; " >
                                        文件编号
                                    </td>
                                    <td style="width: 64px; text-align:center;">
                                        上传者
                                    </td>
                                    <td style="width: 128px; text-align:center;">
                                        课程名
                                    </td>
                                    <td style="width: 256px; text-align:center;">
                                        文件名
                                    </td>
                                    <td style="width: 128px; text-align:center;">
                                        上传时间
                                    </td>
                                    <td style="width: 82px; text-align:center;">
                                        下载次数
                                    </td>
                                </tr>
                                <%if (((List<Test.Models.newUpLoadFiles>)ViewData["files"]).Count == 0)
                                  { %>
                                <tr>
                                    <td colspan="6" style="text-align: center; height: 200px; width: 100%">
                                        暂时无上传文件记录!
                                    </td>
                                </tr>
                                <%} %>
                                <%else
                                    {%>
                                <%foreach (var item in ((List<Test.Models.newUpLoadFiles>)ViewData["files"]))
                                  {%>
                                <tr>
                                    <td>
                                        <%=item.UID%>
                                    </td>
                                    <td>
                                        <%=item.UName%>
                                    </td>
                                    <td>
                                        <%=item.CName%>
                                    </td>
                                    <td>
                                        <%=item.FileName%>
                                    </td>
                                    <td>
                                        <%:String.Format("{0:g}", item.UploadTime)%>
                                    </td>
                                    <td>
                                        <%=item.DownloadCount%>
                                    </td>
                                </tr>
                                <%} %>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="1" cellpadding="5" cellspacing="0" style="border: thin solid #0066FF;
                                border-spacing: 0px; empty-cells: show; table-layout: auto; width:750px" >
                                <tr>
                                    <td  colspan="4" style="font-family: 华文行楷; background-color: #6666FF;">
                                        课程审核
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        课程ID
                                    </td>
                                    <td>
                                        申请者
                                    </td>
                                    <td>
                                        课程名
                                    </td>
                                    <td>
                                        申请时间
                                    </td>
                                </tr>
                                <%if (((List<Test.Models.newapplyNewCourse>)ViewData["applyNewCourses"]).Count == 0)
                                  {%>
                                <tr>
                                    <td colspan="4" style="text-align: center; height: 200px; width: 100%">
                                        暂时无课程审核记录!
                                    </td>
                                </tr>
                                <%} %>
                                <%else
                                    { %>
                                <%foreach (var item in ((List<Test.Models.newapplyNewCourse>)ViewData["applyNewCourses"]))
                                  { %>
                                <tr>
                                    <td>
                                        <%=item.AI %>
                                    </td>
                                    <td>
                                        <%=item.applyerName %>
                                    </td>
                                    <td>
                                        <%=item.courseName %>
                                    </td>
                                    <td>
                                        <%=item.applyTime %>
                                    </td>
                                </tr>
                                <%} %>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
