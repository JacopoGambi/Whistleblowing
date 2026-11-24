using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Whistleblowing.Web.SignalR.Hubs;
using Whistleblowing.Web.SignalR.Hubs.Events;

namespace Whistleblowing.Web.SignalR
{
    public class SignalrPublishDomainEvents : IPublishDomainEvents
    {
        IHubContext<WhistleblowingHub, IWhistleblowingClientEvent> _whistleblowingHub;

        public SignalrPublishDomainEvents(IHubContext<WhistleblowingHub, IWhistleblowingClientEvent> whistleblowingHub)
        {
            _whistleblowingHub = whistleblowingHub;
        }

        private IWhistleblowingClientEvent GetWhistleblowingGroup(Guid id)
        {
            return _whistleblowingHub.Clients.Group(id.ToString());
        }

        public Task Publish(object evnt)
        {
            try
            {
                return ((dynamic)this).When((dynamic)evnt);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                return Task.CompletedTask;
            }
        }

        public Task When(NewMessageEvent e)
        {
            return GetWhistleblowingGroup(e.IdGroup).NewMessage(e.IdUser, e.IdMessage);
        }
    }
}
