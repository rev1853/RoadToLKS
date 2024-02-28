namespace EsemkaStoreAPI.DTOs
{
    public class TransactionDTO
    {
        public string CustomerName { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }


    public class OrderDTO
    {
        public int ProductID { get; set; }
        public int Qty { get; set; }
    }
}
