using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        static object locker = new object();

        static int count = 0;

        private readonly IHubContext<CounterHub> hubContext;

        public CounterController(IHubContext<CounterHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpGet]
        public CountResult GetInitialCount()
        {
            return new CountResult { Count = count };
        }

        [HttpPost]
        public async Task Increment()
        {
            lock (locker)
            {
                count++;
            }

            await hubContext.Clients.All.SendAsync("Count", new CountResult { Count = count });
        }


    }



    public class CounterHub : Hub
    {
        public async void SendCount(int count)
        {
            await this.Clients.All.SendAsync("Count", new CountResult { Count = count });
        }
    }


    public class CountResult
    {
        public int Count { get; set; }
    }

}