using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Работа с числами");
            Console.WriteLine("2. Объединение массивов");
            Console.WriteLine("3. Поиск книги в библиотеке");
            Console.WriteLine("0. Выход");
            Console.Write("\nВаш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            switch (choice)
            {
                case 1:
                    WorkWithNumbers();
                    break;
                case 2:
                    MergeArrays();
                    break;
                case 3:
                    CheckBookAvailability();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        } while (true);
    }

    static void WorkWithNumbers()
    {
        List<double> numbers = new List<double>();

        while (true)
        {
            Console.Write("Введите число или команду (sum/exit): ");
            string input = Console.ReadLine();

            if (input == "sum")
            {
                double sum = CalculateSum(numbers);
                Console.WriteLine($"Сумма всех введённых чисел: {sum}");
            }
            else if (input == "exit")
            {
                break; // Завершаем выполнение программы
            }
            else
            {
                try
                {
                    double number = Convert.ToDouble(input); // Преобразуем строку в число
                    numbers.Add(number); // Добавляем число в список
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод! Пожалуйста, введите число или команду.");
                }
            }
        }
    }

    static double CalculateSum(List<double> numbers)
    {
        return numbers.Sum(); // Используем метод Sum() для вычисления суммы всех чисел в списке
    }

    static void MergeArrays()
    {
        Console.Write("Введите размер первого массива: ");
        int size1 = int.Parse(Console.ReadLine());
        int[] array1 = new int[size1];

        Console.Write("Введите элементы первого массива: ");
        for (int i = 0; i < size1; i++)
        {
            array1[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите размер второго массива: ");
        int size2 = int.Parse(Console.ReadLine());
        int[] array2 = new int[size2];

        Console.Write("Введите элементы второго массива: ");
        for (int i = 0; i < size2; i++)
        {
            array2[i] = int.Parse(Console.ReadLine());
        }

        List<int> mergedArray = MergeTwoArrays(array1, array2);

        Console.WriteLine("Объединённый массив:");
        foreach (var item in mergedArray)
        {
            Console.Write(item + " ");
        }
    }

    static List<int> MergeTwoArrays(int[] array1, int[] array2)
    {
        return array1.Concat(array2).ToList(); // Объединяем два массива и возвращаем результирующий список
    }

    static void CheckBookAvailability()
    {
        string[] books = { "Война и мир", "Мастер и Маргарита", "Преступление и наказание" };

        while (true)
        {
            Console.Write("Введите название книги: ");
            string bookTitle = Console.ReadLine().Trim().ToLower(); // Приводим к нижнему регистру для нечувствительности к регистру

            bool isAvailable = Array.Exists(books, b => b.ToLower() == bookTitle); // Проверяем наличие книги в списке

            if (isAvailable)
            {
                Console.WriteLine($"Книга '{bookTitle}' доступна в библиотеке.");
            }
            else
            {
                Console.WriteLine($"К сожалению, книга '{bookTitle}' отсутствует в библиотеке.");
            }

            Console.WriteLine("Хотите проверить ещё одну книгу? (Y/N)");
            if (Console.ReadLine().ToUpper() != "Y") break;
        }
    }
}