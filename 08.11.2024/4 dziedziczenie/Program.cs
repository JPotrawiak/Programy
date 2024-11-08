using System.Diagnostics.Contracts;

namespace _4_dziedziczenie
{
    internal class Program
    {
        abstract class Shape
        {
            public abstract float CalculateArea();
            public abstract float CalculatePerimater();
            public void DisplayInfo()
            {
                Console.WriteLine("To jest kształt");

            }
        }

        class Rectangle : Shape
        {
            private float width;
            private float height;
            public override float CalculateArea()
            {
                return width * height;
            }

            public override float CalculatePerimater()
            {
                return 2 * (width + height);
            }

            public void SetDimensions(float w, float h)
            {
                width = w; 
                height = h;
            }
        }

        class Circle : Shape
        {
            private float radius;

            public Circle(float radius)
            {
                this.radius = radius;
            }
            public override float CalculateArea()
            {
                return (float)Math.Round(Math.PI * radius * radius, 2);
            }

            public override float CalculatePerimater()
            {
                return (float)Math.Round(2 * Math.PI * radius, 2);
            }

            public void SetRadius(float r)
            {
                radius = r;
            }
        }

        class Triangle : Shape
        {
            private float SideA;
            private float SideB;
            private float SideC;

            public Triangle(float a, float b, float c)
            {
                SideA = a;
                SideB = b;
                SideC = c;
            }

            public override float CalculateArea()
            {
                float halfPerimater = (SideA + SideB + SideC)/2;
                return (float)Math.Round(Math.Sqrt(halfPerimater * (halfPerimater - SideA) * (halfPerimater - SideB) * (halfPerimater - SideC)), 2);
            }

            public override float CalculatePerimater()
            {
                return SideA + SideB + SideC;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wybierz kształt do obliczenia:");
                Console.WriteLine("1. Prostokąt");
                Console.WriteLine("2. Koło");
                Console.WriteLine("3. Trójkąt");
                Console.WriteLine("4. Wyjście");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Rectangle rect = new Rectangle();
                        Console.Write("Podaj szerokość:");
                        float rectWidth = float.Parse(Console.ReadLine());
                        Console.Write("Podaj wysokość:");
                        float rectHeight = float.Parse(Console.ReadLine());
                        rect.SetDimensions(rectWidth, rectHeight);
                        Console.WriteLine($"Pole prostokąta: {rect.CalculateArea()}");
                        Console.WriteLine($"Obwód prostokąta: {rect.CalculatePerimater()}");
                        break;
                    case "2":
                        float circRadius = GetValidInput("Podaj promień:");
                        Circle circ = new Circle(circRadius);
                        Console.WriteLine($"Pole koła: {circ.CalculateArea()}");
                        Console.WriteLine($"Obwód koła: {circ.CalculatePerimater()}");
                        break;
                    case "3":
                        float sideA, sideB, sideC;
                        do
                        {
                            sideA = GetValidInput("Podaj długość boku A:");
                            sideB = GetValidInput("Podaj długość boku B:");
                            sideC = GetValidInput("Podaj długość boku C:");

                            if (!IsValidTriangle(sideA, sideB, sideC))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nNieprawidłowe dane, spróbuj ponownie\n");
                                Console.ResetColor();
                            }
                        } while (!IsValidTriangle(sideA, sideB, sideC));

                        Triangle tri = new Triangle(sideA, sideB, sideC);

                        Console.WriteLine("Pole trójkąta: {0}", tri.CalculateArea());
                        Console.WriteLine("Obwód trójkąta: {0}", tri.CalculatePerimater());

                        
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }
            }
        }

        private static bool IsValidTriangle(float sideA, float sideB, float sideC)
        {
            return (sideA + sideB > sideC) && (sideB + sideC > sideA) && (sideA + sideC > sideB);
        }

        private static float GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out float result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("\nNieprawidłowe dane, spróbuj ponownie\n");
                }
            }
        }
    }
}
