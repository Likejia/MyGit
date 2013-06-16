<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StudentSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.StudentMark>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <br /><br />
    <span style=" margin-top:30px; margin-left:140px; font-size:30px">
    <%foreach (var item in Model.student)
      { %>
      <%if (item.ID == Page.User.Identity.Name)
        { %>
        <%: item.Name %>同学:
      <% } %>
    <%} %>
    </span>

    <table style="font-size:20px; margin-left:400px; margin-top:40px">
    <% foreach (var item in Model.mark)
       { %>
       <% if (item.ID == Page.User.Identity.Name)
          { %>
          <tr ><td><strong>论文成绩：</strong><%:item.ThesisMark %>分</td></tr>
          <tr ><td><strong>答辩成绩：</strong><%:item.SpeechMark %>分</td></tr>
          <tr ><td><strong>总成绩：  </strong><%:item.SpeechMark+item.ThesisMark %>分</td></tr>
       <%} %>
    <%} %>
    </table>
</asp:Content>
