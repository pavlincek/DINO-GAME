using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

   private void Update()
   {
        transform.position += Vector3.left * GameSpeed.Instance.SPEED * Time.deltaTime;

        if(transform.position.x < leftEdge)
            {
                 Destroy(gameObject);
            }
   }
}
