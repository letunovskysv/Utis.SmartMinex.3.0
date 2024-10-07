namespace Utis.Minex.Common.Common
{
    public class RequestContext
    {
        public RequestContext(string serverGuid,
                              string clientGuid,
                              string address,
                              string hostName) 
        {
            ServerGuid = serverGuid;
            ClientGuid = clientGuid;
            Address = address;
            HostName = hostName;
        }

        public string ServerGuid { get; }
        public string ClientGuid { get; }
        public string Address { get; }
        public string HostName { get; }
    }
}
