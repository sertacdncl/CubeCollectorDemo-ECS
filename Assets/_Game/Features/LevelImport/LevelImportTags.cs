namespace Game
{
    public static class LevelImportTags
    {
        public const string GeneratedLevel = "Game GeneratedLevel_";
        public const string LevelInfo = "Game LevelInfo";
        public static string GetLevelName(int level) => GeneratedLevel + level;
    }
}
