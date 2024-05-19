using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class SpriteToMesh : MonoBehaviour
{
    public Sprite sprite;  // Assign this in the Inspector

    void Start()
    {
        if (sprite != null)
        {
            CreateMeshFromSprite(sprite);
        }
    }

    void CreateMeshFromSprite(Sprite sprite)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        Vector2[] spriteVertices = sprite.vertices;
        ushort[] spriteTriangles = sprite.triangles;
        Vector2[] spriteUV = sprite.uv;

        Vector3[] vertices = new Vector3[spriteVertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = spriteVertices[i];
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = System.Array.ConvertAll(spriteTriangles, i => (int)i);
        mesh.uv = spriteUV;

        meshFilter.mesh = mesh;

        // Update PolygonCollider2D points to match the sprite vertices
        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.points = System.Array.ConvertAll(vertices, v => (Vector2)v);
    }
}
