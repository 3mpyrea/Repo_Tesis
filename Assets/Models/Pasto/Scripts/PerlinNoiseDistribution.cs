using UnityEngine;

public class PerlinNoiseDistribution : IDistributionStrategy
{
    private float scale;

    public PerlinNoiseDistribution(float scale = 0.1f)
    {
        this.scale = scale;
    }

    public Vector3 GetPosition(int index, MeshRenderer surface)
    {
        Bounds bounds = surface.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        float noise = Mathf.PerlinNoise(x * scale, z * scale);

        if (noise < 0.5f)
            return Vector3.zero;

        float y = bounds.center.y;

        return new Vector3(x, y, z);
    }
}
