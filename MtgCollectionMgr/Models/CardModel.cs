﻿using System.Collections.Generic;

namespace MtgCollectionMgr.Models
{
    public class CardModel
    {
        public string Name { get; set; }
        public string SetName { get; set; }
        public string ImageUrl { get; set; }
        public int ID { get; set; }
        public int? MultiverseId { get; set; }

        public double MarketPrice { get; set; }
        public double MedianPrice { get; set; }
        public double BuylistMarketPrice { get; set; }

        public CardModel() { }
        public CardModel(Card card)
        {
            //Flavor
            //Id
            //Loyalty
            //ManaCost
            //Names
            //Number
            //Power
            //Printings
            //Rarity
            //Set
            //SetName
            //SubTypes
            //SuperTypes
            //Text
            //Toughness
            //Type
            //Types
            SetName = card.SetName;
            MultiverseId = card.Multiverseid;
            Name = card.Name;
            if (card.ImageUrl != null)
                ImageUrl = card.ImageUrl.ToString();
            else
                ImageUrl = "";
        }

        public IList<CardCollectionModel> CardCollectionModels { get; set; }
    }
}
