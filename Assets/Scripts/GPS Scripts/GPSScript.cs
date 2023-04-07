using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GPSScript : MonoBehaviour
{
    //public Text GPSStatus;
    //public Text lat;
    //public Text lon;
    public Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(GPSLoc());
    }



    IEnumerator GPSLoc()
    {
        while(true){
            if (!Input.location.isEnabledByUser)
                yield break;

            Input.location.Start();

            int maxWait = 20;

            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
            yield return new WaitForSeconds(1);
                maxWait--;            
            }
            
            if(maxWait < 1)
            {
                //GPSStatus.text = "Time out";
                yield break;
            }

            if(Input.location.status == LocationServiceStatus.Failed)
            {
                //GPSStatus.text = "Unable";
                yield break;
            }
            else{
               // GPSStatus.text = "Running";
                InvokeRepeating("UpdateGPSData", 0.5f, 1f);
            }
        }

    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            //GPSStatus.text = "Running";
            //lat.text = Input.location.lastData.latitude.ToString();
            //lon.text = Input.location.lastData.longitude.ToString();
            _rigidbody.position = new Vector3((((Input.location.lastData.longitude+61)*100000f) + 39924), 5.9f, (((Input.location.lastData.latitude-10)*100000f) - 63923));
        }
        else{
            //GPSStatus.text = "Stop";
        }
    }

}
