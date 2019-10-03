using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropping : MonoBehaviour
{
    [SerializeField] Transform m_TargetTransform;
    [SerializeField] float m_Height;
    [SerializeField] float m_RangeXMin, m_RangeXMax;
    [SerializeField] float m_RangeZMin, m_RangeZMax;
    [SerializeField] PhysicMaterial m_PhysicMat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        var rangeXMin = new Vector3(m_RangeXMin, m_Height, 0) + m_TargetTransform.position;
        var rangeXMax = new Vector3(m_RangeXMax, m_Height, 0) + m_TargetTransform.position;
        var rangeZMin = new Vector3(0, m_Height, m_RangeZMin) + m_TargetTransform.position;
        var rangeZMax = new Vector3(0, m_Height, m_RangeZMax) + m_TargetTransform.position;

        Gizmos.DrawLine(rangeXMin, rangeXMax);
        Gizmos.DrawLine(rangeZMin, rangeZMax);
    }

    public void SpawnObject(GameObject targetObj)
    {
        Vector3 spawnPoint = new Vector3();
        spawnPoint.x = Random.Range(m_RangeXMin, m_RangeXMax);
        spawnPoint.y = m_Height;
        spawnPoint.z = Random.Range(m_RangeZMin, m_RangeZMax);
        spawnPoint += m_TargetTransform.position;
        GameObject obj = Instantiate(targetObj, spawnPoint, Random.rotation, transform);
        MeshCollider collider = obj.AddComponent<MeshCollider>();
        collider.convex = true;
        collider.sharedMaterial = m_PhysicMat;

        obj.AddComponent<Rigidbody>().mass = 13;
    }
}
