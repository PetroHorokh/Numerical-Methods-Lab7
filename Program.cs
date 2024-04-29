using Lab7;

var a = 2.0;
var b = 3.0;
var e = 1E-5;
var preciseIntegral = .532456;
var rM = 0.0;
var rL = 0.0;
var rT = 0.0;
var rS = 0.0;
var hM = 0.0;
var hL = 0.0;
var hT = 0.0;
var hS = 0.0;
var iM = preciseIntegral;
var iL = IntegrationApproximation.LeftRectangle(4, a, b, (b - a) / 2, 0.0);
var iT = preciseIntegral;
var iS = preciseIntegral;
Console.WriteLine($"Precise integral - {preciseIntegral}");
for (int n = 4; ; n *= 2){ 
    var h = (b - a) / n;
    if (hM == 0)
    {
        iM = IntegrationApproximation.MiddleRectangle(n, a, b, h);
        if (Math.Abs(preciseIntegral - iM) < e)
        {
            hM = h;
            rM = iM;
        }
    }
    if (hL == 0)
    {
        iL = IntegrationApproximation.LeftRectangle(n, a, b, h, iL);
        if (Math.Abs(preciseIntegral - iL) < e)
        {
            hL = h;
            rL = iL;
        }
    }
    if (hT == 0)
    {
        iT = IntegrationApproximation.Trapeze(n, a, b, h);
        if (Math.Abs(preciseIntegral - iT) < e)
        {
            hT = h;
            rT = iT;
        }
    }
    if (hS == 0)
    {
        iS = IntegrationApproximation.Simpson(n, a, b, h);
        if (Math.Abs(preciseIntegral - iS) < e)
        {
            hS = h;
            rS = iS;
        }
    }
    if (Math.Abs(preciseIntegral - iM) < e && Math.Abs(preciseIntegral - iL) < e && Math.Abs(preciseIntegral - iT) < e && Math.Abs(preciseIntegral - iS) < e) break;
}
Console.WriteLine("Results after all approximations met precision level:");
Console.WriteLine($"Integration with formula of middle rectangles result - {rM}");
Console.WriteLine($"Step - {hM}. Amount of steps = {(b - a) / hM}");
Console.WriteLine($"Integration with formula of left rectangles result - {rL}");
Console.WriteLine($"Step - {hL}. Amount of steps = {(b - a) / hL}");
Console.WriteLine($"Integration with trapezium formula - {rT}");
Console.WriteLine($"Step - {hT}. Amount of steps = {(b - a) / hT}");
Console.WriteLine($"Integration with Simpson's formula - {rS}");
Console.WriteLine($"Step - {hS}. Amount of steps = {(b - a) / hS}");
Console.WriteLine($"Left function use - {IntegrationApproximation.LeftRectangleFunctionCall}");
Console.WriteLine($"Middle function use - {IntegrationApproximation.MiddleRectangleFunctionCall}");
Console.WriteLine($"Incoherency with with formula of middle rectangles - {Math.Abs(preciseIntegral - rM)}");
Console.WriteLine($"Incoherency with formula of left rectangles - {Math.Abs(preciseIntegral - rL)}");
Console.WriteLine($"Incoherency with trapezium formula - {Math.Abs(preciseIntegral - rT)}");
Console.WriteLine($"Incoherency with Simpson's formula - {Math.Abs(preciseIntegral - rS)}");
