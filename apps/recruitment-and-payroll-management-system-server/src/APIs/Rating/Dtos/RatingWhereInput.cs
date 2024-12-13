namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class RatingWhereInput
{
    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? EntityRated { get; set; }

    public string? Id { get; set; }

    public string? Job { get; set; }

    public string? RatedBy { get; set; }

    public int? RatingValue { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
