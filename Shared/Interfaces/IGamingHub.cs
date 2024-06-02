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
        void OnMove(Player player);
    }

    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        ValueTask<Player[]> JoinAsync(string roomName, string userName, Vector3 position, Quaternion rotation);
        ValueTask LeaveAsync();
        ValueTask MoveAsync(Vector3 position, Quaternion rotation);
    }

    [MessagePackObject]
    public class Player
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public Vector3 Position { get; set; }
        [Key(2)]
        public Quaternion Rotation { get; set; }
    }
}