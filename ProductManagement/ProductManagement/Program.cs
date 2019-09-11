using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProductManagement
{
    public class Program
    {
        #region "Main"
        //Defines the entry point of the application.
        //<param name="args">The arguments.</param>
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();
        #endregion

        #region "CreateWebHostBuilder"
        //Creates the web host builder.
        //<param name="args">The arguments.</param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}
