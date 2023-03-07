using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    void Start()
    {
        iTween.PunchRotation(gameObject, iTween.Hash(
            "looptype", iTween.LoopType.loop,
            "amount", new Vector3(transform.localScale.x * 1.6f, transform.localScale.y * 1.6f, transform.localScale.z * 1.6f)
        ));
    }
}
