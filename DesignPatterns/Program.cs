using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desing patterns");
            #region Singleton
            // приватный конструктор не дает создать объект через new 
            // var obj = new CreationalPatterns.Singleton();
            // Xарактерным признаком паттерная "Одиночка" является запрос GetInstance
            var obj = CreationalPatterns.Singleton.GetInstance();
            Console.WriteLine(obj.Moment);
            var obj2 = CreationalPatterns.Singleton.GetInstance();
            Console.WriteLine(obj == obj2 ? "Equals" : "Not equals");

            #endregion
        }
    }
}