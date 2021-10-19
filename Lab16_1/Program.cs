using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Lab16_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] jsonProduct = new string[5];
            string path = "Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }


            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = false
            };

            Product[] product = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введите код товара: ");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите название товара: ");
                string name = Console.ReadLine();
                Console.Write("Введите цену товара: ");
                double price = Convert.ToDouble(Console.ReadLine());
                product[i] = new Product(code, name, price);
                jsonProduct[i] = JsonSerializer.Serialize(product[i], options);
            }

            foreach (string j in jsonProduct)
            {
                Console.WriteLine(j);
            }
            
            File.WriteAllLines(path, jsonProduct);

            Console.ReadKey();

        }

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
}

