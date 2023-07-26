using AutoMapper;
using CRUDDemo.Business.Mapper;
using CRUDDemo.Business.Product.Interface;
using CRUDDemo.Business.Product.Service;
using CRUDDemo.Data.DataAccessObjects.Product.Implementations;
using CRUDDemo.Data.DataAccessObjects.Product.Interfaces;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;
using Unity.RegistrationByConvention;

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

            #region AutoMapping

            var type = typeof(Profile);
            var businessMappingProfileDll = Assembly.Load("CRUDDemo.Business");

            //// Load CRUDDemo.Business 的 MappingProfile
            var businessMappingProfiles = AllClasses.FromAssemblies(businessMappingProfileDll).Where(type.IsAssignableFrom).ToList();

            var webMappingProfileDll = Assembly.Load("CRUDDemo");

            //// Load CRUDDemo 的 MappingProfile
            var webMappingProfiles = AllClasses.FromAssemblies(webMappingProfileDll).Where(type.IsAssignableFrom).ToList();

            var mapperConfig = new MapperConfiguration(config =>
            {
                foreach (var profile in businessMappingProfiles)
                {
                    config.AddProfile(profile);
                }

                foreach (var profile in webMappingProfiles)
                {
                    config.AddProfile(profile);
                }
            });

            var mapper = mapperConfig.CreateMapper();

            container.RegisterInstance(mapper);

            #endregion

            // 將 Unity 容器設定為 MVC 的預設依賴解析器
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
