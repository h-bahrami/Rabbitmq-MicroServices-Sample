using MassTransit;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayApi.Consumers
{
    public class MainConsumer : IConsumer<GatewayCommand>
    {
        public async Task Consume(ConsumeContext<GatewayCommand> context)
        {
            
        }
    }
}
