using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderMaker : MonoBehaviour
{
    [ContextMenu("MakeCollider")]
    public void MakeCollider()
    {
        var line = GetComponent<LineRenderer>();

        //get pos
        var pos = new Vector3[line.positionCount];
        line.GetPositions(pos);

        //create collider
        var edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = pos.Select(p => (Vector2)p).ToArray();

    }
}
