public class JobTitle
{
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }

    public int JobFamilyId { get; set; }
    public JobFamily JobFamily { get; set; }

    public string JobLevelName { get; set; }
}
