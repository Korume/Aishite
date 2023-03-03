namespace Aishite.SettignsManagement
{
    public record Settings
    {
        public string WindowTitle { get; set; } = "Aishite";
        public bool VerticalSync { get; set; } = true;
        public bool IsFullScreen { get; set; } = false;
        public uint WindowWidth { get; set; } = 1280;
        public uint WindowHeight { get; set; } = 720;

        public static Settings CreateDefault() => new();
    }
}
