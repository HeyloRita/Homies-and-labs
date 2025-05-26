using System;

namespace CompanyStructure
{
    public class PremiyaException : Exception
    {
        public PremiyaException(string message) : base(message) { }
    }

    public class OkladException : Exception
    {
        public OkladException(string message) : base(message) { }
    }

    public class Firma
    {
        public string Название { get; set; }
    }

    public class Otdel
    {
        public string Название { get; set; }
        public int КоличествоСотрудников { get; set; }
    }

    public class Sotrudnik
    {
        public string ФИО { get; set; }
        public string Должность { get; set; }
        private decimal оклад;

        public decimal Оклад
        {
            get { return оклад; }
            set
            {
                if (value < 0)
                    throw new OkladException($"Невозможно создать сотрудника – указан отрицательный оклад: {value}");
                оклад = value;
            }
        }

        public virtual decimal РассчитатьЗарплату()
        {
            try
            {
                return оклад;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при расчете зарплаты: {ex.Message}");
                return 0;
            }
        }
    }

    public class ShtatnyySotrudnik : Sotrudnik
    {
        public decimal Премия { get; set; }

        public override decimal РассчитатьЗарплату()
        {
            try
            {
                if (Премия < 0)
                    throw new PremiyaException("Премия не может быть отрицательной.");
                return Оклад + Премия;
            }
            catch (PremiyaException ex)
            {
                Console.WriteLine($"Ошибка при расчете зарплаты: {ex.Message}");
                return Оклад;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при расчете зарплаты: {ex.Message}");
                return 0;
            }
        }
    }

    public class SotrudnikPoKontraktu : Sotrudnik
    {
        public override decimal РассчитатьЗарплату()
        {
            try
            {
                return Оклад;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при расчете зарплаты: {ex.Message}");
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShtatnyySotrudnik shtatnyy = new ShtatnyySotrudnik { ФИО = "Иванов И.И.", Должность = "Менеджер", Оклад = 50000, Премия = -1000 };
                Console.WriteLine($"Зарплата: {shtatnyy.РассчитатьЗарплату()}");

                Sotrudnik sotrudnik = new Sotrudnik { ФИО = "Петров П.П.", Должность = "Разработчик", Оклад = -50000 };
            }
            catch (OkladException ex)
            {
                Console.WriteLine(ex.Message);
            }

            SotrudnikPoKontraktu kontraktnyy = new SotrudnikPoKontraktu { ФИО = "Сидоров С.С.", Должность = "Тестировщик", Оклад = 40000 };
            Console.WriteLine($"Зарплата контрактного сотрудника: {kontraktnyy.РассчитатьЗарплату()}");

            Console.ReadKey();
        }
    }
}
