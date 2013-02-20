using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    public class Primes: IEnumerable
    {
        public const int DEFAULT_lIMIT = 50;
        private int _lim;
        private List<int> list;

        public int Lim
        {
            get { return _lim; }
            set { _lim = value; }
        }

        /*
         * Note that property does not need to tie to any private field
         * Like this example, we don't have a _size field but we can make 
         * a property to return size of list.
         *   
         */
        public int Size { 
            get { return list.Count; }
            private set { }
        }

        public Primes(): this(DEFAULT_lIMIT)
        {
        }

        public Primes(int limit)
        {
            _lim = limit;
            primeGenerate();
        }

        // Brute-force approach to find all primes within a range of integers
        public void primeGenerate() {
            list = new List<int>();
            bool flag;
            for (int i = 2; i < _lim; i++)
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
        }

        /**
         * This uses an indexer to access every prime in the range
         * the advantage is that we don't need to return whole list
         * or whole array to the caller like this:
         *  List<int> prime_gen() or int[] prime_gen() and
         *  the caller cannot change the value in each element
         *  if we do something like : primes[i] = 0; then error is
         *  indexer is readonly.
         *  Come to think about, I think we can set value inthe indexer, too but
         *  that willbe explored later.
         * 
        */
        public int this[int i] {
            get { return this.list[i]; }
        }

        /*
         * demo of yield in C# so that Primes has iterator to use in foreach
         * this look like yield in Python. First we implement IEnumerable interface
         * then we write  yield return item; to return iterator.
         */
        public IEnumerator GetEnumerator() {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        /*
         * Talk about something look like Python generator, now we have a property
         * NextPrime to return list of primes. Note that the code exactly looks like
         * the iterator code but different in get {} as a property.
        */
        public System.Collections.Generic.IEnumerable<int> NextPrime {
            get
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes();
            for (int i = 0; i < primes.Size; i++)
			{
                Console.WriteLine(primes[i]);
			}

            foreach (var i in primes)
            {
                Console.WriteLine(i);
            }

            foreach (var i in primes.NextPrime)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
