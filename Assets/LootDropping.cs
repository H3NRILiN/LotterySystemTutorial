using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropping : MonoBehaviour
{
    [SerializeField] float m_Height;
    [SerializeField] float m_RangeXMin, m_RangeXMax;
    [SerializeField] float m_RangeZMin, m_RangeZMax;
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
        var rangeXMin = new Vector3(m_RangeXMin, m_Height, 0) + transform.position;
        var rangeXMax = new Vector3(m_RangeXMax, m_Height, 0) + transform.position;
        var rangeZMin = new Vector3(0, m_Height, m_RangeZMin) + transform.position;
        var rangeZMax = new Vector3(0, m_Height, m_RangeZMax) + transform.position;

        Gizmos.DrawLine(rangeXMin, rangeXMax);
        Gizmos.DrawLine(rangeZMin, rangeZMax);
    }

    public void SpawnObject(GameObject targetObj)
    {
        Vector3 spawnPoint = new Vector3();
        spawnPoint.x = Random.Range(m_RangeXMin, m_RangeXMax);
        spawnPoint.y = m_Height;
        spawnPoint.z = Random.Range(m_RangeZMin, m_RangeZMax);
        spawnPoint += transform.position;
        GameObject obj = Instantiate(targetObj, spawnPoint, Random.rotation);
        MeshCollider collider = obj.AddComponent<MeshCollider>();
        collider.convex = true;
        //collider.sharedMesh = obj.GetComponent<MeshFilter>().sharedMesh;
        obj.AddComponent<Rigidbody>();
    }
}
