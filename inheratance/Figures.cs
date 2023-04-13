namespace Figures
{
    public abstract class Figure
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
    }

    public class Square : Figure
    {
        public double Side { get; }

        public Square(double side)
        {
            if (side <= 0) 
                throw new ArgumentException("довжина сторони повинна бути більша за 0");

            Side = side;
        }

        public override double GetPerimeter() => Side * 4;

        public override double GetArea() => Side * Side;

        public override string ToString()
        {
            return $"квадрат зі стороною:\na = {Side};" +
                   $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";
        }
    }

    class Rhombus : Square
    {
        public double Height { get; }

        public Rhombus(double side, double height)
            : base(side)
        {
            if (height <= 0)
                throw new ArgumentException("довжина висоти повинна бути більша за 0");

            Height = height;
        }

        public override double GetArea() => Side * Height;

        public override string ToString()
        {
            return $"ромб зі стороною:\na = {Side};" +
                   $"\nта висотою:\nh = {Height};" +
                   $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";
        }
    }

    public class Rectangle : Figure
    {
        public double SideA { get; }
        public double SideB { get; }

        public Rectangle(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0)
                throw new ArgumentException("довжина будь-якої сторони повинна бути більша за 0");

            SideA = sideA;
            SideB = sideB;
        }

        public override double GetPerimeter() => (SideA + SideB) * 2;

        public override double GetArea() => SideA * SideB;

        public override string ToString()
        {
            return $"прямокутних зі сторонами:\na = {SideA};\nb = {SideB};" +
                   $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";
        }
    }

    public class Parallelogram : Rectangle
    {
        double HeightA { get; }

        public Parallelogram(double sideA, double sideB, double heightA)
            : base(sideA, sideB)
        {
            if (heightA <= 0) 
                throw new ArgumentException("довжина висоти повинна бути більша за 0");

            HeightA = heightA;
        }

        public override double GetArea() => HeightA * SideA;

        public override string ToString()
        {
            return $"паралелограм зі сторонами:\na = {SideA};\nb = {SideB};" +
                   $"\nта висотою (до 'a'):\nh = {HeightA};" +
                   $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";
        }
    }

    public class Trapezium : Figure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public double SideD { get; }
        public double HeightAB { get; }

        public Trapezium(double sideA, double sideB, double sideC, double sideD, double heightAB)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 || sideC <= 0)
                throw new ArgumentException("довжина будь-якої сторони повинна бути більша за 0");

            else if (heightAB <= 0)
                throw new ArgumentException("довжина висоти повинна бути більша за 0");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            SideD = sideD;
            HeightAB = heightAB;
        }

        public override double GetPerimeter() => SideA + SideB + SideC + SideD;

        public override double GetArea() => (SideA + SideB) / 2 * HeightAB;

        public override string ToString()
        {
            return $"трапеція зі сторонами:\na (основа) = {SideA};\nb (основа) = {SideB};\nc = {SideC};" +
                   $"\nd = {SideD};\nта висотою (до основи):\nh = {HeightAB};" +
                   $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("радіус повинен бути більшим за 0");

            Radius = radius;
        }

        public override double GetPerimeter() => Radius * 2 * 3.14;

        public override double GetArea() => Radius * Radius * 3.14;

        public string GetDefaultPerimeter() => (Radius * 2).ToString() + "π";
        public string GetDefaultArea() => (Radius * Radius).ToString() + "π";

        public override string ToString()
        {
            return $"коло з радіусом:\nr = {Radius};" +
                   $"\n::\nP = {GetDefaultPerimeter()} ≈ {GetPerimeter()};" +
                   $"\nS = {GetDefaultArea()} ≈ {GetArea()};";
        }
    }

    public class Ellipse : Figure
    {
        public double MajorAxis { get; }
        public double MinorAxis { get; }

        public Ellipse(double majorAxis, double minorAxis)
        {
            if (majorAxis <= 0 || minorAxis <= 0)
                throw new ArgumentException("довжина будь-якої піввісі повинна бути більша за 0");

            MajorAxis = majorAxis;
            MinorAxis = minorAxis;
        }

        public override double GetPerimeter()
        {
            return 4 * (3.14 * MajorAxis * MinorAxis + (MajorAxis - MinorAxis)) / (MajorAxis + MinorAxis);
        }

        public override double GetArea() => MajorAxis * MinorAxis * 3.14;

        public string GetDefaultPerimeter()
        {
            return (4 * (MajorAxis * MinorAxis + (MajorAxis - MinorAxis)) / (MajorAxis + MinorAxis)).ToString() + "π";
        }
        public string GetDefaultArea() => (MajorAxis * MinorAxis).ToString() + "π";

        public override string ToString()
        {
            return $"еліпс з піввісями:\na (більша) = {MajorAxis};\nb (менша) = {MinorAxis};" +
                   $"\n::\nP = {GetDefaultPerimeter()} ≈ {GetPerimeter()};" +
                   $"\nS = {GetDefaultArea()} ≈ {GetArea()};";
        }
    }

    public class Triangle : Figure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        bool DoesNotExist
        {
            get
            {
                double largestSide = Double.Max(Double.Max(SideA, SideB), SideC);

                if (SideA == largestSide)
                    return SideB + SideC <= SideA;

                else if (SideB == largestSide)
                    return SideA + SideC <= SideB;

                else
                    return SideA + SideB <= SideC;
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("довжина будь-якої сторони повинна бути більша за 0");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetPerimeter() => SideA + SideB + SideC;
        
        public override double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }

        public override string ToString()
        {
            string info = $"трикутник зі сторонами:\na = {SideA};\nb = {SideB};\nc = {SideC};" +
                          $"\n::\nP = {GetPerimeter()};\nS = {GetArea()};";

            if (DoesNotExist)
                info += "\n::\n(!) такого трикутника не існує";

            return info;
        }
    }
}