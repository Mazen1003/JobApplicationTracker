namespace JobApplicationTracker.Models
{
    public class JobManager
    {
        //lista över alla jobbansökningar
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();


        //metod för att lägga till en jobbansökan
        public void AddJob(JobApplication job)
        {
            JobApplications.Add(job);
            Console.WriteLine("Job application added successfully.");
        }
        //metod för att ändra status på en befintlig jobbansökan
        public void UpdateStatus(string companyName, ApplicationStatus newStatus)
        {
            var job = JobApplications.FirstOrDefault(j => j.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
            if (job != null)
            {
                job.Status = newStatus;
                Console.WriteLine("Job application status updated successfully.");
            }
            else
            {
                Console.WriteLine("Job application not found.");
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
        //metod för att filtrera jobbansökningar baserat på status med hjälp av LINQ
        public void FilterByStatus(ApplicationStatus status)
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
        //metod som visar statistik med LINQ (Count, Average, OrderBy, Where)
        public void ShowStatistics()
        {
            if (JobApplications.Count == 0)
            {
                Console.WriteLine("No job applications to show statistics.");
                return;
            }
            var totalApplications = JobApplications.Count;
            var averageSalary = JobApplications.Average(j => j.SalaryExpectation);
            var applicationsByStatus = JobApplications
                .GroupBy(j => j.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);
            Console.WriteLine($"Total Applications: {totalApplications}");
            Console.WriteLine($"Average Salary Expectation: {averageSalary:C}");
            Console.WriteLine("Applications by Status:");
            foreach (var group in applicationsByStatus)
            {
                Console.WriteLine($"{group.Status}: {group.Count}");
            }
        }
        //metod för att ta bort en jobbansökan
        public void RemoveJob(string companyName)
        {
            var job = JobApplications.FirstOrDefault(j => j.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
            if (job != null)
            {
                JobApplications.Remove(job);
                Console.WriteLine("Job application removed successfully.");
            }
            else
            {
                Console.WriteLine("Job application not found.");
            }
        }

    }

}
