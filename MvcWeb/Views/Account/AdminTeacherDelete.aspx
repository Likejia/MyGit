﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.Teacher>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <h2>教师信息删除</h2>

    <h3>你确认删除该教师信息吗?</h3>
    <fieldset>
        <legend>信息</legend>
        
        <div class="display-label">编号</div>
        <div class="display-field"><%: Model.ID %></div>
                        
        <div class="display-label">名字</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">性别</div>
        <div class="display-field"><%: Model.Sex %></div>
        
        <div class="display-label">学院</div>
        <div class="display-field"><%: Model.Academic %></div>
        
        <div class="display-label">密码</div>
        <div class="display-field"><%: Model.Password %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" style="width: 95px; font-size:15px;" /> |
		    <%: Html.ActionLink("返回", "AdminTeacher") %>
        </p>
    <% } %>

</asp:Content>

