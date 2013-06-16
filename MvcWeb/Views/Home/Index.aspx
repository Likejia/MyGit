<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcWeb.Models.LogOnModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>暨南大学毕业论文与答辩管理系统</title>
    <link rel="Stylesheet" type="text/css" href="../../Content/Site.css" />
</head>

<body style="background-image:url(https://raw.github.com/hujialin/Hujialin/master/MvcWeb/Content/image/LoginBack.jpg)">
    <form id="form1" runat="server">
    
    <table id="table1" border="0" style=" width:100%; height:100%;" cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td align="center" valign="middle">         
                    <table id="Table2" border="4" cellpadding="0" cellspacing="0" 
                        style=" background-image:url(https://raw.github.com/hujialin/Hujialin/master/MvcWeb/Content/image/LoginBack.jpg);border-color:#80C4DE; margin-top:100px; height:300px; width:500px;">                      
                        <tbody>                                               
                            <tr>
                                <td colspan="4" style=" height:10%; border:0" ></td>
                            </tr>
                                                    
                            <tr>                               
                                <td colspan="4" style=" border:0; height:55px;" align="center"  >                               
                                    <img alt="TopicImage" src="https://raw.github.com/hujialin/Hujialin/master/MvcWeb/Content/image/top.jpg" />                                    
                                    <hr style="margin-left:35px; margin-right:35px; background-color:#FAFAD2; width: 435px;" />
                                </td>                              
                            </tr>
                            
                            <tr>
                                <td colspan="4" style="border:0; height:20px"></td>                            
                            </tr>   

                            <%using (Html.BeginForm())
                              { %>                   
                            <tr>                            
                                <td style="width:100px;border:0;"></td>
                                <td style="border:0; width:35%; font-size:20px;" align="right" >                         
                                    <div class="login-label">
                                       <%=Html.LabelFor(model=>model.UserName) %>
                                    </div> 
                                </td>
                                <td style="border:0; height:20px;">
                                  
                                   <div class="login-textbox">                                       
                                      <%=Html.TextBoxFor(model=>model.UserName) %>
                                   </div>                                   
                                </td>
                                                               
                            </tr>

                            <tr>
                                <td colspan="4" style=" height:10px; border:0" ></td>
                            </tr> 
                             
                            <tr>
                                <td style="width:100px;border:0;"></td>
                                <td style="border:0; width:35%; font-size:20px;" align="right" >                         
                                    <div class="login-label">
                                        <%=Html.LabelFor(model=>model.Password) %>
                                    </div>
                                </td>
                                <td style="border:0; height:20px;">
                                   <div class="login-textbox">
                                        <%=Html.TextBoxFor(model=>model.Password) %>                                     
                                   </div>                                  
                                </td>                                
                            </tr>

                            <tr>
                                <td colspan="4" style="border:0; height:20px;">                                  
                                </td>
                            </tr>
                                                    
                            <tr>
                                <td style="width:100px;border:0;"></td>
                                <td style="border:0; width:35%"></td>
                                <td style="border:0; height:20px;"> 
                                    <span style="margin-left:134px">
                                        <input class="login-button" type="submit" value="Login"  />
                                    </span>
                                </td>                                                              
                            </tr>
                            <%} %>
                            <tr>
                                <td colspan="4" style="border:0; height:30%;"></td>                                                                                                                            
                            </tr>                                                                                                                                 
                        </tbody>                        
                    </table>                    
                </td>
            </tr>           
        </tbody>
    </table>    
  </form>
</body>
</html>
