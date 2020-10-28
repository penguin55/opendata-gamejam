using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    private Vector2 mouseposition;
    [SerializeField] private Vector2 batas;
    public SpriteRenderer sprite;
    float direction;
    private float offsetcamx, offsetcamy;
    Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        direction = mouseposition.x - this.transform.position.x;
        if (direction > 0)
        {
            sprite.flipX = false;
        }
        if(direction < 0)
        {
            sprite.flipX = true;
        }
        if (leveldone.stop) {
            movementcrosshair();
        }
        
    }

    void movementcrosshair()
    {
        mouseposition = camera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mouseposition;
        

        transform.localPosition = new Vector2(Mathf.Clamp(transform.localPosition.x, -batas.x, batas.x), 
            Mathf.Clamp(transform.localPosition.y, -batas.y, batas.y));

        offsetcamx = 0; offsetcamy = 0;
        
        offsetcamx = transform.localPosition.x / batas.x;
        offsetcamy = transform.localPosition.y / batas.y;

        camera.transform.localPosition = new Vector3(offsetcamx * 1.24f, offsetcamy*0.85f, -10);

        //Vector2 batasCamKanan = CameraController.instance.batasKanan;
        //Vector2 batasCamKiri = CameraController.instance.batasKiri;

        //float posX = Mathf.Clamp(this.transform.position.x, batasCamKiri.x, batasCamKanan.x);
        //float posY = Mathf.Clamp(this.transform.position.y, batasCamKiri.y, batasCamKanan.y);
        //camera.transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
