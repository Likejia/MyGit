<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        欢迎进入，<b><%: Page.User.Identity.Name %></b>！
        <%--[ <%: Html.ActionLink("Log Off", "LogOff", "Account") %> ]--%>
<%
    }
    
%> 
       