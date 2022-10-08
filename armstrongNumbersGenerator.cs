// Generate Armstrong Numbers up to the value entered

Console.Write("Enter the maximum limit for searching: ");
int max = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= max; i++)
{
    if (isArmstrong(i))
        Console.WriteLine(i);
}
Console.ReadLine();
Console.Write("\n");

static bool isArmstrong(int x)
{
    if (x == RequiredSum(x))
        return true;
    else
        return false;
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
