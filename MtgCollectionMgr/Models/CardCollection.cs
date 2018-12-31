using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Join table for cards/collections
namespace MtgCollectionMgr.Models
{
    public class CardCollectionModel
    {
        public int CollectionModelID { get; set; }
        public CollectionModel CollectionModel { get; set; }

        public int CardModelID { get; set; }
        public CardModel CardModel { get; set; }

        public CardCollectionModel() { }
        public CardCollectionModel(CollectionModel collectionModel, CardModel cardModel)
        {
            CollectionModel = collectionModel;
            CardModel = cardModel;
        }
    }
}
