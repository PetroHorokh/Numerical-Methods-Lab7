namespace Lab7;

public static class IntegrationApproximation
{
    public static int LeftRectangleFunctionCall { get; set; }
    public static int MiddleRectangleFunctionCall { get; set; }
    public static double Function(double x) { return 1 / (x * Math.Pow(Math.Log(x), 2)); }
    public static double Trapeze(int n, double a, double b, double h)
    {
        double sum = 0;
        double x = a;
        double f0 = Function(a);
        double fn = Function(b);
        for (int i = 1; i < n; i++)
        {
            x += h;
            sum += Function(x);
        }
        return h * (0.5 * (f0 + fn) + sum);
    }

    public static double LeftRectangle(int n, double a, double b, double h, double prevI)
    {
        var sum = 0.0;
        LeftRectangleFunctionCall = 0;
        for (int i = 1; i < n; i += 2)
        {
            var x = a + h * i;
            sum += Function(x);
            LeftRectangleFunctionCall++;
        }
        return prevI / 2 + h * sum;
    }
    public static double MiddleRectangle(int n, double a, double b, double h)
    {
        MiddleRectangleFunctionCall = 0;
        double x = a + .5 * h;
        double sum = Function(x);
        MiddleRectangleFunctionCall++;
        for (int i = 2; i < n + 1; i++)
        {
            x += h;
            sum += Function(x);
            MiddleRectangleFunctionCall++;
        }
        return h * sum;
    }
    public static double Simpson(int n, double a, double b, double h)
    {
        var x = a;
        var f = new List<double> { Function(a) };
        var sum1 = 0.0;
        var sum2 = 0.0;
        for (int i = 1; i < n + 1; i++)
        {
            x += h;
            f.Add(Function(x));
        }
        for (int i = 1; i < n; i += 2) { sum1 += f[i]; }
        for (int i = 2; i < n; i += 2) { sum2 += f[i]; }
        var f0 = f.First();
        var fn = f.Last();
        return h / 3 * (f0 + 4 * sum1 + 2 * sum2 + fn);
    }

}