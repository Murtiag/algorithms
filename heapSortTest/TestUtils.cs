namespace heapSortTest;

public class TestUtils {
    public static int[] CreateRandomIntArray(int size, int lower, int upper)
    {
        var array = new int[size];
        var rand = new Random();
        for (int i = 0; i < size; i++)
            array[i] = rand.Next(lower, upper);
        return array;
    }
}