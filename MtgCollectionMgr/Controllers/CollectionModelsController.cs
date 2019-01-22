﻿using System;
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

        public IActionResult ViewCollection(int? id = 1)
        {
            CollectionModel model = _context.CollectionModels.Single(x => x.ID == id);
            var items = _context.CardCollectionModels
                .Include(x => x.CardModel)
                .Where(x => x.CollectionModelID == id)
                .ToList();

            ViewCollectionViewModel viewModel = new ViewCollectionViewModel()
            {
                CollectionModel = model,
                Cards = items
            };

            return View(viewModel);
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