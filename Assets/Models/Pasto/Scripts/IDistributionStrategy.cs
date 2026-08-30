using UnityEngine;

public interface IDistributionStrategy
{
    Vector3 GetPosition(int index, MeshRenderer surface);
}
