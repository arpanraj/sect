namespace StaticData
{
    public static class SceneNames
    {
        public static string PRELOAD      = "PreLoad";
        public static string START        = "StartMenu";
        public static string OPTIONS      = "OptionsMenu";
        public static string LEVELS       = "LevelsMenu";
        public static string SETTINGS     = "OptionsMenu";
        public static string CONNECT      = "ConnectMenu";
        public static string SUPPORT      = "SupportMenu";
        public static string LEVEL_PREFIX = "Level";
    }

    public static class Triggers
    {
        public static string FADE_IN = "FadeIn";
    }

    public static class Grid3d
    {
        public static class Bounds
        {
            public static float x = 3.5f;
            public static float y = 4.5f;
            public static float z = 3.5f;
        }
        public static class Unit
        {
            public static float x = 0.25f;
            public static float y = 0.25f;
            public static float z = 0.25f;
        }
    }

    public static class UnlockedLevels
    {
        public static string MaxKeyName = "MaxUnlcokedLevels";
        public const int DefaultMax = 1;
        public const int MaxFreeLevel = 10;
    }

    public static class Sound
    {
        public static string bgSoundName = "bgSound";
        public static string uiSoundName = "uiSound";
    }
    public static class AchivementUnlockCount
    {
        public const int knowledge_unlocked = 5;
        public const int experimenter = 10;
        public const int explorer = 20;
        public const int pioneer = 30;
        public const int innovator = 40;
    }
    public static class AppPurchase
    {
        public const string LevelPurchaseKey = "LevelPurchaseKey";
        public const string LevelsPurchased = "LevelsPurchased";
        public const string LevelsNotPurchased = "LevelsNotPurchased";
    }
}
