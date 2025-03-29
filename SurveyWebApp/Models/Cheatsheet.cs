namespace CheatsheetWebApp.Models
{
    public class Cheatsheet
    {
        public int Id { get; set; }
        public string? Question { get; set; }

        public string? Answer { get; set; }

        public Cheatsheet()
        {
            
        }
    }
}
