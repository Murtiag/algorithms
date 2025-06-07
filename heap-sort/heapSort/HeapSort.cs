namespace heapSort;

public class HeapSort<T> where T: IComparable<T> {
    public HeapSort(){}

    public static T[] Sort(T[] array, int size) {
        // one element can not be sorted
        if (size <= 1) {
            return array;
        }

        // first loop if more than 1 element
        for (int i = size / 2 - 1; i >= 0; i--) {

            // create max heap
            Heapify(array, size, i);
        }

        for (int i = size - 1; i >= 0; i--) {

            // swap last with first element
            (array[0], array[i]) = (array[i], array[0]);

            // rebuild heap
            Heapify(array, i, 0);
        }

        return array;
    }

    private static void Heapify (T[] array, int size, int index) {
        var largestIndex = index;
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;

        // swap left with max if larger
        if (leftChild < size && array[leftChild].CompareTo(array[largestIndex]) > 0) {
            largestIndex = leftChild;
        }

        // swap right with max if larger
        if(rightChild < size && array[rightChild].CompareTo(array[largestIndex]) > 0){
            largestIndex = rightChild;
        }

        // only swap if on last child in tree
        if (largestIndex != index) {
            (array[index], array[largestIndex]) = (array[largestIndex], array[index]);

            Heapify(array, size, largestIndex);
        }
    }
}