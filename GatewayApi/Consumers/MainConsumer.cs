using MassTransit;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayApi.Consumers
{
    public class MainConsumer : IConsumer<IGatewayRequest>
    {
        public async Task Consume(ConsumeContext<IGatewayRequest> context)
        {
            
        }
    }
}
