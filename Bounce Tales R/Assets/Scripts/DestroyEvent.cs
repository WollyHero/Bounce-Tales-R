using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy;
    [SerializeField] private bool StateParent = true;
    private bool HasCalled;
    private Collider2D[] colliders;
    private bool HasInst = false;
    private GameObject[] ObjPassed;
    private List<GameObject> Instances = new List<GameObject>();
    private GameObject[] Particle;
    private float Timer;
    [SerializeField] private GameObject[] Exclude;

    private void Update()
    {
        if (HasCalled)
        {
            Timer += Time.deltaTime;
            foreach (var items in ObjPassed)
            {
                items.SetActive(StateParent);
            }
            foreach (Collider2D items in colliders)
            {
                items.enabled = false;
            }
            if (!HasInst)
            {
                foreach (var item in Particle)
                {
                    Instances.Add(Instantiate(item, ObjPassed[0].transform.position, Quaternion.identity));

                }
                foreach (var item in Instances)
                {
                    if (Exclude.Length > 0)
                    {
                        foreach (var excl in Exclude)
                        {
                            if (!item.name.StartsWith(excl.name))
                            {
                                item.transform.parent = this.transform;
                            }
                        }
                    }
                    else
                    {
                        item.transform.parent = this.transform;
                    }
                }
                HasInst = true;
            }
            if (Timer >= TimeToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
    public void DestroyEnh(GameObject[] Listener, Collider2D[] Colliders, GameObject[] Particle)
    {
        this.colliders = Colliders;
        ObjPassed = Listener;
        this.Particle = Particle;
        HasCalled = true;
    }
}
