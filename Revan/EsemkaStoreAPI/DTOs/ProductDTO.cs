namespace EsemkaStoreAPI.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = "Barang Baru";
        public string Brand { get; set; }
        public int CategoryID { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; } = 10000;

    }
}
