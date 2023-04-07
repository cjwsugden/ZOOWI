using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBeacon : MonoBehaviour
{
    [SerializeField]
    private GameObject questBeacon;

    public void disableBeacon()
    {
        questBeacon.SetActive(false);
    }

}
