using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {

	private List<Card> cards = new List<Card>();

	[SerializeField]
	private Board board;

	[SerializeField]
	private GameObject cardPrefab;

	[SerializeField]
	private GridLayoutGroup gridLayout;

	[SerializeField]
	private Transform selectedCardPanel;

	public Card selectedCard;

	private bool draggingCard = false;

	private int lastTouchCount = 0;

	private bool selectedCardLastPressed = false;
	
	void Start () {
	}
	
	void Update () {
		if(selectedCard != null && selectedCard.selected && selectedCardLastPressed == true && !selectedCard.pressed)
		{
			Debug.Log (selectedCard.transform.position);

			for(int i=0; i < board.playerCardSlots.Length; i++)
			{
				Debug.Log (board.playerCardSlots[i].transform.position);

				if(Vector3.Distance(selectedCard.transform.position, board.playerCardSlots[i].transform.position) < 30f)
				{
					if(!board.playerCardSlots[i].occupied)
					{
						selectedCard.transform.SetParent(board.playerCardSlots[i].transform);
						selectedCard.transform.localPosition = Vector3.zero;
						selectedCard.placed = true;
						board.playerCardSlots[i].occupied = true;
						break;
					}
				}
			}

			draggingCard = false;

			if(!selectedCard.placed)
			{
				selectedCard.transform.SetParent(transform);
				selectedCard.transform.SetSiblingIndex(selectedCard.previousHandPosition);
			}

			selectedCard.selected = false;
			selectedCard = null;
			selectedCardLastPressed = false;
		}

		if(!draggingCard && selectedCard != null && selectedCard.pressed)
		{
			selectedCard.transform.GetComponent<RectTransform>().sizeDelta = selectedCard.transform.GetComponent<RectTransform>().sizeDelta/3f;
			draggingCard = true;
		}

		if(selectedCard != null && draggingCard)
		{
			selectedCard.transform.position = Input.mousePosition;
			//selectedCard.transform.position = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, transform.position.z);
		}

		if(selectedCard != null)
		{
			selectedCardLastPressed = selectedCard.pressed;
		}
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
