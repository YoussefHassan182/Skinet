namespace API.DTOs
{
    public class ProductToReturnDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description{set;get;}
        public decimal Price{set;get;}
        public string PictureUrl{set;get;}
        public string ProductType{set;get;}
        public int ProductTypeId{set;get;}
        public string ProductBrand{set;get;}
        public int ProductBrandId{set;get;}
    }
}