namespace ITCenterBack.Utilities
{
    public class JwtConfigurationModel
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public double LifetimeHours { get; set; } = 1D;
    }
}
