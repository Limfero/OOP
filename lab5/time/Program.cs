namespace time
{
    internal class Program
    {
        static void Main()
        {
            CTime time1 = new(14, 30, 25);
            CTime time2 = new(4000);

            Console.WriteLine(time1.ToString());
            Console.WriteLine(time2.ToString());
            Console.WriteLine();
             
            time1++;
            Console.WriteLine("Инкримент: " + time1);
            time1--;
            Console.WriteLine("Дикримент: " + time1);

            CTime sum = time1 + time2;
            CTime difference = time1 - time2;
            CTime multiplied = time1 * 3;
            CTime divided1 = time1 / 0;
            int divided2 = time1 / time2;

            Console.WriteLine("Сумма: " + sum);
            Console.WriteLine("Разность: " + difference);
            Console.WriteLine("Умножение: " + multiplied);
            Console.WriteLine("Деление на число: " + divided1);
            Console.WriteLine("Деление на время: " + divided2);
            Console.WriteLine();

            bool isEqual = time1 == time2;
            bool isNotEqual = time1 != time2;
            bool isLess = time1 < time2;
            bool isGreater = time1 > time2;
            bool isLessOrEqual = time1 <= time2;
            bool isGreaterOrEqual = time1 >= time2;

            Console.WriteLine("Равны: " + isEqual);
            Console.WriteLine("Не равны: " + isNotEqual);
            Console.WriteLine("Меньше: " + isLess);
            Console.WriteLine("Больше: " + isGreater);
            Console.WriteLine("Меньше или равно: " + isLessOrEqual);
            Console.WriteLine("Больше или равно: " + isGreaterOrEqual);
        }
    }
}