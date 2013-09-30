using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TorrentSite.Startup))]
namespace TorrentSite
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
