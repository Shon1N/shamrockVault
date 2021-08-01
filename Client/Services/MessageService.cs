using ShamrockVault.Client.Services;
using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    public class MessageService : IMessageService
    {
        public Task<Message> AddMessage(Message addMessage)
        {
            throw new NotImplementedException();
        }

        public Task<Message> DeleteUser(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessage(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessages()
        {
            throw new NotImplementedException();
        }

        public Task<Message> UpdateMessage(Message updateMessage)
        {
            throw new NotImplementedException();
        }
    }
}
