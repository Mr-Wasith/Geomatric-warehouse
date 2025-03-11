using System;
using System.Collections.Generic;

namespace GW
{
    public abstract class Shape
    {
        public int Id { get; set; }
        public abstract double GetArea();
        public abstract string GetDimensions();
        public abstract string GetShapeType();
    }

    public class Circle : Shape
    {
        public double Diameter { get; set; }
        public override double GetArea() => Math.PI * Diameter * Diameter / 4;
        public override string GetDimensions() => $"Diameter: {Diameter}";
        public override string GetShapeType() => "Circle";
    }

    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double GetArea() => Height * Width;
        public override string GetDimensions() => $"Height: {Height}, Width: {Width}";
        public override string GetShapeType() => "Rectangle";
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public override double GetArea() => 0.5 * Base * Height;
        public override string GetDimensions() => $"Base: {Base}, Height: {Height}";
        public override string GetShapeType() => "Triangle";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            
            List<Shape> shapes = new List<Shape>();
            int shapeId = 1;

            while (true)
            {
                Console.WriteLine("\n1. Add a Circle");

                Console.WriteLine("2. Add a Rectangle");

                Console.WriteLine("3. Add a Triangle");

                Console.WriteLine("4. List Shapes");

                Console.WriteLine("5. Statistics");

                Console.WriteLine("6. Delete a Shape");

                Console.WriteLine("7. Exit");


                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Write("Enter the Diameter: ");

                    if (double.TryParse(Console.ReadLine(), out double diameter) && diameter > 0)
                    {
                        shapes.Add(new Circle { Id = shapeId++, Diameter = diameter });
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Diameter must be positive.");
                    }
                }
                else if (choice == 2)
                {

                    Console.Write("Enter the Height: ");
                    if (!double.TryParse(Console.ReadLine(), out double height) || height <= 0)
                    { 
                        continue;
                    }

                    Console.Write("Enter the Width: ");
                    if (!double.TryParse(Console.ReadLine(), out double width) || width <= 0) 
                    {  
                        continue; 
                    }

                    shapes.Add(new Rectangle { Id = shapeId++, Height = height, Width = width });
                }
                else if (choice == 3)
                {

                    Console.Write("Enter the Base: ");
                    if (!double.TryParse(Console.ReadLine(), out double baseLength) || baseLength <= 0) 
                    { 
                        continue; 
                    }

                    Console.Write("Enter the Height: ");
                    if (!double.TryParse(Console.ReadLine(), out double triHeight) || triHeight <= 0) 
                    { 
                        continue; 
                    }

                    shapes.Add(new Triangle { Id = shapeId++, Base = baseLength, Height = triHeight });
                }
                else if (choice == 4)
                {
                    if (shapes.Count == 0)
                    {
                        Console.WriteLine("No shapes added yet!");
                    }
                    else {

                        foreach (var shape in shapes) 
                        { 
                            Console.WriteLine($"ID: {shape.Id}, Type: {shape.GetShapeType()}, Dimensions: {shape.GetDimensions()}, Area: {shape.GetArea():F2}"); 
                        } 
                    }
                }
                else if (choice == 5)
                {
                    int circleCount = 0, rectangleCount = 0, triangleCount = 0;
                    double totalCircleArea = 0, totalRectangleArea = 0, totalTriangleArea = 0;

                    foreach (var shape in shapes)
                    {
                        if (shape is Circle) 
                        { 
                            circleCount++; 
                            totalCircleArea += shape.GetArea(); 
                        }
                        else if (shape is Rectangle) 
                        { 
                            rectangleCount++; 
                            totalRectangleArea += shape.GetArea(); 
                        }
                        else if (shape is Triangle) 
                        { 
                            triangleCount++; 
                            totalTriangleArea += shape.GetArea(); 
                        }
                    }

                    double totalArea = totalCircleArea + totalRectangleArea + totalTriangleArea;

                    Console.WriteLine("\nShape Statistics:");

                    Console.WriteLine($"Total Shapes: {shapes.Count}");

                    Console.WriteLine($"Total Circles: {circleCount} | Total Area: {totalCircleArea:F2} ({(totalArea > 0 ? (totalCircleArea / totalArea) * 100 : 0):F2}%)");

                    Console.WriteLine($"Total Rectangles: {rectangleCount} | Total Area: {totalRectangleArea:F2} ({(totalArea > 0 ? (totalRectangleArea / totalArea) * 100 : 0):F2}%)");

                    Console.WriteLine($"Total Triangles: {triangleCount} | Total Area: {totalTriangleArea:F2} ({(totalArea > 0 ? (totalTriangleArea / totalArea) * 100 : 0):F2}%)");
                }
                else if (choice == 6)
                {

                    Console.Write("Enter Shape ID to delete: ");

                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {

                        Shape shapeToRemove = shapes.Find(shape => shape.Id == deleteId);

                        if (shapeToRemove != null)
                        {
                            shapes.Remove(shapeToRemove);
                            Console.WriteLine($"Shape with ID {deleteId} removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No shape found with this ID.");
                        }
                    }
                    else 
                    { 
                        Console.WriteLine("Invalid input! Please enter a valid ID."); 
                    }
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Exiting... Thank you!");
                    break;
                }
            }
        }
    }
}
