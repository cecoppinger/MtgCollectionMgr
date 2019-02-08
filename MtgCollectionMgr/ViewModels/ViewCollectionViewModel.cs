using MtgCollectionMgr.Models;
using System.Collections.Generic;

namespace MtgCollectionMgr.ViewModels
{
    public class ViewCollectionViewModel
    {
        public CollectionModel CollectionModel { get; set; }
        public IList<CardCollectionModel> Cards { get; set; }

        public double TotalMarketPrice { get; set; }
        public double TotalMedianPrice { get; set; }
        public double TotalBuylistMarketPrice { get; set; }
    }
}
