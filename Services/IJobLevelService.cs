public interface IJobLevelService
{
    IReadOnlyList<int> GetLevelsForFamily(int familyId);
    string GetNameForLevel(int jobLevelId);
    List<(int Id, string Name)> GetAllLevels();
}
