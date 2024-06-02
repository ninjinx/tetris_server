using System.Threading.Tasks;
using MagicOnion;
using MessagePack;
using UnityEngine;

namespace Shared.Interfaces
{
    public interface IGamingHubReceiver
    {
        void OnJoin(Player player);
        void OnLeave(Player player);
        void OnOjama(Player player);
    }

    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        ValueTask<Player[]> JoinAsync(string roomName, string userName);
        ValueTask LeaveAsync();
        ValueTask OjamaAsync();
    }

    [MessagePackObject]
    public class Player
    {
        [Key(0)]
        public string Name { get; set; }
    }
}