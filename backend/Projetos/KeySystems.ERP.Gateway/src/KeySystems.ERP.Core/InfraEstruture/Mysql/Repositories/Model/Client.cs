namespace KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories.Model
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; } 
        public string AllowedOrigin { get; set; }
    }

    public enum ApplicationType
    {
        Javascript = 0,
        NativeConfidential = 1
    }
}
