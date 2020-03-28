using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;
    // public float electricFieldRange;
    // public LayerMask electricLayer;

    // private List<ElectricBehaviour> sourceElements = new List<ElectricBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checkElectricRange();
        // Debug.Log(electricLayer.value);
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(gameObject.transform.position, electricFieldRange);        
    // }

    // private void checkElectricRange()
    // {
    //     Collider2D[] electricElements = Physics2D.OverlapCircleAll(gameObject.transform.position, electricFieldRange, electricLayer);
    //     List<ElectricBehaviour> sourceElements = new List<ElectricBehaviour>();

    //     foreach(Collider2D element in electricElements)
    //     {
    //         ElectricBehaviour electricElement = element.GetComponent<ElectricBehaviour>();
    //         if(electricElement.isOn)
    //         {
    //             sourceElements.Add(electricElement);
    //             isOn = true;
    //         }            
    //     }

    //     if(sourceElements.Count == 0)
    //     {
    //         isOn = false;
    //     }
    // }
}
