using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderContainer : MonoBehaviour
{

    public List<Collider> destructibles = new List<Collider>();
    public List<Collider> GetColliders() { return destructibles; }

    private void OnTriggerEnter(Collider other)
    {
        if (!destructibles.Contains(other)) { destructibles.Add(other); }
    }

    private void OnTriggerExit(Collider other)
    {
        destructibles.Remove(other);
    }

}
