using FreeIt.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Dependency.Configuration.Db
{
    public static class SqlConfiguration
    {
        public static IServiceCollection RegisterSqlClient(
            this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<GameDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString())
                });
        //<IMongoClient>(x => new MongoClient(configuration.GetDatabaseConfiguration().ConnectionString));

        //public static IServiceCollection RegisterMongoDataBase(this IServiceCollection services)
        //    => services
        //        .AddScoped<IMongoContext, MongoContext>()
        //        .AddScoped<IUnitOfWork, UnitOfWork>();

        //public static IServiceCollection RegisterMongoRepositories(this IServiceCollection services)
        //    => services
        //        .AddScoped<IUserRepository, UserRepository>()
        //        .AddScoped<ITargetRepository, TargetRepository>()
        //        .AddScoped<IGroupRepository, GroupRepository>()
        //        .AddScoped<IUserTargetRepository, UserTargetRepository>()
        //        .AddScoped<ITargetGroupRepository, TargetGroupRepository>()
        //        .AddScoped<IUserGroupRepository, UserGroupRepository>()
        //        .AddScoped<ILogRepository, LogRepository>()
        //        .AddScoped<IUserSettingsRepository, UserSettingsRepository>()
        //        .AddScoped<IPlaceMarkerRepository, PlaceMarkerRepository>();
    }
}