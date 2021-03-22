using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>(n);

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ");
           
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
              articles =   articles.OrderBy(x => x.Title)
                    .ToList();// и двете със сорт вършат едно и също
            }
            else if (criteria == "content")
            {
               articles.Sort((c1,c2)=> c1.Content.CompareTo(c2.Content));
            }
            else if (criteria == "author")
            {
               articles =  articles.OrderBy(x => x.Author)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine,articles));
        }
    }
}
