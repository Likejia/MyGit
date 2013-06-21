using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Test
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


                routes.MapRoute(
                    "Default", // 路由名称
                    "{controller}/{action}/{id}", // 带有参数的 URL
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
                );
        
            routes.MapRoute(
                "UpcomingUsers", // 路由名称
                "{controller}/{action}/page/{page}", // 带有参数的 URL
                new { controller = "Admin", action = "Admin_users", id = UrlParameter.Optional } // 参数默认值
            );
            routes.MapRoute(
                "UpcomingCourses", // 路由名称
                "{controller}/{action}/page/{page}", // 带有参数的 URL
                new { controller = "Admin", action = "Admin_courses", id = UrlParameter.Optional } // 参数默认值
            );
            routes.MapRoute(
                "UpcomingFiles", // 路由名称
                "{controller}/{action}/page/{page}", // 带有参数的 URL
                new { controller = "Admin", action = "Admin_files", id = UrlParameter.Optional } // 参数默认值
            );
            routes.MapRoute(
                "UpcomingNewCourse", // 路由名称
                "{controller}/{action}/page/{page}", // 带有参数的 URL
                new { controller = "Admin", action = "Admin_applyNewCourse", id = UrlParameter.Optional } // 参数默认值
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}