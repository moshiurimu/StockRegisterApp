using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockRegisterApp.DAL.DAO
{
    class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quentity { get; set; }

        

        public Product(string code, string name, int quentity):this()
        {
            Code = code;
            Name = name;
            Quentity = quentity;
        }

        public Product()
        {
        }
    }
}
