using System;

/* ЧЕКЛИСТ
*   1 +
*   2 +
*   3 +
*   4 -
*   5 -
*   6 -
*   7 -
*   8 -
*   9 -
*/

class Matrix
{
    public int n, m;
    double[,] matrix;

    public Matrix(int n, int m)
    {
        this.n = n;
        this.m = m;
        matrix = new double[n, m];
    }

    public void setMatrix()
    {
        Console.WriteLine("Введите n строк по m чисел (числа в строке вводятся через пробел):");
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = double.Parse(line[j]);
            }
        }
    }

    public void setRandom(double a, double b)
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = a + rnd.NextDouble() * (b - a);
            }
        }
    }

    public void printMatrix()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public double this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }

    public static Matrix operator +(Matrix matrix1, Matrix other)
    {
        if (matrix1.n != other.n || matrix1.m != other.m)
        {
            Console.WriteLine("Нельзя сложить матрицы разной размерности");
            return null;
        }
        Matrix ans = new Matrix(matrix1.n, matrix1.m);
        for (int i = 0; i < ans.n; i++)
        {
            for (int j = 0; j < ans.m; j++)
            {
                ans[i, j] = matrix1[i, j] + other[i, j];
            }
        }
        return ans;
    }
}

public interface IMyInterface
{
    
}

// Ввод размеров массива с клавиатуры
Console.Write("Введите количество строк (n): ");
int n = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов (m): ");
int m = int.Parse(Console.ReadLine());

// Создание объекта класса Matrix
Matrix matrix = new Matrix(n, m);

// Заполнение матрицы значениями
matrix.setMatrix();

// Вывод матрицы на экран
matrix.printMatrix();

matrix.setRandom(1, 10);
matrix.printMatrix();