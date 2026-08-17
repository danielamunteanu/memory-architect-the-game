using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public float interactDistance = 3f;

    private PlayerControls controls;
    private DoorInteraction currentDoor;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => Interact();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void Update()
    {
        CheckDoorInFront();
    }

   private void CheckDoorInFront()
{
    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

    DoorInteraction newDoor = null;

    if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
    {
        newDoor = hit.collider.GetComponent<DoorInteraction>()
                 ?? hit.collider.GetComponentInParent<DoorInteraction>();
    }

    // dacă NU mai vezi nimic
    if (newDoor == null)
    {
        if (currentDoor != null)
        {
            currentDoor.ShowText(false);
            currentDoor = null;
        }
        return;
    }

    // dacă vezi altă ușă
    if (currentDoor != newDoor)
    {
        if (currentDoor != null)
        {
            currentDoor.ShowText(false);
        }

        currentDoor = newDoor;
        currentDoor.ShowText(true);
    }
}

    private void Interact()
    {
        if (currentDoor != null)
        {
            currentDoor.ToggleDoor();
        }
    }
}