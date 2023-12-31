namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int _MaxPageSize=50;
        private int _PageSize=6;
        public int PageSize
        {
            get=>_PageSize;
            set=>_PageSize=(value >_MaxPageSize)?_MaxPageSize:value;
        }
        public int PageIndex{set;get;}=1;
        public int? BrandId{set;get;}
        public int? TypeId{set;get;}
        public string Sort{set;get;}
        private string _search;
        public string Search
        {
            get=>_search;
            set=> _search=value.ToLower();
        }
    }
}