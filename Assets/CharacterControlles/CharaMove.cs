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

        //�d�͏���
        PlayerVelocity.y += gravity * Time.deltaTime;
        if (groundedPlayer & PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }
        //�d�͏���


        //�ړ�����
        ForwardBack MoveX = GetComponent<ForwardBack>();
        MoveX.forwardback(charaCon, playerSpeed);
        //�ړ�����


        //�W�����v����
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            PlayerVelocity.y += jumpHeight * -0.25f * gravity;
        }
        //�W�����v����


        //�U���������
        if (groundedPlayer)
        {
            LookAtTarget MoveZ = GetComponent<LookAtTarget>();
            MoveZ.lookattarget(_self, _target);
        }
        //�U���������


        //�ŏI�ړ�����
        charaCon.Move(PlayerVelocity * Time.deltaTime);
        //�ŏI�ړ�����


    }

}
