using StackExchange.Redis;

namespace E_Commerce.Basket.Settings
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer connectionMultiplexer;

        public RedisService(int port, string host)
        {
            _port = port;
            _host = host;
        }

        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host},{_port} ");
        public IDatabase GetDb(int db = 1) => connectionMultiplexer.GetDatabase(0);
    }
}
