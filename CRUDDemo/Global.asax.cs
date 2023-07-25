using CRUDDemo.Business.Product.Interface;
using CRUDDemo.Business.Product.Service;
using CRUDDemo.Data.DataAccessObjects.Product.Implementations;
using CRUDDemo.Data.DataAccessObjects.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace CRUDDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Unity
            var container = new UnityContainer();

            // 註冊服務
            container.RegisterType<IProductImpl, ProductImpl>();
            container.RegisterType<IProductService, ProductService>();

            // 將 Unity 容器設定為 MVC 的預設依賴解析器
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
