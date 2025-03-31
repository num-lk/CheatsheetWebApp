using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheatsheetWebApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }

        public virtual Cheatsheet Post { get; set; }
        public virtual IdentityUser User { get; set; }
        public Comment()
        {
            
        }
    }
}
