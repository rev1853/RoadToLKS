namespace Challenges
{
    public class MovieRequest
    {
        public required string title { get; set; }
        public required string release_data { get; set; }
        public required int ticket_price { get; set; }
        public required string genre { get; set; }
    }
}
