using System;
namespace DesignPatterns.StructuralPatterns
{
    public class Decorator
    {
        public void Show()
        {
            IComponent product;

            product = new Coffee();
            // product = new CoffeeDecorator(null!);
            product = new WaterDecorator(product);
            product = new SugarDecorator(product);
            product = new LiquorDecorator(product);
            product = new SyropDecorator(product);

            PrintComponent(product);
        }

        private void PrintComponent(IComponent component)
        {
            Console.WriteLine(component.GetDescription());
            Console.WriteLine(component.GetPrice());
        }
    }

    interface IComponent
    {
        float GetPrice();
        String GetDescription(); // Название - кофе/сливки/сахар
    }



    class Coffee : IComponent
    {
        private float price;
        private String description;
        public Coffee()
        {
            description = "Coffee";
            price = 15;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Water : IComponent
    {
        private float price;
        private String description;
        public Water()
        {
            description = "Water";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Sugar : IComponent
    {
        private float price;
        private String description;
        public Sugar()
        {
            description = "Sugar";
            price = 1;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }

    class Liquor : IComponent
    {
        private float price;
        private String description;
        public Liquor()
        {
            description = "Liquor";
            price = 10;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }

    class Syrop : IComponent
    {
        private float price;
        private String description;
        public Syrop()
        {
            description = "Syrop";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }



    abstract class IDecorator : IComponent
    {
        protected float price;
        protected String description;
        protected IComponent wrappee;
        public IDecorator(IComponent wrappee)
        {
            this.wrappee = wrappee;
        }

        public String GetDescription()
        {
            String description = String.Empty;
            if (wrappee != null) description += wrappee.GetDescription() + " + ";
            description += this.description;
            return description;
        }

        public float GetPrice()
        {
            float price = this.price;
            if (wrappee != null) price += wrappee.GetPrice();
            return price;
        }
    }

    class CoffeeDecorator : IDecorator
    {
        public CoffeeDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Coffee();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class WaterDecorator : IDecorator
    {
        public WaterDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Water();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class SugarDecorator : IDecorator
    {
        public SugarDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Sugar();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class LiquorDecorator : IDecorator
    {
        public LiquorDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Liquor();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }

    class SyropDecorator : IDecorator
    {
        public SyropDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Syrop();
            description = component.GetDescription();
            price = component.GetPrice();
        }
    }     



}

/*
Декоратор - структурный паттерн
Пример: кофе
У нас есть кофейня и посетитель может заказать кофе
К кофе можно добавить:
 - молоко
 - сахар
 - сливки
 - сироп
 - корица

Особенность: открыты для расширения, т.е. меню может быть дополнено:
 - шоколад
 - мороженное

Альтернатива: паттерн строитель - похож, но плохо расширяется
Альтернатива: агрегация - кофе + массив добавок --
               особая роль отводится контейнеру (кофе), это усложняет
               смену контейнера
Декоратор:
Первый элемент заказа берется за основу (кофе/молоко/вода)
Остальные добавляются, "расширяя" основной,
    создавая для него "оболочку"-декорацию

1. Кофе
2. +Сахар сахар(кофе)
3. +сливки сливки(сахар(кофе))
4. +что-то что-то(сливки(сахар(кофе)))
 */