using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMailerForm.NewsContentModel
{
    public static class NewsBuilder
    {
        public static INewsContent? GetThematicNews(string type)
        {
            switch (type)
            {
                case "politic":
                    return new NewsPolitic();
                case "economics":
                    return new NewsEconomics();
                  
                case "sport":
                    return new NewsSport();
                default:
                    return null;
            }
        }
    }
}
