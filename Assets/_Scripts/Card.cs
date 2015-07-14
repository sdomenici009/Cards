using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

	public bool placed = false;

	public bool selected = false;
	
	public Hand hand;
	public Transform selectedCardPanel;
	public bool pressed = false;

	public int previousHandPosition;

	private RectTransform rectTranform;

	public bool selectabled = true;

	void Start () {
		rectTranform = transform.GetComponent<RectTransform>();
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
		damageText.text = damage.ToString();
		healthText.text = health.ToString();
	}

	public void OnTouchDown()
	{
		if(selectabled && !placed)
		{
			if(hand.selectedCard == null)
			{
				if(!selected) 
				{	
					previousHandPosition = transform.GetSiblingIndex();
					transform.SetParent(selectedCardPanel);
					rectTranform.sizeDelta = rectTranform.sizeDelta*3f;
					transform.localPosition = Vector3.zero;
					
					hand.selectedCard = this;
					selected = true;
				}
			}
			else if(hand.selectedCard == this && selected)
			{
				pressed = true;
			}
		}
	}

	public void OnTouchUp()
	{
		if(pressed)
		{
			pressed = false;
		}
	}
}
