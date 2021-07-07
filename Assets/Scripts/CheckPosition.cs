
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public Vector2 position;
    private void Awake()
    {
        position = this.gameObject.transform.position;
        print("POSITION " + position);
    }
}
