using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Tasinmaz.API.Business.Concrete;
using Tasinmaz.API.DataAccess.Abstract;
using TasinmazProje.API.Business.Abstract;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParselManager>().As<IParselService>().SingleInstance();
            

            builder.RegisterType<UserManager>().As<IUserService>();
            

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<IlManager>().As<IIlService>().SingleInstance();
          

            builder.RegisterType<IlceManager>().As<IIlceService>().SingleInstance();
            

            builder.RegisterType<MahalleManager>().As<IMahalleService>().SingleInstance();
            
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            


            builder.RegisterType<LogManager>().As<ILogService>().SingleInstance();
           



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
