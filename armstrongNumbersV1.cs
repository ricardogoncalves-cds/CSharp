/*
An armstring number is a number of lenght 
N where the sum of all the individual digits
to the power of N is equal to the number 
itself;

For example:
371 has 3 digits, so in this case we will
sum the result of every individual digit
(3, 7, 1) to the power of 3: 
3^3 + 7^3 + 1^3 = 371
371 is an example of an armstrong number!

This is a simple number that verifies if a
number entered by the user is an armstrong 
number or not.
*/

var input = "";
string quit = "Exit";

while(input != quit)
{
    input = inputMenu();

    if(input != quit)
    {
        try
        {
            int sum = 0;
            int i = 0;
            int number = Int32.Parse(input);

            int[] digits = input.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            while(i < digits.Length)
            {
                sum += (int)Math.Pow(digits[i], digits.Length);
                i++;
            }

            drawLine();

            if(number == sum)
            {
                Console.WriteLine(input + " is an armstrong number");
            } else {
                Console.WriteLine(input + " is not an armostrong number");
            }

            drawLine();
        }
        catch (FormatException)
        {
            Console.WriteLine($"Invalid value! Unable to parse '{input}'");
        }
    } else {
        Console.WriteLine(input);
    }
}

static void drawLine()
{
    Console.WriteLine("---------------------------------------------------");
}

static string inputMenu()
{
    Console.WriteLine();
    Console.WriteLine("Enter 'Exit' to quit the program!");
    Console.WriteLine("Please enter an integer to verify if it is an Armstrong Number");
    Console.Write(">>> ");
    var value = Console.ReadLine();
    if(value != null)
    {
        return value;
    } else {
        return "Invalid value. Unable to process 'null' value";
    }
}
