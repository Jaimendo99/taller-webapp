namespace taller_mvc.Models
{
    public class ClientDetails: Client
    {
        public List<ShoppingListClient> shoppingLists { get; set; }
    }
}
