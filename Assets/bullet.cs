using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        rigidbody.velocity = this.transform.right * speed * Time.fixedDeltaTime; 
    }
}
