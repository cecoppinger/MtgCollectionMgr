
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

            if (context.CardModels.Any())
                return;

            CollectionModel model = new CollectionModel();
            context.Add(model);

            var cards = GetCards();

            foreach (CardFromJson cardList in cards)
            {
                for(int i = 0; i < cardList.Cards.Count; i++)
                {

                }
            }

            context.SaveChanges();

        }

        //public static IEnumerable<Card> GetAllCards()
        //{
        //    int page = 1;
        //    List<Card> cards = new List<Card>();

        //    CardService service = new CardService();
        //    var result = service.Where(x => x.Page, page).All();
        //    var value = result.Value;

        //    while (result.IsSuccess)
        //    {                
        //        if (result.Value.Count == 0)
        //            break;

        //        foreach (Card card in value)
        //            cards.Add(card);

        //        page++;

        //        result = service.Where(x => x.Page, page).All();
        //        value = result.Value;
        //    }

        //    return cards;
        //}

        public static List<CardFromJson> GetCards()
        {
            List<CardFromJson> cards = new List<CardFromJson>();

            for (int i = 0; i < 448; i++)
            {
                WebRequest request = WebRequest.Create("https://api.magicthegathering.io/v1/cards?page=" + i);
                WebResponse response = request.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string responseFromServer = reader.ReadToEnd();
                JObject parsedString = JObject.Parse(responseFromServer);
                CardFromJson myCards = parsedString.ToObject<CardFromJson>();

                cards.Add(myCards);
            }

            return cards;
        }
    }
}
