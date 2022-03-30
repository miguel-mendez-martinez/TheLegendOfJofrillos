using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Este metodo se activa cuando alguien entra por primera vez al collider asociado, se ejecutará un codigo para cambiar las coordenadas maximas de la camara y mover al personaje un poco para que entre a la habitacion
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //primero tenemos que mirar que quien colisione es solo el personje, utilizaremos las tags

        if (collision.CompareTag("Player"))
        {
            cam.minLimits += cameraChange;
            cam.maxLimits += cameraChange;
            collision.transform.position += playerChange;
        }
    }
}
