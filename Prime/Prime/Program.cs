using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    public class Primes
    {
        private int lim;
        public Primes(): this(50)
        {
        }

        public Primes(int limit)
        {
            lim = limit;
        }
        public List<int> primeGenerate() {
            List<int> list = new List<int>();
            bool flag;
            for (int i = 2; i < lim; i++)
            {
                flag = true;
                for (int j = 2; j < i; j++)
                {
                    if ((i % j) == 0)
                    {
                        flag = false;
                        break;
                    }               
                }
                if (flag)
                {
                    list.Add(i);
                } 
            }
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes();
            List<int> l = primes.primeGenerate();
            foreach(var p in l ){
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
    }
}
