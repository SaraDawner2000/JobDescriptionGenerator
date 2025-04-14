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
        // remove the empty or whitespace only strings
        form.KeyAccountabilities = form.KeyAccountabilities
        .Where(s => !string.IsNullOrWhiteSpace(s))
        .ToList();

        form.KnowledgeAndSkills = form.KnowledgeAndSkills
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToList();

        var jobTitle = _db.JobTitles
            .FirstOrDefault(t => t.JobTitleId == form.JobTitleId);

        // EditForm ensures client-side validation, but if expanding to API or just for
        // defence in depth and changes in the database, make sure to verify and throw errors

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
