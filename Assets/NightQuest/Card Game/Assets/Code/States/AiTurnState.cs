using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ZoowiGoFish.Unity {
	
	public class AiTurnState : GameStateNode {
		
		public float secondsToPick;
		public float secondsToDeliver;
		public float secondsToExit;
		public GameObject loser;

		 void Update()
		 {
			 Cursor.lockState = CursorLockMode.Confined;
		 }
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "<color=red>KIRAN TURN</color>";
			
			this.hand = this.GetComponent<CardHand>();
			Debug.Log(this.hand);
			
			this.StartCoroutine(this.PickPattern());
			
		}
		
		private IEnumerator PickPattern() {
			
			yield return new WaitForSeconds(this.secondsToPick);
			
			CardController picked = this.hand.cards[Random.Range(0, this.hand.cards.Count)];
			CardValue val = picked.cardType.Value;
			List<CardController> opponentMatches = this.opponent.GetCardsOfValue(val);
			
			TurnSelector.INSTANCE.Text = "<i>Got any " + val.name + "s?</i>";
			
			yield return new WaitForSeconds(this.secondsToDeliver);
			
			if (opponentMatches.Count > 0) {
				
				// Take the cards.
				opponentMatches.ForEach(match => {
					
					this.opponent.RemoveCard(match);
					this.hand.AddCard(match);
					
				});
				
			} else {
				
				// Or "go fish".
				CardController fish = this.dealer.DealOneOff();
				this.hand.AddCard(fish);
				
				Debug.Log("AI Fished card: " + fish);
				
			}
			
			yield return new WaitForSeconds(this.secondsToDeliver);
			
			this.hand.Simplify();
			yield return new WaitForSeconds(this.secondsToExit);
			
			// Win!
			if (this.hand.cards.Count == 0) {
				//Application.LoadLevel(this.winSceneName);
				loseScreen();

			}
			
			this.next.Enter(this);
			
		}

		public void loseScreen()
		{
			loser.SetActive(true);
			Time.timeScale = 0f;
		}
		
	}
	
}
