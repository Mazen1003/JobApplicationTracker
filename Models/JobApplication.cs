namespace JobApplicationTracker
{
    public enum ApplicationStatus
    {
        Applied,
        Interview,
        Offer,
        Rejected
    }
    public class JobApplication
    {
        //CompanyName | string
        //PositionTitle | string
        //Status | enum - (Applied, Interview, Offer, Rejected)
        //ApplicationDate | DateTime - Datum när ansökan skickades
        //ResponseDate | DateTime? - Datum när svar mottogs
        //SalaryExpectation | int - Önskad lön i kronor

        //Metoder:
        //GetDaysSinceApplied() – returnerar antal dagar sedan ansökan skickades.
        //GetSummary() – returnerar en kort sammanfattning av ansökan.
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int SalaryExpectation { get; set; }

        public JobApplication(string companyName, string positionTitle, ApplicationStatus status, int salaryExpectation, DateTime applicationDate)
        {
            CompanyName = companyName;
            PositionTitle = positionTitle;
            Status = status;
            ApplicationDate = applicationDate;
            SalaryExpectation = salaryExpectation;
        }

        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }
        public string GetSummary()
        {
            string response = ResponseDate.HasValue
                ? $"Response: {ResponseDate.Value.ToShortDateString()}"
                : "No response yet";

            return $"{CompanyName} - {PositionTitle} | Status: {Status} | Applied: {ApplicationDate.ToShortDateString()}";
        }


    }
}
