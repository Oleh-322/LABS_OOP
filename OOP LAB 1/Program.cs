using System.Numerics;

double First_task()
{
    double x = 0, c = 0, b = 0, y = 0;

    Console.WriteLine("Enter x: ");
    x = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter c: ");
    c = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter b: ");
    b = double.Parse(Console.ReadLine());

    y = ((2 * x - c) / (Math.Sqrt(x - b))) + Math.Abs(x - c);

    return y;
}

void Second_task()
{
    //Дано матрицю розміром n на m з дійсними елементами.
    //Побудувати послідовність b1, b2, b3 .... bk — це добуток квадратів тих елементів k-го рядка,
    //модулі яких належать до відрізку [1, 1.5]

    Console.WriteLine("Enter the number of rows (n): ");
    int rows = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the number of columns (m): ");
    int cols = int.Parse(Console.ReadLine());

    double[,] matrix = new double[rows, cols];

    Fill_matrix(matrix, rows, cols);
    Print_matrix(matrix, rows, cols);

    double result = 1, element = 0;
    List<double> lst = new List<double>();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            element = matrix[i, j];
            if (Math.Abs(matrix[i, j]) >= 1 && Math.Abs(matrix[i, j]) <= 1.5)
                result *= Math.Pow(element, 2);
        }
        lst.Add(result);
    }

    Console.Write("\n(If all values = 1, then no such elements were found that satisfy the condition)\nResulting: ");

    foreach (double elem in lst)
        Console.Write(elem + " ");
}

void Third_task()
{
    //Дано дійсні числа  x1, x2,...,x10,  y1, y2,...,y10. Знайти периметр десятикутника, вершини якого мають відповідно координати.
    //Визначити функцію обчислення відстані між двома точками, що задані своїми координатами.

    Console.WriteLine("Do you want to enter the numbers yourself (enter 1) or let the computer do it (enter 2)");
    int choice = int.Parse(Console.ReadLine());

    double[] vector_x = new double[10];
    double[] vector_y = new double[10];
    double p = 0;

    if (choice == 1)
    {
        Console.WriteLine("Enter value x:");
        Enter_Numbers_Yourself(vector_x, 10);

        Console.WriteLine("Enter value y:");
        Enter_Numbers_Yourself(vector_y, 10);
    }
    else if (choice == 2)
    {
        Enter_Numbers_Random(vector_x, 10);
        Enter_Numbers_Random(vector_y, 10);
    }

    for (int i = 0; i < 9; i++)
    {
        double side = calc_distance(vector_x[i], vector_x[i + 1], vector_y[i], vector_y[i + 1]);
        p += side;
    }

    Console.WriteLine("\nP = " + p);
}

void Fill_matrix(double[,] matrix, int rows, int cols)
{
    Random random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = random.NextDouble();
        }
    }
}
void Print_matrix(double[,] matrix, int rows, int cols)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
void Enter_Numbers_Yourself(double[] vec, int amount)
{
    for (int i = 0; i < amount; i++)
    {
        Console.Write("Enter a value at index " + i + ": ");
        vec[i] = double.Parse(Console.ReadLine());
    }
}
void Enter_Numbers_Random(double[] vec, int amount)
{
    Random random = new Random();
    for (int i = 0; i < amount; i++)
    {
        vec[i] = random.NextDouble();
    }
}
double calc_distance(double x1, double x2, double y1, double y2)
{
    return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
}

bool exit = false;
while (!exit)
{
    Console.WriteLine("Оберіть завдання:");
    Console.WriteLine("1. Перше завдання");
    Console.WriteLine("2. Друге завдання");
    Console.WriteLine("3. Третє завдання");
    Console.WriteLine("0. Вийти");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            First_task();
            break;
        case 2:
            Second_task();
            break;
        case 3:
            Third_task();
            break;
        case 0:
            exit = true;
            break;
        default:
            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            break;
    }
}