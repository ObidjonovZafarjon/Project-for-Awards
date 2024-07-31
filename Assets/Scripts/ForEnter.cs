using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForEnter : MonoBehaviour
{
    public Text AlertText;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        AlertText.gameObject.SetActive(true);
    }
}
