public class JobLevelService : IJobLevelService
{
    private readonly Dictionary<int, string> _names;
    private readonly Dictionary<int, List<int>> _levelsPerFamily;

    public JobLevelService(AppDbContext db)
    {
        _names = db.JobLevels.ToDictionary(l => l.JobLevelId, l => l.JobLevelName);
        _levelsPerFamily = db.JobTitles
            .GroupBy(t => t.JobFamilyId)
            .ToDictionary(
                g => g.Key,
                g => g.Select(t => t.JobLevelId).Distinct().OrderBy(x => x).ToList()
            );
    }

    public IReadOnlyList<int> GetLevelsForFamily(int familyId) =>
        _levelsPerFamily.TryGetValue(familyId, out var levels) ? levels : new List<int>();

    public string GetNameForLevel(int jobLevelId) =>
        _names.TryGetValue(jobLevelId, out var name) ? name : $"(Unknown Level {jobLevelId})";

    public List<(int Id, string Name)> GetAllLevels() =>
        _names.OrderBy(kvp => kvp.Key).Select(kvp => (kvp.Key, kvp.Value)).ToList();
}
