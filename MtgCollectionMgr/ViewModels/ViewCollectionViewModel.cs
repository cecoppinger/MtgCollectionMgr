using MtgCollectionMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.ViewModels
{
    public class ViewCollectionViewModel
    {
        public CollectionModel CollectionModel { get; set; }
        public IList<CardCollectionModel> Cards { get; set; }
    }
}
