using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    internal class BuilderDemo
    {
        public void Show()
        {
            DrinkBuilder builder = new CoffeeBuilder();
            builder.SetMilk().SetSugar().SetSyrop(); // не обязательно вызывать сразу всё
            Drink drink = builder.Build();
            Console.WriteLine(drink.Description);
            Console.WriteLine("--------------------");
            DrinkDirector drinkDirector = new DrinkDirector(builder);
            drink = drinkDirector.MakeAmericano();
            Console.WriteLine(drink.Description);
            drink = drinkDirector.MakeEspresso();
            Console.WriteLine(drink.Description);
            Console.WriteLine("--------------------");

            Drink drink1 = new CoffeeBuilder().SetCinnamon().SetCream().SetIce().Build(); // вариант #2, сразу в одну строчку создаем объект
              // объект строится и становится drink1                                                                                                  
            Console.WriteLine(drink1.Description);


            // или можно использовать как одну переменную, повторно использовать ссылку
            drink1 = new CacaoBuilder()  // в отличии от "Drink drink1" переносится (семантика переноса)
                .SetSyrop()
                .SetSugar()
                .Build();
            Console.WriteLine(drink1.Description);  // более понятно для человека + данный код можно повторить почти на каждом языке программирования



            Drink drink2 = new CacaoBuilder().SetCinnamon().SetCream().Build();
            Console.WriteLine(drink2.Description);


            // без паттерна
            drink = new Coffee();
            drink.HasMilk = true;
            drink.HasCinnamon = true;
            Console.WriteLine(drink.Description); // менее понятно для человека


            // C# style без паттерна
            drink = new Cacao
            {
                HasCinnamon = true,
                HasChocko = true
            };
            Console.WriteLine(drink.Description);
        }
    }

    abstract class Drink
    {
        public string? Name { get; private set; }

        #region Состав напитка
        public bool HasMilk { get; set; } = false;
        public bool HasSugar { get; set; } = false;
        public bool HasSyrop { get; set; } = false;
        public bool HasCream { get; set; } = false;
        public bool HasChocko { get; set; } = false;
        public bool HasCinnamon { get; set; } = false;
        public bool HasIce { get; set; } = false;
        public String Feature { get; set; } = String.Empty;
        #endregion

        public Drink(string Name)
        {
            this.Name = Name;
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder(Name);

                if (HasMilk) sb.Append(" + milk");
                if (HasSugar) sb.Append(" + sugar");
                if (HasSyrop) sb.Append(" + syrup");
                if (HasCream) sb.Append(" + cream");
                if (HasChocko) sb.Append(" + chocko");
                if (HasCinnamon) sb.Append(" + cinnamon");
                if (HasIce) sb.Append(" + ice");
                if (Feature != String.Empty) sb.Append($" ({Feature}) " );

                return sb.ToString();
            }
        }
    }

    class Coffee : Drink
    {
        public Coffee() : base("Coffee")
        {

        }
    }
    class Cacao : Drink
    {
        public Cacao() : base("Cacao")
        {

        }
    }

    abstract class DrinkBuilder
    {
        private Drink drink;    // объект, который будет построен

        public DrinkBuilder(Drink drink)
        {
            this.drink = drink;
        }

        public DrinkBuilder SetMilk() { drink.HasMilk = true; return this; }  // DrinkBuilder, т.к. в конце возвращает this (ссылку на вновь построенный объект, что позволяет каскадно устанавливать set)
        public DrinkBuilder SetSugar() { drink.HasSugar = true; return this; }
        public DrinkBuilder SetSyrop() { drink.HasSyrop = true; return this; }
        public DrinkBuilder SetCream() { drink.HasCream = true; return this; }
        public DrinkBuilder SetChocko() { drink.HasChocko = true; return this; }
        public DrinkBuilder SetCinnamon() { drink.HasCinnamon = true; return this; }
        public DrinkBuilder SetIce() { drink.HasIce = true; return this; }

        public Drink Build() { return drink; }

    }

    class CoffeeBuilder : DrinkBuilder
    {
        public CoffeeBuilder() : base(new Coffee())
        {

        }
    }

    class CacaoBuilder : DrinkBuilder
    {
        public CacaoBuilder() : base(new Cacao())
        {

        }
    }

    class DrinkDirector
    {
        private readonly DrinkBuilder drinkBuilder;
        public DrinkDirector(DrinkBuilder drinkBuilder)
        {
            this.drinkBuilder = drinkBuilder;
        }
        public Drink MakeEspresso()
        {
            Drink drink = drinkBuilder.Build();
            drink.Feature = "Espresso";
            return drink;
        }

        public Drink MakeAmericano()
        {
            Drink drink = drinkBuilder.Build();
            drink.Feature = "Americano";
            return drink;
        }
    }
}

/*
Строиль (Builder) - порождающий паттерн (создающий/производящий объекты). Используется для производства объектов, у которых много различных настроек. 
Противопоставляется антипаттерну "телескоп".

  object.ctor(int par1, int par2, string par3, ..., int parN) { ... }; 

Альтернатива: список инициализации

Суть: 
    Создается Builder: builder = new()
    Задаются его параметры (в любом порядке и количестве)
     builder.SetPar1(10);
     builder.SetPar3("Test");
    Проивзводится объект
     а) obj = builder.build()
     б) obj = new Obj(builder)

----------

Пример: напитки
= кофе
= какао
   К напитку можно добавить:
     - молоко
     - сахар
     - сливки
     - сироп
     - корицу

Зачем нужен этот паттерн? 

1) Повышение уровня абстракции
2) Борьба со списками инициализации (если в языке программирования их нет)
3) Повышение читаемости 
4) Запрет на установку взаимоисключающих параметров (сеттеров), например нельзя одновременно поставить "сахар" и "сахарозаменитель"
 */