using System;

class Activity
{
    protected DateTime date;
    protected int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return $"{date:dd MMM yyyy} {GetType().Name} ({duration} min): Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
    }
}

class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (duration / 60.0);
    }

    public override double GetPace()
    {
        return duration / distance;
    }
}

class StationaryBicycle : Activity
{
    private double speed; // in mph

    public StationaryBicycle(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * (duration / 60.0);
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 * 0.000621371; // convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / (duration / 60.0));
    }

    public override double GetPace()
    {
        return duration / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new Activity[]
        {
            new Running(new DateTime(2022, 11, 03), 30, 3.0),
            new Running(new DateTime(2022, 11, 03), 30, 4.8),
            new StationaryBicycle(new DateTime(2022, 11, 03), 20, 15),
            new Swimming(new DateTime(2022, 11, 03), 45, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
