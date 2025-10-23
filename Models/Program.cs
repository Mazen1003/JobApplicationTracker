using JobApplicationTracker;
using JobApplicationTracker.Models;

internal class Program
{
    static void Main(string[] args)
    {
        JobManager manager = new JobManager();
        manager.SeedDummyData();
        bool running = true;

        while (running)
        { // Huvudmeny loop
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("JOB APPLICATION TRACKER");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Add new application");
            Console.WriteLine("2. Show all applications");
            Console.WriteLine("3. Update application status");
            Console.WriteLine("4. Remove an application");
            Console.WriteLine("5. Filter by status");
            Console.WriteLine("6. Show statistics");
            Console.WriteLine("7. Show applications sorted by date");
            Console.WriteLine("8. Exit");
            Console.WriteLine("choose an option (1-7):");

            string choice = Console.ReadLine();
            // Hantera användarens val
            switch (choice)
            {
                case "1":
                    manager.AddJob();
                    break;
                case "2":
                    manager.ShowAll();
                    break;
                case "3":
                    manager.UpdateStatus();
                    break;
                case "4":
                    manager.RemoveJob();
                    break;
                case "5":
                    manager.ShowByStatus();
                    break;
                case "6":
                    manager.ShowStatistics();                   
                    break;
                case "7":
                    manager.ShowSortedByDate();
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");             
                    break;
            }
            if (running)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }



        }


    }

}