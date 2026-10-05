using Application.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.ServiceImplementation
{
    public class DeliveryBackGroundService(IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var deliveryService = scope.ServiceProvider.GetService<IDeliveryService>();
                    await deliveryService!.ProcessPendingDelivery();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
