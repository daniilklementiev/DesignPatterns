using System;
using System.Text.RegularExpressions;

namespace DesignPatterns.BehavioralPatterns
{
    public class ObserverDemo
    {
        public void Show()
        {
            TextWriter textWriter = new TextWriter();
            SymbolCounter symbolCounter = new SymbolCounter();  
            WordSearcher wordSearcher = new WordSearcher();
            DigitCounter digitCounter = new DigitCounter();
            textWriter.Subscribe(symbolCounter); 
            textWriter.Subscribe(wordSearcher);
            textWriter.Subscribe(digitCounter);
            Console.WriteLine("Type smth");
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                textWriter.State = textWriter.State + k.KeyChar;
            } while (k.Key != ConsoleKey.Enter);
        }
    }

    interface Observer
    {
        void Update(object state);
    }

    abstract class Subject
    {
        private List<Observer> Observers;
        private object state;

        public Subject()
        {
            Observers = new List<Observer>();
        }

        public void Subscribe(Observer observer)
        {
            if(!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }
        public void Unubscribe(Observer observer)
        {
            if (Observers.Contains(observer))
            {
                Observers.Remove(observer);
            }
        }
        public virtual void Notify(object arg = null!)
        {
            if (arg == null) arg = this.state;
            foreach(Observer obs in Observers)
            {
                obs.Update(arg);
            }
        }
    }

    class TextWriter : Subject
    {
        private String _state;
        public String State
        {
            get => _state;
            set
            {
                _state = value;
                base.Notify(_state);
            }
        }

        public TextWriter() : base()
        {
            State = string.Empty;
        }
    }

    class SymbolCounter : Observer
    {
        public void Update(object state)
        {
            
            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.CursorLeft = 0;
                Console.CursorTop = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"cnt: {str.Length}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorTop = top;
                Console.CursorLeft = left;
                
            }
            else throw new ArgumentException("String expected");
        }
    }

    class WordSearcher : Observer
    {
        public void Update(object state)
        {
            
            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.CursorLeft = 0;
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Hi cnt: {Regex.Matches(str, "Hi").Count}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorTop = top;
                Console.CursorLeft = left;
            }
            else throw new ArgumentException("String expected");
        }
    }

    class DigitCounter : Observer
    {
        public void Update(object state)
        {
            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Digit cnt: {Regex.Matches(str, "[0-9]").Count}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorTop = top;
                Console.CursorLeft = left;
            }
            else throw new ArgumentException("String expected");
        }
    }

}
/* Наблюдатель(Observer)
Шаблон, реализующий "поток" событий от центра(Subject) к подписчикам(Subscribers)
Противопоставляется клиент-серверной схеме, в которой клиенты проявляют активность,
а серверы лишь отвечают, не имея возможности ининциировать обмен данными
Наиболее популярный приме - события и обработчиик событий

Ключевые моменты -
 - Две группы участников - Источники событий (Subject) и Наблюдатели
 - Каждый источник содержит коллекцию наблюдателей
 - При возникновении события источник перебирая коллекцию уведомляет наблюдателей
   путем вызова их методов
 - Традиционно, источник имеет состояние, которое передается как аргумент при вызове
   методов наблюдателей

   Пример: набор текста (как источник) и наблюдатели
     - считающий символы
     - проводящий поиск ключевых слов

 
 */

