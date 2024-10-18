using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    // 自身のTransform
    [SerializeField] private Transform _self;
    
    // ターゲットのTransform
    [SerializeField] private Transform _target;

    private void Update()
    {
        // ターゲットの方向に自身を回転させる
        //_self.LookAt(_target);

        // Transform型を渡す方法
        _self.transform.LookAt(_target.transform);

        // Vector3型を渡す方法
        _self.transform.LookAt(_target.transform.position);

        Vector3 targetPos = _target.transform.position;
        // ターゲットのY座標を自分と同じにすることで2次元に制限する。
        targetPos.y = _self.transform.position.y;
        if(CharaMove.instance.groundedPlayer){
        _self.transform.LookAt(targetPos);
        }
    }
}
