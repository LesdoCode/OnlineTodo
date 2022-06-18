using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTodo.Startup))]
namespace OnlineTodo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
