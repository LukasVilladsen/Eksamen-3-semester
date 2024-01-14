namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal)
        {
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == tal)
                    {
                        return i; // Returner indekset, hvis tallet findes.
                    }
                }

                return -1; // Returner -1, hvis tallet ikke findes i arrayet.
            }
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal)
        {
            {
                int venstre = 0;
                int højre = array.Length - 1;

                while (venstre <= højre)
                {
                    int midten = (venstre + højre) / 2;

                    if (array[midten] == tal)
                    {
                        return midten; // Returner indekset, hvis tallet findes.
                    }
                    else if (array[midten] < tal)
                    {
                        venstre = midten + 1; // Tallet er muligvis i den højre del af arrayet.
                    }
                    else
                    {
                        højre = midten - 1; // Tallet er muligvis i den venstre del af arrayet.
                    }
                }

                return -1; // Returner -1, hvis tallet ikke findes i arrayet.
            }
        }
        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            {
                int[] sortedArray = { 2, 4, 8, 10, 15, 17, -1, -1, -1, -1 };  // Eksempel på et sorteret array
                int length = sortedArray.Length;

                // Check om der er nok plads i arrayet
                if (sortedArray[length - 1] != -1)
                {
                    // Ikke nok plads, returner uændret array
                    return sortedArray;
                }

                // Find det rigtige sted at indsætte det nye tal
                int insertIndex = 0;
                while (insertIndex < length - 1 && sortedArray[insertIndex] < tal)
                {
                    insertIndex++;
                }

                // Flyt elementer til højre for at gøre plads til det nye tal
                for (int i = length - 1; i > insertIndex; i--)
                {
                    sortedArray[i] = sortedArray[i - 1];
                }

                // Indsæt det nye tal på det rigtige sted
                sortedArray[insertIndex] = tal;

                return sortedArray;
            }
        }
    }
}