using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerController : MonoBehaviour
{
    public float speed = 5.0f;

    Dictionary<QuestItem, int> inventory = new Dictionary<QuestItem, int>();

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hitNPC = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hitNPC.collider != null)
            {
                NPCDisplayDialog(hitNPC);
            }
            RaycastHit2D hitItem = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Item"));
            if (hitItem.collider != null)
            {
                QuestItem item = hitItem.collider.GetComponent<QuestItem>();
                UpdateInventory(item, 2);
                item.QuestItemAlert();
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    void NPCDisplayDialog(RaycastHit2D hit)
    {
        NPCDialog character = hit.collider.GetComponent<NPCDialog>();
            if(character != null)
            {
                character.DisplayQuestDialog();
            }
    }

    public void UpdateInventory(QuestItem item, int count)
    {
        inventory.Add(item, count);
    }
}
