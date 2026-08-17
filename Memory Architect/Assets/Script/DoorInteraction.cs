using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform doorHinge;
    public float openAngle = 90f;
    public float speed = 2f;

    public GameObject interactText;

    private bool isOpen = false;
    private Quaternion closedRot;
    private Quaternion openRot;

   void Start()
{
    if (interactText != null)
        interactText.SetActive(false);
}

    void Update()
    {
        // animație ușă
        Quaternion target = isOpen ? openRot : closedRot;
        doorHinge.localRotation = Quaternion.Lerp(doorHinge.localRotation, target, Time.deltaTime * speed);

        // textul se uită la player
        if (interactText != null && interactText.activeSelf)
        {
            interactText.transform.LookAt(Camera.main.transform);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

   public void ShowText(bool show)
{
    if (interactText != null)
    {
        interactText.SetActive(show);
        // DEBUG
        Debug.Log(gameObject.name + " text: " + show);
    }
}
}