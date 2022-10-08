// Assign the elements of an array in reversed order to a new array

int[] arr = {1,3,4,9,8,7,2,5};
int[] reverseArr = new int[arr.Length];

for (int i = 0; i < arr.Length; i++)
{
   reverseArr[i] = arr[arr.Length - i - 1];
}

printArray(arr);
printArray(reverseArr);

static void printArray(int[] arr)
{
    Console.WriteLine();

    foreach(int element in arr)
        {
            Console.Write(element + " ");
        }

    Console.Write("\n\n");
}
