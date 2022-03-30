using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform movementTarget;
    public float smoothing;
    public Vector2 maxLimits;
    public Vector2 minLimits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// this method is called at the last part of an update per frame, it will move the camera towards the character 
    /// </summary>
    void LateUpdate()
    {
        //si la camara no esta con el personaje, se mueve
        if(transform.position != movementTarget.position)
        {
            //creamos una variable que almacena los nuevos x e y pero que conserva la z de la camara
            Vector3 targetPosition = new Vector3(movementTarget.position.x, movementTarget.position.y, transform.position.z);

            //ahora usaremos Math.clamp para mantener la camara donde queramos
            targetPosition.x = Mathf.Clamp(targetPosition.x, minLimits.x, maxLimits.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minLimits.y, maxLimits.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
