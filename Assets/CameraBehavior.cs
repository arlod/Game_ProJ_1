using UnityEngine;
using System.Collections;



public class CameraBehavior : MonoBehaviour
{
    public GameObject PlayerPos;
    public float FracLag = 0.2F;
    public float screenShiftModifier = 0.5F;
    private Vector3 CameraPos;
    private Vector3 Player;
    



    void Update()
    {
        Player = new Vector3(PlayerPos.GetComponent<Transform>().position.x, 10, PlayerPos.GetComponent<Transform>().position.z);
        CameraPos = new Vector3(gameObject.GetComponent<Transform>().position.x, 10, gameObject.GetComponent<Transform>().position.z);
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            mousePos.y -= Screen.height / 2;
            float mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);
            float targetX = Mathf.Cos(mouseAngle) /  screenShiftModifier + Player.x;
            float targetY = Mathf.Sin(mouseAngle) /  screenShiftModifier + Player.z;
            gameObject.GetComponent<Transform>().position = Vector3.Lerp(CameraPos, new Vector3(targetX, 10, targetY), FracLag);
        }
        else {
            if (Mathf.Abs(CameraPos.x - Player.x) > 0.1 || Mathf.Abs(CameraPos.z - Player.z) > 0.1)
            {
                gameObject.GetComponent<Transform>().position = Vector3.Lerp(CameraPos, Player, FracLag);
            }
        }
        if (Input.GetKey("a"))
        {
            Quaternion turnAngle = Quaternion.Euler(70, -90, -90);
            //Quaternion turnAngle = Quaternion.LookRotation(PlayerPos.GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position + new Vector3(-5, 0, 0));
            gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, turnAngle, FracLag);
            
        }

    }


}
