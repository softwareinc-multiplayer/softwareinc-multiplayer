using System.Net;
using System.Net.Sockets;
using LiteNetLib;
using LiteNetLib.Utils;

namespace Multiplayer.Net
{
    /// <summary>
    /// Base for Client and Server managers
    /// </summary>
    internal abstract class Manager : INetEventListener
    {
        /// <summary>
        /// Network manager backend
        /// </summary>
        protected readonly NetManager _manager;

        /// <summary>
        /// Network packet processor for (de)serialization
        /// </summary>
        protected readonly NetPacketProcessor _packetProcessor = new NetPacketProcessor();

        /// <summary>
        /// Connection port
        /// </summary>
        public readonly int Port;

        /// <summary>
        /// Connection key
        /// </summary>
        public readonly string Key;

        /// <summary>
        /// Creates a new manager
        /// </summary>
        /// <param name="port">Connection port</param>
        /// <param name="key">Connection key</param>
        protected Manager(int port, string key)
        {
            Port = port;
            Key = key;

            _manager = new NetManager(this);
        }

        /// <summary>
        /// Starts the manager backend
        /// </summary>
        /// <returns>Success</returns>
        public bool Start()
        {
            return _manager.Start(Port);
        }

        /// <summary>
        /// Stops the manager backend
        /// </summary>
        public void Stop()
        {
            _manager.Stop();
        }

        public abstract void OnPeerConnected(NetPeer peer);

        public abstract void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo);

        public abstract void OnNetworkError(IPEndPoint endPoint, SocketError socketError);

        public abstract void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod);

        public abstract void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader,
            UnconnectedMessageType messageType);

        public abstract void OnNetworkLatencyUpdate(NetPeer peer, int latency);

        public abstract void OnConnectionRequest(ConnectionRequest request);
    }
}
