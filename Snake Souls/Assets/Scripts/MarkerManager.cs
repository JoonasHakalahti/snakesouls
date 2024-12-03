using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    public List<Marker> markerList = new List<Marker>();

    [SerializeField] private float markerInterval = 0.05f; 
    private float markerTimer = 0f;

    void FixedUpdate()
    {
        markerTimer += Time.fixedDeltaTime;
        if (markerTimer >= markerInterval)
        {
            UpdateMarkerList();
            markerTimer = 0f;
        }
    }

    public void UpdateMarkerList()
    {
        markerList.Add(new Marker(transform.position, transform.rotation));
        if (markerList.Count > 50)
        {
            markerList.RemoveAt(0);
        }
    }

    public void ClearMarkerList()
    {
        markerList.Clear();
    }
}
