using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFieldBehaviour : MonoBehaviour
{
    // public int layer;
    // public ElectricBehaviour electricObject;

    // public List<ElectricBehaviour> sourceElements = new List<ElectricBehaviour>();
    // public List<ElectricBehaviour> inactiveElements = new List<ElectricBehaviour>();

    // void Update()
    // {
    //     List<ElectricBehaviour> sourceElementsTemporal = new List<ElectricBehaviour>();
    //     foreach (ElectricBehaviour element in sourceElements)
    //     {
    //         if (element.isOn)
    //         {
    //             sourceElementsTemporal.Add(element);
    //         }
    //     }
    //     sourceElements = sourceElementsTemporal;

    //     // foreach (ElectricBehaviour element in inactiveElements)
    //     // {
    //     //     if (element.isOn)
    //     //     {
    //     //         sourceElements.Add(element);
    //     //         inactiveElements.Remove(element);
    //     //         electricObject.isOn = true;
    //     //     }
    //     // }

    //     if (sourceElements.Count == 0 && !electricObject.alwaysOn)
    //     {
    //         electricObject.isOn = false;
    //     }
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.layer == layer)
    //     {
    //         activateObject(other.gameObject);
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     deactivateObject(other);
    // }

    // // void OnTriggerStay2D(Collider2D other)
    // // {
    // //     handleStay(other);
    // // }

    // public void addSourceElement(ElectricBehaviour electricBehaviour)
    // {
    //     sourceElements.Add(electricBehaviour);
    // }

    // public void addInactiveElement(ElectricBehaviour electricBehaviour)
    // {
    //     if (!electricBehaviour.isOn)
    //     {
    //         inactiveElements.Add(electricBehaviour);
    //     }
    // }

    // public void activateObject(GameObject other)
    // {
    //     ElectricBehaviour electricOther = other.transform.parent.GetComponent<ElectricBehaviour>();

    //     if (electricOther.isOn)
    //     {
    //         // if(electricOther.isOn)
    //         // {
    //         addSourceElement(electricOther);
    //         // }
    //         StartCoroutine(updateObject());
    //     }
    //     else
    //     {
    //         addInactiveElement(electricOther);
    //     }

    // }

    // public void activateInactive(GameObject other)
    // {
    //     ElectricBehaviour electricOther = other.transform.parent.GetComponent<ElectricBehaviour>();
    //     addSourceElement(electricOther);
    //     electricObject.isOn = true;
    // }

    // IEnumerator updateObject()
    // {
    //     yield return new WaitForSeconds(0.01f);
    //     electricObject.isOn = true;

    //     foreach(ElectricBehaviour element in inactiveElements)
    //     {
    //         Debug.Log(sourceElements.Count);
    //         element.gameObject.GetComponentInChildren<ElectricFieldBehaviour>().activateInactive(this.gameObject);
    //         Debug.Log(sourceElements.Count);
    //         // inactiveElements.RemoveAll(isElement);
            
    //     }
    //     inactiveElements.Clear();
    // }

    // private static bool isElement(ElectricBehaviour element)
    // {
    //     return true;
    // }

    // private void deactivateObject(Collider2D other)
    // {
    //     List<ElectricBehaviour> sourceElementsTemporal = this.sourceElements;

    //     if (other.gameObject.layer == layer)
    //     {
    //         sourceElementsTemporal.Remove(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>());
    //         inactiveElements.Remove(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>());

    //         this.sourceElements = sourceElementsTemporal;
    //     }
    // }
}
