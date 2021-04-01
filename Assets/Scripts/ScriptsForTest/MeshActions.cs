using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MeshActions : MonoBehaviour
{
    [SerializeField] private Mesh[] array;
    [SerializeField] private Sprite spriteOnScene;
    void Update()
    {
        gameObject.GetComponent<MeshFilter>().mesh = SpriteToMesh2(spriteOnScene);
    }
    [ContextMenu("SpriteToMesh")]
    private Mesh SpriteToMesh(Sprite sprite)
    {
        Mesh mesh = new Mesh
        {
            //vertices = array.ConvertAll(sprite.vertices, i => (Vector3)i),
            uv = sprite.uv,
            //triangles = array.ConvertAll(sprite.triangles, i => (int)i)
        };

        return mesh;
    }
    private Mesh SpriteToMesh2(Sprite sprite)
    {
        Mesh mesh = new Mesh();
        //mesh.SetVertices(array.ConvertAll(sprite.vertices, i => (Vector3)i).ToList());
        mesh.SetUVs(0, sprite.uv.ToList());
        //
        //mesh.SetTriangles(array.ConvertAll(sprite.triangles, i => (int)i), 0);

        return mesh;
    }
}
