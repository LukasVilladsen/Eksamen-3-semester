namespace Sortering
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            _mergeSort(array, 0, array.Length - 1);
        }

        private static void _mergeSort(int[] array, int l, int h)
        {
            if (l < h)
            {
                int m = (l + h) / 2;
                _mergeSort(array, l, m);
                _mergeSort(array, m + 1, h);
                Merge(array, l, m, h);
            }
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {
            int n1 = middle - low + 1;
            int n2 = high - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Kopier data til midlertidige arrays leftArray[] og rightArray[]
            for (int i = 0; i < n1; ++i)
                leftArray[i] = array[low + i];
            for (int j = 0; j < n2; ++j)
                rightArray[j] = array[middle + 1 + j];

            // Fusionér de midlertidige arrays tilbage i array[l..h]
            int iMerge = low; // Initialt indeks for sammensmeltet underarray
            int iLeft = 0;    // Initialt indeks for det venstre underarray
            int iRight = 0;   // Initialt indeks for det højre underarray

            while (iLeft < n1 && iRight < n2)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                {
                    array[iMerge] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    array[iMerge] = rightArray[iRight];
                    iRight++;
                }
                iMerge++;
            }

            // Kopier de resterende elementer i leftArray[], hvis der er nogen
            while (iLeft < n1)
            {
                array[iMerge] = leftArray[iLeft];
                iLeft++;
                iMerge++;
            }

            // Kopier de resterende elementer i rightArray[], hvis der er nogen
            while (iRight < n2)
            {
                array[iMerge] = rightArray[iRight];
                iRight++;
                iMerge++;
            }
        }
    }
}
