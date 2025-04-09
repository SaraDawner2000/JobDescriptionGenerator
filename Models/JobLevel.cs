public class JobLevel
{
    public int JobLevelId { get; set; }
    public string JobLevelName { get; set; } // e.g. "Job Level - 5"
    public List<JobTitle> JobTitles { get; set; } = new();
}
