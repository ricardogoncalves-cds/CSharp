// Important C# array methods with examples

// Arrays used:

string[] animals = {"Dog", "Lion", "Dolphin", "Turtle", "Elephant", "Chimpanzee", "Eagle"};
int[] numbers = {3, 76, 11, 309, 132, 98, 99};

Console.WriteLine();


/*
--------------------------
1. Array.IndexOf()
--------------------------
Returns the index of an 
element of an array
*/

int indexValue = Array.IndexOf(animals, "Turtle");

Console.WriteLine("1. IndexOf()");
Console.WriteLine($"The index of 'Turtle' in the 'animals' array is {indexValue}\n");


/*
--------------------------
2. Array.Exists()
--------------------------
Checks whether or not
an element exists in
an array
*/

bool elementExist = Array.Exists(numbers, number => numbers.Contains(76));

Console.WriteLine("2. Exists()");
Console.WriteLine($"Does the 'numbers' array contain the number 50? {elementExist}\n");


/*
--------------------------
3. Array.Find()
--------------------------
Finds the first element in 
an array that matches the 
condition
*/

var foundElement = Array.Find(animals, animal => animal.Contains("T"));

Console.WriteLine("3. Find()");
Console.WriteLine($"{foundElement} was found in the 'animals' array\n");


/*
--------------------------
4. Array.FindLast()
--------------------------
Works like the Find method,
but starts from the end of
the array
*/

var foundLastElement = Array.FindLast(animals, animal => animal.Contains("o"));

Console.WriteLine("4. FindLast()");
Console.WriteLine($"{foundLastElement} was found in the 'animals' array\n");


/*
--------------------------
5. Array.FindIndex()
--------------------------
Find the index of an element
in an array using a predicate
*/

var indexSearch = Array.FindIndex(animals, animal => animal.Contains("on"));

Console.WriteLine("5. FindIndex()");
Console.WriteLine($"{indexSearch} is the index of an element that contains 'on'\n");

/*
--------------------------
6. Array.FindAll()
--------------------------
Find all the elements that
pass the condition
*/

var allFound = Array.FindAll(animals, animal => animal.Contains("an"));

Console.WriteLine("6. FindAll()");
Console.Write("The elements in 'animals' array contianing 'an' are: ");

foreach(var element in allFound)
{
    Console.Write($"{element} ");
}

Console.WriteLine("\n");


/*
--------------------------
7. Array.Reverse()
--------------------------
Reverses the elements
in an array
*/

Console.WriteLine("7. Reverse()");
Console.Write("Original 'numbers' array: ");

foreach(int number in numbers)
{
    Console.Write(number + " ");
}

Array.Reverse(numbers);

Console.WriteLine();
Console.Write("Reversed 'numbers' array: ");

foreach(int number in numbers)
{
    Console.Write(number + " ");
}

Console.WriteLine("\n");


/*
--------------------------
8. Array.Copy()
--------------------------
Copies the element of an 
array to another one

It takes 3 arguments:
source, destination, and
number of items to copy
*/

string[] animals2 = new string[animals.Length];

Array.Copy(animals, animals2, 3);

Console.WriteLine("8. Copy()");
Console.Write("The new array 'animals2' contains: ");

foreach(string animal in animals2)
{
    Console.Write(animal + " ");
}

Console.WriteLine("\n");


/*
--------------------------
9. Array.Sort()
--------------------------
Sorts elements of an array
*/

Array.Sort(numbers);

Console.WriteLine("9. Sort()");
Console.Write("Sorted 'numbers' array: ");

foreach(int number in numbers)
{
    Console.Write(number + " ");
}

Console.WriteLine("\n");


/*
--------------------------
10. Array.BinarySearch()
--------------------------
Search for an element in a
sorted array in acending 
order
*/

Array.Sort(animals);
int indexOfElement = Array.BinarySearch(animals, "Dog");

Console.WriteLine("10. BinarySearch()");
Console.Write("Sorted array: ");

foreach(string animal in animals)
{
    Console.Write(animal + " ");
}

Console.WriteLine();

if(indexOfElement == -1)
{
    Console.WriteLine("Not found");
}
else
{
    Console.WriteLine($"Dog is on index {indexOfElement}");
}

Console.WriteLine();
