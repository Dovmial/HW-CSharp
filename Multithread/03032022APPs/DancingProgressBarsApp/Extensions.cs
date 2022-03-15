using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DancingProgressBarsApp
{
    public static class Extensions
    {
        delegate void Increment();
        public static void IncrementInvoke(this ProgressBar pb, int step = 1)
        {
            pb.Invoke(new Increment(() => { pb.Value += step; }));
        }
    }
}
