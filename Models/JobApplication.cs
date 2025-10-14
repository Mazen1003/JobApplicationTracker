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

        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }
        public string GetSummary()
        {
            string response = ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "No response yet";
            return $"{CompanyName} - {PositionTitle} | Status: {Status} | {response}";

        }


    }
}
