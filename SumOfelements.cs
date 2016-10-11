using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace Tsk1
{
    class Sum {
        List<List<double>> mas;
        StreamReader reader;
        public Sum()
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                int counter, N = 0;
                this.mas = new List<List<double>>();
                file.ShowDialog();
                this.reader = new StreamReader(@"" + (file.FileName).Replace("/", "\\"));
                while (reader.ReadLine() != null)
                {
                    N += 1;
                }
                this.reader.BaseStream.Position = 0;
                for (int i = 0; i < N; i++)
                {
                    this.mas.Add(new List<double>());
                    for (int j = 0; j < N; j++)
                    {
                        this.mas[i].Add(0);
                    }
                    counter = 0;
                    foreach (var elem in reader.ReadLine().Split(' '))
                    {
                        this.mas[i].RemoveAt(counter);
                        this.mas[i].Insert(counter, Convert.ToDouble(elem));
                        counter += 1;
                    }
                }
            }
        }       
     public double TriangleSum() {
            double sum = 0, number;
            for (int i = 0; i < mas.Count; i++)
                { 
                   number = this.mas[i][0];
                   this.mas[i].ForEach((x) => { if (x > number) number = x; });
                   sum += number;
                }
            return sum;
        }

    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Sum cl = new Sum();
            Console.WriteLine("The sum is "+cl.TriangleSum());
            Console.ReadKey();
            }
        }     
}
