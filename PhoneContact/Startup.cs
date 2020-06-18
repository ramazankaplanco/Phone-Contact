#region 

using Microsoft.Owin;
using Owin;

#endregion

[assembly: OwinStartup(typeof(PhoneContact.Startup))]
namespace PhoneContact
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}