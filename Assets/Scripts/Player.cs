using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    
    private bool isWalking;
    private void Update() {
        Vector2 moveDir =  new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) {
            moveDir.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveDir.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveDir.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveDir.x = 1;
        }

        isWalking = moveDir != Vector2.zero;
        
        Vector2 unitMoveDir = moveDir.normalized;
        Vector3 transformedUnitMoveDir = new Vector3(unitMoveDir.x, 0, unitMoveDir.y);
        float frameDistance = Time.deltaTime * moveSpeed;
        
        transform.forward = Vector3.Slerp(transform.forward, transformedUnitMoveDir, rotateSpeed*Time.deltaTime);
        transform.position += frameDistance * transformedUnitMoveDir;
    }

    public bool IsWalking() {
        return isWalking;
    }
}