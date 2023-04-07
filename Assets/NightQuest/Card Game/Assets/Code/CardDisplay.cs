using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ZoowiGoFish.Unity {
	
	public class CardDisplay : MonoBehaviour {
		
		private Text suit;
		private Text value;
		private Text number;
		
		void Awake() {
			
			this.suit = this.transform.Find("Suit").GetComponent<Text>();
			this.value = this.transform.Find("Value").GetComponent<Text>();
			this.number = this.transform.Find("Number").GetComponent<Text>();
			
		}
		
		public void UpdateDisplay(CardType type) {
			
			this.suit.text = type.Suit.name;
			this.value.text = type.Value.name;
			this.number.text = char.ToString(type.Value.icon);
			
		}
		
	}
	
}
