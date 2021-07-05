using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch mTouch = Input.GetTouch(0);
            Debug.Log(mTouch.fingerId);     // Id is always the same for that finger
            Debug.Log(mTouch.position);     // Position is in pixels, instead position in Unity
            Debug.Log(mTouch.deltaPosition);    // desplazamiento (posición comparativa con un dato inicial)
            Debug.Log(mTouch.phase);        // The touch phase refers to the action the finger has taken on the most recent frame update. 
            /*
                https://learn.unity.com/tutorial/touch-input-for-mobile-scripting#
                
                There are 5 possible touch phases:
               
                    Began: a finger has just began touching the screen.
                    Moved: the finger has moved position without breaking contact with the screen since it was last polled.
                    Stationary: the finger has remiained in position without breaking contact with the screen since it was last polled.
                    Ended: the finger is no longer touching the screen.
                    Cancelled: tracking for this touch has been cancelled.
            */

        }
    }
}
