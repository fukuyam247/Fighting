using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    private CharacterController charaCon;
    private Vector3 PlayerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 0.1f;
    public float gravity = -121f;
    public float rotSpeed = 700f;


    public Transform _self;
    public Transform _target;


    void Start()
    {
      charaCon = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = charaCon.isGrounded;

        //重力処理
        PlayerVelocity.y += gravity * Time.deltaTime;
        if (groundedPlayer & PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }
        //重力処理


        //移動処理
        ForwardBack MoveX = GetComponent<ForwardBack>();
        MoveX.forwardback(charaCon, playerSpeed);
        //移動処理


        //ジャンプ処理
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            PlayerVelocity.y += jumpHeight * -0.25f * gravity;
        }
        //ジャンプ処理


        //振り向き処理
        if (groundedPlayer)
        {
            LookAtTarget MoveZ = GetComponent<LookAtTarget>();
            MoveZ.lookattarget(_self, _target);
        }
        //振り向き処理


        //最終移動処理
        charaCon.Move(PlayerVelocity * Time.deltaTime);
        //最終移動処理


    }

}
