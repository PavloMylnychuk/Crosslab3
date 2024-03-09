using System;
using System.Collections.Generic;
using System.Linq;

class Transport
{
    public string Name { get; set; }
    public int Year { get; set; }
    public double Speed { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Транспорт: {Name}, Рік випуску: {Year}, Швидкість: {Speed} км/год");
    }
}

class Car : Transport
{
    public int PassengerCapacity { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Пасажирська вмісткість: {PassengerCapacity} осіб");
    }
}

class Train : Transport
{
    public int CarriageCount { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Кількість вагонів: {CarriageCount}");
    }
}

class Express : Train
{
    public bool WiFiEnabled { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Наявність Wi-Fi: {(WiFiEnabled ? "Так" : "Ні")}");
    }
}

class Program
{
    static void Main()
    {
        Transport[] transports = new Transport[]
        {
            new Car { Name = "Легковий автомобіль", Year = 2022, Speed = 150.5, PassengerCapacity = 5 },
            new Train { Name = "Пасажирський поїзд", Year = 2019, Speed = 120.8, CarriageCount = 10 },
            new Express { Name = "Швидкий експрес", Year = 2020, Speed = 200.0, CarriageCount = 5, WiFiEnabled = true },
        };

        var orderedTransports = transports.OrderBy(t => t.Speed).ToArray();
        Console.WriteLine("Впорядкований масив транспортних засобів за швидкістю:");
        foreach (var transport in orderedTransports)
        {
            transport.Show();
            Console.WriteLine();
        }
    }
}
