using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSystem : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTip;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            GameObject bull = (GameObject) Instantiate(bullet, bulletTip.position, bulletTip.rotation);
        }
    }
}
