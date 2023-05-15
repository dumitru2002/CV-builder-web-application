using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.BLL.Entities
{
    public class CV
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Add other properties as needed

        // Navigation properties (if applicable)
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }

    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateTime GraduationDate { get; set; }
        // Add other properties as needed

        // Foreign key property
        public int CVId { get; set; }
        public CV CV { get; set; }
    }

    public class Experience
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // Add other properties as needed

        // Foreign key property
        public int CVId { get; set; }
        public CV CV { get; set; }
    }

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Add other properties as needed

        // Foreign key property
        public int CVId { get; set; }
        public CV CV { get; set; }
    }
}
