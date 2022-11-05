using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_для_DNS
{
    internal class Products
    {
        List<Product> _products = new List<Product>();

        public void Addproduct(string name, string parametr, string discription, string price)
        {
            _products.Add(new Product(name, parametr, discription, price));
        }

        public Product GetProduct(int index)
        {
            Product p = _products[index];
            return p;
        }

        public int GetIndex(string item)
        {
            int index = 0;
            foreach(var obj in _products)
            {
                if (obj.ToString() == item)
                {
                    break;
                }
                index++;
            }

            return index;
        }

        public string EditProduct(int index, Product p)
        {
            return (_products[index] = p).ToString();
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public string Getname()
        {
            return _products[0].Getname();
        }
        public override string ToString()
        {
            return $"Наименование: {_products[_products.Count-1].Getname()} характеристика: {_products[_products.Count - 1].Getparam()} описание: {_products[_products.Count - 1].Getdis()}";
        }
    }

    struct Product
    {
        string _name;
        string _parametr;
        string _discription;
        string _price;
        public Product()
        {
            _name = "None";
            _parametr = "None";
            _discription = "None";
            _price = "None";
        }

        public Product(string name, string parametr, string Discription, string price)
        {
            _name = name;
            _parametr = parametr;
            _discription = Discription;
            _price = price;
        }

        public string Getname()
        {
            return _name;
        }
        public string Getparam()
        {
            return _parametr;
        }
        public string Getdis()
        {
            return _discription;
        }
        public string Getprice()
        {
            return _price;
        }

        public override string ToString()
        {
            return $"Наименование: {_name} характеристика: {_parametr} описание: {_discription}";
        }
    }
}
