using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

   // private void Update()
   public void lookattarget(Transform _self,Transform _target)
    {
        // Vector3型を渡す方法
       _self.transform.LookAt(_target.transform.position);

       Vector3 targetPos = _target.transform.position;
       //ターゲットのY座標を自分と同じにすることで2次元に制限する。
       targetPos.y = _self.transform.position.y;
       _self.transform.LookAt(targetPos);
    }
}