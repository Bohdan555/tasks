using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CircularPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10000;
            int index = 0;
            List<double> prime = new List<double>();
            List<double> circularPrime = new List<double>();
            char spare,spare1;
            bool flag;
            for (int i = 2; i <= N; i++)
                prime.Add(i);
            for (int i = 0; i < prime.Count; i++)
            { 
               for(int k = i+1 ; k < prime.Count; k++)
                   if (prime[k] % prime[i] == 0)
                       {
                           prime[k] = 0;            
                       }
            }            
            for (int i = 0; i < prime.Count; i++)
                {
                    if (prime[i] == 0)
                        {
                            for (int k = i + 1; k < prime.Count; k++)
                                {
                                    if (prime[k] != 0)
                                    {
                                        index = k;
                                        break;  
                                    }
                                }
                            prime[i] = prime[index];
                            prime[index] = 0; 
                        }
                }
            prime.RemoveAll(x => x == 0);
            for (int i = 0; i < prime.Count; i++)
            {
                flag = true;
                var mas = prime[i].ToString().ToCharArray();
                if (mas.Length == 1)
                {
                    // var sth =  Convert.ToString(mas);
                    circularPrime.Add(Convert.ToDouble(new string(mas)));
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
                        double number = Convert.ToDouble(new string(mas));
                        if (ISprime(number))
                            flag = false;
                    }
                    if (flag == true)
                        circularPrime.Add(prime[i]);
                }
            }
            //var mas = prime[5].ToString().ToCharArray();
            foreach (var i in circularPrime)
                Console.WriteLine(i);
            Thread.Sleep(90000);
        }
        static bool ISprime(double number)
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
    }
}
