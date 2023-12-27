namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{set;get;}
        public decimal Price{set;get;}
        public string PictureUrl{set;get;}
        public ProductType ProductType{set;get;}
        public int ProductTypeId{set;get;}
        public ProductBrand ProductBrand{set;get;}
        public int ProductBrandId{set;get;}
    }

}