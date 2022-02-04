using EFCoreApp_DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Extensions;
internal static class ApplicationServiceExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration){
        services.AddDbContext<DataContext>(options =>{
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    } 

}
