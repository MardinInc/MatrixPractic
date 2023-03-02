using System.Data;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите кол-во строк:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во столбцов:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int maxVal;
            int[,] oldMatrix = new int[a, b];
            int[,] newMatrix = new int[a, b];
            int[] chMatrix = new int[b];
            oldMatrix = FillMatrix(oldMatrix, a, b);
            ViewMatrix(oldMatrix, a, b);
            chMatrix = FindArrayWithMatrix(chMatrix, oldMatrix, a, b);
            maxVal = CalcAndViewArrayMaxNum(chMatrix);
            newMatrix = ChangeMatrix(oldMatrix, newMatrix, maxVal, chMatrix, a, b);
            ViewMatrix(newMatrix, a, b);
        }
        catch
        {
            Console.WriteLine("Ошибка ввода!");
        }
    }
    
    public static int[,] FillMatrix(int[,] matrix, int a, int b)
    {
        Random rnd = new Random();
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                matrix[i, j] = rnd.Next(-9, 9);
            }
        }
        return matrix;
    }
        
    public static void ViewMatrix(int[,] matrix, int a, int b)
    {
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (matrix[i, j] >= 0)
                {
                    Console.Write(" " + matrix[i, j] + " ");
                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
        
    public static int[] FindArrayWithMatrix(int[] array, int[,] matrix, int a, int b) 
    {
        for (int i = 0; i < b; i++)
        {
            for (int j = 0; j < a; j++)
            {
                if (matrix[j, i] < 0 && Math.Abs(matrix[j, i]) % 2 == 1)
                {
                    array[i] += Math.Abs(matrix[j, i]);
                }
            }
        }
        return array;
    }
        
    public static int CalcAndViewArrayMaxNum(int[] array)
    {
        int maxVal = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (maxVal < array[i])
            {
                maxVal = array[i];
            }
            Console.Write(array[i] + "  ");
        }
        Console.WriteLine();
        Console.WriteLine();
        return maxVal;
    }

    public static int[,] ChangeMatrix(int[,] oldM, int[,] newM, int maxVal, int[] array, int a, int b)
    {
        int val = 0;
        int key = 0;
        while (key <= maxVal)
        {
            for (int j = 0; j < b; j++)
            {
                if (array[j] == key)
                {
                    for (int i = 0; i < a; i++)
                    {
                        newM[i, val] = oldM[i, j];
                    }
                    val = val + 1;
                }
            }
            key += 1;
        }
        return newM;
    }
}