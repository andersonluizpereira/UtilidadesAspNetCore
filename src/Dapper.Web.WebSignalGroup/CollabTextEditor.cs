using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Dapper.Web.WebSignalGroup
{
    public class TextHub : Hub
    {
        private static Dictionary<string, string> connectionsNgroup = new Dictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (connectionsNgroup.ContainsKey(Context.ConnectionId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, connectionsNgroup[Context.ConnectionId]);
                connectionsNgroup.Remove(Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task BroadcastText(string text)
        {
            if (connectionsNgroup.ContainsKey(Context.ConnectionId))
            {
                await Clients.OthersInGroup(connectionsNgroup[Context.ConnectionId]).SendAsync("ReceiveText", text);
            }
        }

        public async Task JoinGroup(string group)
        {
            if (connectionsNgroup.ContainsKey(Context.ConnectionId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, connectionsNgroup[Context.ConnectionId]);
                connectionsNgroup.Remove(Context.ConnectionId);
            }
            connectionsNgroup.Add(Context.ConnectionId, group);
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
    }
}

