using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public enum Owner { Player, Opponent };

	private Deck playerDeck;
	private Deck opponentDeck;

	[SerializeField]
	private Hand playerHand;

	[SerializeField]
	private Hand opponentHand;

	[SerializeField]
	private GameObject playerCardPrefab;

	[SerializeField]
	private GameObject opponentCardPrefab;

	[SerializeField]
	private int drawCount;

	[SerializeField]
	private float drawDelay;

	private enum GameState { Mulligan, PlayerStart, PlayerAction, PlayerEnd, OpponentStart, OpponentAction, OpponentEnd };
	private GameState currentState = GameState.Mulligan;

	public void Start()
	{
		OnGameStart();

		if(Random.Range(0, 2) == 0) currentState = GameState.PlayerStart;
		else currentState = GameState.OpponentStart;
	}

	public void Update()
	{
		switch ( currentState )
		{
			case GameState.Mulligan : break;

			case GameState.PlayerStart : playerDeck.Draw(); currentState = GameState.PlayerAction; break;
			case GameState.PlayerAction : break;
			case GameState.PlayerEnd : currentState = GameState.OpponentStart; break;

			case GameState.OpponentStart : opponentDeck.Draw(); currentState = GameState.OpponentAction; break;
			case GameState.OpponentAction : break;
			case GameState.OpponentEnd : currentState = GameState.PlayerStart; break;

			default : break;
		}
	}

	private void OnGameStart()
	{
		playerDeck = new Deck(Owner.Player, playerHand, playerCardPrefab);
		opponentDeck = new Deck(Owner.Opponent, opponentHand, opponentCardPrefab);

		StartCoroutine(InitialDraw(playerDeck));
		StartCoroutine(InitialDraw(opponentDeck));
	}

	private IEnumerator InitialDraw(Deck deck)
	{
		for(int i=0; i < drawCount; i ++)
		{
			deck.Draw();
			yield return new WaitForSeconds(drawDelay);
		}
	}
}
