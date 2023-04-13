using System.Text;
using Figures;
using static ConsoleNeededMethods;

internal static class Program
{
    internal static bool IsEqualOrLessThanZero(double value) => value <= 0;

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        ConsoleKeyInfo KeyInfo;

        int choice;

        while (true)
        {
            Console.Clear();

            Console.Write(":: :: :: :: :: :: ::\n" +
                          "::  ESC -- вихід  ::\n" +
                          ":: :: :: :: :: :: ::\n" +
                          ":: ОБЕРІТЬ ФІГУРУ ::\n" +
                          ":: :: :: :: :: :: :: :: :: :: :: :: :: :: :: :: ::\n" +
                          ":: [1] -> трикутник     :: [2] -> еліпс         ::\n" +
                          ":: [3] -> квадрат       :: [4] -> трапеція      ::\n" +
                          ":: [5] -> прямокутник   :: [6] -> коло          ::\n" +
                          ":: [7] -> парлелограм   :: [8] -> ромб          ::\n" +
                          ":: :: :: :: :: :: :: :: :: :: :: :: :: :: :: :: ::\n" +
                          ":: ==> ");

            KeyInfo = Console.ReadKey();

            while (!(Int32.TryParse(KeyInfo.KeyChar.ToString(), out choice)
                && choice >= 1 || choice <= 8)
                && KeyInfo.Key != ConsoleKey.Escape)
            {
                KeyInfo = Console.ReadKey();
            } 

            if (KeyInfo.Key == ConsoleKey.Escape)
                break;

            switch (choice)
            {
                case 1:

                    double triangleSideA;
                    double triangleSideB;
                    double triangleSideC;

                    DoubleFormatInput(out triangleSideA, "введіть дані трикутника\nсторона 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out triangleSideB, "введіть дані трикутника\nсторона 'b' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out triangleSideC, "введіть дані трикутника\nсторона 'c' = ", IsEqualOrLessThanZero);

                    Triangle TRes = new(triangleSideA, triangleSideB, triangleSideC);

                    Console.WriteLine(TRes);
                    Console.ReadKey();

                    break;

                case 2:

                    double ellipseMajorAxis;
                    double ellipseMinorAxis;

                    DoubleFormatInput(out ellipseMajorAxis, "введіть дані еліпса\nбільша піввісь 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out ellipseMinorAxis, "введіть дані еліпса\nменша піввісь 'b' = ", IsEqualOrLessThanZero);

                    Ellipse ERes = new(ellipseMajorAxis, ellipseMinorAxis);

                    Console.WriteLine(ERes);
                    Console.ReadKey();

                    break;

                case 3:

                    double squareSide;
                    DoubleFormatInput(out squareSide, "введіть дані квадрата\nсторона 'a' = ", IsEqualOrLessThanZero);

                    Square SRes = new(squareSide);

                    Console.WriteLine(SRes);
                    Console.ReadKey();

                    break;

                case 4:

                    double trapeziumSideA;
                    double trapeziumSideB;
                    double trapeziumSideC;
                    double trapeziumSideD;
                    double trapeziumHeightAB;

                    DoubleFormatInput(out trapeziumSideA, "введіть дані трапеції\nоснова 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out trapeziumSideB, "введіть дані трапеції\nоснова 'b' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out trapeziumSideC, "введіть дані трапеції\nбічна сторона 'c' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out trapeziumSideD, "введіть дані трапеції\nбічна сторона 'd' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out trapeziumHeightAB, "введіть дані трапеції\nвисота трапеції 'h' до основи = ", IsEqualOrLessThanZero);

                    Trapezium TrRes = new(trapeziumSideA, trapeziumSideB, trapeziumSideC, trapeziumSideD, trapeziumHeightAB);

                    Console.WriteLine(TrRes);
                    Console.ReadKey();

                    break;

                case 5:

                    double rectangleSideA;
                    double rectangleSideB;

                    DoubleFormatInput(out rectangleSideA, "введіть дані прямокутника\nсторона 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out rectangleSideB, "введіть дані прямокутника\nсторона 'b' = ", IsEqualOrLessThanZero);

                    Rectangle RRes = new(rectangleSideA, rectangleSideB);

                    Console.WriteLine(RRes);
                    Console.ReadKey();

                    break;

                case 6:

                    double circleRadius;
                    DoubleFormatInput(out circleRadius, "введіть дані кола\nрадіус 'r' = ", IsEqualOrLessThanZero);

                    Circle CRes = new(circleRadius);

                    Console.WriteLine(CRes);
                    Console.ReadKey();

                    break;

                case 7:

                    double parallelogreamSideA;
                    double parallelogreamSideB;
                    double parallelogreamHeightA;

                    DoubleFormatInput(out parallelogreamSideA, "введіть дані паралелограма\nсторона 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out parallelogreamSideB, "введіть дані паралелограма\nсторона 'b' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out parallelogreamHeightA, "введіть дані паралелограма\nвисота 'h' до сторони 'a' = ", IsEqualOrLessThanZero);

                    Parallelogram PRes = new(parallelogreamSideA, parallelogreamSideB, parallelogreamHeightA);

                    Console.WriteLine(PRes);
                    Console.ReadKey();

                    break;

                case 8:

                    double rhombusSide;
                    double rhombusHeight;

                    DoubleFormatInput(out rhombusSide, "введіть дані ромба\nсторона 'a' = ", IsEqualOrLessThanZero);
                    DoubleFormatInput(out rhombusHeight, "введіть дані ромба\nвисота 'h' = ", IsEqualOrLessThanZero);

                    Rhombus RhRes = new(rhombusSide, rhombusHeight);

                    Console.WriteLine(RhRes);
                    Console.ReadKey();

                    break;
            }
        }
    }
}