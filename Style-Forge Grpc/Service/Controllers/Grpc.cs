using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System.Timers;
using Style_Forge_Grpc.Service.Interfaces;
using Style_Forge_Grpc.Service.Modules;

namespace Style_Forge_Grpc.Service.Controllers
{
    internal class Grpc : GrpcConnectionHandler, IGrpcService
    {
        private CancellationToken UpdateToken;
        private GrpcChannel? serverChannel;

        public event EventHandler? ClientSubscribed;
        public event EventHandler? ClientUnsubscribed;

        public event EventHandler? ClientConnected;
        public event EventHandler? ClientDisconnected;
        public event EventHandler<AutoReconnectArgs>? ClientReconnecting;
        public event EventHandler? KeepAliveRequested;

        public UInt32 ProgramVersion { get; set; } = 100;
        public UInt32 MessageVersion { get; set; } = 100;
        public UInt64 DeviceID { get; set; }

        public async Task<GrpcChannel> Init(IGrpcConnection connection)
        {
            if (serverChannel == null)
            {
                serverChannel = GrpcChannel.ForAddress("https://" + connection.Address + ":" + connection.Port + "/", new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });
            }

            StartTimer();

            return serverChannel;
        }

        public async Task<IMessage?> DispatchMessage(IMessage msg)
        {
            if (_apiClient == null)
            {
                NotifyTransactionFailed("Not Connected to Channel");
                return null;
            }

            try
            {
                NotifyTransactionStarting();

                Console.WriteLine(">> [Sending Register Request...]");

                LastTransactionSent = DateTime.UtcNow.AddSeconds(25);

                BaseMessage xResp = await _apiClient.DoTransactionAsync(msg, deadline: LastTransactionSent);

                if (xResp != null)
                {
                    Console.WriteLine(">> [Reading Register Reply...]");

                    ResetReconnect();

                    Connected();

                    return xResp;
                }
                else
                {
                    NotifyTransactionFailed("Null Response");
                    return null;
                }
            }
            catch (RpcException ex)
            {
                Console.WriteLine(">> [Attempt Failed Reason: " + ex.Message + "]");
                Reconnect(msg);
                return null;
            }
            
        }

        public async void Close() => await serverChannel?.ShutdownAsync();



        //===========================================================================================================//
        // NOTIFICATIONS //////////////////////////////////////////////////////////////////////////////////////////////
        //===========================================================================================================//
        public override void Connected()
        {
            IsConnected = true;
            ClientConnected?.Invoke(null, EventArgs.Empty);
        }

        public override void Reconnecting(AutoReconnectArgs x)
        {
            ClientReconnecting?.Invoke(null, x);
        }

        public override async void TriggerKeepAlive()
        {
            KeepAliveRequested?.Invoke(null, EventArgs.Empty); //notify to any classes subscribed to this event that a keepalive happened
        }

        public override void AttemptsExceeded()
        {
            //TODO
            //throw new NotImplementedException();
        }

        public override async void TryReconnect(IMessage message)
        {
            await DispatchMessage(message);
        }
    }
}
