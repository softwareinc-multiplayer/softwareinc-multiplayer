using System.Net;
using System.Net.Sockets;
using LiteNetLib;

namespace Multiplayer.Net
{
    /// <summary>
    /// Server manager used when hosting a game
    /// </summary>
    internal class ServerManager : Manager
    {
        /// <summary>
        /// Max number of clients allowed to connect
        /// </summary>
        public readonly ushort MaxClients;

        /// <summary>
        /// Clients connected to this server
        /// </summary>
        public NetPeer[] Clients => _manager.GetPeers(ConnectionState.Any);

        /// <summary>
        /// Creates a new server manager
        /// </summary>
        /// <param name="port">Connection port</param>
        /// <param name="key">Connection key</param>
        /// <param name="maxClients">Max number of clients allowed to connect</param>
        public ServerManager(int port, string key, ushort maxClients) : base(port, key)
        {
            MaxClients = maxClients;
        }

        public override void OnPeerConnected(NetPeer peer)
        {
        }

        public override void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
        }

        public override void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
        {
        }

        public override void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
        }

        public override void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader,
            UnconnectedMessageType messageType)
        {
        }

        public override void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
        }

        public override void OnConnectionRequest(ConnectionRequest request)
        {
            if (_manager.PeersCount < MaxClients)
            {
                request.AcceptIfKey(Key);
            }
            else
            {
                request.Reject();
            }
        }
    }
}
