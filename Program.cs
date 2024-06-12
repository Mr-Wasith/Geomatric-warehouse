using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Circle
    {
        public double dia;
        public int id;
        public double area()
        {
            return Math.PI * (dia * dia / 4);
        }
    }
    public class Rectangle
    {
        public double height;
        public double width;
        public int id;
        public double area()
        {
            return height * width;
        }
    }

    internal class program
    {
        static void Main(string[] args)
        {
            Circle[] c = new Circle[100];
            Rectangle[] r = new Rectangle[100];

            int a;
            int cnt = 0;
            int cir_cnt = 0;
            int rec_cnt = 0;
            double total_area = 0;
            double cir_area = 0;
            double rec_area = 0;

            while (true)
            {
                Console.WriteLine("1. Add a Circle");
                Console.WriteLine("2. Add a Rectangle");
                Console.WriteLine("3. List Items");
                Console.WriteLine("4. Get Statistics");
                Console.WriteLine("5. Exit");

                a = Convert.ToInt32(Console.ReadLine());

                if (a == 1)
                {
                    c[cnt] = new Circle();
                    r[cnt] = new Rectangle();
                    c[cnt].id = 1;
                    r[cnt].id = 01;
                    Console.Write("Enter the Diameter : ");
                    c[cnt].dia = Convert.ToInt32(Console.ReadLine());
                    cir_cnt++;
                    cnt++;
                }

                else if (a == 2)
                {
                    c[cnt] = new Circle();
                    r[cnt] = new Rectangle();
                    c[cnt].id = 0;
                    r[cnt].id = 1;
                    Console.Write("Enter the Height : ");
                    r[cnt].height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Width : ");
                    r[cnt].width = Convert.ToInt32(Console.ReadLine());
                    rec_cnt++;
                    cnt++;
                }

                else if (a == 3)
                {
                    Console.WriteLine("ID Type Dimension");
                    Console.WriteLine("=================");
                    for (int i = 0; i < cnt; i++)
                    {
                        if (c[i].id == 1)
                        {
                            Console.WriteLine($"{i + 1} Circle {c[i].dia}");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1} Rectangle {r[i].height} x {r[i].width}");
                        }
                    }
                }

                else if (a == 4)
                {
                    Console.WriteLine($"Total Shapes : {cnt}");
                    Console.WriteLine($"Total numbers of Circles : {cir_cnt}");
                    Console.WriteLine($"Total numbers of Rectangles : {rec_cnt}");
                    for (int i = 0; i < cnt; i++)
                    {
                        if (c[i].id == 1)
                        {
                            total_area += c[i].area();
                            cir_area += c[i].area();
                        }
                        else
                        {
                            total_area += r[i].area();
                            rec_area += r[i].area();
                        }
                    }
                    Console.WriteLine($"The Total Area : {(total_area)}");
                    Console.WriteLine($"The Total Area occupied by rectangles : {(rec_area)}({((rec_area / total_area) * 100):F1}%)");
                    Console.WriteLine($"The Total Area occupied by circles : {(cir_area)}({((cir_area / total_area) * 100):F1}%)");

                }

                else if (a == 5)
                {
                    break;
                }
            }

        }
    }

}
