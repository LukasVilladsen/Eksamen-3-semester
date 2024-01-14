namespace Sortering
{
    public class SelectionSort
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
                // Find det mindste element i den uordnede del af arrayet
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Byt det mindste element med det første element i den uordnede del
                Swap(array, i, minIndex);
            }
        }
    }
}
