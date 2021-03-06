using UnityEngine;

public class KeeperController : MonoBehaviour
{
    
    [SerializeField] private Transform a_point, b_point;
    [SerializeField] private Transform skin;
    [SerializeField] private Transform keeperRange;
    private bool goRight;
    private float speedPatrol = 1.1f;
    private Collider2D circleCollider;
    private Collider2D collider2D;
    private Characters characters;
    private Animator receiveSkinAnimator;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        circleCollider = GetComponentInChildren<CircleCollider2D>();
        characters = GetComponent<Characters>();
        receiveSkinAnimator = skin.GetComponent<Animator>();
    }
    void Update()
    {
        if(characters.life <= 0)
        {
            collider2D.enabled = false;
            circleCollider.enabled = false;
            this.enabled = false;
        }

        if (receiveSkinAnimator.GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }

        if (goRight)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if(Vector2.Distance(transform.position, b_point.position) < 0.1f)
            {
                goRight = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, b_point.position, speedPatrol * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a_point.position) < 0.1f)
            {
                goRight = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, a_point.position, speedPatrol * Time.deltaTime);
        }
    }
}
