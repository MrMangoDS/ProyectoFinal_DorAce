using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectGrabber : MonoBehaviour
{
    public Camera playerCamera;
    public Transform holdPoint;
    public float grabDistance = 3f;
    public LayerMask interactableLayer;

    private GameObject heldObject;
    private Interactable currentInteractable;

    void Update()
    {
        if (Keyboard.current == null) return;

        DetectInteractable();

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (heldObject == null && currentInteractable != null)
                Grab();
            else if (heldObject != null)
                Drop();
            Debug.DrawRay(
    playerCamera.transform.position,
    playerCamera.transform.forward * grabDistance,
    currentInteractable ? Color.green : Color.red
);
        }
    }

    void DetectInteractable()
    {
        currentInteractable = null;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, grabDistance, interactableLayer))
        {
            currentInteractable = hit.collider.GetComponent<Interactable>();
        }
    }

    void Grab()
    {
        heldObject = currentInteractable.gameObject;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;
    }

    void Drop()
    {
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}