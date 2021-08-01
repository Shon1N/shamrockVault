using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessages();
        Task<Message> GetMessage(string Id);
        Task<Message> UpdateMessage(Message updateMessage);
        Task<Message> AddMessage(Message addMessage);
        Task<Message> DeleteUser(Message message);
    }
}
