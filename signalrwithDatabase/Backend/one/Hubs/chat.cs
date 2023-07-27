using Microsoft.AspNetCore.SignalR;
using one.Models;

namespace one.Hubs
{
    public class chat:Hub
    {

        private static Dictionary<int, string> userConnectionStore = new Dictionary<int, string>();
        private readonly RasmitestContext _context;

        public chat(RasmitestContext context)
        {
                _context= context;
        }
        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            int userId = Convert.ToInt16(Context.GetHttpContext().Request.Query["userId"]);
         
            userConnectionStore[userId] = connectionId;
            await base.OnConnectedAsync();
        }

        public async Task SendMessages(string mes,int id)
        {
            var data = new Me()
            {
                UserId = id,
                Mes = mes,
            };
            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

          await  Clients.Client(userConnectionStore[id]).SendAsync("ReceiveMessage", new {userId=id,mes=mes });

            //await Clients.Client(userConnectionStore[id]).SendAsync("ReceiveMessage", mes);
        }
    }
}
