using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desing patterns");
            Console.WriteLine("1  Creational: ");
            Console.WriteLine("11 Singleton: ");
            Console.WriteLine("2  Behavioral: ");
            Console.WriteLine("21 Strategy: ");
            String? userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "11":
                    #region Singleton
                    // Приватный конструктор не дает создать объект через new 
                    // var obj = new CreationalPatterns.Singleton();

                    // Xарактерным признаком паттерная "Одиночка" является запрос GetInstance
                    var obj = CreationalPatterns.Singleton.GetInstance();
                    Console.WriteLine(obj.Moment);
                    var obj2 = CreationalPatterns.Singleton.GetInstance();
                    Console.WriteLine(obj == obj2 ? "Equals" : "Not equals");
                    #endregion
                    break;
                case "21":
                    #region Strategy
                    var StrategyDemo = new BehavioralPatterns.Strategy();
                    // Автоматическая работа
                    StrategyDemo.Show();
                    // Задание: Вывести по всем стратегиям
                    // Название - значение
                    StrategyDemo.ShowDetails();
                    
                    #endregion
                    break;
                default:
                    Console.WriteLine("Invalid Choice 💩");
                    break;

            }
            

            
        }
    }
}