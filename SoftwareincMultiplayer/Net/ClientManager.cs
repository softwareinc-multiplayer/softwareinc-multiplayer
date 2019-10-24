using System.Net;
using System.Net.Sockets;
using LiteNetLib;

namespace Multiplayer.Net
{
    /// <summary>
    /// Client manager used when joining a game
    /// </summary>
    internal class ClientManager : Manager
    {
        /// <summary>
        /// Server this client is connected to
        /// </summary>
        public NetPeer Server => _manager.FirstPeer;

        /// <summary>
        /// Creates a new client manager
        /// </summary>
        /// <param name="port">Connection port</param>
        /// <param name="key">Connection key</param>
        public ClientManager(int port, string key) : base(port, key)
        {
        }

        /// <summary>
        /// Connects to a server
        /// </summary>
        /// <param name="address">Server IP address</param>
        /// <returns>Success</returns>
        public bool Connect(string address)
        {
            return _manager.Connect(address, Port, Key) != null;
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
        }
    }
}
