public class JobFamily
{
    public int JobFamilyId { get; set; }
    public string JobFamilyName { get; set; }

    public ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
}
