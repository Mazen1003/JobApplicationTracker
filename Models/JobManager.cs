using System.Linq;
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
        //metod för att filtrerar ansökningar baserat på status.
        public void ShowSortedByDate()
        {
            var ordered = JobApplications
                .OrderBy(a => a.ApplicationDate)
                .ToList();

            if (ordered.Count == 0)
            {
                Console.WriteLine("No applications to show.");
                return;
            }

            Console.WriteLine("=== Applications sorted by date ===");
            foreach (var job in ordered)
            {
                Console.WriteLine(job.GetSummary());
            }

        }
        public void ShowByStatus(ApplicationStatus status)
        {
            var filtered = JobApplications
                .Where(a => a.Status == status)
                .ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine($"No applications found with status: {status}");
                return;
            }

            Console.WriteLine($"=== Applications with status: {status} ===");
            foreach (var job in filtered)
            {
                Console.WriteLine(job.GetSummary());
            }

        }
        public void SeedDummyData()
        {
            JobApplications = new List<JobApplication>
    {
        new JobApplication
        {
            CompanyName = "Techify AB",
            PositionTitle = "Software Developer",
            Status = ApplicationStatus.Applied,
            ApplicationDate = DateTime.Now.AddDays(-10),
            ResponseDate = null,
            SalaryExpectation = 40000
        },
        new JobApplication
        {
            CompanyName = "NextGen IT",
            PositionTitle = "Frontend Engineer",
            Status = ApplicationStatus.Interview,
            ApplicationDate = DateTime.Now.AddDays(-20),
            ResponseDate = DateTime.Now.AddDays(-15),
            SalaryExpectation = 42000
        },
        new JobApplication
        {
            CompanyName = "DataWorks",
            PositionTitle = "Data Analyst",
            Status = ApplicationStatus.Offer,
            ApplicationDate = DateTime.Now.AddDays(-30),
            ResponseDate = DateTime.Now.AddDays(-25),
            SalaryExpectation = 45000
        },
        new JobApplication
        {
            CompanyName = "CloudCorp",
            PositionTitle = "System Administrator",
            Status = ApplicationStatus.Rejected,
            ApplicationDate = DateTime.Now.AddDays(-40),
            ResponseDate = DateTime.Now.AddDays(-35),
            SalaryExpectation = 38000
        },
        new JobApplication
        {
            CompanyName = "FinTech Nordic",
            PositionTitle = "Backend Developer",
            Status = ApplicationStatus.Applied,
            ApplicationDate = DateTime.Now.AddDays(-5),
            ResponseDate = null,
            SalaryExpectation = 46000
        },
        new JobApplication
        {
            CompanyName = "BrightApps",
            PositionTitle = "Mobile Developer",
            Status = ApplicationStatus.Interview,
            ApplicationDate = DateTime.Now.AddDays(-18),
            ResponseDate = DateTime.Now.AddDays(-10),
            SalaryExpectation = 44000
        },
        new JobApplication
        {
            CompanyName = "SecureTech",
            PositionTitle = "Cybersecurity Specialist",
            Status = ApplicationStatus.Applied,
            ApplicationDate = DateTime.Now.AddDays(-7),
            ResponseDate = null,
            SalaryExpectation = 50000
        },
        new JobApplication
        {
            CompanyName = "EcoSystems AB",
            PositionTitle = "Full Stack Developer",
            Status = ApplicationStatus.Offer,
            ApplicationDate = DateTime.Now.AddDays(-22),
            ResponseDate = DateTime.Now.AddDays(-17),
            SalaryExpectation = 47000
        },
        new JobApplication
        {
            CompanyName = "CloudNova",
            PositionTitle = "DevOps Engineer",
            Status = ApplicationStatus.Rejected,
            ApplicationDate = DateTime.Now.AddDays(-60),
            ResponseDate = DateTime.Now.AddDays(-55),
            SalaryExpectation = 49000
        },
        new JobApplication
        {
            CompanyName = "HealthTech Solutions",
            PositionTitle = "QA Tester",
            Status = ApplicationStatus.Interview,
            ApplicationDate = DateTime.Now.AddDays(-14),
            ResponseDate = DateTime.Now.AddDays(-12),
            SalaryExpectation = 39000
        }
            };
        }
    }
    
    
    } 

