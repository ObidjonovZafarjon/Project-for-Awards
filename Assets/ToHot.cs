using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHot : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void hotting()
    {
        anim.Play("ToHot");
    }
    public void ToOpen()
    {
        anim.SetTrigger("ToOpen");
    }
    public void ToClose()
    {
        anim.SetTrigger("ToClose");
    }
}
