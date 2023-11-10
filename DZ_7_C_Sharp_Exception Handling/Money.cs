using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
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
namespace DZ_7_C_Sharp_Exception_Handling
{
    internal class Money
    {
        private int rubles;
        private int kopeks;
        public int Rubles
        {
        get { return rubles; }
            set
            {
            if(value < 0)
                throw new BankruptException();
            Rubles = value;
            } 
        }
        public int Kopeks 
        {
            get { return kopeks; }
            set { 
            if( value < 0)
                    throw new BankruptException();
                kopeks = value % 100;
                rubles += value / 100;
            }
        }
        public Money(int rubles, int kopeks)
        {
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        public Money() { Rubles = 0; Kopeks = 0; }

        public static Money operator + (Money m1, Money m2)
        {
            return new Money(m1.Rubles + m2.Rubles, m1.Kopeks + m2.Kopeks);
        }
        public static Money operator - (Money m1, Money m2)
        {
            int totalKopeks =(m1.Rubles * 100 + m1.Kopeks) - (m2.Rubles * 100 + m2.Kopeks);
            if(totalKopeks < 0)            
                throw new BankruptException();
                return new Money(totalKopeks / 100, totalKopeks % 100);          
        }

        public static Money operator / (Money money, int divisor)
        {
            if(divisor  == 0)
                throw new DivideByZeroException();
            return new Money(money.Rubles/ divisor, money.Kopeks/ divisor);
        }

        public static Money operator * (Money money, int miltiplier)
        {
            int totalKopeks = money.Rubles * 100 + money.Kopeks * miltiplier;
            int newRubles = totalKopeks / 100;
            int newKopeks = totalKopeks % 100;

            return new Money(newRubles, newKopeks);
        }

        public static Money operator ++ (Money money)
        {
            return new Money(money.Rubles,money.Kopeks + 1);
        }

        public static Money operator -- (Money money)
        {
            return new Money(money.Rubles, money.Kopeks - 1);
        }

        public static bool operator > (Money m1 , Money m2 )
        {
            return (m1.Rubles * 100 + m1.Kopeks) > (m2.Rubles *100 + m2.Kopeks);
        }

        public static bool operator < (Money m1, Money m2)
        {
            return (m1.Rubles * 100 + m1.Kopeks) < (m2.Rubles * 100 + m2.Kopeks);
        }

        public static bool operator == (Money m1, Money m2)
        {
            return (m1.Rubles * 100 + m1.Kopeks) == (m2.Rubles * 100 + m2.Kopeks);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return (m1.Rubles * 100 + m1.Kopeks) != (m2.Rubles * 100 + m2.Kopeks);
        }

        public override string ToString()
        {
            return $"{Rubles} руб. {Kopeks} коп.";
        }

        public class BankruptException : Exception
        {
            public BankruptException() : base("Банкрот") { }
        }
    }
}
