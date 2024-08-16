using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Calculator
{
    // Перегрузка операторов для работы с целыми и дробными числами
    public static double operator +(Calculator c, double value)
    {
        return c.Value + value;
    }

    public static double operator -(Calculator c, double value)
    {
        return c.Value - value;
    }

    public static double operator *(Calculator c, double value)
    {
        return c.Value * value;
    }

    public static double operator /(Calculator c, double value)
    {
        if (value == 0)
            throw new DivideByZeroException("Деление на ноль");
        return c.Value / value;
    }

    public double Value { get; set; }

    public Calculator(double initialValue)
    {
        Value = initialValue;
    }
}