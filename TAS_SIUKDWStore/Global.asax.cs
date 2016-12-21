﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using System.Data.Entity;

using TAS_SIUKDWStore.Models;

namespace TAS_SIUKDWStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();


            //Database.SetInitializer<TAS_SIUKDWStoreContext>(
            //    new TAS_SIUKDWStoreContextInitializer());

            //Database.SetInitializer<TAS_SIUKDWStoreContext>(
            //new DropCreateDatabaseAlways<TAS_SIUKDWStoreContext>());


            WebSecurity.InitializeDatabaseConnection("TAS_SIUKDWStoreContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

        }
    }
}