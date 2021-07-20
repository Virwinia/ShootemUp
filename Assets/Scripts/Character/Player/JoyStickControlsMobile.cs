using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickControlsMobile : MonoBehaviour, IDragHandler, IEndDragHandler {

    public Canvas canvasParent; //

    public float ratio;
    Vector3 initialPos;

    Vector2 Axis;

    public float horizontal;
    public float vertical;
         

    public bool isMoving  //Propiedad booleana que indica si el Vector2 Axis es 0.
    {
        get
        {
            return Axis != Vector2.zero;
        }
    }

    private void Start()
    {
        initialPos = transform.position;
    }    
    
    void Update()
    {
        horizontal = Axis.x;
        vertical = Axis.y;
    }

    public void OnDrag(PointerEventData eventData)                                
    {       
        Vector2 pos;                                                              //Transforma un punto de la pantalla (en píxeles) en un punto del recttransform del canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasParent.transform as RectTransform, eventData.position, canvasParent.worldCamera, out pos);        
        Vector2 newPos = canvasParent.transform.TransformPoint(pos) - initialPos; //Vector2 que recoge el dato de la resta de la salida pos anterior y el vector inicial
        newPos.x = Mathf.Clamp(newPos.x, -ratio, ratio);                          //Limitamos el valor de x entre ratio positivo y negativo.
        newPos.y = Mathf.Clamp(newPos.y, -ratio, ratio);

        Axis = newPos / ratio;                                                    //El eje es igual al Vector2 newPos/ratio, para mover por porcentaje, x/x == 1 si estamos en límite
        transform.localPosition = newPos;                                         //Muevo el joystick
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPos;
        Axis = Vector2.zero;
    }   
}
