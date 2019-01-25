using System.Collections.Generic;

namespace MtgCollectionMgr.Models
{
    public class CollectionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<CardCollectionModel> CardCollectionModels { get; set; }
    }
}
