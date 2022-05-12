using System;
using DesignPatterns.CreationalPatterns;
using DesignPatterns.StructuralPatterns;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Desing patterns");
            Console.WriteLine("1  Creational: ");
            Console.WriteLine(" 11 Singleton: ");
            Console.WriteLine(" 12 Simple Factory: ");
            Console.WriteLine(" 13 Factory Method: ");
            Console.WriteLine(" 14 Abstract Factory: ");
            Console.WriteLine(" 15 Builder: ");
            Console.WriteLine("2  Behavioral: ");
            Console.WriteLine(" 21 Strategy: ");
            Console.WriteLine(" 22 Observer: ");
            Console.WriteLine("3  Structural: ");
            Console.WriteLine(" 31 Decorator: ");
            Console.WriteLine(" 32 Bridge: ");
            Console.WriteLine(" 33 Proxy: ");
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
                case "12":
                    #region Factory
                    new CreationalPatterns.FactoryDemo().Show();
                    #endregion
                    break;
                case "13":
                    #region Factory Method
                    new CreationalPatterns.FactoryMethodDemo().Show();
                    #endregion
                    break;
                case "14":
                    #region Abstract Factory
                    new CreationalPatterns.AbstractFactoryDemo().Show();
                    #endregion
                    break;
                case "15":
                    #region Builder
                    new CreationalPatterns.BuilderDemo().Show();
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
                case "22":
                    #region Observer
                    Console.Clear();
                    new BehavioralPatterns.ObserverDemo().Show();
                    #endregion
                    break;
                case "31":
                    #region Decorator
                    new Decorator().Show();
                    #endregion
                    break;
                case "32":
                    #region Bridge
                    new StructuralPatterns.BridgeDemo().Show();
                #endregion
                    break;
                case "33":
                    #region Proxy
                    new StructuralPatterns.ProxyDemo().Show();
                    #endregion
                    break;

                default:
                    Console.WriteLine("Invalid Choice 💩");
                    break;

            }
            

            
        }
    }
}