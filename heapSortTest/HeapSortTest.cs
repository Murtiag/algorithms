using heapSort;
using System.Linq;

namespace heapSortTest {
    [TestClass]
    public sealed class HeapSortTest {
        [TestMethod]
        public void simpleSort() {
            int[] sortableArray = [1, 4, 5, 2, 0,3];
            int[] expected = [0, 1, 2, 3, 4, 5];

            // sort
            int[] sortedArray = HeapSort<int>.Sort(sortableArray,sortableArray.Length);

            Console.WriteLine("sorted array: {0}", string.Join(",", sortedArray));
            CollectionAssert.AreEqual(expected, sortedArray);
        }

        [TestMethod]
        public void alreadySorted() {
            int[] sortableArray = [0, 1, 2, 3, 4, 5];
            int[] expected = [0, 1, 2, 3, 4, 5];

            // sort
            int[] sortedArray = HeapSort<int>.Sort(sortableArray, sortableArray.Length);

            Console.WriteLine("sorted array: {0}", string.Join(",", sortedArray));
            CollectionAssert.AreEqual(expected, sortedArray);
        }
    }
}
