using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpanAidAdmin.Startup))]
namespace SpanAidAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
