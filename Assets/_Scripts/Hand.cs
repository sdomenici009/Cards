using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {

	private List<Card> cards = new List<Card>();

	[SerializeField]
	private GameObject cardPrefab;

	[SerializeField]
	private GridLayoutGroup gridLayout;

	[SerializeField]
	private Transform selectedCardPanel;

	public Card selectedCard;
	
	void Start () {
	}
	
	void Update () {
	}

	public void AddCard(Card card)
	{
		card.selectedCardPanel = selectedCardPanel;
		card.transform.SetSiblingIndex(cards.Count);
		card.hand = this;
		cards.Add(card);
			
		if(cards.Count > 1)
			gridLayout.spacing = new Vector2((1080 - gridLayout.padding.left - gridLayout.padding.right - cards.Count*gridLayout.cellSize.x)/(cards.Count-1), gridLayout.spacing.y);
	}
}
