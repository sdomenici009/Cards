using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Deck {

	private List<Card> cards = new List<Card>();
	
	private GameStateManager.Owner owner;
	private Hand hand;
	private GameObject cardPrefab;

	public Deck(GameStateManager.Owner owner, Hand hand, GameObject cardPrefab)
	{
		this.owner = owner;
		this.hand = hand;
		this.cardPrefab = cardPrefab;

		InstantiateDeck();
		Shuffle(25);
	}

	void InstantiateDeck()
	{
		int testCardInfo = 0;

		for(int i=0; i < 40; i++)
		{
			if(i!=0 && i%4 == 0) testCardInfo++;
			
			Card card = ((GameObject)GameObject.Instantiate(cardPrefab)).GetComponent<Card>();
			card.transform.SetParent(hand.transform);
			card.transform.localScale = Vector3.one;
			card.gameObject.SetActive(false);
			card.InitializeCard(testCardInfo, testCardInfo, testCardInfo, testCardInfo);
			cards.Add(card);
		}

	}

	public void Shuffle(int num)
	{
		for(int j = 0; j < num; j++)
		{
			int n = cards.Count-1;
			for (int i = 0; i < n; i++)
			{
				int r = i + Random.Range(0, 2) * (n - i);
				Card t = cards[r];
				cards[r] = cards[i];
				cards[i] = t;
			}
		}
	}

	public void Draw()
	{
		if(cards.Count > 0)
		{
			hand.AddCard(cards[0]);
			cards[0].gameObject.SetActive(true);
			cards.RemoveAt(0);
		}
	}
}
