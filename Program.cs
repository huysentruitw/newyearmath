using System;

namespace NewYearMath
{
    class Program
    {
        public static void Main()
        {
            var operations = FindCombination(2019, 10);
            Console.WriteLine(operations != null ? "Combination found!!!" : "No combination found");
            Console.ReadKey();
        }

        public static Operation[] FindCombination(int targetYear, int countDownFrom = 10)
        {
            var operations = new Operation[countDownFrom - 1];
            var result = 0;
            while (result != targetYear)
            {
                result = countDownFrom;
                Console.Write(result);
                for (var i = countDownFrom - 1; i > 0; i--)
                {
                    var operationIndex = countDownFrom - i - 1;
                    switch (operations[operationIndex])
                    {
                        case Operation.Add:
                            Console.Write(" + ");
                            result += i;
                            break;
                        case Operation.Subtract:
                            Console.Write(" - ");
                            result -= i;
                            break;
                        case Operation.Multiply:
                            Console.Write(" * ");
                            result *= i;
                            break;
                        case Operation.Divide:
                            Console.Write(" / ");
                            result /= i;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.Write(i);
                }

                Console.Write(" = ");
                Console.WriteLine(result);

                for (var i = 0; i < operations.Length; i++)
                {
                    if (operations[i] < Operation.Divide)
                    {
                        operations[i]++;
                        break;
                    }

                    if (i == operations.Length - 1) return null;
                    operations[i] = Operation.Add;
                }
            }

            return operations;
        }
    }

    public enum Operation
    {
        Add = 0,
        Subtract = 1,
        Multiply = 2,
        Divide = 3
    }
}
