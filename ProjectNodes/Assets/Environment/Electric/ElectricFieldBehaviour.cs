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

    void OnTriggerStay2D(Collider2D other)
    {
        handleStay(other);
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
            sourceElementsTemporal.Remove(other.gameObject.transform.parent.GetComponent<ElectricBehaviour>());

            if (sourceElementsTemporal.Count == 0 && !electricObject.alwaysOn)
            {
                electricObject.isOn = false;
            }

            this.sourceElements = sourceElementsTemporal;
        }
    }

    private void handleStay(Collider2D other)
    {

    }
}
