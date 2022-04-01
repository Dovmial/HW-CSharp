using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace BookDownloadApp
{
    public class ParserHTML
    {
        public int TimeDelay { get; private set; } = 6000;
        string site = @"https://www.gutenberg.org";
        string searchRequest = @"https://www.gutenberg.org/ebooks/search/?query=";
        public string Code404error { get; } = "No records found.";
        public List<Book> Books { get; private set; } = new List<Book>(100);
        public List<Book> BooksSearch { get; private set; } = new List<Book>();
        static HttpClient client = new HttpClient();

        private List<List<Book>> _listsBooks = new List<List<Book>>()
        {
            new List<Book>(25),
            new List<Book>(25),
            new List<Book>(25),
            new List<Book>(25)
        };

        private List<string> urlsSortedDownloads = new List<string>()
        {
            @"https://www.gutenberg.org/ebooks/search/?sort_order=downloads&start_index=1",
            @"https://www.gutenberg.org/ebooks/search/?sort_order=downloads&start_index=26",
            @"https://www.gutenberg.org/ebooks/search/?sort_order=downloads&start_index=51",
            @"https://www.gutenberg.org/ebooks/search/?sort_order=downloads&start_index=76"
        };

        public void GetBooksTop100()
        {

            Task.Run(() =>
            {
                var result = Parallel.For(
                    0,
                    urlsSortedDownloads.Count,
                    async i => await GetBooksAsync(urlsSortedDownloads[i], _listsBooks[i]));
            });

            Thread.Sleep(TimeDelay);
            initBooks();
        }

        private void initBooks()
        {
            if (Books.Count > 0)
                Books.Clear();
            foreach (var list in _listsBooks)
                Books.AddRange(list);
            _listsBooks.Clear();
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            return html;
        }

        private async Task GetBooksAsync(string url, List<Book> books)
        {
            var textHTML = await GetHtmlAsync(url);
            HtmlParser(textHTML, books, isSearching: false);
        }

        private void HtmlParser(in string html, List<Book> books, bool isSearching)
        {
            string[] keys = { "booklink", "href=\"/", "src=\"/", "title\">", "subtitle\">" };
            string url;
            string ImageUrl;

            int indexStart = 0;
            while (true)
            {
                indexStart = html.IndexOf(keys[0], indexStart);
                if (indexStart < 0)
                    break;
                Book book = new Book();

                url = GetString(keys[1], ref indexStart, '"', html);
                // ebooks/1342 -> files/1342/1342-0.txt
                book.Url = strategyUrlParsing(url,isSearching);

                if (!isSearching)
                {
                    ImageUrl = $"{site}/{GetString(keys[2], ref indexStart, '"', html)}";
                    book.ImageBook = GetImageFromUrl(ImageUrl);
                }

                book.Title = GetString(keys[3], ref indexStart, '<', html);
                book.Author = GetString(keys[4], ref indexStart, '<', html);
                books.Add(book);
            }
        }
        private string GetString(in string key, ref int indexStart, char endSymbol, in string html)
        {
            indexStart = html.IndexOf(key, indexStart) + key.Length;
            int indexEnd = html.IndexOf(endSymbol, indexStart);
            return html.Substring(indexStart, indexEnd - indexStart);
        }

        public async Task SearchAsync(string keySearch)
        {
            string url = $@"{searchRequest}/{keySearch}&submit_search=Go%21";
            var html =  await GetHtmlAsync(url);
            Thread.Sleep(TimeDelay/3);
            if (html.Contains(Code404error))
                return;
            HtmlParser(html, BooksSearch, isSearching: true);
        }

        private string strategyUrlParsing(string url, bool isSeasching)
        {
            if (!isSeasching)
            {
                url = url.Replace("ebooks", "files");
                string number = $"{ url.Split('/')[1]}";
                return $"{site}/{url}/{number}-0.txt";
            }
            return $@"{site}/{url}";
        }

        private Image GetImageFromUrl(string url)
        {
            using (var stream = client.GetStreamAsync(url).Result)
            {
                return Image.FromStream(stream);
            }
        }
    }
}
