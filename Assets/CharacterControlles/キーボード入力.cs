using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class キーボード入力 : MonoBehaviour
{

    private CharacterController charaCon;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jumpHeight = 0.85f;
    private float gravity = -9.81f;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        charaCon = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = charaCon.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) //接地しているかつ、プレイヤーのY方向がマイナスなら（下向きなら）
        {
            playerVelocity.y = 0f;  //速度を0にして落下を止める
        }

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charaCon.Move(dir * Time.deltaTime * playerSpeed);

        if (dir != Vector3.zero)
        {
            Quaternion qua = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qua, rotSpeed * Time.deltaTime);
        }
    }
}
