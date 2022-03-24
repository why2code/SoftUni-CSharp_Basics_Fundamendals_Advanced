using System;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class Advertisment
    {
        public Advertisment()
        {
            this.phrases = new List<string>()
            {
                "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };

            this.events = new List<string>()
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            this.authors = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            this.cities = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };
        }


        public List<string> phrases { get; set; }
        public List<string> events { get; set; }
        public List<string> authors { get; set; }
        public List<string> cities { get; set; }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                Advertisment add = new Advertisment();
                List<string> mixedAdvertisment = new List<string>();

                string phraseRandom = add.phrases[rand.Next(0, add.phrases.Count)];
                string eventRandom = add.events[rand.Next(0, add.events.Count)];
                string authorRandom = add.authors[rand.Next(0, add.authors.Count)];
                string cityRandom = add.cities[rand.Next(0, add.cities.Count)];

                mixedAdvertisment.Add(phraseRandom);
                mixedAdvertisment.Add(" ");
                mixedAdvertisment.Add(eventRandom);
                mixedAdvertisment.Add(" ");
                mixedAdvertisment.Add(authorRandom);
                mixedAdvertisment.Add(" – ");
                mixedAdvertisment.Add(cityRandom);
                mixedAdvertisment.Add(".");

                Console.WriteLine(String.Join("", mixedAdvertisment));

            }
        }
    }
}
