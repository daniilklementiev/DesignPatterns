using System;
namespace DesignPatterns.CreationalPatterns
{
    public class FactoryMethodDemo
    {
        public void Show()
        {
            IDialog TheDialog;
            TheDialog = new DialogTwo();
            IButton TheButton = TheDialog.MakeButton();

            Console.WriteLine(TheButton.Render());
            TheButton.Click();
        }
    }



    interface IDialog
    {
        IButton MakeButton();              // Фабричный метод - построит объект-кнопку
        void Show();
    }
    class DialogOne : IDialog
    {
        public IButton MakeButton()        // Реализация фабричного метода - 
        {                                  // создание конкретного объекта,
            return new ButtonOne(this);    // согласующегося конкретно с этим
                                           // классом DialogOne
        }

        public void Show()
        {
            Console.WriteLine("Dialog One");
        }
    }
    class DialogTwo : IDialog
    {
        public IButton MakeButton()
        {
            return new ButtonTwo(this);
        }

        public void Show()
        {
            Console.WriteLine("Dialog Two");
        }
    }

    interface IButton
    {
        String Render();              // Вывод (отрисовка) кнопки
        void Click();
    }
    class ButtonOne : IButton         // Конкретный объект для DialogOne
    {
        private DialogOne dialog;
        public ButtonOne(DialogOne dialog)
        {
            this.dialog = dialog;
        }

        public void Click()
        {
            dialog.Show();
        }

        public String Render()
        {
            
            return "<<Button One>>";
        }
    }
    class ButtonTwo : IButton         // Конкретный объект для DialogTwo
    {
        private DialogTwo dialog;
        public ButtonTwo(DialogTwo dialog)
        {
            this.dialog = dialog;
        }

        public void Click()
        {
            dialog.Show();
        }

        public String Render()
        {
            return "[[Button Two]]";
        }
    }
}

/*
Фабричный метод
 Суть - создание конкретных объектов делегируется в методы других объектов
В отличии от Простой Фабрики, у которой есть единый центр - класс - по созданию
 объектов, в фабричном методе эти задачи разнесены по разным объектам/классам

Пример (задача) - образец на сайте https://refactoring.guru/ru/design-patterns/factory-method.
Кнопки, запускающие диалоги
Есть несколько форм диалогов под разные задачи, 
Необходимо иметь возможность оперативно переключаться между ними:
 кнопка одна, а запускаемый диалог нужно переключать

Решение (в стиле фабричного Метода)
 Диалог должен уметь "нарисовать" кнопку
 В области интерфейса (пользователя) - TheDialog.MakeButton()
 TheDialog может поменяться, но код создания кнопки остается неизменимым
 */

