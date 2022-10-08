/*
A better implementation of a program
to identify Armstrong Numbers
*/

Console.WriteLine("Enter the number:");
int value = int.Parse(Console.ReadLine());

if (value == RequiredSum(value))
{
    Console.WriteLine("Armstrong Number");
}
else 
{
    Console.WriteLine("Not an Armstrong Number");
}

static int CountDigits(int num)
{
    int i = 0; 
    for (;num > 0; ++i) num /= 10;

    return i;    
}

static int RequiredSum(int num)
{
    int count = CountDigits(num);

    int sum = 0;
    while (num > 0)
    {
        sum += (int)Math.Pow(num % 10, count);
        num /= 10;
        
    }

    return sum;
}
