namespace Sortering
{
    public class BubbleSort
    {
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Sammenligner naboelementer
                    if (array[j] > array[j + 1])
                    {
                        // Hvis det aktuelle element er større end det næste, så byt dem
                        Swap(array, j, j + 1);
                    }
                }
            }
        }
    }
}
