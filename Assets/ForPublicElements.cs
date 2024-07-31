using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPublicElements : MonoBehaviour
{
    public GameObject Green1;
    public GameObject Green2;
    public GameObject Green3;

    // Start is called before the first frame update
    void Start()
    {
        Green1.SetActive(false);
        Green2.SetActive(false);
        Green3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ForCircuit2.sendScene41 == 1)
            Green1.SetActive(true);
        if (ForCircuit2.sendScene42 == 1)
            Green2.SetActive(true);
        if (ForCircuit2.sendScene43 == 1)
            Green3.SetActive(true);


    }
}
