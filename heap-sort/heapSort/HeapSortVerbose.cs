using arraySort;

namespace heapSort;

public class HeapSortVerbose<T> where T : IComparable<T> {

    public HeapSortVerbose() { }

    public static T[] Sort(T[] array, int size, bool smallPrint = false) {
        // step counters
        int comparisonCount = 0;
        int swapCount = 0;
        int heapifyCalls = 0;

        void Heapify(T[] array, int size, int index) { 
            heapifyCalls++;

            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;

            // swap left with max if larger
            if (leftChild < size ) {
                comparisonCount++;

                if (array[leftChild].CompareTo(array[largestIndex]) > 0) {
                    largestIndex = leftChild;
                }
            }

            // swap right with max if larger
            if (rightChild < size) {
                comparisonCount++;

                if (array[rightChild].CompareTo(array[largestIndex]) > 0) {
                    largestIndex = rightChild;

                }
            }

            // only swap if on last child in tree
            if (largestIndex != index) {
                swapCount++;

                (array[index], array[largestIndex]) = (array[largestIndex], array[index]);

                Heapify(array, size, largestIndex);
            }
        }

        if (!smallPrint) {
            Console.WriteLine("input: {0}", string.Join(',', array));
        }

        // one element can not be sorted
        if (size <= 1) {
            return array;
        }

        Utils.PrintDivider();
        Console.WriteLine(" array has {0} elements, binary heap tree needs ~{1} layers", array.Length, Math.Ceiling((Math.Log2(size + 1) - 1)) + 1);
        Utils.PrintDivider();
        Console.WriteLine("STEP: creating max heap");

        for (int i = size / 2 - 1; i >= 0; i--) {

            // create max heap
            Heapify(array, size, i);
        }

        if (!smallPrint) {
            Console.WriteLine("INFO: heapified array: {0}", string.Join(',', array));
        }

        Console.WriteLine("STEP: starting sort");

        for (int i = size - 1; i >= 0; i--) {
            swapCount++;

            // swap last with first element
            (array[0], array[i]) = (array[i], array[0]);

            // rebuild heap
            Heapify(array, i, 0);
        }

        if (!smallPrint) {
            Console.WriteLine("INFO: sorted array: {0}", string.Join(",", array));
        }

        Utils.PrintDivider();
        Console.WriteLine("STATS:");
        Console.WriteLine(" Total heapify calls: {0}", heapifyCalls);
        Console.WriteLine(" Total comparisons: {0}", comparisonCount);
        Console.WriteLine(" Total swaps: {0}", swapCount);
        var total = heapifyCalls + comparisonCount + swapCount;
        Console.WriteLine(" Total steps: {0}", total);
        Console.WriteLine("efficiency: {0} times input size", total/ array.Length);

        return array;
    }
}