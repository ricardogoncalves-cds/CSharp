/*
This is a manual implemenation
of the Binary search algorithm

This implementation allows to
provide the starting index values
for the left and right pointers

It's important to note that the
array must be sorted in order
for the Binary search algorithm
to work

Big O notation: O(log n)
*/

int[] myArray = {2, 4, 5, 11, 22, 24, 25, 38, 41, 44, 51, 53, 57, 58, 61, 65, 68, 82, 86};
int elementToFind = 38;

if(BinarySearch(myArray, 0, myArray.Length, elementToFind) != -1)
{
    Console.WriteLine($"Item {elementToFind} was found in the array");
}
else
{
    Console.WriteLine($"Item {elementToFind} not found in the array");
}

// BinarySearch implementation
int BinarySearch(int[] arr, int left, int right, int target)
{
    if(left <= right)
    {
        int middle = (left + right) / 2;

        if(arr[middle] == target)
        {
            return target;
        }

        if(arr[middle] > target)
        {
            return BinarySearch(arr, left, middle - 1, target);
        }
        else
        {
            return BinarySearch(arr, middle + 1, right, target);
        }
    }

    return -1;
}
