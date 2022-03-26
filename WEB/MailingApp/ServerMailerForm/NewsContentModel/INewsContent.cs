
using System.Collections;
using System.Collections.Generic;

namespace ServerMailerForm.NewsContentModel
{
    public interface INewsContent : IEnumerable
    {
        List<string> News { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return News.GetEnumerator();
        }
        void NewsLoad();
    }
   
}
