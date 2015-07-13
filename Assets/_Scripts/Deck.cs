using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

	private List<Card> cards = new List<Card>();

	[SerializeField]
	private Hand hand;

	[SerializeField]
	private GameObject cardPrefab;

	void Start () {
		int testCardInfo = 0;
		for(int i=0; i < 40; i++)
		{
			if(i!=0 && i%4 == 0) testCardInfo++;

			GameObject card = (GameObject)Instantiate(cardPrefab);
			card.transform.SetParent(hand.transform);
			card.transform.localScale = Vector3.one;
			card.SetActive(false);
			card.GetComponent<Card>().InitializeCard(testCardInfo, testCardInfo, testCardInfo, testCardInfo);
			cards.Add(card.GetComponent<Card>());
		}

		Shuffle(25);

		for(int i=0; i < 5; i++)
		{
			Draw();
		}
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			Shuffle(25);
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

	void Draw()
	{
		if(cards.Count > 0)
		{
			hand.AddCard(cards[0]);
			cards[0].gameObject.SetActive(true);
			cards.RemoveAt(0);
		}
	}
	
	public void OnClick()
	{
		Draw();
	}
}
