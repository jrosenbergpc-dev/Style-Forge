using Grpc.Core;
using GrpcClient;
using Style_Forge_Grpc.Service.Interfaces;

namespace Style_Forge_Grpc.Service.Modules
{
    internal abstract class GrpcDataHandler
    {
        protected readonly IGrpcService _grpc;

        protected GrpcDataHandler(IGrpcService grpc)
        {
            _grpc = grpc;
        }

        internal async Task SendMessage(BaseMessage msg)
        {
            BaseMessage? resp = await _grpc.DispatchMessage(msg);

            if (resp != null)
            {
                ReadMessage(resp);
            }
        }
        internal abstract void ReadMessage(BaseMessage payload);
        internal abstract BaseMessage CreateMessage(UInt64 deviceID, object messageobj, UInt32 messageType);
        internal abstract void StartStream(UInt32 data);
        internal abstract void StopStream(UInt32 data);
        internal abstract Task<BaseMessage> ReadStream(BaseMessage msg);
        internal abstract Task<BaseMessage> WriteStream();
        internal abstract Task ReadStreamCallback(AsyncDuplexStreamingCall<BaseMessage, BaseMessage> call, UInt32 data);
    }
}
