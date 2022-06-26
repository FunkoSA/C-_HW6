/* 
    Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

* b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; 5,5) 
y = k1 * x + b1
y = k2 * x + b2

k2 * x + b2 = k1 * x + b1
y = k1 * x + b1

b2 - b1 = k1 * x - k2 * x 
y = k1 * x + b1

X = (b2 - b1) / (k1 - k2);
Y = k1 * X + b1;

(n+1)-я прямая добавляет n точек

(n+1)n/2 

(0 линий + 1) 0 / 2 = 0
(1 линия + 1) 1 / 2 = 1
(2 линии + 1) 2 / 2 = 3
(3 линии + 1) 3 / 2 = 6
(4 линии + 1) 4 / 2 = 10

*/


 using System;
 using static System.Console;

Clear();
WriteLine("Данная программа выводит точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.");

Write("Введите последовательно n раз значения K и B для описания прямых y = kn * x + bn разделяя их пробелом, либо запятой или точкой с зяпятой ");
int [] ArrayForAnalice = GetArrayFromString(ReadLine());
//Для того чтобы задача имела решения нужно минимум 2 прямые, а значит две мары переменных для описания уравнения прямой

while (ArrayForAnalice.Length %2 != 0 || ArrayForAnalice.Length /2 == 1 || ArrayForAnalice.Length == 2)
{
    WriteLine("Введено не парное количество значени1 переменных b и k, пожалуйста повторите ввод:");
    ArrayForAnalice = GetArrayFromString(ReadLine());
}

CrossOfLine(ArrayForAnalice);

/*
В общем случае с двумя прямыми имеем одно пересечение ((1 линия + 1) 1 / 2 = 1), две пары переменных половина массива - количество пар переменных array.Length/2 = 2, 
значит чтобы привести к общей формуле добавления точек пересечения необходимо вычесть 1 -> ((array.Length/2)-1 +1)*((array.Length/2)-1)/2 = (2 - 1 + 1)*(2-1)/2 = 1
проверим с тремя парами координат array.Length/2 = 3 -> ((array.Length/2)-1 +1)*((array.Length/2)-1)/2 = (3-1+1)*(3-1)/2 = 3

то есть в формуле, определяющей количество точек пересечений прямых (n+1)n/2 в нашем случае n = (array.Length/2)-1

в частном случае когда 2 пары переменных уравнения прявых принимают вид

y = array[0] * x + array[1]
y = array[2] * x + array[3]

одно решение 

y = array[0] * x + array[1]
array[0] * x + array[1] = array[2] * x + array[3]
(array[0] - array[2]) * x =  array[3] - array[1]
x =  (array[3] - array[1])/(array[0] - array[2])

array.Length = 4
количество прогона циклов в методе нахождения точки пересечения ((array.Length/2)-1 +1)*((array.Length/2)-1)/2 = 1

X = (array[3] - array[1]) / (array[0] - array[2]);
Y = array[0] * array[1];

i+=2 шаг


в случае если линий 3 и более необходимо вычислить точки пересечения первой прямой со всеми остальными, потом перейти ко второй и вычислить пересечения с оставшимисяю
Нужен вложенный цыкл

то есть смотрим пересечение i прямой со всеми j прямыми до конца массива и переходим к следующей i прямой 

j+=2 до n-i

X = (array[i+j] - array[i-2]) / (array[i-3] - array[i-2+j]);
Y = array[i-3] * array[i-2];


*/



void CrossOfLine (int [] lines)
{   
    WriteLine($"Вы задали переменные, описывающие функции {lines.Length / 2} прямых, точки пересечения для них следующие:");
    int countCrosses = 1; 
    for (int i = 3; i < lines.Length; i+=2)
    {
        
        
        for (int j=0; j < (lines.Length - i)  ; j+=2)
        {

            double x = (double) (lines[i+j] - lines[i-2]) / (lines[i-3] - lines[i-1+j]);
            double y = (double) lines[i-3] * x + lines[i-2];
            WriteLine($"{countCrosses} пересевение: прямая Y = {lines[i-3]} * X + {lines[i-2]} с прямой Y = {lines[i-1+j]} * x + {lines[i+j]} в точке с координами [{x:f2} ; {y:f2}]");
            countCrosses++;
        }
        
    }
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