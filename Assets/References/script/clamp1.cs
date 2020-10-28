using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clamp : MonoBehaviour
{
    //bikin object kiri atas , kanan bawah untuk batas
    public GameObject kiriatas;
    public GameObject kananbawah;
    float minX, maxX, minY, maxY;
    float posisilamaX, posisilamaY;
    float posisibaruX, posisibaruY;
    private void Start()
    {
        minX = kiriatas.transform.position.x;
        maxX = kananbawah.transform.position.x;

        maxY = kiriatas.transform.position.y;
        minY = kananbawah.transform.position.y;
    }
    void Update()
    {
        posisilamaX = this.transform.position.x;

        posisibaruX = Mathf.Clamp(posisilamaX, minX, maxX);

        posisilamaY = this.transform.position.y;

        posisibaruY = Mathf.Clamp(posisilamaY, minY, maxY);
        this.transform.position = new Vector3(posisibaruX, posisibaruY, 0f);
    }
}
