using System;
using System.Collections.Generic;

namespace Article2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString()
        {
            return ($"{this.Title} - {this.Content}: {this.Author}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int articleNumbers = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < articleNumbers; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
                string title = commandArgs[0].Trim();
                string content = commandArgs[1].Trim();
                string author = commandArgs[2].Trim();

                articles.Add(new Article(title, content, author));
            }

            string commandToSort = Console.ReadLine();
            OrderListOfArticles(articles, commandToSort);

            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine($"{articles[i].Title} - {articles[i].Content}: {articles[i].Author}");

            }




        }

        static void OrderListOfArticles(List<Article> articles, string commandToSort)
        {

            if (commandToSort == "title")
            {
                articles.Sort((p, q) => p.Title.CompareTo(q.Title));

            }
            else if (commandToSort == "content")
            {
                articles.Sort((p, q) => p.Content.CompareTo(q.Content));

            }
            else if (commandToSort == "author")
            {
                articles.Sort((p, q) => p.Author.CompareTo(q.Author));

            }
        }

    }
}

