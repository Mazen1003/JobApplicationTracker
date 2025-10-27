using System.Linq;
namespace JobApplicationTracker.Models
{
    public class JobManager
    {
        //lista över alla jobbansökningar
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();


        //metod för att lägga till en jobbansökan
        public void AddJob()
        {
            Console.WriteLine("Enter Company Name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Enter Position Title:");
            string positionTitle = Console.ReadLine();
            Console.WriteLine("Enter date of application (yyyy-mm-dd)");
            string dateInput = Console.ReadLine();
            DateTime applicationDate;
            if (!DateTime.TryParse(dateInput, out applicationDate))
            {
                Console.WriteLine("Invalid date format. Job application not added.");
                return;
            }
            Console.WriteLine("Enter Salary Expectation (in SEK):");
            if (!int.TryParse(Console.ReadLine(), out int salaryExpectation))
            {
                Console.WriteLine("Invalid salary input. Job application not added.");
                return;
            }

            JobApplication newJob = new JobApplication(companyName, positionTitle, ApplicationStatus.Applied, salaryExpectation, applicationDate);
            JobApplications.Add(newJob);

            Console.WriteLine("Job application added successfully.");
            

        }
        //metod för att ändra status på en befintlig jobbansökan
        public void UpdateStatus()
        {
            Console.WriteLine("Enter Company Name of the application to update:");
            string companyName = Console.ReadLine();
            var job = JobApplications.FirstOrDefault(j => j.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
            if (job == null)
            {
                Console.WriteLine("Job application not found.");
                return;
            }
            Console.WriteLine("Select new status:");


            if (Enum.TryParse<ApplicationStatus>(Console.ReadLine(), true, out ApplicationStatus newStatus))

            {
                job.Status = newStatus;
                Console.WriteLine("Job application status updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid status input. Status not updated.");
            }
            
        }
        //metod för att visa alla jobbansökningar
        public void ShowAll()
        {
            if (JobApplications.Count == 0)
            {
                Console.WriteLine("No job applications found.");
                return;
            }
            Console.WriteLine("All Job Applications:");
            foreach (var job in JobApplications)
            {
                
                Console.WriteLine(job.GetSummary());
            }
            
        }
    
        //metod för att ta bort en jobbansökan
        public void RemoveJob()
        {
            Console.WriteLine("Enter Company Name of the application to remove:");
            string name = Console.ReadLine();
            var job = JobApplications.FirstOrDefault(j => j.CompanyName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (job == null)
            {
                Console.WriteLine("Job application not found.");
                return;
            }
            JobApplications.Remove(job);
            Console.WriteLine("Job application removed successfully.");

           
        }
        //metod för att filtrerar ansökningar baserat på status.
        public void ShowSortedByDate()
        {
            var sortedJobs = JobApplications.OrderBy(j => j.ApplicationDate).ToList();
            Console.WriteLine("Job Applications sorted by Application Date:");
            foreach (var job in sortedJobs)
            {
                Console.WriteLine(job.GetSummary());
            }


        }
        //metod för att filtrera ansökningar baserat på status
        public void ShowByStatus()
        {
            Console.WriteLine("Enter status to filter by (Applied, Interview, Offer, Rejected):");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out ApplicationStatus status))
            {
                var filteredJobs = JobApplications.Where(j => j.Status == status).ToList();
                if (filteredJobs.Count == 0)
                {
                    Console.WriteLine($"No job applications found with status: {status}");
                    return;
                }
                foreach (var job in filteredJobs)
                {
                    Console.WriteLine(job.GetSummary());
                }
            }
            
        }
        //metod för att lägga till några dummydata för testning
        public void SeedDummyData()
        {
            JobApplications.Add(new JobApplication("Volvo", "Software Engineer", ApplicationStatus.Applied, 60000, DateTime.Now.AddDays(-10)));
            JobApplications.Add(new JobApplication("ICA", "Data Analyst", ApplicationStatus.Interview, 55000, DateTime.Now.AddDays(-20)));
            JobApplications.Add(new JobApplication("IKEA", "Frontend Developer", ApplicationStatus.Offer, 65000, DateTime.Now.AddDays(-15)));
            JobApplications.Add(new JobApplication("Apple", "Dev", ApplicationStatus.Rejected, 70000, DateTime.Now.AddDays(-5)));

        }
    }
}
       















