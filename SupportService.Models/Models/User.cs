using SupportService.Models.Enums;

namespace SupportService.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Roles Role { get; set; }
        
    }
}