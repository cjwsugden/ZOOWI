using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ZoowiGoFish.Unity {
	
	[RequireComponent(typeof(CardHand))]
	public class PlayerTurnState : GameStateNode {
		
		public float secondsToDeliver;
		public float secondsToFishing;
		public float secondsToExit;
		public GameObject warning;
		public GameObject info;
		public GameObject winner;
		
		private CardController picked;

		void Update()
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "<color=blue>YOUR TURN</color>";
			
			this.hand = this.GetComponent<CardHand>();
			Debug.Log(this.hand);
			
			this.hand.cardClickCallback = (CardController cc) => {
				
				Debug.Log("Click called back to " + cc + "!");
				this.hand.cardClickCallback = null;
				
				this.picked = cc;
				this.StartCoroutine(this.DrawPattern());
				
			};
			
		}
		
		private IEnumerator DrawPattern() {
			
			CardValue val = this.picked.cardType.Value;
			List<CardController> opponentMatches = this.opponent.GetCardsOfValue(val);
			
			if (opponentMatches.Count > 0) {
				
				TurnSelector.INSTANCE.Text = "You: Any " + val.name + "s? <i>\nKiran: Yea, " + opponentMatches.Count + ".</i>";
				
				// Take the cards.
				opponentMatches.ForEach(match => {
					
					this.opponent.RemoveCard(match);
					this.hand.AddCard(match);
					
				});
				
			} else {
				
				TurnSelector.INSTANCE.Text = "You: Any " + val.name + "s? <i>\nKiran: Nah, go fish</i>";
				
				// Or "go fish".
				yield return new WaitForSeconds(this.secondsToFishing);
				CardController fish = this.dealer.DealOneOff();
				this.hand.AddCard(fish);
				
				Debug.Log("Player fished card: " + fish);
				
			}
			
			yield return new WaitForSeconds(this.secondsToDeliver);
			
			this.hand.Simplify();
			yield return new WaitForSeconds(this.secondsToExit);
			
			// Win!
			if (this.hand.cards.Count == 0) {
				//Application.LoadLevel(this.winSceneName);
				winScreen();
			}
			
			this.next.Enter(this);
			
		}

		public void ReturnToCampus()
		{
			SceneManager.LoadScene(9);
        	Cursor.lockState = CursorLockMode.Locked;
		}

		public void removeWarning()
		{
			warning.SetActive(false);
			Time.timeScale = 1f;
		}

		public void addWarning()
		{
			warning.SetActive(true);
			Time.timeScale = 0f;
		}

		public void removeInfo()
		{
			info.SetActive(false);
			Time.timeScale = 1f;
		}

		public void reloadScene()
		{
			SceneManager.LoadScene(11);
		}

		public void winScreen()
		{
			winner.SetActive(true);
			Time.timeScale = 0f;
		}

		
		
	}
	
}
