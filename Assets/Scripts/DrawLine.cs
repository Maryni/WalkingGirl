using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private bool isMousePressed;
    [SerializeField] private List<Vector3> pointsList;
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Camera cam;
    [SerializeField] private PathScript pathScript;
    [SerializeField] private MeshCollider meshColliderR;
    [SerializeField] private MeshCollider meshColliderL;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform point;


    // Structure for line points
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };
    //    -----------------------------------    
    void Awake()
    {
        // Create line renderer component and set its property
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.SetVertexCount(0);
        line.SetWidth(0.05f, 0.05f);
        line.SetColors(Color.green, Color.green);
        line.useWorldSpace = false;
        line.sortingOrder = 1;
        isMousePressed = false;
        pointsList = new List<Vector3>();


    }
    //    -----------------------------------    

    private void MakeMeshCollider()
    {

    }
    void Update()
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos.z = 1.5f;
        mousePos = new Vector3(mousePos.x - 0.48f, mousePos.y - 0.83f, mousePos.z);
        // If mouse button down, remove old line and set its color to green
        if (Input.GetMouseButtonDown(0))
        {

            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(Color.green, Color.green);
            print("LMB pressed, isMousePressed = " + isMousePressed);





        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            //pathScript.line = line;

            //pathScript.MakePath(line);
            line.BakeMesh(mesh,cam,true);

            Mesh mem1 = meshColliderR.sharedMesh;
            meshColliderR.sharedMesh = mem1;
            Mesh mem2 = meshColliderL.sharedMesh;
            meshColliderL.sharedMesh = mem2;

            navMeshAgent.destination = point.position;
            //pathScript.MakeMeshCollider();
        }

        // Drawing line when mouse is moving(presses)

        if (isMousePressed)
        {
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
            }
        }
    }
    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
}
