using System;
namespace DesignPatterns.BehavioralPatterns
{
    public class Strategy
    {
        List<Double> data = new List<Double>() { 1, 2, 3, 4, 5 };
        MeanCalculator? meanCalculator;
        public Strategy()
        {
            meanCalculator = new MeanCalculator();
            meanCalculator.Strategies.Add(new MeanArithmetic());
            meanCalculator.Strategies.Add(new MeanHarmonic());
            meanCalculator.Strategies.Add(new MeanGeometric());
            meanCalculator.Strategies.Add(new MeanQubed());
        }
        public void Show()
        {
            Console.WriteLine("Mean : ");
            foreach(var mean in meanCalculator.GetAll(data))
            {
                Console.WriteLine(mean);
            }
            Console.WriteLine($"Greatest : {meanCalculator.GetGreatest(data)}");
        }

        public void ShowDetails()
        {
            Console.WriteLine("Details:");
            foreach (IMeanValue strategy in meanCalculator.Strategies)
            {
                String algo = strategy.GetType().Name;
                double val = strategy.GetMean(data);
                Console.WriteLine($"Algo : {algo} \n  Value : {val}");
            }
        }
    }

    interface IMeanValue
    {
        double GetMean(List<Double> arr);
    }

    class MeanArithmetic : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 0;
            int n = arr.Count;
            foreach(var x in arr)
            {
                ret += x;
            }
            return ret / n;
        }
    }

    class MeanHarmonic : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 0;
            int n = arr.Count;
            foreach (var x in arr)
            {
                ret += 1 / x;
            }
            return n / ret;
        }
    }

    class MeanGeometric : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 1;
            int n = arr.Count;
            foreach (var x in arr)
            {
                ret *= x;
            }
            return Math.Pow(ret, 1.0 / n);
        }
    }

    class MeanQubed : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 1;
            int n = arr.Count;
            foreach (var x in arr)
            {
                ret += Math.Pow(x, 3);
            }
            
            return Math.Pow(ret /= n, 1.0 / 3.0);
        }
    }

    class MeanCalculator
    {
        public List<IMeanValue> Strategies = new List<IMeanValue>();

        public Double GetGreatest(List<Double> arr)
        {
            if (Strategies.Count != 0)
            {

                double ret = Strategies[0].GetMean(arr);
                foreach (IMeanValue it in Strategies)
                {
                    if (it.GetMean(arr) > ret) ret = it.GetMean(arr);
                }
                return ret;
            }
            else throw new Exception("Strategies is null");
            
        }

        public List<Double> GetAll(List<Double> arr)
        {
            List<Double> ret = new List<Double>();
            foreach (IMeanValue strategy in Strategies)
            {
                ret.Add(strategy.GetMean(arr));
            }
            return ret;
        }
    }
}
/*
Паттерн Стратегия (Strategy)
Позволяет реализовывать (разрабатывать) несколько алгоритмов (версий, вариантов)
работы и:
а) переключаться между ними
б) выполнять все и выбирать оптимальный

- Пример-задача: расчет средних значений
Разновидности средних:
 - арифметическая
 - геометрическая
 - медиана
 - степенное
 - квадратическая
 - гармоническая

 */

