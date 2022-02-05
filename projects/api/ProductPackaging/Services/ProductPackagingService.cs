using ProductPackaging.Models;
using MongoDB.Driver;

namespace ProductPackaging.Services
{
    public class ProductPackagingService
    {
        private readonly IMongoCollection<MProductPackaging> _productPackaging;

        public ProductPackagingService(IProductPackagingDbSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _productPackaging = database.GetCollection<MProductPackaging>(settings.ProductPackagingCollectionName);
        }

        public MResponseData Get(int? pSkip, int? pQtdPage) {
            int skip = pSkip??0;
            int qtdPage = pQtdPage??10;
            var productList = _productPackaging
                .AsQueryable()
                .OrderBy(o => o.Code)
                .Skip(skip)
                .Take(qtdPage)
                .ToList();
            return new MResponseData() {
                Status = "SUCESS",
                Payload = productList,
                Footer = this.GetFooter(skip, qtdPage)
            };
        }

        public MResponseData Get(int pCode) {
            var productList = _productPackaging
                .AsQueryable()
                .Where(w => w.Code == pCode)
                .ToList();
            return new MResponseData() {
                Status = "SUCESS",
                Payload = productList,
                Footer = this.GetFooter(0, 1)
            };
        }

        public MResponseExecution Create(MProductPackaging pProduct)
        {
            _productPackaging.InsertOne(pProduct);
            return new MResponseExecution() {
                Status = "SUCESS",
                Message = "Product packaging created"
            };
        }

        public MResponseExecution Update(MProductPackaging pProduct) {
            _productPackaging.ReplaceOne(product => product.Id == pProduct.Id, pProduct);
            return new MResponseExecution() {
                Status = "SUCESS",
                Message = "Product packaging updated"
            };
        }

        public MResponseExecution Remove(int pCode) {
            _productPackaging.DeleteOne(product => product.Code == pCode);
            return new MResponseExecution() {
                Status = "SUCESS",
                Message = "Product packaging deleted"
            };
        }

        private MFooter GetFooter(int pSkip, int pQtdPage) {
            var totalRecords = this.GetTotalRecords();
            return new MFooter() {
                Page = pQtdPage,
                Skip = pSkip,
                hasNext = (pSkip + pQtdPage) < totalRecords,
                TotalRecords = totalRecords
            };
        }

        private long GetTotalRecords() {
            return _productPackaging.CountDocuments(c => true);
        }
    }
}