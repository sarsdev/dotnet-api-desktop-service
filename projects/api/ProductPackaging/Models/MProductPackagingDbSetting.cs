namespace ProductPackaging.Models
{
    public class MProductPackagingDbSetting : IProductPackagingDbSetting
    {
        public string ProductPackagingCollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }

    public interface IProductPackagingDbSetting
    {
        string ProductPackagingCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}