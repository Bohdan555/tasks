using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace Tsk1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<List<double>> mas;
            StreamReader reader;
            int counter,N = 0;          
            using (System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog())
            {
                mas = new List<List<double>>();
                file.ShowDialog();                
                reader = new StreamReader(@"" + (file.FileName).Replace("/", "\\"));
                while (reader.ReadLine()!=null)
                    {
                        N += 1;                   
                    }
                reader.BaseStream.Position = 0;
                for (int i = 0; i < N; i++)
                {
                    mas.Add(new List<double>());
                    for (int j = 0; j < N; j++)
                    {
                        mas[i].Add(0);
                    }
                    counter = 0;
                    foreach (var elem in reader.ReadLine().Split(' '))
                    {
                        mas[i].RemoveAt(counter);
                        mas[i].Insert(counter,Convert.ToDouble(elem));
                        counter+=1;
                    }  
                 }               
                Console.WriteLine("The sum is "+TriangleSum(mas));
                Console.ReadKey();
            }
        }
     private static double TriangleSum(List<List<double>> mas ) {
            double sum = 0, number;
            for (int i = 0; i < mas.Count; i++)
                { 
                   number = mas[i][0];
                   mas[i].ForEach((x) => { if (x > number) number = x; });
                   sum += number;
                }
            return sum;
        }
    }
}
