using System.Collections.Generic;
using UnityEngine;
public class UnitController : MonoBehaviour
{
    private Camera mainCamera;
    private UnitMovement unit;
    private List<GameObject> _units;
    private List<Vector3> _unitsPos;
    public int TypeOfFormation = 0;
    void Start()
    {
        mainCamera = Camera.main;
        unit = GetComponent<UnitMovement>();
        _units = UnitSelections.Instance.unitSelected;
        _unitsPos = new List<Vector3>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _units.Count > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Format(hit.point);
                for (int i = 0; i < _units.Count; i++)
                {
                    _units[i].GetComponent<UnitMovement>().Move(_unitsPos[i]);
                }
            }

        }
    }
    private void Format(Vector3 point)
    {
        if (_unitsPos.Count > 0)
        {
            _unitsPos.Clear();
        }
        if (_units.Count == 1)
        {
            _unitsPos.Add(new Vector3(point.x, 0, point.z));
            return;
        }
        int middle = _units.Count / 2;
        ToCrowd(point);
    }

    private void ToCrowd(Vector3 point)
    {
        int row = _units.Count / 2;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < 2; j++)
            {

                _unitsPos.Add(new Vector3(i * 2 + point.x, 0, j * 2 + point.z));
            }
        }
    }
    private void ToRow()
    {

    }
    private void ToCollumn()
    {

    }
}
