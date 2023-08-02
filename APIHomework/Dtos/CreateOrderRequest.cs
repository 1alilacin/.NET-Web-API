namespace APIHomework.Dtos
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public List<ProductIdCountDto> Products { get; set; }

    }
    public class ProductIdCountDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}

