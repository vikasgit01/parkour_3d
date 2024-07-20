using UnityEngine;

//This script is attached to GameManager GameObject
public class GameControlles : MonoBehaviour
{

    #region Not Using Yet

    //Keycodes for Movement
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;

    //Alternate Keycodes for Movement
    public KeyCode altForward = KeyCode.UpArrow;
    public KeyCode altBackward = KeyCode.DownArrow;
    public KeyCode altRight = KeyCode.RightArrow;
    public KeyCode altLeft = KeyCode.LeftArrow;

    #endregion

    //Keycodes for otherMovement
    public KeyCode jump = KeyCode.Space;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode crouch = KeyCode.LeftControl;

    //Keycodes for Interactive
    public KeyCode grapple = KeyCode.F;
}

