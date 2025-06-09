using heapSort;

namespace heapSortTest {
    [TestClass]
    public sealed class HeapSortTest {
        [TestMethod]
        public void simpleSort() {
            int[] sortableArray = [2, 8, 5, 3, 9, 1];
            int[] expected = [1, 2, 3, 5, 8, 9];

            // sort
            int[] sortedArray = HeapSortVerbose<int>.Sort(sortableArray,sortableArray.Length);

            CollectionAssert.AreEqual(expected, sortedArray);
        }

        [TestMethod]
        public void alreadySorted() {
            int[] sortableArray = [0, 1, 2, 3, 4, 5];
            int[] expected = [0, 1, 2, 3, 4, 5];

            // sort
            int[] sortedArray = HeapSortVerbose<int>.Sort(sortableArray, sortableArray.Length);

            CollectionAssert.AreEqual(expected, sortedArray);
        }

        [TestMethod]
        public void duplicateElement() {
            int[] sortableArray = [20,4,2,6,2,5,10,6,1,0];
            int[] expected = [0,1,2,2,4,5,6,6,10,20];

            // sort
            int[] sortedArray = HeapSortVerbose<int>.Sort(sortableArray, sortableArray.Length);

            CollectionAssert.AreEqual(expected, sortedArray);
        }

        [TestMethod, TestCategory("performance")]
        public void verySmallSort() {
            internalTest(100);
        }

        [TestMethod, TestCategory("performance")]
        public void smallSort() {
            internalTest(1000);
        }

        [TestMethod, TestCategory("performance")]
        public void mediumSort() {
            internalTest(10000);
        }

        [TestMethod, TestCategory("performance")]
        public void largeSort() {
            internalTest(100000);
        }

        [TestMethod, TestCategory("performance")]
        public void veryLargeSort() {
            internalTest(1000000);
        }

        [TestMethod, TestCategory("performance")]
        public void megaLargeSort() {
            internalTest(10000000);
        }
        
        private void internalTest(int size) {
            int[] sortableArray = TestUtils.CreateRandomIntArray(size, 1, 1000000);
            int[] expected = new int[size];
            Array.Copy(sortableArray, expected, size);
            Array.Sort(expected);

            // sort
            int[] sortedArray = HeapSortVerbose<int>.Sort(sortableArray, sortableArray.Length, true);

            CollectionAssert.AreEqual(expected, sortedArray);
        }

    }
}
