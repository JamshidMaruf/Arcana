using Arcana.Domain.Commons;
using Arcana.Domain.Enums.Levels;

namespace Arcana.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime Duration { get; set; }
    public int Count_Of_Lessons { get; set; }
    public Level Level { get; set; }
    public long Category_Id { get; set; }
    public long Instructor_Id { get; set; }
    public long File_Id { get; set; }
    //public long Language_Id {  get; set; }

}
