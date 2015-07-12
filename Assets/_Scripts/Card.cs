using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

	bool selected = false;

	public Transform hand;
	public Transform selectedCardPanel;

	public Sprite[] foils;

	[SerializeField]
	private Image foil;
	
	void Start () {
		for(int i=0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<Text>() != null)
				transform.GetChild(i).GetComponent<Text>().text = Random.Range(0, 9).ToString();
		}

		foil.sprite = foils[Random.Range(0, foils.Length)];
	}
	
	void Update () {

		if(selected && Input.touches.Length > 0)
		{
			transform.localScale = Vector3.one;
			transform.position = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, transform.position.z);
		}

		if(selected && Input.touches.Length == 0)
		{
			transform.SetParent(selectedCardPanel);
			transform.localScale = Vector3.one*2f;
			transform.localPosition = Vector3.zero;
		}

		if(!selected)
		{
			transform.SetParent(hand);
			transform.localScale = Vector3.one;
		}
	}

	public void OnClick()
	{
		selected = !selected;
	}
}
