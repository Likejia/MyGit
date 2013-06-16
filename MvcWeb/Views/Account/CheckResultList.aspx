<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TeacherSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.StudentThesis>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <%foreach (var item in Model.student)
      { %>
        <%if (Model.ID == item.ID)
          {%>
          <span style="font-size:20px; font-family:@华文隶书"><strong><%: item.Name %>同学</strong></span>
        <%} %>
    <%} %>
    <br /><br />
    <fieldset>
        <legend><strong>审阅记录</strong></legend>

    <%foreach (var item in Model.check)
      { %>
        <%if (Model.ID == item.ID)
          {%>          
        <br />
        <div class="display-label" style="font-size:20px"><strong>论题（20分制）</strong></div>
        <div class="display-field" style=" margin-left:40px; margin-top:4px; font-size:20px"><%: item.Topic %>分</div>
        <br />
        <div class="display-label" style="font-size:20px"><strong>文献（20分制）</strong></div>
        <div class="display-field" style=" margin-left:40px; margin-top:4px; font-size:20px"><%: item.Literature %>分</div>
        <br />
        <div class="display-label" style="font-size:20px"><strong>研究能力（20分制）</strong></div>
        <div class="display-field" style=" margin-left:40px; margin-top:4px; font-size:20px"><%: item.ResearchCapacity %>分</div>
        <br />
        <div class="display-label" style="font-size:20px"><strong>论文质量（20分制）</strong></div>
        <div class="display-field" style=" margin-left:40px; margin-top:4px; font-size:20px"><%: item.ThesisQuality %>分</div>
        <br />
        <div class="display-label" style="font-size:20px"><strong>创新能力（20分制）</strong></div>
        <div class="display-field" style=" margin-left:40px; margin-top:4px; font-size:20px"><%: item.InnovationCapacity %>分</div>
    <%} %>
    <%} %>   
    </fieldset>
    <p>
        <%: Html.ActionLink("编辑", "CheckResultEdit", new { id = Model.ID }) %> |
        <%: Html.ActionLink("返回", "TeacherThesisCheck") %>
    </p>
    
</asp:Content>

