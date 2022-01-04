using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Deck : MonoBehaviour
{
    #region Variables
    public int deckQuantity = 6; //Mostly used 6 to 8.

    [SerializeField]
    public List<CardData> listOfCards = new List<CardData>();

    private System.Random rn1 = new System.Random();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckQuantity; i++)
        {
            CreateDeck();
        }
    }

    #region Methods
    private void CreateDeck()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                listOfCards.Add(new CardData() { number = j, symbol = i });
            }
        }
    }
    public void Shuffle()
    {
        CardData tempCd;
        for (int i = 0; i < 50; i++)
        {
            var index1 = rn1.Next(0, listOfCards.Count());
            var index2 = rn1.Next(0, listOfCards.Count());

            tempCd = listOfCards[index1];
            listOfCards[index1] = listOfCards[index2];
            listOfCards[index2] = tempCd;
        }
    }

    public CardData PickCard()
    {
        var card = listOfCards.First();
        listOfCards.Remove(card);
        return card;
    }

    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    public class CardData 
    {
        [SerializeField]
        public int number { get; set; }

        [SerializeField]
        public int symbol { get; set; }

        public override string ToString()
        {
            return "N: " + number + " S: " + symbol;
        }
    }
}