using System.Diagnostics;

namespace Console_Blank_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings;
            int[] ints;
            int[] intArrayToBeSorted;
            int[] intArrayToBeSearched;
            strings = new string[3]
            {
                "Hello",
                "This is",
                "An array"
            };
            ints = new int[3]
            {
                1,
                5,
                7
            };
            intArrayToBeSorted = new int[6]
            {
                3, 5, 2, 1, 4, 0
            };
            intArrayToBeSearched = new int[6]
            {
                2, 7, 6, 1, 12, 9
            };
            PrintElements(strings);
            Console.WriteLine("The sum of these numbers is " + SumInts(ints));
            Console.WriteLine("That this number is prime is " + FindIfNumIsPrime(5));
            Console.WriteLine("That this number is prime is " + FindIfNumIsPrime(6));
            Console.WriteLine("Array before sorting: " + string.Join(", ", intArrayToBeSorted));
            BubbleSort(intArrayToBeSorted);
            Console.WriteLine("Array after sorting: " + string.Join(", ",intArrayToBeSorted));
            BubbleSort(intArrayToBeSearched);
            Console.WriteLine("Array getting searched: " + string.Join(", ", intArrayToBeSearched));
            Console.WriteLine("The number is at index " + SearchArrayForInt(intArrayToBeSearched, 12));
        }
        static void PrintElements(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }
        static int SumInts(int[] intArray)
        {
            int total = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                total += intArray[i];
            }
            return total;
        }
        static bool FindIfNumIsPrime(int num)
        {
            bool isPrime = true;
            int maxNum = Convert.ToInt32(Math.Sqrt(num));
            if (num < 2)
            {
                return false;
            }
            else if (num == 2 || num == 3)
            {
                return true;
            }
            else
            {
                for (int i = 2; i <= maxNum; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                return isPrime;
            }
                
        }
        static void BubbleSort(int[] arrayToBeSorted)
        {
            int temp = 0;
            bool changeMade = false;
            for (int j = 0; j < arrayToBeSorted.Length; j++)
            {
                for (int i = 0; i < arrayToBeSorted.Length; i++)
                {
                    if (i < arrayToBeSorted.Length - 1)
                    {
                        if (arrayToBeSorted[i] > arrayToBeSorted[i + 1])
                        {
                            temp = arrayToBeSorted[i];
                            arrayToBeSorted[i] = arrayToBeSorted[i + 1];
                            arrayToBeSorted[i + 1] = temp;
                            changeMade = true;
                        }
                    }
                }
                if (!changeMade)
                {
                    break;
                }
                changeMade = false;
            }
        }
        static int SearchArrayForInt(int[] arrayToBeSearched, int num)
        {
            bool numFound = false;
            int index = 0;
            int numTimesToSplit = 0;
            int arrayStartIndex = 0;
            int arrayEndIndex = arrayToBeSearched.Length;
            float lengthBeingUsedToFindThePowerOfTwo = arrayToBeSearched.Length;

            while (lengthBeingUsedToFindThePowerOfTwo > 1)
            {
                lengthBeingUsedToFindThePowerOfTwo /= 2;
                numTimesToSplit++;
            }
            for (int i = 0; i <= numTimesToSplit; i++)
            {
                index = (arrayStartIndex + arrayEndIndex) / 2;
                if (arrayToBeSearched[index] == num)
                {
                    numFound = true;
                    break;
                }
                else if (num < arrayToBeSearched[index])
                {
                    arrayEndIndex = index;
                }
                else
                {
                    arrayStartIndex = index;
                }
            }
            if (numFound)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }
    }
}