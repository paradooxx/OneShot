using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CurvingSprite : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private MeshFilter meshFilter;
    private Mesh originalMesh;
    private Vector3[] originalVertices;

    private void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        meshFilter = GetComponent<MeshFilter>();

        if(meshFilter != null)
        {
            originalMesh = meshFilter.mesh;
            originalVertices = originalMesh.vertices;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(polygonCollider != null && meshFilter != null)
        {
            Vector2[] points = polygonCollider.points;
            Vector3[] vertices = originalVertices.Clone() as Vector3[];

            for(int i = 0 ; i < points.Length ; i ++)
            {
                Vector2 deformDirection = (Vector2)collision.relativeVelocity * 0.1f;
                points[i] += deformDirection;
                vertices[i] += (Vector3)deformDirection;
            }

            polygonCollider.points = points;

            Mesh deformingMesh = new Mesh();
            deformingMesh.vertices = vertices;
            deformingMesh.triangles = originalMesh.triangles;
            deformingMesh.uv = originalMesh.uv;
            deformingMesh.RecalculateNormals();
            deformingMesh.RecalculateBounds();

            meshFilter.mesh = deformingMesh;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(polygonCollider != null && meshFilter != null)
        {
            polygonCollider.points = System.Array.ConvertAll(originalVertices, v => (Vector2)v);
            meshFilter.mesh = originalMesh;
        }
    }
}
