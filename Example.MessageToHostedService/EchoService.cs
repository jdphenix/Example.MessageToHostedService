using MediatR;

namespace Example.MessageToHostedService
{
    public enum Status
    {
        Success,
        Failed,
    }

    public class Message : IRequest<Status>
    {
        public string Description { get; }

        public Message(string description)
        {
            Description = description;
        }
    }

    public class EchoService : IHostedService, IRequestHandler<Message, Status>
    {
        public Task<Status> Handle(Message request, CancellationToken cancellationToken)
        {
            // pretend I do something riveting here.
            Console.WriteLine(request.Description);
            return Task.FromResult(Status.Success);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
