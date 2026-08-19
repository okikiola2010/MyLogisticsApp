
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.Service;
using Application.Interfaces.ServiceInterfaces;
using Application.ServiceImplementation;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(config => config.UseMySQL(builder.Configuration.GetConnectionString("Default")!));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IDeliveryManRepository,DeliverManRepository>();
            builder.Services.AddScoped<IStateRepository, StateRepository>();
            builder.Services.AddScoped<ILgaRepository, LgaRepository>();
            builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();
            builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.Services.AddScoped<IClientService,ClientService>();
            builder.Services.AddScoped<IDeliveryManService,DeliveryManService>();
            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IStateService,StateService>();
            builder.Services.AddScoped<ILgaService,LgaService>();
            builder.Services.AddScoped<ICommunityService,CommunityService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IDeliveryRequestService, DeliveryRequestService>();
            builder.Services.AddHostedService<DeliveryBackGroundService>();


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
