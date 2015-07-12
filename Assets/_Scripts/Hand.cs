using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {

	List<Card> cards = new List<Card>();

	[SerializeField]
	private GameObject cardPrefab;

	[SerializeField]
	private GridLayoutGroup gridLayout;

	[SerializeField]
	private Transform selectedCardPanel;
	
	void Start () {
		for(int i=0; i < 5; i++)
		{
			GameObject card = (GameObject)Instantiate(cardPrefab);
			card.transform.SetParent(transform);
			card.transform.localScale = Vector3.one;
			AddCard(card.GetComponent<Card>());
		}
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			GameObject card = (GameObject)Instantiate(cardPrefab);
			card.transform.SetParent(transform);
			card.transform.localScale = Vector3.one;
			AddCard(card.GetComponent<Card>());
		}
	}

	void AddCard(Card card)
	{
		card.selectedCardPanel = selectedCardPanel;
		card.hand = transform;
		cards.Add(card);
			
		if(cards.Count > 1)
			gridLayout.spacing = new Vector2((1080 - gridLayout.padding.left - gridLayout.padding.right - cards.Count*gridLayout.cellSize.x)/(cards.Count-1), gridLayout.spacing.y);
	}
}
