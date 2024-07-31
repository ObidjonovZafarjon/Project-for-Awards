using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSecondScene : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpLayer;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PickUpRange;
    [SerializeField] private Transform Hand;
    [SerializeField] private float ThrowingForce;
    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;

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
                    CurrentObjectRigidbody.drag = 0;
                }
                else
                {
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                    CurrentObjectRigidbody.drag = 0;


                }
                return;
            }
            if (CurrentObjectRigidbody)
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;

            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (CurrentObjectRigidbody)
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody.AddForce(PlayerCamera.transform.forward * ThrowingForce, ForceMode.Impulse);

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;

            }
        }

        if (CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;
        }


    }
}
