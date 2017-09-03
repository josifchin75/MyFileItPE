using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFileItDirectAmbassador.Startup))]
namespace MyFileItDirectAmbassador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
