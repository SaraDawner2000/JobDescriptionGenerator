public interface IJobLevelService
{
    IReadOnlyList<(int Id, string Name)> GetLevelsForFamily(int familyId);
    string GetNameForLevel(int jobLevelId);
}
