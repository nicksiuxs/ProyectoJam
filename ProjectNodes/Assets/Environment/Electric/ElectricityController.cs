using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityController : MonoBehaviour
{

    public LayerMask electricLayer;

    public List<ElectricBehaviour> sourceList;
    public List<ElectricBehaviour> nodesList;
    public List<ElectricBehaviour> checkingList;
    public List<ElectricBehaviour> toCheckList;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    void OnValidate()
    {
        // setUp();
    }

    // Update is called once per frame
    void Update()
    {
        checkList();

    }

    private void setUp()
    {
        var electricElements = FindObjectsOfType<ElectricBehaviour>();
        foreach (ElectricBehaviour element in electricElements)
        {
            if (element.alwaysOn)
            {
                sourceList.Add(element);
            }
            else
            {
                nodesList.Add(element);
            }
        }

        toCheckList = new List<ElectricBehaviour>(nodesList);

        checkingList = new List<ElectricBehaviour>(sourceList);
    }

    private void checkList()
    {
        List<ElectricBehaviour> checkingListTemporal = new List<ElectricBehaviour>();
        foreach (ElectricBehaviour element in checkingList)
        {
            Debug.Log("checking: " + element.name);
            Collider2D[] collidedElements = Physics2D.OverlapCircleAll(element.gameObject.transform.position, element.electricFieldRange, electricLayer);

            foreach (Collider2D collider in collidedElements)
            {
                Debug.Log(collider.name);
                ElectricBehaviour electricBehaviour = collider.gameObject.GetComponent<ElectricBehaviour>();
                if (toCheckList.Exists(e => e == electricBehaviour))
                {
                    checkingListTemporal.Add(electricBehaviour);
                    toCheckList.Remove(electricBehaviour);
                }
                electricBehaviour.isOn = true;
            }
        }

        checkingList = checkingListTemporal;
        if (checkingList.Count > 0)
        {
            checkList();
        }
        else
        {
            foreach (ElectricBehaviour electricBehaviour in toCheckList)
            {
                electricBehaviour.isOn = false;
            }

            toCheckList = new List<ElectricBehaviour>(nodesList);

            checkingList = new List<ElectricBehaviour>(sourceList);
        }
    }
}
