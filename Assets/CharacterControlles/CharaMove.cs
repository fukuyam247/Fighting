using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    private CharacterController charaCon;
    private Vector3 PlayerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 0.85f;
    private float gravity = -9.81f;
    public float rotSpeed = 700f;
    // Start is called before the first frame update
    void Start()
    {
      charaCon = gameObject.GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = charaCon.isGrounded;
        if (groundedPlayer & PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        charaCon.Move(dir*Time.deltaTime*playerSpeed);

        if(dir != Vector3.zero)
        {
            Quaternion qua = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,qua,rotSpeed*Time.deltaTime);
        }
        if(Input.GetButtonDown("Jump")&&groundedPlayer)
        {
            PlayerVelocity.y += jumpHeight * -1.0f * gravity;
        }

        PlayerVelocity.y += gravity * Time.deltaTime;
        charaCon.Move(PlayerVelocity * Time.deltaTime);
    }
}
