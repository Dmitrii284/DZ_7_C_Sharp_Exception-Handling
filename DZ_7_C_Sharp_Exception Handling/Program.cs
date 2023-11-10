/*
 Написать класс Money, предназначенный для хранения денежной суммы (в рублях и копейках). Для класса
реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое
число), * (умножение суммы на целое число), ++ (сумма
увеличивается на 1 копейку), -- (сумма уменьшается на 1 копейку), <, >, ==, !=.
Класс не может содержать отрицательную сумму.
В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
исключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money.
Обработка исключительных ситуаций производится в программе.
 */

using static DZ_7_C_Sharp_Exception_Handling.Money;

namespace DZ_7_C_Sharp_Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                Money m1 = new Money(10, 50);
                Money m2 = new Money(5, 25);

                Money sum = m1 + m2;
                Console.WriteLine($"Сумма: {sum}");

                Money diff = m1 - m2;
                Console.WriteLine($"Разность: {diff}");

                Money div = sum / 2;
                Console.WriteLine($"Деление: {div}");

                Money mul = sum * 3;
                Console.WriteLine($"Умножение: {mul}");

                Money inc = ++m1;
                Console.WriteLine($"Увеличение: {inc}");

                Money dec = --m1;
                Console.WriteLine($"Уменьшение: {dec}");

                if (m1 < m2)
                    Console.WriteLine($"{m1} меньше, чем {m2}");

                if (m1 > m2)
                    Console.WriteLine($"{m1} больше, чем {m2}");

                if (m1 == m2)
                    Console.WriteLine($"{m1} равно {m2}");

                if (m1 != m2)
                    Console.WriteLine($"{m1} не равно {m2}");

                // Генерация исключительной ситуации Банкрот
                Money bankrupt = new Money(-10, 0);
            }
            catch (BankruptException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}