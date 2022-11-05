using Microsoft.AspNetCore.SignalR;

namespace NetCoreMVCBoilerPlate.Hubs;

public interface IBackgroundServiceHubStrongTyped
{
   Task SendToClientsData(DateTime currentTime);
}

public class BackgroundServiceHub : Hub<IBackgroundServiceHubStrongTyped>
{
   public async Task SendToClients(DateTime dateTime)
   {
      await Clients.All.SendToClientsData(dateTime);
   }
}