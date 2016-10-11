using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CircularPrimes
{
    class PrimeNumbers {
        List<int> primes;        
        public List<int> Primes{          
          get
            {
               return this.primes;          
            }
        }
        public PrimeNumbers()
        {
            this.primes = new List<int>();            
         }
        public List<int> findPrimes(int size)
        {
            this.primes.Add(0);
            this.primes.Add(0);
            for (int i = 2; i <= size; i++)
                this.primes.Add(i);
            for (int i = 2; i * i < this.primes.Count; i++)
            {
                if (this.primes[i] != 0)
                {
                    for (int j = i * this.primes[i]; j < this.primes.Count; j += this.primes[i])
                    {
                        this.primes[j] = 0;
                    }
                }
            }
            this.primes.RemoveAll(x => x == 0);
            return this.Primes;
        }
        public bool ISprime(int number)
        {
            if (number == 1)
                return false;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return true;
                    break;
                }
            }
            return false;       
        }
        public void show()
        {
            foreach (var i in this.primes)
                Console.WriteLine(i);
        }
    }
    class CircularPrimes : PrimeNumbers {
        List<int> circularPrimes;             
        public List<int> circularprimes {
            get
            {
                return this.circularPrimes;
            }
        }
        public CircularPrimes() : base() { 
             this.circularPrimes = new List<int>();                           
        }
        public List<int> findCirculars(int size){
            bool flag;
            char spare, spare1;
            List<int> primes = base.findPrimes(size).GetRange(0,base.Primes.Count);
            for (int i = 0; i < primes.Count; i++)
            {
                flag = true;
                var mas = primes[i].ToString().ToCharArray();
                if (mas.Length == 1)
                {
                    this.circularPrimes.Add(Convert.ToInt32(new string(mas)));
                }
                else
                {
                    for (int j = 0; j < mas.Length - 1; j++)
                    {
                        for (int k = 0; k < mas.Length - 1; k++)
                        {
                            spare = mas[k];
                            spare1 = mas[k + 1];
                            mas[k] = spare1;
                            mas[k + 1] = spare;                           
                        }
                        int number = Convert.ToInt32(new string(mas));
                        if (base.ISprime(number))
                            flag = false;
                    }
                    if (flag == true)
                        this.circularPrimes.Add(primes[i]);
                }
            }
            return this.circularPrimes;  
        }
        public void show() {                          
            foreach (var i in this.circularPrimes)
                    Console.WriteLine(i);            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularPrimes cl = new CircularPrimes();            
            Console.WriteLine(cl.findCirculars(1000000).Count);            
            Console.ReadKey();            
        }      
    }
}
