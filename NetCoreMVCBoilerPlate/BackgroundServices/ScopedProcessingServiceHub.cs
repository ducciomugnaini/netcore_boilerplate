using Microsoft.AspNetCore.SignalR;
using NetCoreMVCBoilerPlate.Hubs;

namespace NetCoreMVCBoilerPlate.BackgroundServices;

internal interface IScopedProcessingService
{
   Task DoWork(CancellationToken stoppingToken);
}

internal class ScopedProcessingServiceHub : IScopedProcessingService
{
   private int executionCount = 0;
   private readonly ILogger _logger;
   private readonly IHubContext<BackgroundServiceHub, IBackgroundServiceHubStrongTyped> _clockHub;

   public ScopedProcessingServiceHub(ILogger<ScopedProcessingServiceHub> logger, IHubContext<BackgroundServiceHub, IBackgroundServiceHubStrongTyped> clockHub)
   {
      _logger = logger;
      _clockHub = clockHub;
   }

   public async Task DoWork(CancellationToken stoppingToken)
   {
      while (!stoppingToken.IsCancellationRequested)
      {
         executionCount++;

         _logger.LogInformation("Scoped Processing Service is working. Count: {Count}", executionCount);
         
         await _clockHub.Clients.All.SendToClientsData(DateTime.Now);
         
         await Task.Delay(10000, stoppingToken);
      }
   }
}