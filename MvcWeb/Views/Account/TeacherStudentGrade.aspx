<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TeacherSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.StudentMark>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <p style="margin-top:30px; margin-left:100px">
        <span style="font-size:30px; font-family:@隶书; color:Black; margin-left:50px">学生成绩查询</span>
        <hr style="background-color:Red; margin-right:100px;width: 900px;" /><br />
        <span style="margin-left:180px; font-size:20px">专业：</span> <span style="height:40px; font-size:20px"><%=Html.DropDownListFor(model => Model.major, ViewData["Major"] as IEnumerable<SelectListItem>)%></span> 
        <span style="margin-left:100px; font-size:20px">年级：</span> <span style="height:40px; font-size:20px"><%=Html.DropDownListFor(model => Model.grade, ViewData["Grade"] as IEnumerable<SelectListItem>)%></span>
        <span style="margin-left:100px"></span><input type="submit" id="submit" value="确 定" style="width:150px; height:30px; font-size:20px" />
    </p>


    <table style="margin-top:30px;width:700px" align="center">
        <tr style="font-family:@黑体; font-size:20px;  height:30px; background-color:#F5DEB3" align="center" valign="middle">
            <td>学号</td>
            <td>姓名</td>
            <td>学院</td>
            <td>专业</td>
            <td>年级</td>
            <td>论文成绩</td>
            <td>答辩成绩</td>
            <td>总成绩</td>
        </tr>

        <% foreach (var item in Model.student) { %>
    
        <tr align="center" style="">            
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Academic %>
            </td>
            <td>
                <%: item.Major %>
            </td>
            <td>
                <%: item.Grade %>
            </td>
            <% foreach (var it in Model.mark)
               { %>
               <% if( it.ID == item.ID ){ %>
               <td>
                <%: it.ThesisMark %>
               </td>
               <td>
                <%: it.SpeechMark %>
               </td>
               <td>
                <%: (it.ThesisMark + it.SpeechMark) %>
               </td>
            <%} }%>
        </tr>
    
    <% } %>

    </table>

</asp:Content>
