namespace Arcana.WebApi.Models.InstructorStars;

public class InstructorStarsCreateModel
{
    public long StudentId { get; set; }
    public long InstructorId { get; set; }
    public byte Stars { get; set; }
}
