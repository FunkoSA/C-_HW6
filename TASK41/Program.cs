/*
     Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

* 0, 7, 8, -2, -2 -> 2
* 1, -7, 567, 89, 223-> 3

 */

 using System;
 using static System.Console;

Clear();
WriteLine("Данная программа принимает разумное количество введенных с клавиатуры чисел и выводит ощее количество положительных из введенных на экран");
Write("Введите для аназила числа через пробел, либо запятой или точкой с зяпятой ");
int [] ArrayForAnalice = GetArrayFromString(ReadLine());

WriteLine($"Среди, введенных Вами, чисел {PositiveNumbers(ArrayForAnalice)} положительных.");

int PositiveNumbers (int[] array)
{
    int positive = 0;
    for(int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0) positive++;
    }
    
    return positive;
}

int [] GetArrayFromString (string arrayStr)
{
    string [] arS = arrayStr.Split(new char[] {' ', ',', ';',}, StringSplitOptions.RemoveEmptyEntries);
    int [] result = new int [arS.Length];
    for (int i = 0; i < arS.Length; i++)
    {
        result [i] = int.Parse(arS [i]);
    }
    return result;
}