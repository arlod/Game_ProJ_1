using UnityEngine;
using System.Collections;



public class CameraBehavior : MonoBehaviour
{
    public GameObject PlayerPos;
    public float FracLag = 0.2F;
    public float tiltShift = 10;
    public float screenShiftModifier = 0.5F;
    public float cameraHeightModifier = 5;
    private Vector3 CameraPos;
    private Vector3 Player;
    private float cameraHeight = 18;

    



    void Update()
    {
        
        Player = new Vector3(PlayerPos.GetComponent<Transform>().position.x, cameraHeight, PlayerPos.GetComponent<Transform>().position.z);
        CameraPos = new Vector3(gameObject.GetComponent<Transform>().position.x, cameraHeight, gameObject.GetComponent<Transform>().position.z + cameraHeightModifier);

        //If mouse is clicked, move the camera in the direction of the mouse
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            mousePos.y -= Screen.height / 2;
            float mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);
            float targetX = Mathf.Cos(mouseAngle) /  screenShiftModifier + Player.x;
            float targetY = Mathf.Sin(mouseAngle) /  screenShiftModifier + Player.z;
            gameObject.GetComponent<Transform>().position = Vector3.Lerp(CameraPos, new Vector3(targetX, 10, targetY + cameraHeightModifier), FracLag);
        }
        //When mouse is released, or not pressed, move to center the camera above the player, smoothly.
        else {
            if (Mathf.Abs(CameraPos.x - Player.x) > 0.1 || Mathf.Abs(CameraPos.z - Player.z) > 0.1)
            {
                gameObject.GetComponent<Transform>().position = Vector3.Lerp(CameraPos, Player, FracLag);
            }
        }

        //tilt the camera when the player moves
        if (Input.GetKey("a"))
        {
            Quaternion turnAngle = Quaternion.Euler(80, -tiltShift * 10, -tiltShift * 10);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
            
        }
        else if (Input.GetKey("d"))
        {
            Quaternion turnAngle = Quaternion.Euler(80, tiltShift * 10, tiltShift * 10);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
        }
        else if (Input.GetKey("s"))
        {
            Quaternion turnAngle = Quaternion.Euler(80 + tiltShift, -180, -180);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
        }
        else if (Input.GetKey("w"))
        {
            Quaternion turnAngle = Quaternion.Euler(80 - tiltShift, 0, 0);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
        }
        //reset camera angle when player is not moving
        else
        {
            Quaternion turnAngle = Quaternion.Euler(80, 0, 0);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
            
        }

    }


}
