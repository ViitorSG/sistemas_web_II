using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StudentsNotes.Models;

namespace StudentsNotes.Data
{
    public class StudentsNotesContext : DbContext
    {
        public StudentsNotesContext(DbContextOptions<StudentsNotesContext> options) : base(options)
        {
        }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> grades { get; set; }
    }
}

