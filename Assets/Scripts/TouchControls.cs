using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchControls : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public PlayerMovement playerMovement; // Referenz auf das PlayerMovement-Skript

    private void Start()
    {
        // Bewegung nach links
        EventTrigger leftButtonTrigger = leftButton.gameObject.AddComponent<EventTrigger>();
        AddEventTrigger(leftButtonTrigger, EventTriggerType.PointerDown, () => playerMovement.MoveLeft(true));
        AddEventTrigger(leftButtonTrigger, EventTriggerType.PointerUp, () => playerMovement.MoveLeft(false));

        // Bewegung nach rechts
        EventTrigger rightButtonTrigger = rightButton.gameObject.AddComponent<EventTrigger>();
        AddEventTrigger(rightButtonTrigger, EventTriggerType.PointerDown, () => playerMovement.MoveRight(true));
        AddEventTrigger(rightButtonTrigger, EventTriggerType.PointerUp, () => playerMovement.MoveRight(false));

        // Sprung
        jumpButton.onClick.AddListener(playerMovement.Jump);
    }

    private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, System.Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((eventData) => { action(); });
        trigger.triggers.Add(entry);
    }
}
