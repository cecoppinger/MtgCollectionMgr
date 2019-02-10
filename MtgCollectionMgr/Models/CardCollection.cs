//Join table for cards/collections
namespace MtgCollectionMgr.Models
{
    public class CardCollectionModel
    {
        //public int CollectionModelID { get; set; }
        //public CollectionModel CollectionModel { get; set; }

        public int CardModelID { get; set; }
        public CardModel CardModel { get; set; }

        public int UserID { get; set; }
        public UserModel User { get; set; }

        public int Quantity { get; set; }

        public CardCollectionModel() { }
        public CardCollectionModel(UserModel user, CardModel cardModel)
        {
            User = user;
            CardModel = cardModel;
        }
    }
}
