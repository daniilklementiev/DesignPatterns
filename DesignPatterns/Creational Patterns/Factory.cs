using System;
namespace DesignPatterns.CreationalPatterns
{
    public class FactoryDemo
    {
        public void Show()
        {
            Console.WriteLine("Which algo?");
            String? algo = Console.ReadLine();
            try
            {
                IHasher? hasher = CryptoFactory.GetInstance(algo);
                Console.WriteLine(hasher.Hash("content"));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "💩");
            }
        }
    }

    interface IHasher
    {
        String Hash(string s);
    }

    class Md5Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"MD5 hash of {s}";
        }
    }

    class Sha1Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"SHA-1 hash of {s}";
        }
    }

    class KupinaHasher : IHasher
    {
        public String Hash(string s)
        {
            return $"Kupina-256 hash of {s}";
        }
    }

    class Sha2Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"Sha-256 hash of {s}";
        }
    }

    class CryptoFactory
    {
        public static IHasher GetInstance(String algoName)
        {
            switch(algoName)
            {
                case "MD5":
                case "MD-5":
                case "Md5":
                    return new Md5Hasher();
                case "SHA":
                case "SHA-1":
                case "SHA-160":
                    return new Sha1Hasher();
                case "Kupina":
                case "DSTU":
                case "DSTU-256":
                    return new KupinaHasher();
                case "Sha2":
                case "SHA2":
                case "SHA-256":
                    return new Sha2Hasher();
                default:
                    throw new Exception($"Algo '{algoName}' invalid");
            }
        }
    }
}
/*
  Фабрика (factory)
Фабрики (в целом) - шаблоны, задачи которых является делегирование
задач создания объектов в специальные "подразделы" - фабрики

Фабрика (просто) - класс/объект, создающая другие объекты
Абстрактная фабрика - для задач связанных объектов
Фабричный метод - перенос задач создания "своих" объектов в сами объекты

 */

