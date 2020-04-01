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
        setUp();
    }

    // Update is called once per frame
    void Update()
    {
        checkList();

    }

    private void setUp()
    {
        sourceList = new List<ElectricBehaviour>();
        nodesList = new List<ElectricBehaviour>();
        checkingList = new List<ElectricBehaviour>();
        toCheckList = new List<ElectricBehaviour>();

        sourceList.Clear();
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
            List<Collider2D> collidedElements = element.getCollidedElements();

            foreach (Collider2D collider in collidedElements)
            {
                ElectricBehaviour electricBehaviour = collider.gameObject.GetComponent<ElectricBehaviour>();
                if (toCheckList.Exists(e => e == electricBehaviour))
                {
                    checkingListTemporal = handleElementsToLists(checkingListTemporal, electricBehaviour);
                }
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
                electricBehaviour.handleDeactivate();
            }

            setUp();
        }
    }

    private List<ElectricBehaviour> handleElementsToLists(List<ElectricBehaviour> checkingListTemporal, ElectricBehaviour electricBehaviour)
    {
        List<ElectricBehaviour> relatedElements = electricBehaviour.handleActivate();

        foreach (ElectricBehaviour relatedElement in relatedElements)
        {
            checkingListTemporal.Add(relatedElement);
            toCheckList.Remove(relatedElement);
        }

        return checkingListTemporal;
    }
}
