using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mix;

public class Time
{
    public int Hour { get; set; }

    public int Minute { get; set; }

    public int Second { get; set; }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public static Time operator +(Time a, Time b)
    {
        return new Time(10, 10, 10);
    }

    public static Time operator *(Time a, Time b)
    {
        return new Time(10, 10, 10);
    }
}
