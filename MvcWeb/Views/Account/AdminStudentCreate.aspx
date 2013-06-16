<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.Student>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <h2>学生信息创建</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>学生信息</legend>
            
            <div class="editor-label">
                学号
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ID) %>
            </div>
            
            <div class="editor-label">
                密码
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                名字
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                性别
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sex) %>
            </div>
            
            <div class="editor-label">
                学院
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Academic) %>
            </div>
            
            <div class="editor-label">
                专业
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Major) %>
            </div>
            
            <div class="editor-label">
                年级
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Grade) %>
            </div>
            
            <p>
                <input type="submit" value="创建" style="width: 95px; font-size:15px;" />
            </p>
        </fieldset>

    <% } %>
    <br />
    <div>
        <%: Html.ActionLink("返回", "AdminStudent") %>
    </div>

</asp:Content>

