using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(gameObject, 2, 1).setEaseInOutSine().setLoopPingPong().setRepeat(-1);
    }
    
}

