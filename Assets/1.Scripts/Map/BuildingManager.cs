using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public Building myBox;
    public Building myBoxPrefab;
    public LayerMask Block;

    public Material canPlaceMaterial;
    public Material cantPlaceMaterial;

    public bool BuildState;

    // Start is called before the first frame update
    void Start()
    {
        BuildState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Down();
        }
        else if(Input.GetMouseButton(0))
        {
            Drag();
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

    void Up()
    {
        if (myBox == null) return;

        Vector3 point = GetPointOnGround();
        Collider[] cols = Physics.OverlapBox(point, myBox.size, Quaternion.identity, Block);

        if(cols.Length > 0)
        {
            Destroy(myBox.gameObject);
            return;
        }

        myBox.canPlaceIndicator.gameObject.SetActive(false);
        myBox.GetComponentInChildren<Collider>().enabled = true;
        myBox = null;
    }

    void Drag()
    {
        if (myBox == null) return;

        Vector3 point = GetPointOnGround();

        myBox.transform.position = point;

        CheckCanPlace(point);
    }

    void Down()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        myBox = Instantiate(myBoxPrefab);

        myBox.GetComponentInChildren<Collider>().enabled = false;
        myBox.canPlaceIndicator.gameObject.SetActive(true);

        Vector3 point = GetPointOnGround();
        myBox.transform.position = point;

        CheckCanPlace(point);
    }

    void CheckCanPlace(Vector3 point)
    {
        Collider[] cols = Physics.OverlapBox(point, myBox.size, Quaternion.identity, Block);

        if (cols.Length > 0)
        {
            myBox.canPlaceIndicator.material = cantPlaceMaterial;
        }
        else
        {
            myBox.canPlaceIndicator.material = canPlaceMaterial;
        }
    }

    public void ChangeBuildState()
    {
        if(BuildState)
        {
            BuildState = !BuildState;

            Camera.main.transform.SetParent(Player.Instance.transform);

            Player.Instance.trueJoystick();
            Player.Instance.gameObject.SetActive(true);
            Time.timeScale = 1.0f;

            gameObject.SetActive(false);
        }
        else
        {
            BuildState = !BuildState;

            Camera.main.transform.SetParent(null);

            Player.Instance.falseJoystick();
            Player.Instance.gameObject.SetActive(false);
            Time.timeScale = 0.0f;

            gameObject.SetActive(true);
        }
    }
}