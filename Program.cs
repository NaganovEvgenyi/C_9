// Задача 54: Задайте двумерный массив. Напишите программу,которая 
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
PrintArray(SortDownLine(newArry));