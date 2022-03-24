using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
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

        public void EditContent(string content)
        {
            Content = content;
        }
        public void ChangeAutroh(string author)
        {
            Author = author;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return ($"{this.Title} - {this.Content}: {this.Author}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleInitialInput = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            string articleTitle = articleInitialInput[0].Trim();
            string articleContent = articleInitialInput[1].Trim();
            string articleAuthor = articleInitialInput[2].Trim();

            Article newArticleCreated = new Article(articleTitle, articleContent, articleAuthor);

            int commantsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commantsCount; i++)
            {
                List<string> receivedCommands = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = receivedCommands[0];
                string textToEdit = receivedCommands[1].Trim();

                if (command == "Edit")
                {
                    newArticleCreated.EditContent(textToEdit);
                }
                else if (command == "ChangeAuthor")
                {
                    newArticleCreated.ChangeAutroh(textToEdit);
                }
                else if (command == "Rename")
                {
                    newArticleCreated.Rename(textToEdit);
                }
            }

            Console.WriteLine(newArticleCreated.ToString());
        }
    }
}
