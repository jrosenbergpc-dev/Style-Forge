namespace Style_Forge_Grpc.Service.Interfaces
{
    public interface IGrpcConnection
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
