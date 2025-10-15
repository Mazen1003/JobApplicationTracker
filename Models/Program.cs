using JobApplicationTracker;
using JobApplicationTracker.Models;

internal class Program
{
    static void Main(string[] args)
    {
        JobManager manager = new JobManager();
        bool running = true;

        while (running) {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("JOB APPLICATION TRACKER");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Add new application");
            Console.WriteLine("2. Show all applications");
            Console.WriteLine("3. Update application status");
            Console.WriteLine("4. Remove an application");
            Console.WriteLine("5. Exit");
            Console.WriteLine("choose an option (1-5):");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewApplication(manager);
                    break;
                case "2":
                   manager.ShowAll();
                    Pause();
                    break;
                case "3":
                    UpdateApplicationStatus(manager);
                    break;
                case "4":
                    RemoveApplication(manager);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }




        }


    }
    static void AddNewApplication(JobManager manager)
    {
        Console.Clear();
        Console.Write("Company name: ");
        string company = Console.ReadLine();

        Console.Write("Position title: ");
        string title = Console.ReadLine();

        Console.Write("Expected salary (SEK): ");
        int salary = int.Parse(Console.ReadLine());

        var newJob = new JobApplication
        {
            CompanyName = company,
            PositionTitle = title,
            ApplicationDate = DateTime.Now,
            Status = ApplicationStatus.Applied,
            SalaryExpectation = salary
        };

        manager.AddJob(newJob);
        Console.WriteLine("✅ Application added!");
        Pause();
    }

    static void UpdateApplicationStatus(JobManager manager)
    {
        Console.Clear();
        Console.Write("Enter company name: ");
        string company = Console.ReadLine();

        Console.WriteLine("Available statuses:");
        foreach (var status in Enum.GetValues(typeof(ApplicationStatus)))
        {
            Console.WriteLine($"- {status}");
        }

        Console.Write("Enter new status: ");
        string statusInput = Console.ReadLine();

        if (Enum.TryParse(statusInput, true, out ApplicationStatus newStatus))
        {
            manager.UpdateStatus(company, newStatus);
        }
        else
        {
            Console.WriteLine("❌ Invalid status!");
        }
    }

    static void RemoveApplication(JobManager manager)
    {
        Console.Clear();
        Console.Write("Enter company name to remove: ");
        string company = Console.ReadLine();

        manager.RemoveJob(company);
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

}

