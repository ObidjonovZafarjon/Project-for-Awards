using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpLayer;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PickUpRange;
    [SerializeField] private Transform Hand;
    [SerializeField] private float ThrowingForce;
    public Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;
    float[] massaNum = { 220.5f, 264.6f, 296.7f, 250f, 200f, 150f, 250f, 100f };
    string[] objects = { "Cone", "Sphere", "Cylinder", "Cube", "Stone", "Crone", "JinLamp", "Capsule" };
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray PickUpRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            
            
            if (Physics.Raycast(PickUpRay, out RaycastHit hitInfo, PickUpRange, PickUpLayer))
            {
                if (CurrentObjectRigidbody)
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                    Debug.Log("Double");
                    Debug.Log(CurrentObjectRigidbody.name);
                    


                }
                else
                {
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                    Debug.Log("Olingan");
                    for(int i=0; i<8; i++)
                    {
                        if(CurrentObjectRigidbody.name == objects[i] && Weighter.BooleanObj[i]==true)
                        {
                            Weighter.BooleanObj[i] = false;
                            Weighter.sum = Weighter.sum - massaNum[i];
                            GameObject.Find("TextWeighter").GetComponent<TMP_Text>().text = Weighter.sum.ToString() + " gr";
                        }
                    }


                }
                return;
            }
            if (CurrentObjectRigidbody)
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;
                Debug.Log("Tashlangan");

            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (CurrentObjectRigidbody)
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody.AddForce(PlayerCamera.transform.forward*ThrowingForce, ForceMode.Impulse);

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;

            }
        }

        if(CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;
        }

    
    }
}
