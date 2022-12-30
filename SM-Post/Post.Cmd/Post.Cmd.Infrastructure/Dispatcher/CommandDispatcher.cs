using System.Reflection.Metadata;
using CQRS.Core.Commands;
using CQRS.Core.Infrastructure;

namespace Post.Cmd.Infrastructure.Dispatcher
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Dictionary<Type, Func<BaseCommand, Task>> _Handlers = new(); 
        

        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if(_Handlers.ContainsKey(typeof(T)))
            {
                throw new IndexOutOfRangeException("You cannot register the same command handler twice!");
            }

            _Handlers.Add(typeof(T), x => handler((T)x));
        }

        public async Task SendAsync(BaseCommand command)
        {
            if(_Handlers.TryGetValue(command.GetType(), out Func<BaseCommand, Task> handler))
            {
                await handler(command);
            }else {
                throw new ArgumentNullException(nameof(handler), "No command handler was registered");
            }
        }
    }
}