namespace Arcana.WebApi.Models.InstructorStars;

public class InstructorStarsUpdateModel
{
    public long StudentId { get; set; }
    public long InstructorId { get; set; }
    public byte Stars { get; set; }
}
