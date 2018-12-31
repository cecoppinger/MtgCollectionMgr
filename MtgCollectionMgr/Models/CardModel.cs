using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MtgApiManager.Lib.Dto;
using MtgApiManager.Lib.Model;

namespace MtgCollectionMgr.Models
{
    public class CardModel
    {
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
            MultiverseId = card.MultiverseId;
            Name = card.Name;
            if (card.ImageUrl != null)
                ImageUrl = card.ImageUrl.ToString();
            else
                ImageUrl = "";
        }

        public string Name { get; set; }
        //public string Rarity { get; set; }
        //public string Flavor { get; set; }
        public string ImageUrl { get; set; }
        public int ID { get; set; }
        public int? MultiverseId { get; set; }
        //public IList<string> Names { get; set; }
        //public int Number { get; set; }
        //public int Power { get; set; }
        //public int Toughness { get; set; }
        //public string Type { get; set; }
        //public IList<string> SuperTypes { get; set; }
        //public IL MyProperty { get; set; }

        public IList<CardCollectionModel> CardCollectionModels { get; set; }
    }
}
