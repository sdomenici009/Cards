using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

	[SerializeField]
	private Image foil;

	public Sprite[] foils;

	[SerializeField]
	private Text costText;
	
	[SerializeField]
	private Text experienceText;
	
	[SerializeField]
	private Text healthText;
	
	[SerializeField]
	private Text damageText;

	private int cost;
	private int experience;
	private int damage;
	private int health;

	bool selected = false;
	
	public Hand hand;
	public Transform selectedCardPanel;

	private int previousHandPosition;

	void Start () {
		foil.sprite = foils[Random.Range(0, foils.Length)];
	}

	public void InitializeCard(int cost, int experiece, int damage, int health)
	{
		this.cost = cost;
		this.experience = experiece;
		this.damage = damage;
		this.health = health;

		costText.text = cost.ToString();
		experienceText.text = experience.ToString();
		healthText.text = health.ToString();
		damageText.text = damage.ToString();
	}
	
	void Update () {
		/*
		if(selected && Input.touches.Length > 0)
		{
			//transform.GetComponent<RectTransform>().sizeDelta = transform.GetComponent<RectTransform>().sizeDelta/2f;
			//transform.position = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, transform.position.z);
		}*/
	}

	public void OnClick()
	{
		if(hand.selectedCard == null)
		{
			if(!selected) 
			{
				previousHandPosition = transform.GetSiblingIndex();
				transform.SetParent(selectedCardPanel);
				transform.GetComponent<RectTransform>().sizeDelta = transform.GetComponent<RectTransform>().sizeDelta*2f;
				transform.localPosition = Vector3.zero;

				hand.selectedCard = this;
				selected = true;
			}
		}
		else
		if(hand.selectedCard == this && selected)
		{
			transform.SetParent(hand.transform);
			transform.SetSiblingIndex(previousHandPosition);

			hand.selectedCard = null;
			selected = false;
		}
	}
}
