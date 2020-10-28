using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVMesh : MonoBehaviour
{
    [SerializeField] FOV fov;
    Mesh mesh;
    RaycastHit2D hit;
    [SerializeField] float meshRes;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public int[] triangles;
    [HideInInspector] public int stepCount;

    [SerializeField] public static bool isPlayer;



    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isPlayer) MakeMesh();
    }

    void MakeMesh()
    {
        stepCount = Mathf.RoundToInt(fov.getViewAngle() * meshRes);
        float stepAngle = fov.getViewAngle() - stepCount;

        List<Vector3> viewVertex = new List<Vector3>();

        hit = new RaycastHit2D();

        for (int i = 0; i < stepCount; i++)
        {
            float angle = fov.transform.eulerAngles.y - fov.getViewAngle() / 2 + stepAngle * i;
            Vector3 dir = fov.dirFromAngle(angle, false);
            hit = Physics2D.Raycast(fov.transform.position, dir, fov.getViewRadius(), fov.obstcaleMask);

            if (hit.collider == null)
            {
                viewVertex.Add(transform.position + dir.normalized * fov.getViewRadius());
            }
            else
            {
                viewVertex.Add(transform.position + dir.normalized * hit.distance);
            }
        }

        int vertexCount = viewVertex.Count + 1;

        vertices = new Vector3[vertexCount];
        triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;

        for (int i = 0; i < vertexCount-1; i++)
        {
            vertices[i+1] = transform.InverseTransformPoint(viewVertex[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3 + 2] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3] = i + 2;
            }      
        }

        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }

}
