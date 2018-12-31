using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.Models
{
    public class CollectionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<CardCollectionModel> CardCollectionModels { get; set; }
    }
}
