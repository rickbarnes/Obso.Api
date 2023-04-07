namespace Obso.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildHostBuilder(args).Build().Run();
        }

        public static IHostBuilder BuildHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBulder =>
        {
            webBulder.UseStartup<Startup>();
        });
    }
}