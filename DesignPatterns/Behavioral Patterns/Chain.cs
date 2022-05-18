using System;
using System.Data;

namespace DesignPatterns.BehavioralPatterns
{
    public class ChainDemo
    {
        public void Show()
        {
            Manipulation
                coffee = new Coffee(),
                boiling = new Boiling(),
                sugar = new SugarInserter(),
                milk = new MilkInserter(),
                ins = new CoffeeInserter();
            coffee.Next = boiling;
            boiling.Next = ins;
            ins.Next = milk;
            milk.Next = sugar;

            coffee.Execute(150);

            Console.WriteLine("---------------");
            Manipulation coffee2 = new Coffee();
            Console.WriteLine("Variation 1/2?");
            if (Console.ReadKey().Key == ConsoleKey.D1)
            {
                coffee2
                .SetNext(new Boiling())
                .SetNext(new CoffeeInserter())
                .SetNext(new SugarInserter())
                .SetNext(new MilkInserter());
            }
            else
            {
                coffee2
                .SetNext(new MilkInserter())
                .SetNext(new Boiling())
                .SetNext(new CoffeeInserter())
                .SetNext(new SugarInserter());
            }
            Console.WriteLine("Volume: ");
            try
            {

                coffee2.Execute(Int32.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Process failed with message '{ex.Message}' ");
            }
        }
    }

    abstract class Manipulation
    {
        public Manipulation Next { get; set; }
        public Manipulation SetNext(Manipulation next)
        {
            Next = next;
            return Next;
        }
        abstract public void Execute(int volume);
    }

    class Coffee : Manipulation
    {
        public override void Execute(int volume)
        {
            Console.WriteLine("Coffee preparing starts...");
            Next?.Execute(volume);
        }
    }

    class Boiling : Manipulation
    {
        
        public override void Execute(int volume)
        {
            if (volume > 300)
            {
                throw new ArgumentException("Boiler capacity overloaded (300ml max)");
            }
                Console.WriteLine("Water boiling starts...");
            Next?.Execute(volume);
        }
    }

    class SugarInserter : Manipulation
    {
        public override void Execute(int volume)
        {
            Console.WriteLine("Sugar inserts...");
            Next?.Execute(volume);
        }
    }

    class MilkInserter : Manipulation
    {
        public override void Execute(int volume)
        {
            Console.WriteLine("Filling milk... (50ml)");
            Next?.Execute(volume + 50);
        }
    }

    class CoffeeInserter : Manipulation
    {
        public override void Execute(int volume)
        {
            Console.WriteLine("Coffee inserts...");
            Next?.Execute(volume);
        }
    }

}

/*  Chain of Responsibilies, CoR (Цепочка зависимостей)
С развитием также получил название MiddleWare
Создает "цепочку" рабочих процессов и дает возможность встраивать в нее
новые элементы "в середину"
Общая идея похожа на:
 - связанный список, но есть возможность прервать цепочку на любом звене
 - хуки, но встраиванием обычно занимается контейнер (хук обычно не хранит
    ссылку на следующий)
 - callback (по завершению тела функции вызывается следующий сallback)
В некоторых случаях кроме возможности прервать цепочку, есть возможность
 перейти на другое звено, в т.ч. на ее начало
Реализация паттерна:
 - В стиле связанного списка: каждое звено хранит ссылку на следующее звено
     Node { next; handle() { ... next; handle() } }
 - В стиле хука: каждое звено получает зависимость от цепочки
     Node {   handle(chain)  {  chain.doNext()  } }

Основные отличия в характере связывания звеньев в цепь:
- node1 = new ConcreteNode1(); node2 = new ConcreteNode2(); node2.next(node1)
- chain = new { ConcreteNode1(), ConcreteNode2() }
    а также можно декларативно: chain.config [ ConcreteNode1; ConcreteNode2 ]
?? как встроить новый узел в середину (между 1 и 2) ??
- разорвать старую связь 2-1 и построить новые 2-new-1
- добавить новый узел в нужное место списка инициализации chain
?? как поменять порядок работы узлов ??
?? а потом вернуть в исходный или снова поменять ??

Шаблон очень популярен в Enterprise разработке, в частности, в веб-разработке
запрос - [] - ответ
[] = [Есть подключение к БД? -- Есть данные авторизации? -- Права админа? -- ... ]
            \ лендинг              \ гостевая                \ ...

ТЗ.
Кофе: приготовление кофе состоит из следующих процессов:
 - кипячение воды
 - добавление кофе
 - добавление сахара
 - добавление молока
Рассматриваем возможность изменения как порядка так и составления (количества)
    процессов


 */
