﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//namespace Blogger.Web.Framework.Mvc
//{
//    public class BlogDependencyResolver : IDependencyResolver
//    {
//        public object GetService(Type serviceType)
//        {
//            return EngineContext.Current.ContainerManager.ResolveOptional(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
//            return (IEnumerable<object>)EngineContext.Current.Resolve(type);
//        }
//    }
//}