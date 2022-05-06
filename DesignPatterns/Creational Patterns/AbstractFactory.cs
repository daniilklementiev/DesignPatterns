using System;
namespace DesignPatterns.CreationalPatterns
{
    public class AbstractFactoryDemo
    {
        public void Show()
        {
            ICrypterAbstractFactory factory;
            Console.WriteLine("Hasher:");
            string? userHasher = Console.ReadLine();
            switch (userHasher)
            {
                case "DSTU":
                    { 
                    factory = new DSTUFactory();
                    ICryptoHasher hasher = factory.GetHasher();
                    Console.WriteLine(hasher.Hash("test"));
                    ICryptoCipher cipher = factory.GetCipher();
                    Console.WriteLine(cipher.Cipher("test"));
                    ICryptoDecipher decipher = factory.GetDecipher();
                    Console.WriteLine(decipher.Decipher("test"));
                    }
                    break;
                case "AES":
                    {
                    factory = new AESFactory();
                    ICryptoHasher hasher = factory.GetHasher();
                    Console.WriteLine(hasher.Hash("test"));
                    ICryptoCipher cipher = factory.GetCipher();
                    Console.WriteLine(cipher.Cipher("test"));
                    ICryptoDecipher decipher = factory.GetDecipher();
                    Console.WriteLine(decipher.Decipher("test"));
                    }
                    break;
                default:
                    Console.WriteLine("Invalid algo");
                    break;
            }
            
            
        }  
    }

    interface ICryptoHasher
    {
        String Hash(string input);
    }
    interface ICryptoCipher
    {
        String Cipher(string input);
    }
    interface ICryptoDecipher
    {
        String Decipher(string input);
    }

    interface ICrypterAbstractFactory
    {
        ICryptoHasher GetHasher();
        ICryptoCipher GetCipher();
        ICryptoDecipher GetDecipher();
    }

    //////////////DSTU/////////////////////
    
    class DSTUHasher : ICryptoHasher
    {
        public string Hash(string input)
        {
            return $"Kupina hash of '{input}'";
        }
    }

    class DSTUCipher :ICryptoCipher
    {
        public string Cipher(string input)
        {
            return $"Kalina cipher of '{input}'";
        }
    }
    class DSTUDecipher : ICryptoDecipher
    {
        public string Decipher(string input)
        {
            return $"Kalina decipher of '{input}'";
        }
    }

    class DSTUFactory : ICrypterAbstractFactory
    {
        public ICryptoCipher GetCipher()
        {
            return new DSTUCipher();
        }

        public ICryptoDecipher GetDecipher()
        {
            return new DSTUDecipher();
        }

        public ICryptoHasher GetHasher()
        {
            return new DSTUHasher();
        }
    }

    ///////////////AES/////////////////////

    class AESHasher : ICryptoHasher
    {
        public string Hash(string input)
        {
            return $"SHA hash of '{input}'";
        }
    }

    class AESCipher : ICryptoCipher
    {
        public string Cipher(string input)
        {
            return $"AES cipher of '{input}'";
        }
    }

    class AESDecipher : ICryptoDecipher
    {
        public string Decipher(string input)
        {
            return $"AES decipher of '{input}'";
        }
    }

    class AESFactory : ICrypterAbstractFactory
    {
        public ICryptoCipher GetCipher()
        {
            return new AESCipher();
        }

        public ICryptoDecipher GetDecipher()
        {
            return new AESDecipher();
        }

        public ICryptoHasher GetHasher()
        {
            return new AESHasher();
        }
    }

}
/* Абстрактная фабрика - фабрика фабрик
Простая фабрика - создает конкретные объекты
Если конкретные объекты связаны, то переключение на новую связку - это использование
новой фабрики. Абстрактная фабрика - фабрика, создающая конкретную (простую) фабрику
Crypto { Hash, Encipher, Decipher }
 AES { SHA, Cipher, Decipher }
 DSTU { Kupina, KalinaC, KalinaD }
 */
