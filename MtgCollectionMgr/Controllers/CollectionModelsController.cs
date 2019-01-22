using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgCollectionMgr.Models;
using MtgCollectionMgr.ViewModels;
using Newtonsoft.Json.Linq;

namespace MtgCollectionMgr.Controllers
{
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
            WebRequest request = WebRequest.Create("https://api.magicthegathering.io/v1/cards?multiverseid=409741");

            //Send that response off
            WebResponse response = request.GetResponse();

            //Get back the response stream
            Stream stream = response.GetResponseStream();

            //This makes the info from our new stream accessible
            StreamReader reader = new StreamReader(stream);

            //This string will be JSON formatted
            string responseFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(responseFromServer);
            CardFromJson myCard = parsedString.ToObject<CardFromJson>();

            return View(myCard);
        }

        public IActionResult AddCard(int id)
        {
            var card = _context.CardModels.SingleOrDefault(c => c.ID == id);
            if(card != null)
            {
                CardCollectionModel newCard = new CardCollectionModel()
                {
                    CardModelID = card.ID,
                    CollectionModelID = 1
                };
                _context.Add(newCard);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewCollection");
        }

        //[HttpPost]
        //public IActionResult AddCard(AddCardViewModel viewModel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        CardCollectionModel newCard = new CardCollectionModel()
        //        {
        //            CardModelID = viewModel.CardModelID,
        //            CollectionModelID = viewModel.CollectionModelID
        //        };
        //        _context.Add(newCard);
        //        _context.SaveChanges();
        //        return Redirect("/CollectionModels/ViewCollection/" + viewModel.CollectionModelID);
        //    }

        //    return View(viewModel);
        //}
    }
}