using System;
using System.Collections.Generic;
using System.Threading;

namespace AbstractFactory
{
    public class Client
    {

        private readonly IServer _server;
        private readonly ILogger _logger;
        private readonly List<IProductFactory> _factories;

        public Client(IServer server, ILogger logger, List<IProductFactory> factories)
        {
            _server = server;
            _logger = logger;
            _factories = factories;

        }
        public void Start()
        {
            while (true)
            {
                _logger.WriteToConsole($"====================<<PRODUCTS ON SALE>>=======================");

                _factories.ForEach(factory =>
                {
                    var products = _server.GetAllProducts(factory);
                foreach (var p in products)
                {
                    _logger.WriteToConsole(p);
                }
                });

                Thread.Sleep(5000);
            }
        }


    }
}
