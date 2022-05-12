using System;
namespace DesignPatterns.StructuralPatterns
{
    public class ProxyDemo // client (on Diagram)
    {
        public void Show()
        {
            String cmd1 = "GET ALL DATA";
            String cmd2 = "DELETE ALL DATA";

            // Without proxy
            IRequester requester = new DbRequester();
            Console.WriteLine(requester.Request(cmd1));
            Console.WriteLine(requester.Request(cmd2));

            // With proxy
            requester = new DbProxy(requester);
            Console.WriteLine(requester.Request(cmd1));
            Console.WriteLine(requester.Request(cmd2));

        }
    }

    interface IRequester
    {
        String Request(String cmd); // send cmd request and get result
    }

    class DbRequester : IRequester
    {
        public string Request(string cmd)
        {
            return $"DB result for command '{cmd}'";
        }
    }

    class DbProxy : IRequester
    {
        private IRequester RealDb;
        public DbProxy()
        {
            RealDb = new DbRequester();
        }
        public DbProxy(IRequester RealDb)
        {
            this.RealDb = RealDb;
        }
        public string Request(string cmd)
        {
            if (cmd.Contains("GET"))
            {
                return RealDb.Request(cmd);
            }
            else
            {
                return "command blocked on proxy level";
            }
        }
    }
}

/* Посредник - proxy
Встраивание посредника в канал обмена данными

*/
