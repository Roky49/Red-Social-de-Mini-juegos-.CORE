using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Hubs
{
    public class ChatHub: Hub
    {

        public async Task SendMessage(String user, String mensaje)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, mensaje);
        }
    }
}
