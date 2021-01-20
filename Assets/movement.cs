using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 inputs;
    public rope rope;
    private Rigidbody2D rigidbody;
    public float speed;
    public float slowTime;
    public float jumpForce;
    public float gravity;
    [SerializeField]private bool isGrounded;
    private bool slowMo;
    private bool controlledMovment;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        inputs = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if(rope.enabled){
            controlledMovment = false;
        }else if(!rope.enabled){
            controlledMovment = true;
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            rigidbody.velocity = this.transform.right  * slowTime * Time.fixedDeltaTime;
            slowMo = true;
            controlledMovment = false;
        }// slow motion
        if(Input.GetKeyUp(KeyCode.LeftControl) && inputs.magnitude > 0){
            slowMo = false;
            controlledMovment = true;
        }
        if(inputs.magnitude > 0){
            controlledMovment = true;
           if(isGrounded){
               rigidbody.velocity = new Vector2(inputs.x,0) * speed * Time.fixedDeltaTime;
           }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            rigidbody.AddForce(new Vector2(inputs.x, jumpForce),ForceMode2D.Impulse);
        }
       if(inputs.magnitude <= 0){
           controlledMovment = false;
       }
       if(!controlledMovment && !rope.enabled){
           if(isGrounded){
               rigidbody.velocity = new Vector2(1,0) * speed * Time.fixedDeltaTime;
           }else{
               rigidbody.velocity = new Vector2(1,-0.3f) * speed * Time.fixedDeltaTime;
           }
       }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        isGrounded = true;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        isGrounded = false;
    }
}
