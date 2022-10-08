// Reverse of array in place

int[] arr = {1,3,4,9,8,7,2,5};

printArray(arr, "Original");

for (int i = 0; i < arr.Length / 2; i++)
{
   int tmp = arr[i];
   arr[i] = arr[arr.Length - i - 1];
   arr[arr.Length - i - 1] = tmp;
}

printArray(arr, "Reversed");

static void printArray(int[] arr, string type)
{
    Console.WriteLine();
    Console.WriteLine($"{type} array");

    foreach(int element in arr)
        {
            Console.Write(element + " ");
        }

    Console.Write("\n\n");
}
