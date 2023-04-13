internal static class ConsoleNeededMethods
{
    internal delegate bool CompareValue(double value);

    internal static void DoubleFormatInput(out double value, string message = "", CompareValue? method = null)
    {
        Console.Clear();

        while (true)
        {
            if (!String.IsNullOrEmpty(message) && !String.IsNullOrWhiteSpace(message))
                Console.Write(message);

            try
            {
                value = Double.Parse(new string(Console.ReadLine()));

                if (method != null)
                {
                    if (method(value))
                    {
                        Console.Clear();
                        Console.WriteLine("(!) помилка - недопустиме значення числа");
                        continue;
                    }
                }

                Console.Clear();
                break;
            }
            catch (FormatException)
            {

                Console.Clear();
                Console.WriteLine("(!) помилка - неправильний формат числа");
                continue;
            }
        }
    }
}