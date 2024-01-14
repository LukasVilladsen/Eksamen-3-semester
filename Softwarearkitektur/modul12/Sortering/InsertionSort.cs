namespace Sortering
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                // Flyt elementer af array, der er større end key, til en position foran deres aktuelle position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
            }
        }
    }
}