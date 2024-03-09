using System.Net.Mime;
using BootCamp.Contexts;
using BootCamp.Repositories;
using BootCamp.SandBox;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("=== Start ===");

// DbContext Inject
IConfiguration configuration = new ConfigurationManager();

var services = new ServiceCollection();

services.AddDbContext<BootCampContext>(option
    => option.UseSqlServer(configuration.GetConnectionString("BootCampConnection")));

services.AddTransient<DataInjector>();
services.AddScoped<IProductService, ProductService>();

var provider = services.BuildServiceProvider();

var site = provider.GetService<DataInjector>();

if (site == null) return;

await site.RunAsync();

/* == [ EntityFrameworkCore ] ==

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServer

brew update
brew install mono-libgdiplus
brew install --cask dotnet
Microsoft.Extensions.Configuration.Json
dotnet ef migration add Init
dotnet ef database update

 */