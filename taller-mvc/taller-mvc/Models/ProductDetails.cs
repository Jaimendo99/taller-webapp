namespace taller_mvc.Models
{
    public class ProductDetails: Product
    {
        public List<ShoppingListProduct> shoppingLists { get; set; }
    }
}
