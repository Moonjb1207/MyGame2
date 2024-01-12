using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public Building cube;
    public Building myBoxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitted = Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, LayerMask.GetMask("Ground"));
            
            if(hitted)
            {
                Debug.Log("충돌한 위치 : " + hitInfo.point);

                cube = Instantiate(myBoxPrefab);
                cube.GetComponent<Collider>().enabled = false;
            }
        }
        else if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitted = Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, LayerMask.GetMask("Ground"));

            if (hitted)
            {
                Debug.Log("충돌한 위치 : " + hitInfo.point);

                cube.transform.position = GetGridPoint(hitInfo.point);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Up();
        }

    }

    Vector3 GetPointOnGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitted = Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, LayerMask.GetMask("Ground"));
        if (hitted)
        {
            return GetGridPoint(hitInfo.point);
        }
        return Vector3.zero;
    }

    Vector3 GetGridPoint(Vector3 point)
    {
        float x = Mathf.Round(point.x / 1.5f) * 1.5f;
        float z = Mathf.Round(point.z / 1.5f) * 1.5f;

        return new Vector3(x, 0, z);
    }

    private void Up()
    {
        if (cube == null) return;

        Vector3 point = GetPointOnGround();
        Collider[] cols = Physics.OverlapBox(point, cube.size, Quaternion.identity, LayerMask.GetMask("Obstacle"));

        if(cols.Length > 0)
        {
            Destroy(cube.gameObject);
            return;
        }

        cube.GetComponent<Collider>().enabled = true;
        cube = null;
    }
}
