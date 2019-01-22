using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.Models
{
    public class Ruling
    {
        public string Date { get; set; }
        public string Text { get; set; }
    }

    public class ForeignName
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public object Flavor { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public int Multiverseid { get; set; }
    }

    public class Legality
    {
        public string Format { get; set; }
        public string Legal { get; set; }
    }

    public class Card
    {
        public string Name { get; set; }
        public List<string> Names { get; set; }
        public string ManaCost { get; set; }
        public int Cmc { get; set; }
        public List<string> Colors { get; set; }
        public List<string> ColorIdentity { get; set; }
        public string Type { get; set; }
        public List<string> Supertypes { get; set; }
        public List<string> Types { get; set; }
        public List<string> Subtypes { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string Text { get; set; }
        public string Artist { get; set; }
        public string Number { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Layout { get; set; }
        public int Multiverseid { get; set; }
        public string ImageUrl { get; set; }
        public List<Ruling> Rulings { get; set; }
        public List<ForeignName> ForeignNames { get; set; }
        public List<string> Printings { get; set; }
        public string OriginalText { get; set; }
        public string OriginalType { get; set; }
        public List<Legality> Legalities { get; set; }
        public string Id { get; set; }
    }

    public class CardFromJson
    {
        public List<Card> Cards { get; set; }
    }
}
