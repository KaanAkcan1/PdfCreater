namespace PdfCreater.Models
{
    public class PdfContent
    {
        public string CompanyName { get; set; }
        public string ApplicantName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Questions> QuestionList { get; set; }
    }
    public class Questions
    {
        public string SorthingPath { get; set; }
        public string Text { get; set; }
        public string Note { get; set; }
        public int Point { get; set; }
        public string AddProperty1 { get; set; }
        public string AddProperty2 { get; set; }
        public string AddProperty3 { get; set; }
    }
}
