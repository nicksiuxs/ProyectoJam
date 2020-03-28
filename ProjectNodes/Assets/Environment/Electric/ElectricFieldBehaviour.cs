using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFieldBehaviour : MonoBehaviour
{
    public int layer;
    public ElectricBehaviour electricObject;

    public List<ElectricBehaviour> sourceElements = new List<ElectricBehaviour>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        activateOther(other);
        // Debug.Log(sourceElements.Count);
        // Debug.Log(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        deactivateObject(other);
    }

    public void addSourceElement(ElectricBehaviour electricBehaviour)
    {
        sourceElements.Add(electricBehaviour);
    }

    private void activateOther(Collider2D other)
    {
        if (other.gameObject.layer == layer)
        {
            ElectricBehaviour electricOther = other.gameObject.transform.parent.GetComponent<ElectricBehaviour>();

            if (electricOther.isOn)
            {
                // if(electricOther.isOn)
                // {
                addSourceElement(electricOther);
                // }
                StartCoroutine(updateObject());
            }
        }
    }

    IEnumerator updateObject()
    {
        yield return new WaitForSeconds(0.01f);
        electricObject.isOn = true;
    }

    private void deactivateObject(Collider2D other)
    {
        List<ElectricBehaviour> sourceElementsTemporal = this.sourceElements;

        if (other.gameObject.layer == layer)
        {
            foreach (ElectricBehaviour element in sourceElementsTemporal)
            {
                Debug.Log((other.gameObject.transform.parent.GetComponent<ElectricBehaviour>().GetInstanceID() == element.GetInstanceID()) + " - " + other.gameObject.transform.parent.GetComponent<ElectricBehaviour>().GetInstanceID());
                if (other.gameObject.transform.parent.GetComponent<ElectricBehaviour>().GetInstanceID() == element.GetInstanceID())
                {
                    Debug.Log(sourceElementsTemporal.Count + " ++");
                    sourceElementsTemporal.Remove(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>());
                    Debug.Log(sourceElementsTemporal.Count + " --");

                    if (sourceElementsTemporal.Count == 0 && !electricObject.alwaysOn)
                    {
                        Debug.Log("---------------------");
                        electricObject.isOn = false;
                    }
                }
            }
            // if(sourceElements.Contains(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>()))
            // {
            // Debug.Log(sourceElements.Contains(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>()) + " --");
            // sourceElements.Remove(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>());

            // }


            this.sourceElements = sourceElementsTemporal;
        }
    }
}
