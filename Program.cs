using System;
namespace GW
{
    public class Shape
    {
        public int id;
        public virtual double getarea()
        {
            return 0;
        }

    }
    public class Circle : Shape
    {
        public double diameter;
        public override double getarea()
        {
            return Math.PI * diameter * diameter / 4;
        }
    }

    public class Rectangle : Shape
    {
        public double height;
        public double width;
        public override double getarea()
        {
            return height * width;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Shape[] sh = new Shape[100];
            double cir_area = 0;
            double rect_area = 0;
            int i = 0;
            int cir_ct = 0;
            int rect_ct = 0;
            while (i < 100)
            {
                Console.WriteLine("1. Add a Circle");
                Console.WriteLine("2. Add a Rectangle");
                Console.WriteLine("3. List Items");
                Console.WriteLine("4. Statisitcs");
                Console.WriteLine("5. Exit");
                int n;
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    Console.Write("Enter the Diameter : ");
                    Circle circle = new Circle();
                    circle.id = i + 1;
                    circle.diameter = Convert.ToInt32(Console.ReadLine());
                    cir_area += circle.getarea();
                    sh[i] = circle;
                    i++;
                    cir_ct++;

                }
                else if (n == 2)
                {
                    Rectangle rectangle = new Rectangle();
                    Console.Write("Enter the Height : ");
                    rectangle.height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Width : ");
                    rectangle.width = Convert.ToInt32(Console.ReadLine());
                    rectangle.id = i + 1;
                    rect_area += rectangle.getarea();
                    sh[i] = rectangle;
                    i++;
                    rect_ct++;

                }
                else if (n == 3)
                {
                    Console.WriteLine("ID\tTypes\tDimension");
                    Console.WriteLine("=========================");
                    foreach (Shape j in sh)
                    {
                        if (j is Circle)
                        {
                            Circle circle = (Circle)j;
                            Console.WriteLine(circle.id + "\tCircle\t\t" + circle.diameter);
                        }
                        else if (j is Rectangle)
                        {
                            Rectangle rectangle = (Rectangle)j;
                            Console.WriteLine(rectangle.id + "\tRectangle\t" + rectangle.height + " X " + rectangle.width);
                        }
                    }
                }
                else if (n == 4)
                {
                    Console.WriteLine("Total Shapes : " + (cir_ct + rect_ct));
                    Console.WriteLine("Total Circles : " + cir_ct);
                    Console.WriteLine("Total Rectangles : " + rect_ct);
                    Console.WriteLine($"Total Area : {cir_area + rect_area:F2}");
                    Console.WriteLine($"Total area occupied by Circles : {cir_area:F2} ({(((cir_area) / (cir_area + rect_area)) * 100):F2}%)");
                    Console.WriteLine($"Total area occupied by Rectangles : {rect_area:F2} ({(((rect_area) / (rect_area + cir_area)) * 100):F2}%)");
                }
                else if (n == 5)
                {
                    break;
                }
            }
        }
    }
}