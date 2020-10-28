using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[Header("Position Value")]
    //public Transform target;
    //public float smooth;
    //public Vector2 maxPosition;
    //public Vector2 minPosition;

    [Header("Initial Value")]
    public Vector2 camMax;
    public Vector2 camMin;


    public static CameraController instance;
    public AddRoom room;
    public float moveSpeed;

    [SerializeField]public Vector2 batasKiri;
    [SerializeField]public Vector2 batasKanan;

    void Start()
    {
        instance = this;
        batasKanan = camMax;
        batasKiri = camMin;
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    void Update()
    {
        if (room != null)
        {
            float posX = Mathf.Clamp(this.transform.position.x, batasKiri.x, batasKanan.x);
            float posY = Mathf.Clamp(this.transform.position.y, batasKiri.y, batasKanan.y);

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

    //private void LateUpdate()
    //{
    //    if (transform.position != target.position)
    //    {
    //        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
    //        targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
    //        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
    //        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
    //    }
    //}

    public void setBatas(Vector2 _batasKiri, Vector2 _batasKanan)
    {
        batasKiri = _batasKiri - new Vector2(4,4);
        batasKanan = _batasKanan + new Vector2(4,4);
    }

    //public void MoveCamera()
    //{
    //    if (room == null)
    //    {
    //        return;
    //    }

    //    Vector3 targetPos = GetCamPos();

    //    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    //}

    //public Vector3 GetCamPos()
    //{
    //    if (room == null)
    //    {
    //        return Vector3.zero;
    //    }

    //    Vector3 targetPos = room.getRoomPos();

    //    targetPos.z = transform.position.z;

    //    return targetPos;
    //}
}
