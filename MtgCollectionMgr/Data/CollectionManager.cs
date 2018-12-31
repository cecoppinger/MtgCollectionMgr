using MtgCollectionMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.Data
{
    public class CollectionManager
    {
        private CollectionModel _collectionModel;

        public CollectionManager() { }
        public CollectionManager(CollectionModel collectionModel)
        {
            _collectionModel = collectionModel;
        }

        
    }
}
