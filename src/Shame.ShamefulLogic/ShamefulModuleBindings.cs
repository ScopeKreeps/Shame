using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Shame.ShamefulLogic
{
    public class ShamefulModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IShamefulService>().To<TweetSharpShamefulService>()
                .WithConstructorArgument("consumerKey", ConfigurationManager.AppSettings["consumerKey"])
                .WithConstructorArgument("consumerSecret", ConfigurationManager.AppSettings["consumerSecret"])
                .WithConstructorArgument("accessToken", ConfigurationManager.AppSettings["accessToken"])
                .WithConstructorArgument("accessTokenSecret", ConfigurationManager.AppSettings["accessTokenSecret"]);
        }
    }
}
