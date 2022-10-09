/*
This is a manual implemenation
of the Binary search algorithm

This implemenation only takes
the array and the target value
as arguments, thus it performs
the search on the whole array,
unlike the binarySearch_V1 were
we provide the index values for
the left and right pointer,
allowing to slice the array

It's important to note that the
array must be sorted in order
for the Binary search algorithm
to work

Big O notation: O(log n)
*/

int[] myArray = {2, 4, 5, 11, 22, 24, 25, 38, 41, 44, 51, 53, 57, 58, 61, 65, 68, 82, 86};
int target = 82;

if(BinarySearch(myArray, target) != -1)
{
    Console.WriteLine($"Item {target} was found in the array");
}
else
{
    Console.WriteLine($"Item {target} was not found in the array");
}

int BinarySearch(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length;
    while(left <= right)
    {
        int middle = (left + right) / 2;
        if(arr[middle] == target)
        {
            return target;
        }
        else if(target < arr[middle])
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }
    return -1;
}
