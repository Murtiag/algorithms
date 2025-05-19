/*
    C. Fibonacci
       Verwenden Sie einen Stack, um die Fibonacci-Folge iterativ bis zu einer gewünschten Zahl zu
       berechnen. Die gewünschte Zahl soll von der Console eingelesen werden. Für die Berechnung
       dürfen Sie ausschliesslich einen Stack<long> (gemäss Aufgabe 1) und eine for-Schlaufe
       verwenden. Am Schluss soll das Resultat auf der Console ausgegeben werden.
 */

long getFibonacci(long goal) {
    Stack<long> stack = new Stack<long>();
    stack.Push(0);
    stack.Push(1);

    // 0, 1, 1, 2, 3, 5, 8, 13
    for (long i = 1; stack.Peek() <= goal; i++) {
        Console.WriteLine(i.ToString());
        var top = stack.Peek();
        stack.Pop();
        var last = stack.Peek();
        stack.Push(last);
        stack.Push(last + top);
    }

    return stack.Peek();
}

Console.WriteLine("Enter a number:");

string input = Console.ReadLine();

Console.WriteLine(getFibonacci((long)Convert.ToDouble(input)));