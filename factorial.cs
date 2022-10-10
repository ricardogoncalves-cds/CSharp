/*
Factorial multiplies a number by
all its subsequent numbers.

For example:
5! = 5*4*3*2*1

But:
5! = 5*4! and 4! = 4*3!

This is a good example of recursion.

In computing, recursion is the idea,
of a function calling itself to
perform a task.

Below is a simple implementation of
a factorial function that uses 
recursion in its logic
*/

int f = factorial(5);
Console.WriteLine(f);

static int factorial(int n)
{
    if(n == 1)
        return 1;
    else
    {
        int result = n * factorial(n-1);
        return result;
    }
}
