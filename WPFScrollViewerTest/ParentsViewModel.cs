using System.Collections.Generic;
using System.Linq;

namespace WPFScrollViewerTest
{

    public class ParentsViewModel
    {
        public List<List<int>?>? Parents { get; set; }

        public ParentsViewModel()
        {
            Parents = GetFamily();
        }

        private static List<List<int>?>? GetFamily()
        {
            return new List<List<int>?>
            {
                Enumerable.Range(1, 5).ToList(),
                Enumerable.Range(1, 2).ToList(),
                Enumerable.Range(1, 15).ToList(),
                Enumerable.Range(1, 20).ToList(),
                Enumerable.Range(1, 5).ToList(),
                Enumerable.Range(1, 10).ToList(),
                Enumerable.Range(1, 20).ToList(),
                Enumerable.Range(1, 20).ToList(),
            };
        }

    }
}
