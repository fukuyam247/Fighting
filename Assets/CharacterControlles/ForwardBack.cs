using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBack : MonoBehaviour
{
    public void forwardback(CharacterController charaCon,float playerSpeed,Animator Moves)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        charaCon.Move(dir * Time.deltaTime * playerSpeed);
        if(dir.x>0)
        {
            Moves.SetInteger("moveX",1);
        }
        if(dir.x<0)
        {
            Moves.SetInteger("moveX",-1);
        }
    }
}
