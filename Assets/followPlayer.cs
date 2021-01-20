using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float offsetX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = position;
    }
}
