﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MtgCollectionMgr.Models;
using System.Collections.Generic;

namespace MtgCollectionMgr.ViewModels
{
    public class AddCardViewModel
    {
        public CollectionModel Collection { get; set; }
        public int CollectionModelID { get; set; }

        public int CardModelID { get; set; }
        public List<SelectListItem> Cards { get; set; } = new List<SelectListItem>();

        public AddCardViewModel() { }
        public AddCardViewModel(CollectionModel collectionModel, IEnumerable<CardModel> cards)
        {
            Collection = collectionModel;
            foreach(CardModel card in cards)
            {
                Cards.Add(new SelectListItem
                {
                    Value = card.ID.ToString(),
                    Text = card.Name
                });
            }
        }
    }
}
