using MassTransit;
using Shared;
using System.Threading.Tasks;

namespace MicroService2
{
    public class MainConsumer : IConsumer<IRequestMessage>
    {
        public Task Consume(ConsumeContext<IRequestMessage> context)
        {
            return Task.CompletedTask;
        }
    }
}
