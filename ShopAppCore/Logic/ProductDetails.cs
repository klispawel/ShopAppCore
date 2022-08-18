public class ProductDetails
{
    public string Description { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public ProductDetails(string description, DateTime expirationDate)
    {
        Description = description;
        ExpirationDate = expirationDate;
    }
}