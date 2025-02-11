using Google.Protobuf;
using Grpc.Net.Client;

namespace Style_Forge_Grpc.Service.Interfaces
{
    public interface IGrpcService
    {
        public UInt32 ProgramVersion { get; set; }
        public UInt32 MessageVersion { get; set; }
        public UInt64 DeviceID { get; set; }

        public event EventHandler KeepAliveRequested;
        public Task<GrpcChannel> Init(IGrpcConnection connection);
        public Task<IMessage?> DispatchMessage(IMessage msg);
        public void Close();
    }
}
