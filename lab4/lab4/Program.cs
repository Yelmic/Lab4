using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    interface IGeneric<T> //интерфейс
    {
        void Add(T item);
        void Remove(T item);
        void Display(Set<T> Items);
    }
    public class Set<T> : IGeneric<T> 
    {
        public int x=9;
        public class Date
        {
            public string date;
            public string x;
            public Date()
            {
                date = DateTime.Now.ToString();
            }
        }
        public class Owner
        {
            public int id = 8;
            public string name = "Елена Михновец";
            public string organization = "БГТУ";
        }
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        public void Display(Set<T> Item)
        {
            foreach (T elem in Item.Items)
            {
                Console.Write($"{elem}  ");
            }
            Console.WriteLine();
        }
        public static int count;
        public Set()
        {
            count++;
            Console.WriteLine($"Создано {count}-е множество");
        }
        public static string operator >(T elem, Set<T> item)
        {

            if (item.Items.Contains(elem))
            {
                return $"{elem} находится в этом множестве";
            }
            else
            {
                return $"{elem} нету в  этом множестве";
            }
        }
        public static string operator <(T item1, Set<T> item2)
        {
            if (!item2.Items.Contains((item1)))
            {
                return $"{item1} нету в этом множестве";
            }
            else
            {
                return $"{item1} есть в этом множестве";
            }
        }
        public static string operator *(Set<T> item1, Set<T> item2)
        {
            Console.WriteLine("Пересечение множеств");
            List<T> item3 = new List<T>();
           foreach (T elem in item1.Items)
           {
                if (item2.Items.Contains(elem))
                {
                    item3.Add(elem);
                }
           }
            foreach (T elems in item3)
            {
                Console.WriteLine(elems);
            }
            return null;
        }
        public static explicit operator Date(Set<T> im)
        {
            throw new NotImplementedException();//Это исключение выбрасывается, когда запрошенный метод или операция не реализованы.
        }
}
    static public class StaticOperation
    {
        static int count;
        static int sum;
        static int max=-900000;
        static int min = 99999;
        public static void Sum(Set<int> Item)
        {
            foreach (int elem in Item.Items)
            {
                sum += elem;
            }
            System.Console.WriteLine($"Сумма элементов {sum}");
        }
        public static void Difference(Set<int> Item)
        {

            foreach (int elem in Item.Items)
            {
                if (elem > max)
                {
                    max = elem;
                }
                if (elem < min)
                {
                    min = elem;
                }
            }
            int difference = max - min;
            Console.WriteLine($"Разница между максимальным и минимальным элементом {difference}");
        }
        public static void Count(Set<int> Item)
        {
            foreach (int elem in Item.Items)
            {
                count++;
            }
            Console.WriteLine($"Количество элементов {count}");
            count = 0;
        }
        public static void First_number(this string str) // Выделение первого числа, содержащего в строке
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))//подходит ли символ к десятичным цифрам
                {
                    Console.WriteLine($"Первая цифра строки {str[i]}");
                    break;
                }
            }
        }
        public static void Delete(this Set<int> item) // Удаление положительных элементов из множества
        {
            Set<int> item2 = new Set<int>();
            for (int i = 0; i < item.Items.Count; i++)
            {
                if (item.Items[i] < 0)
                {
                    item2.Items.Add(item.Items[i]);
                }
            }
            Console.WriteLine("После удаление положительных элементов");
            for (int i = 0; i < item2.Items.Count; i++)
            {
                Console.Write(item2.Items[i] + " ");
                
            }
            Console.WriteLine();
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Set<int>.Date today = new Set<int>.Date();
            Console.WriteLine("Сегодняшняя дата");
            Console.WriteLine(today.date);
            Set<int>.Owner person = new Set<int>.Owner();
            Console.WriteLine("Мои данные");
            Console.WriteLine(person.id+" "+person.name+" "+person.organization+'\n');
            Set<int> obj1 = new Set<int>();
            obj1.Add(-5);
            obj1.Add(3);
            obj1.Add(-2);
            obj1.Add(7);
            obj1.Add(3);
            obj1.Add(-1);
            obj1.Display(obj1);
            StaticOperation.Count(obj1);
            StaticOperation.Sum(obj1);
            Set<int> obj2 = new Set<int>();
            obj2.Add(1);
            obj2.Add(2);
            obj2.Add(3);
            obj2.Add(7);
            obj2.Display(obj2);
            StaticOperation.Count(obj2);
            StaticOperation.Difference(obj2);
            var element = -5 > obj1;
            Console.WriteLine(element);
            var qwe = 6 < obj1;
            Console.WriteLine(qwe);
            var crossing = obj1 * obj2;
            Console.WriteLine(crossing);
            string str = "l3ol4bdxfd25ef6";
            Console.WriteLine(str);
            StaticOperation.First_number(str);
            StaticOperation.Delete(obj1);
            Set<int> im = new Set<int>();
        }
    }
}
