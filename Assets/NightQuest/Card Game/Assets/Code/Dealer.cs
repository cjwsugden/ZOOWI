﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ZoowiGoFish.Unity {
	
	public class Dealer : MonoBehaviour {
		
		public GameObject cardPrefab;
		public Transform spawnTransform;
		public List<CardHand> hands;
		
		public uint dealCycles = 1;
		public uint cardsPerDeal = 2;
		
		public float delayEachCard = 1F;
		
		private int cardsDealtInitially;
		private int cardsDealt;
		
		private List<CardType> deck = new List<CardType>(); // 0 is the higheset value.
		
		private Action dealCallback;
		
		private GameObject preparedCard;
		
		public int CardsDealtInitially {
			get { return this.cardsDealtInitially; }
		}


		
		
		void Awake() {
			
			List<CardType> cardsUnshuffled = new List<CardType>();
			foreach (CardType ct in Cards.CARDS) {
				cardsUnshuffled.Add(ct);
			}
			
			// Add a random card until they're all gone.
			while (cardsUnshuffled.Count > 0) {
				
				int removed = UnityEngine.Random.Range(0, cardsUnshuffled.Count);
				
				CardType type = cardsUnshuffled[removed];
				cardsUnshuffled.RemoveAt(removed);
				deck.Add(type);
				
			}
			
		}
		
		public void StartDealing(Action callback) {
			
			this.dealCallback = callback;
			
			this.cardsDealtInitially = (int) (this.dealCycles * this.cardsPerDeal * this.hands.Count);
			this.StartCoroutine(this.DealPattern());
			
		}
		
		private IEnumerator DealPattern() {
			
			for (int i = 0; i < this.dealCycles; i++) {
				
				foreach (CardHand ch in this.hands) {
					
					for (int j = 0; j < this.cardsPerDeal; j++) {
						
						GameObject card = this.PrepareCard();
						yield return new WaitForSeconds(this.delayEachCard);
						
						CardController cc = card.GetComponent<CardController>();
						cc.SetCardType(this.DrawCardType());
						ch.AddCard(cc);
						
						this.cardsDealt++;
						this.UpdateScale();
						
						this.preparedCard = null;
						
					}
					
				}
				
			}
			
			this.hands.ForEach(h => h.Simplify());
			
			this.PrepareCard();
			
			this.dealCallback.Invoke();

		}
		
		private void UpdateScale() {
			
			float percentage = ((float) (this.deck.Count)) / ((float) (this.deck.Count + this.cardsDealt));
			this.transform.localScale = new Vector3 (1, percentage, 1);
			
		}
		
		private CardType DrawCardType() {
			
			CardType drawn = this.deck[0];
			this.deck.RemoveAt(0);
			
			// Remove the deck if we are empty.
			if (this.deck.Count <= 0) {
				GameObject.Destroy (this.gameObject);
			}
			
			return drawn;
			
		}
		
		private GameObject PrepareCard() {
			
			if (this.preparedCard == null && this.deck.Count > 0) {
				
				// Spawn and position.
				GameObject card = (GameObject) GameObject.Instantiate(this.cardPrefab);
				card.transform.position = this.spawnTransform.position;
				card.transform.rotation = this.spawnTransform.rotation;
				
				CardController cc = card.GetComponent<CardController>();
				cc.dealer = this;
				
				this.preparedCard = card;
				
			}
			
			return this.preparedCard;
						
		}
		
		public CardController DealOneOff() {
			
			GameObject card = this.PrepareCard();
			
			// Populate.
			CardController cc = card.GetComponent<CardController>();
			cc.SetCardType(this.DrawCardType());
			
			// Cleanup.
			this.cardsDealt++;
			this.UpdateScale();
			this.preparedCard = null;
			
			this.PrepareCard();
			return cc;
			
		}
		
		public void AddCardToBottom(CardController cc) {
			
			CardType type = cc.cardType;
			cc.SetHand(null);
			
			this.deck.Add(type);
			GameObject.Destroy(cc.gameObject);
			
		}
		
	}
	
}
