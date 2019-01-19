using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MtgCollectionMgr.Models;
using System.Collections.Generic;
using System.Linq;

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
 
            var cards = GetAllCards();
            
            foreach(Card card in cards)
            {
                if(card.MultiverseId != null)
                    context.Add(new CardModel(card));
            }

            context.SaveChanges();
            
        }

        public static IEnumerable<Card> GetAllCards()
        {
            int page = 1;
            List<Card> cards = new List<Card>();

            CardService service = new CardService();
            var result = service.Where(x => x.Page, page).All();
            var value = result.Value;

            while (result.IsSuccess)
            {                
                if (result.Value.Count == 0)
                    break;

                foreach (Card card in value)
                    cards.Add(card);

                page++;

                result = service.Where(x => x.Page, page).All();
                value = result.Value;
            }

            return cards;
        }
    }
}
