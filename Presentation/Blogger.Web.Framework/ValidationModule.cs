using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Web.Framework
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BloggerValidationFactory>().As<IValidatorFactory>();
            builder.RegisterType<CustomerRegisterValidator>()
               .Keyed<IValidator>(typeof(IValidator<RegisterModel>))
               .As<IValidator>();

        }
    }
}