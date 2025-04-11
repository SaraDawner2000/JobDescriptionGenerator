using System.ComponentModel.DataAnnotations;

namespace JobDescriptionGenerator.Forms;

public class JobDescriptionForm
{
    [Required]
    public int? JobFamilyId { get; set; }

    [Required]
    public int? JobTitleId { get; set; }

    [Required]
    public bool IsManager { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "Job Purpose must be at least 10 characters long.")]
    public string JobPurpose { get; set; }

    [Required]
    [TextListRequired(ErrorMessage = "At least one accountability is required.")]
    public List<string> KeyAccountabilities { get; set; } = new();

    [Required]
    [TextListRequired(ErrorMessage = "At least one knowledge or skill is required.")]
    public List<string> KnowledgeAndSkills { get; set; } = new();
}
