using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class Move : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    public float timeToMove = 0.1f;

    private Vector2 pos;


    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving && pos.x > -8)
            StartCoroutine(MovePlayer(Vector3.left));
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving && pos.x < 10.5)
            StartCoroutine(MovePlayer(Vector3.right));

        if(pos.x<-1.6 && pos.y < -9.5)
        {
            SceneManager.LoadScene("level");
        }

    }

    public IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;


        while (elapsedTime < timeToMove)
        {
            //Lerp-linear interpolation
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;

        }

        transform.position = targetPos;
        isMoving = false;
    }
}     
    

