using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDownloadApp
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Image ImageBook { get; set; }
        public override string ToString()
        {
            return $"Title - {Title}\nAuthor - {Author}\nURL - {Url}";
        }

    }
}
