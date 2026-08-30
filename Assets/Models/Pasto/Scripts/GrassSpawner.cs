using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private Mesh grassMesh;
    [SerializeField] private Material grassMaterial;
    [SerializeField] private int grassCount = 40000;
    [SerializeField] private LayerMask surfaceMask;
    [SerializeField] private MeshRenderer surfaceMesh;
    [SerializeField] private LayerMask exclusionMask;
    [SerializeField] private float exclusionCheckRadius = 0.5f;

    private IDistributionStrategy distributionStrategy;
    private List<Matrix4x4[]> batches = new List<Matrix4x4[]>();

    private void Start()
    {
        distributionStrategy = new RandomDistribution(0.05f);
        CalculateGrassPositions();
    }

    private void CalculateGrassPositions()
    {
        List<Matrix4x4> currentBatch = new List<Matrix4x4>();

        for (int i = 0; i < grassCount; i++)
        {
            Vector3 pos = distributionStrategy.GetPosition(i, surfaceMesh);

            if (pos == Vector3.zero) continue;

            if (Physics.Raycast(new Vector3(pos.x, pos.y + 10f, pos.z), Vector3.down, out RaycastHit hit, 20f, surfaceMask))
            {

                if (Physics.CheckSphere(hit.point, exclusionCheckRadius, exclusionMask))
                {
                    continue; 
                }

                Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                Vector3 randomScale = Vector3.one * Random.Range(0.8f, 1.2f); 
                Matrix4x4 matrix = Matrix4x4.TRS(hit.point, randomRotation, randomScale);
                
                currentBatch.Add(matrix);

                if (currentBatch.Count == 1023)
                {
                    batches.Add(currentBatch.ToArray());
                    currentBatch.Clear();
                }
            }
        }

        if (currentBatch.Count > 0)
        {
            batches.Add(currentBatch.ToArray());
        }
    }

    private void Update()
    {
        foreach (var batch in batches)
        {
            Graphics.DrawMeshInstanced(grassMesh, 0, grassMaterial, batch);
        }
    }
}