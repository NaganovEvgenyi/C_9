/* Задача 54: Задайте двумерный массив. Напишите программу,которая 
//упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2
Console.Clear();
int[,] FillMas(int n, int m)
{
    int[,] mas = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int k = 0; k < m; k++)
        {
            mas[i, k] = new Random().Next(0, 10);
        }
    }
    return mas;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int k = 0; k < arr.GetLength(1); k++)
        {
            if (k != arr.GetLength(1) - 1) Console.Write($"\t{arr[i, k]} ");
            else if (i == arr.GetLength(0) - 1 && k == arr.GetLength(1) - 1) Console.WriteLine($"\t{arr[i, k]}");
            else if (k == arr.GetLength(1) - 1) Console.WriteLine($" \t{arr[i, k]}");
        }
    }
}
 void Swap(ref int leftItem, ref int rightItem)
 {
     int temp = leftItem;

     leftItem = rightItem;

    rightItem = temp;
 }
int[,] SortDownLine(int[,] mas)
{
    for (int i = 0; i < mas.GetLength(0); i++) // Берем строку
    {
        for (int k = 0; k < mas.GetLength(1); k++)  // Перебираем ячейки в строке
        {
            for (int y = 0; y < mas.GetLength(1); y++)  // Перебираем сравниваемые элементы
            {
                if (mas[i, k] > mas[i, k]) Swap(ref mas[i, k], ref mas[i, k]); // Метод сортировки пузырьковый, но работает и надежный
            }
        }
    }
    return mas;
}
int[,] newArry = FillMas(3, 5);
PrintArray(newArry);
System.Console.WriteLine("____________");
PrintArray(SortDownLine(newArry));*/

/* Задача 56: Задайте прямоугольный двумерный массив. 
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7
//Программа считает сумму элементов в каждой строке и выдаёт номер строки 
//с наименьшей суммой элементов: 1 строка
Console.Clear();
int[,] FillMas(int n, int m)
{
    int[,] mas = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int k = 0; k < m; k++)
        {
            mas[i, k] = new Random().Next(0, 10);
        }
    }
    return mas;
}
void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int k = 0; k < arr.GetLength(1); k++)
        {
            if (k != arr.GetLength(1) - 1) Console.Write($"\t{arr[i, k]} ");
            else if (i == arr.GetLength(0) - 1 && k == arr.GetLength(1) - 1) Console.WriteLine($"\t{arr[i, k]}");
            else if (k == arr.GetLength(1) - 1) Console.WriteLine($" \t{arr[i, k]}");
        }
    }
}
int LowestLine(int[,] mas)
{
    int lowerIndex = 0;
    int[] sumInLine = new int[mas.GetLength(0)];
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        for (int k = 0; k < mas.GetLength(1); k++)
        {
            sumInLine[i] += mas[i, k];
        }
    }
    for (int i = 0; i < sumInLine.Length; i++)
    {
        for (int k = 0; k < sumInLine.Length; k++)
        {
            if (sumInLine[i] < sumInLine[k]) lowerIndex = i;
        }
    }
    return lowerIndex;
}
int[,] newArry = FillMas(5, 3);
PrintArray(newArry);
System.Console.WriteLine($"Самая маленькая суммма в массиве на {LowestLine(newArry)} строчке.");*/


//Задача 58: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц.
//Например, даны 2 матрицы:
//2 4 | 3 4
//3 2 | 3 3
//Результирующая матрица будет:
//18 20
//15 18
Console.Clear();
int[,] FillMas(int n, int m)
{
    int[,] mas = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int k = 0; k < m; k++)
        {
            mas[i, k] = new Random().Next(0, 10);
        }
    }
    return mas;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int k = 0; k < arr.GetLength(1); k++)
        {
            if (k != arr.GetLength(1) - 1) Console.Write($"\t{arr[i, k]} ");
            else if (i == arr.GetLength(0) - 1 && k == arr.GetLength(1) - 1) Console.WriteLine($"\t{arr[i, k]}");
            else if (k == arr.GetLength(1) - 1) Console.WriteLine($" \t{arr[i, k]}");
        }
    }
}
int[,] MatrixMultiply(int[,] mas1, int[,] mas2)
{
    int[,] result = new int[mas1.GetLength(0), mas2.GetLength(1)];
    if (mas1.GetLength(1) != mas2.GetLength(0) && mas1.GetLength(0) != mas2.GetLength(1)) return null;
    if (mas1.GetLength(1) != mas2.GetLength(0)) return MatrixMultiply(mas2, mas1);
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            for (int k = 0; k < mas1.GetLength(1); k++)
            {
                result[i, j] += mas1[i, k] * mas2[k, j];
            }
        }
    }
    return result;
}
int[,] newArry1 = FillMas(2, 3);
int[,] newArry2 = FillMas(3, 4);
System.Console.WriteLine("Первая матрица");
PrintArray(newArry1);
System.Console.WriteLine("Вторая матрица");
PrintArray(newArry2);
System.Console.WriteLine("Произведение матриц :");
try
{
    PrintArray(MatrixMultiply(newArry1, newArry2));
}
catch
{
    System.Console.WriteLine("Матрицы не совместимы");
}