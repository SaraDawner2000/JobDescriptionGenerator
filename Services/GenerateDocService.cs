using JobDescriptionGenerator.Forms;

namespace JobDescriptionGenerator.Services;

public class GenerateDocService : IGenerateDocService
{
    private readonly AppDbContext _db;

    public GenerateDocService(AppDbContext db)
    {
        _db = db;
    }

    public byte[] GenerateDocument(JobDescriptionForm form)
    {
        // TODO: Validate form (if needed)

        // Fetch JobTitle data from DB
        var jobTitle = _db.JobTitles
            .FirstOrDefault(t => t.JobTitleId == form.JobTitleId);

        if (jobTitle is null)
            throw new InvalidOperationException("Job title not found");

        // Example access:
        var jobTitleName = jobTitle.JobTitleName;
        var jobTitleCode = jobTitle.JobProfile;

        // TODO: Insert form + jobTitle data into a .docx template using DocX

        // For now, return an empty file
        return new byte[0]; // placeholder
    }
}
