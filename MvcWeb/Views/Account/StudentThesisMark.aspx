<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StudentSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.StudentThesis>" %>

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
    <% foreach (var item in Model.check)
       { %>
       <% if (item.ID == Page.User.Identity.Name)
          { %>
          <tr ><td><strong>论题分数：</strong><%:item.Topic %>分</td></tr>
          <tr ><td><strong>文献分数：</strong><%:item.Literature %>分</td></tr>
          <tr ><td><strong>研究能力分数：</strong><%:item.ResearchCapacity %>分</td></tr>
          <tr ><td><strong>论文质量分数：</strong><%:item.ThesisQuality %>分</td></tr>
          <tr ><td><strong>创新能力分数：</strong><%:item.InnovationCapacity %>分</td></tr>
          <tr ><td><strong>总分：</strong><%:item.Topic+item.InnovationCapacity+item.Literature+item.ResearchCapacity+item.ThesisQuality %>分</td></tr>
       <%} %>
    <%} %>
    </table>

</asp:Content>
