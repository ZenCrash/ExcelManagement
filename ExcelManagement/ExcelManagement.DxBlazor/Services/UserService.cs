using System.Collections.Concurrent;

namespace ExcelManagement.DxBlazor.Services
{
    public class UserService
    {
        private readonly ConcurrentDictionary<string, bool> _connectedUserIds = new ConcurrentDictionary<string, bool>();

        public Task<List<string>> GetUserIdsAsync()
        {
            return Task.FromResult(new List<string>(_connectedUserIds.Keys));
        }

        public void AddConnectedUser(string userId)
        {
            _connectedUserIds.TryAdd(userId, true);
        }

        public void RemoveConnectedUser(string userId)
        {
            bool removed;
            _connectedUserIds.TryRemove(userId, out removed);
        }
    }
}
