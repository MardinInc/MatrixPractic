public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            try

            {
                Console.WriteLine("\nВведите три коэффициента двух уравнений через пробел,\nНовое уравнение начинается с новой строки");

                var firstString = Console.ReadLine().Split();

                var secondString = Console.ReadLine().Split();

                double[] firstEq = new double[3];

                double[] secondEq = new double[3];

                for (int i = 0; i < 3; i++)
                {

                    firstEq[i] = double.Parse(firstString[i]);

                    secondEq[i] = double.Parse(secondString[i]);

                }

                Kramer(firstEq, secondEq);

            }

            catch (Exception ex)
            {

                Console.WriteLine("Некорректные данные");

            }
        }
    }

    public static void Kramer(double[] firstEq, double[] secondEq)

    {
        var delta = firstEq[0] * secondEq[1] - firstEq[1] * secondEq[0];

        var deltaX = firstEq[2] * secondEq[1] - firstEq[1] * secondEq[2];

        var deltaY = firstEq[0] * secondEq[2] - firstEq[2] * secondEq[0];


        Console.WriteLine("delta = " + delta);

        Console.WriteLine("delta x = " + deltaX);

        Console.WriteLine("delta y = " + deltaY);

        if (delta != 0)
        {
            var x = deltaX / delta;

            var y = deltaY / delta;

            Console.WriteLine("x = " + x);

            Console.WriteLine("y = " + y);
        }

        else if (deltaX == 0 && deltaY == 0)
        {
            Console.WriteLine("Система линейных уравнений имеет множество решений");
        }

        else
        {
            Console.WriteLine("У системы линейных уравнений нет решений");
        }

        DefinitionLine(firstEq, "Первая");

        DefinitionLine(secondEq, "Вторая");
    }

    public static void DefinitionLine(double[] eq, string numberLine)
    {
        if (eq[0] != 0 && eq[1] != 0)
        {
            Console.WriteLine(numberLine + " прямая общего положения");
        }

        else if (eq[0] == 0 && eq[1] == 0)
        {
            Console.WriteLine(numberLine + " прямая - это множество точек плоскости");
        }

        else if (eq[0] == 0 && eq[1] != 0 && eq[2] != 0)
        {
            Console.WriteLine(numberLine + " прямая параллельна оси OY");
        }

        else if (eq[0] != 0 && eq[1] == 0 && eq[2] != 0)
        {
            Console.WriteLine(numberLine + " прямая параллельна оси OX");
        }

        else if (eq[0] != 0 && eq[1] == 0 && eq[2] == 0)
        {
            Console.WriteLine(numberLine + " прямая - это ось OX");
        }

        else if (eq[0] == 0 && eq[1] != 0 && eq[2] == 0)
        {
            Console.WriteLine(numberLine + " прямая - это ось OY");
        }
    }
}
