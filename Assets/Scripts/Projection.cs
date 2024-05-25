using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Projection : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int maxPhysicsFrameIteration = 100;
    [SerializeField] private Transform obstacleParent;
    private Scene simulationScene;
    private PhysicsScene2D physicsScene;
    private readonly Dictionary<Transform, Transform> spawnedObjects = new Dictionary<Transform, Transform>();

    private void Start()
    {
        CreatePhysicsScene();
    }

    private void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        physicsScene = simulationScene.GetPhysicsScene2D();
        foreach(Transform obj in obstacleParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            //ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
            if(!gameObject.isStatic)
                spawnedObjects.Add(obj, ghostObj.transform);
        }
    }

    private void Update()
    {
        foreach(var item in spawnedObjects)
        {
            item.Value.position = item.Key.position;
            item.Value.rotation = item.Key.rotation;
        }
    }

    public void SimulateTrajectory(Bullet bulletPrefab, Vector2 pos, Vector2 velocity) 
    {
        var ghostObj = Instantiate(bulletPrefab, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, simulationScene);

        ghostObj.Launch(velocity);

        lineRenderer.positionCount = maxPhysicsFrameIteration;

        for (var i = 0; i < maxPhysicsFrameIteration; i++) {
            physicsScene.Simulate(Time.fixedDeltaTime);
            lineRenderer.SetPosition(i, ghostObj.transform.position);
        }

        Destroy(ghostObj.gameObject);
    }
}