using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CollectionWin.coinCount += 1;

            this.gameObject.SetActive(false);
        }
    }
}
