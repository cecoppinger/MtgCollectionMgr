using MtgCollectionMgr.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MtgCollectionMgr.Data
{
    public class DbInitializer
    {
        public static void Initialize(MtgCollectionMgrContext context)
        {
            context.Database.EnsureCreated();
            TcgPriceCrawler priceCrawler = new TcgPriceCrawler();
            List<CardPrice> prices = priceCrawler.GetPrices();

            if (context.CardModels.Any())
            {
                InitPrices(context, prices);
                return;
            }

            CollectionModel model = new CollectionModel();
            context.Add(model);

            var cards = GetCards();

            foreach (CardFromJson cardList in cards)
            {
                for(int i = 0; i < cardList.Cards.Count; i++)
                {
                    CardModel newCard = new CardModel(cardList.Cards[i]);
                    context.Add(newCard);
                }
            }

            context.SaveChanges();
        }

        private static List<CardFromJson> GetCards()
        {
            List<CardFromJson> cards = new List<CardFromJson>();

            for (int i = 1; i <= 600; i++)
            {
                WebRequest request = WebRequest.Create("https://api.magicthegathering.io/v1/cards?page=" + i);
                WebResponse response = request.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string responseFromServer = reader.ReadToEnd();
                JObject parsedString = JObject.Parse(responseFromServer);
                CardFromJson myCards = parsedString.ToObject<CardFromJson>();

                if (myCards.Cards.Count == 0)
                    break;

                cards.Add(myCards);
            }

            return cards;
        }

        private static void InitPrices(MtgCollectionMgrContext context, List<CardPrice> prices)
        {
            foreach(CardPrice price in prices)
            {
                CardModel myCard = context.CardModels
                    .FirstOrDefault(c => c.Name == price.CardName && c.SetName == price.SetName);

                if(myCard != null)
                {
                    myCard.MedianPrice = price.MedianPrice;
                    myCard.MarketPrice = price.MarketPrice;
                    myCard.BuylistMarketPrice = price.BuylistMarketPrice;
                    //context.CardModels.Update(myCard);
                }
            }

            context.SaveChanges();
        }
    }


}
