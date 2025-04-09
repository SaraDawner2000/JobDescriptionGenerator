public class JobTitle
{
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; }
    public string JobTitleCode { get; set; }

    public int JobFamilyId { get; set; }
    public JobFamily JobFamily { get; set; }

    public int JobLevelId { get; set; }
    public JobLevel JobLevel { get; set; }
}
