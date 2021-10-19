using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPrice = 0;
            string[] readText = new string[5];
            string path = "C:/Users/v.medzakovskiy.SPB/source/repos/Lab16/Lab16_1/bin/Debug/Products.json";
            Product[] product = new Product[5];

            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < 5; i++)
                {
                    readText[i] = sr.ReadLine();
                    product[i] = JsonSerializer.Deserialize<Product>(readText[i]);
                    product[i].ShowInfo();
                }
            }
                for (int i = 1; i < 5; i++)
                {
                    if (product[i].Price > product[maxPrice].Price)
                    {
                        maxPrice = i;
                    }
                }
            Console.WriteLine($"Самый дорогой товар - {product[maxPrice].Name}, его цена: {product[maxPrice].Price}");
            Console.ReadKey();
        }
    }


    class Product
    {
        [JsonPropertyName("code")]
        public int Code { set; get; }
        [JsonPropertyName("name")]
        public string Name { set; get; }
        [JsonPropertyName("price")]
        public double Price { set; get; }

        public Product(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Code + " " + Name + " " + Price);
        }
    }
}
