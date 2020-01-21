using System.Web.Mvc;

namespace Editory.Blog.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Dashboard",
                url: "dashboard/",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "UnAuthorized",
                url: "dashboard/UnAuthorized",
                defaults: new { controller = "Base", action = "UnAuthorized" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityList",
                url: "dashboard/{controller}/",
                defaults: new { action = "Index" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityCreate",
                url: "dashboard/{controller}/Create/",
                defaults: new { action = "Action" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityEdit",
                url: "dashboard/{controller}/Edit/{id}",
                defaults: new { action = "Action" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityEditWithoutID",
                url: "dashboard/{controller}/Edit/",
                defaults: new { action = "Action" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityDetails",
                url: "dashboard/{controller}/Details/{id}",
                defaults: new { action = "Details" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "EntityDelete",
                url: "dashboard/{controller}/Delete/",
                defaults: new { action = "Delete" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "UserRoles",
                url: "dashboard/Users/Roles/{userName}",
                defaults: new { controller = "Users", action = "Roles" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "AssignUserRole",
                url: "dashboard/Users/Roles/{userName}/Assign/",
                defaults: new { controller = "Users", action = "AssignUserRole" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "DeleteUserRole",
                url: "dashboard/Users/Roles/{userName}/Delete/",
                defaults: new { controller = "Users", action = "DeleteUserRole" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "UserComments",
                url: "dashboard/Users/Comments/{userName}",
                defaults: new { controller = "Users", action = "Comments" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "RoleDetails",
                url: "dashboard/Roles/RoleDetails/{roleID}",
                defaults: new { controller = "Roles", action = "RoleDetails" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "RoleUsers",
                url: "dashboard/Roles/Users/{roleName}",
                defaults: new { controller = "Roles", action = "Users" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );


            context.MapRoute(
                name: "OrdersByEmail",
                url: "dashboard/Orders/OrdersByEmail",
                defaults: new { controller = "Orders", action = "OrdersByEmail" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "UpdateOrderStatus",
                url: "dashboard/Orders/{orderID}/Update-Status/",
                defaults: new { controller = "Orders", action = "UpdateStatus" },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );

            context.MapRoute(
                name: "DashboardDefault",
                url: "dashboard/{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", lang = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "Editory.Blog.Areas.Dashboard.Controllers" }
            );
        }
    }
}