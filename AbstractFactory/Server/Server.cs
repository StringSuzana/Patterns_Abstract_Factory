using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractFactory
{
    public class Server : IServer
    {
        private string FILE_PATH_EAST = String.Empty;
        private string FILE_PATH_WEST = String.Empty;
        private readonly ILogger _logger;
        public Server(ILogger logger)
        {
            _logger = logger;

            string FILE_NAME_EAST = "products_east.txt";
            string FILE_NAME_WEST = "products_west.txt";
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string sFile_e = Path.Combine(sCurrentDirectory, (@"..\..\..\Data\" + FILE_NAME_EAST));
            FILE_PATH_EAST = Path.GetFullPath(sFile_e);

            string sFile_w = Path.Combine(sCurrentDirectory, (@"..\..\..\Data\" + FILE_NAME_WEST));
            FILE_PATH_WEST = Path.GetFullPath(sFile_w);

        }
        private List<String> GetAllProductsOnSaleNames()
        {
            List<String> products_on_sale_Names = new List<string>();
            string line = "";
            using (StreamReader sr = new StreamReader(FILE_PATH_EAST))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var props = line.Split(';');
                    products_on_sale_Names.Add(props[0]);
                }
            }
            using (StreamReader sr = new StreamReader(FILE_PATH_WEST))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var props = line.Split(';');
                    products_on_sale_Names.Add(props[0]);
                }
            }
            return products_on_sale_Names;

        }


        public List<IProduct> GetAllProducts(IProductFactory selected_factory)
        {
            List<IProduct> products = new List<IProduct>();
            string line = "";
            using (StreamReader sr = new StreamReader(ChooseFileBasedOnFactory(selected_factory)))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var props = line.Split(';');
                    var product = selected_factory.CreateProduct(props[0], props[1], props[2], props.Length>3? props[3]: "");
                    products.Add(product);
                    _logger.WriteToLogFile(product);

                }
            }
            return products;
        }

        private string ChooseFileBasedOnFactory(IProductFactory selected_factory)
        {
            switch (selected_factory)
            {
                case WestFactory w:
                    return FILE_PATH_WEST;
                case EastFactory e:
                    return FILE_PATH_EAST;
                default:
                    return string.Empty;
            }
        }
    }

}
