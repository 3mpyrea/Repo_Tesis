using Unity.VisualScripting;
using UnityEngine;

public class RandomDistribution : IDistributionStrategy
{
    private float scale;
    public RandomDistribution(float scale = 0.1f)
    {
        this.scale = scale;
    }
    public Vector3 GetPosition(int index, MeshRenderer surface)
    {
        Bounds bounds = surface.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.center.y;
        return new Vector3(x, y, z);
    }
}

