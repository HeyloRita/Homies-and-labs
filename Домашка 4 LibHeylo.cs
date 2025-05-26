using System;
using System.Linq;
using System.Collections.Generic;

namespace LibHeylo
{
    public class MathOperations
    {
        public double Сложить(double a, double b)
        {
            return a + b;
        }

        public double Вычесть(double a, double b)
        {
            return a - b;
        }

        public double Умножить(double a, double b)
        {
            return a * b;
        }

        public double Разделить(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно.");
            }
            return a / b;
        }

        public double Возвести_в_степень(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        public double Найти_квадрат(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Квадратный корень из отрицательного числа не может быть вычислен.");
            }
            return Math.Sqrt(number);
        }

        public void Ввод_и_вывод_математических_операций()
        {
            Console.WriteLine("Выберите операцию: 1) Сложить 2) Вычесть 3) Умножить 4) Разделить 5) Возвести в степень 6) Найти квадратный корень");
            int choice = int.Parse(Console.ReadLine());

            double a, b;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите первое число:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите второе число:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Результат сложения: {Сложить(a, b)}");
                    break;
                case 2:
                    Console.WriteLine("Введите первое число:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите второе число:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Результат вычитания: {Вычесть(a, b)}");
                    break;
                case 3:
                    Console.WriteLine("Введите первое число:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите второе число:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Результат умножения: {Умножить(a, b)}");
                    break;
                case 4:
                    Console.WriteLine("Введите первое число:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите второе число:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Результат деления: {Разделить(a, b)}");
                    break;
                case 5:
                    Console.WriteLine("Введите основание:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите степень:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Результат возведения в степень: {Возвести_в_степень(a, b)}");
                    break;
                case 6:
                    Console.WriteLine("Введите число для вычисления квадратного корня:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Квадратный корень: {Найти_квадрат(a)}");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    public class Statistics
    {
        public double Среднее_значение(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.");
            }
            return numbers.Average();
        }

        public double Медиана(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.");
            }

            Array.Sort(numbers); //Сортирует в порядке возрастания
            int n = numbers.Length;
            double median;

            if (n % 2 == 0)
            {
                median = (numbers[n / 2 - 1] + numbers[n / 2]) / 2.0;
            }
            else
            {
                median = numbers[n / 2];
            }

            return median;
        }

        public double Мода(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.");
            }

            var groupedNumbers = numbers.GroupBy(n => n).OrderByDescending(g => g.Count()).ToList();
            return groupedNumbers.First().Key;
        }

        public double Стандартное_отклонение(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.");
            }

            double mean = Среднее_значение(numbers);
            double sumOfSquares = numbers.Sum(n => Math.Pow(n - mean, 2));
            return Math.Sqrt(sumOfSquares / numbers.Length);
        }

        public void Ввод_и_вывод_статистики()
        {
            Console.WriteLine("Введите количество элементов в массиве:");
            int count = int.Parse(Console.ReadLine());
            double[] numbers = new double[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите элемент {i + 1}:");
                numbers[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Среднее значение: {Среднее_значение(numbers)}");
            Console.WriteLine($"Медиана: {Медиана(numbers)}");
            Console.WriteLine($"Мода: {Мода(numbers)}");
            Console.WriteLine($"Стандартное отклонение: {Стандартное_отклонение(numbers)}");
        }
    }
}
