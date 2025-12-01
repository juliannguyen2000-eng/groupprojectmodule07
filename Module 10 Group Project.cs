using System;
using System.Collections.Generic;

class Contractor
{
    private string contractorName;
    private int contractorNumber;
    private DateTime contractorStartDate;

    public Contractor()
    {
        contractorName = "";
        contractorNumber = 0;
        contractorStartDate = DateTime.Now;
    }

    public Contractor(string name, int number, DateTime startDate)
    {
        contractorName = name;
        contractorNumber = number;
        contractorStartDate = startDate;
    }
    // thank you ozalers for doing this previous section of the code!

    // this is an accessor method. this lets the code outside the body read the private variables. private variables are variables which can be only be accessed from within the body of the same class or structure.
    public string GetName() { return contractorName; }
    public int GetNumber() { return contractorNumber; }
    public DateTime GetStartDate() { return contractorStartDate; }

    // this is a mutator method. this allows the private variables to be changed from outside the body
    public void SetName(string n) { contractorName = n; }
    public void SetNumber(int num) { contractorNumber = num; }
    public void SetStartDate(DateTime d) { contractorStartDate = d; }
}

class Subcontractor : Contractor
{
    private int shift;          // 1 = day, 2 = night
    private double hourlyRate;

    // Constructors
    public Subcontractor() : base()
    {
        shift = 1;
        hourlyRate = 0.0;
    }

    public Subcontractor(string name, int number, DateTime date,
                         int shift, double hourlyRate)
        : base(name, number, date)
    {
        this.shift = shift;
        this.hourlyRate = hourlyRate;
    }

    // accessor method
    public int GetShift() { return shift; }
    public double GetHourlyRate() { return hourlyRate; }

    // mutators method
    public void SetShift(int s) { shift = s; }
    public void SetHourlyRate(double r) { hourlyRate = r; }

    // compute pay method. self-explanatory. returns as a float value
    public float ComputePay(float hoursWorked)
    {
        double pay = hourlyRate * hoursWorked;

        if (shift == 2)      // night shift differential. adds the 3% stated in the pdf.
        {
            pay *= 1.03;
        }

        return (float)pay;
    }
}

class Program
{
    static void Main()
    {
        List<Subcontractor> subs = new List<Subcontractor>();

        bool running = true;

        while (running) // this section is entirely for the user's input. 
        {
            Console.WriteLine("\n--- Create Contractor ---");

            Console.Write("Contractor Name: ");
            string name = Console.ReadLine();

            int number;
            while (true)
            {
                Console.Write("Contractor Number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                    break;
                Console.WriteLine("Invalid Number. Please enter contractor Number.");
            }
            DateTime date;
            while (true)
            {
                Console.Write("Start Date (MM/DD/YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                Console.WriteLine("Invalid Date. Please enter start date.");
            }
            int shift;
            while (true)
            {
                Console.Write("Day shift or Night shift? (1 = Day, 2 = Night): ");
                if (int.TryParse(Console.ReadLine(), out shift) && (shift == 1 || shift == 2))
                    break;
                Console.WriteLine("Invalid Shift. Please enter either 1 or 2.");
            }
            double rate;
            while (true)
            {
                Console.Write("Hourly Pay: ");
                if (double.TryParse(Console.ReadLine(), out rate) && rate >= 0) ;
                break;
                Console.WriteLine("Invalid Rate. Please enter Hourly Pay.");
            }

            Subcontractor sub = new Subcontractor(name, number, date, shift, rate);
            subs.Add(sub);

            Console.Write("Create another contractor? (y/n): ");
            running = Console.ReadLine().ToLower() == "y";
        }

        Console.WriteLine("\n--- Contractor Summary ---"); // provides the details of the contractor

        foreach (var s in subs)
        {
            Console.WriteLine($"\nName: {s.GetName()}");
            Console.WriteLine($"Number: {s.GetNumber()}");
            Console.WriteLine($"Start Date: {s.GetStartDate().ToShortDateString()}");
            Console.WriteLine($"Shift: {s.GetShift()}");
            Console.WriteLine($"Hourly Rate: ${s.GetHourlyRate():0.00}");

            float hours;
            while (true)
            {
                Console.Write("Enter hours worked to compute pay: ");
                if (float.TryParse(Console.ReadLine(), out hours) && hours >= 0)
                    break;
                Console.WriteLine("Invalid hours. Please enter amount of hours.");
            }

            float pay = s.ComputePay(hours);
            Console.WriteLine($"Total Pay: ${pay:0.00}");
        }
    }
}
