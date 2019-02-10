using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgCollectionMgr.Models;
using MtgCollectionMgr.ViewModels;

namespace MtgCollectionMgr.Controllers
{
    [Authorize]
    public class CollectionModelsController : Controller
    {
        private readonly MtgCollectionMgrContext _context;

        public CollectionModelsController(MtgCollectionMgrContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Redirect("/CollectionModels/ViewCollection");
        }

        public IActionResult Search(string searchTerm)
        {
            var results = _context.CardModels.Where(c => c.Name.Contains(searchTerm));

            if (results != null)
                return View(results);

            return View("Index");
        }

        public IActionResult Create()
        {
            return View(new CreateCollectionViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateCollectionViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                CollectionModel newCollection = new CollectionModel()
                {
                    Name = viewModel.Name,
                };
                _context.Add(newCollection);
                _context.SaveChanges();

                return View("Index");
            }

            return View(viewModel);
        }

        public IActionResult ViewCollection(int? id)
        {
            //CollectionModel model = _context.CollectionModels.Single(x => x.ID == id);
            //var cards = _context.CardCollections
            //    .Include(x => x.CardModel)
            //    .Where(x => x.CollectionModelID == id)
            //    .ToList();
            var user = GetCurrentUser((ClaimsIdentity)User.Identity);
            var cards = _context.CardCollections
                .Include(x => x.CardModel)
                .Where(x => x.UserID == user.ID)
                .ToList();


            ViewCollectionViewModel viewModel = new ViewCollectionViewModel()
            {
                User = user,
                Cards = cards,
                TotalMarketPrice = GetTotalPrice(cards, "market"),
                TotalMedianPrice = GetTotalPrice(cards, "median"),
                TotalBuylistMarketPrice = GetTotalPrice(cards, "buylist")
            };

            return View(viewModel);
        }

        public IActionResult AddCard(int id)
        {
            var card = _context.CardModels.SingleOrDefault(c => c.ID == id);
            if(card != null)
            {
                var exists = _context.CardCollections
                    .Include(c => c.CardModel)
                    .Where(c => c.CardModelID == card.ID && c.UserID == GetCurrentUser((ClaimsIdentity)User.Identity).ID)
                    .SingleOrDefault();

                if (exists != null)
                {
                    exists.Quantity++;
                }
                else
                {
                    CardCollectionModel newCard = new CardCollectionModel()
                    {
                        CardModelID = card.ID,
                        UserID = GetCurrentUser((ClaimsIdentity)User.Identity).ID,
                        Quantity = 1
                    };
                    _context.Add(newCard);
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ViewCollection");
        }

        private UserModel GetCurrentUser(ClaimsIdentity identity)
        {
            var claims = identity.Claims;
            string username = claims.Where(c => c.Type == ClaimTypes.Name).Single().Value;
            if(username != null)
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == username);
                if(user != null)
                {
                    return user;
                }
            }

            return null;
        }
        
        private double GetTotalPrice(IEnumerable<CardCollectionModel> cards, string priceType)
        {
            double total = 0;

            switch (priceType)
            {
                case "market":
                    foreach(var card in cards)
                        total += card.CardModel.MarketPrice * card.Quantity;
                    break;
                case "buylist":
                    foreach (var card in cards)
                        total += card.CardModel.BuylistMarketPrice * card.Quantity;
                    break;
                case "median":
                    foreach (var card in cards)
                        total += card.CardModel.MedianPrice * card.Quantity;
                    break;
            }

            return total;
        }
    }
}