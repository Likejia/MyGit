<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TeacherSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.ThesisCheck>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
 
    <br /><br />
    <% using (Html.BeginForm()) {%>
        
        <fieldset>
            <legend><strong>审阅成绩修改</strong></legend>
       
            <div class="display-label" style="font-size:20px"><strong>论题（20分制）</strong></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Topic) %>
            </div>
            
            <div class="display-label" style="font-size:20px"><strong>文献（20分制）</strong></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Literature) %>
            </div>
            
            <div class="display-label" style="font-size:20px"><strong>研究能力（20分制）</strong></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ResearchCapacity) %>
            </div>

            <div class="display-label" style="font-size:20px"><strong>论文质量（20分制）</strong></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThesisQuality) %>
            </div>

            <div class="display-label" style="font-size:20px"><strong>创新能力（20分制）</strong></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.InnovationCapacity) %>
            </div>
            <p>
                <input type="submit" value="保存" />
            </p>
        </fieldset>

    <% } %>
    <br />
    <div>
        <%: Html.ActionLink("返回", "TeacherThesisCheck", "Account")%>
    </div>

</asp:Content>

