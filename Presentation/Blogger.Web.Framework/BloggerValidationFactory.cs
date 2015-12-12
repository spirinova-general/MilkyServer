using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FluentValidation.Attributes;
using FluentValidation;
using Autofac;
using System.Web.Mvc;
namespace Blogger.Web.Framework
{
    public class BloggerValidationFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;
        public BloggerValidationFactory(IContainer container)
        {
            this.container = container;
        }

        public override FluentValidation.IValidator CreateInstance(Type validatorType)
        {
            FluentValidation.IValidator validator = container.ResolveOptionalKeyed<FluentValidation.IValidator>(validatorType);
            return validator;
        }

        public FluentValidation.IValidator GetValidator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return DependencyResolver.Current.GetService(typeof(FluentValidation.IValidator<>).MakeGenericType(type)) as FluentValidation.IValidator;
        }

        public IValidator<T> GetValidator<T>()
        {
            return DependencyResolver.Current.GetService<IValidator<T>>();
        }

       
    
    }
}