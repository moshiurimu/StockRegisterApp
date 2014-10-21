using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockRegisterApp.DAL.DAO;
using StockRegisterApp.DAL.Gateway;

namespace StockRegisterApp.BLL
{
    class ProductBLL
    {
        ProductGateway aProductGateway= new ProductGateway();
        public string Save(Product aProduct)
        {
            if (aProduct.Code.Length < 3 || aProduct.Code.Length > 3)
            {
                return "Product Code must be three character!";
            }
            if (aProduct.Name.Length<5 || aProduct.Name.Length>10)
            {
                return "Product name must be set 5 to 10 character!";
            }

            
            if (HasThisCode(aProduct.Code))
            {
               return  "Product code already exist.";
            }
            if (HasThisName(aProduct.Name))
            {
              return  "Product name already exist.";
            }


             return aProductGateway.Save(aProduct);       
        }


        private bool HasThisCode(string code)
        {
            return aProductGateway.HasThisCode(code);
        }

        private bool HasThisName(string name)
        {
            return aProductGateway.HasThisName(name);
        }

        public List<Product> ShowAllProductInGrid()
        {
            return aProductGateway.ShowAllProductInGrid();
        }

        public int GetTotalQuentity()
        {
            return aProductGateway.GetTotalQuentity();
        }
    }
}
