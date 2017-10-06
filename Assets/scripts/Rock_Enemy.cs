using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Enemy : ClassBase
{

    public enum STATE {MOVE_LEFT, MOVE_RIGHT, STAND_STILL, LANDING, REEL_BACK, ATTACK }

    public STATE curr_state;
    float curr_time;
    bool hasHopped, hasAttacked;
    public float end_time_landing = 0.25f, end_time_reelback = 0.25f, end_time_attacking = 0.75f, end_jump_height = 2.0f, end_scale_y, end_image_y;
    Rigidbody2D rb;
    BoxCollider2D rock_collider;
    SpriteRenderer rend;
    public Sprite image_idle, image_jump, image_land, image_reel_back, image_punch;

    // Use this for initialization
    public override void Start()
    {
        curr_state = STATE.STAND_STILL;
        hasHopped = false;
        hasAttacked = false;
        rb = GetComponent<Rigidbody2D>();
        rock_collider = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if ((curr_state == STATE.MOVE_LEFT || curr_state == STATE.MOVE_RIGHT) && (hasHopped && rb.velocity.y == 0))
        {
            hasHopped = false;
            curr_state = STATE.LANDING;
            rend.sprite = image_land;
            if (rend.flipX)
            {
                rock_collider.offset = new Vector2(-1.16f, -1.6f);
                rock_collider.size = new Vector2(19.01f, 8.5f);
            }
            else
            {
                rock_collider.offset = new Vector2(1.6f, -1.6f);
                rock_collider.size = new Vector2(19.01f, 8.5f);
            }
        }

        if (curr_state == STATE.REEL_BACK)
        {
            curr_time += Time.deltaTime;

            if (curr_time > end_time_reelback)
            {
                curr_state = STATE.ATTACK;
                rend.sprite = image_punch;
                curr_time = 0;
                GetComponentInChildren<Rock_Enemy_Punch>().punchcollider.enabled = true;
            }
        }
        if (curr_state == STATE.ATTACK)
        {
            curr_time += Time.deltaTime;

            if (curr_time > end_time_attacking)
            {
                curr_state = STATE.STAND_STILL;
                rend.sprite = image_idle;
                curr_time = 0;
                GetComponentInChildren<Rock_Enemy_Punch>().punchcollider.enabled = false;
            }

            if (rend.flipX)
            {
                GetComponentInChildren<Rock_Enemy_Punch>().punchcollider.offset = new Vector2(14.9f, -1.31f);
            }
            else // (!rend.flipX)
            {
                GetComponentInChildren<Rock_Enemy_Punch>().punchcollider.offset = new Vector2(-14.9f, -1.31f);
            }
        }
        if (curr_state == STATE.LANDING)
        {
            curr_time += Time.deltaTime;
            if (curr_time > end_time_landing)
            {
                curr_time = 0;
                curr_state = STATE.STAND_STILL;
                rend.sprite = image_idle;
                if (rend.flipX)
                {
                    rock_collider.offset = new Vector2(1.77f, -1.73f);
                    rock_collider.size = new Vector2(12.1f, 8.69f);
                }
                else
                {
                    rock_collider.offset = new Vector2(-1.69f, -1.73f);
                    rock_collider.size = new Vector2(14.15f, 8.69f);
                }
            }
        }
        if (curr_state == STATE.STAND_STILL)
        {
            if (!hasHopped)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    curr_state = STATE.MOVE_RIGHT;
                    rb.velocity = new Vector3(-1, 3, 0);
                    hasHopped = true;
                    rend.flipX = false;
                    rend.sprite = image_jump;
                    rock_collider.offset = new Vector2(-3.2f, 1.87f);
                    rock_collider.size = new Vector2(14.15f, 13.09f);

                    GetComponentInChildren<Rock_Enemy_AI>().detectionCollider.offset = new Vector2(-45.5f, 8.66f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    curr_state = STATE.MOVE_LEFT;
                    rb.velocity = new Vector3(1, 3, 0);
                    hasHopped = true;
                    rend.flipX = true;
                    rend.sprite = image_jump;
                    rock_collider.offset = new Vector2(-3.2f, 1.87f);
                    rock_collider.size = new Vector2(14.15f, 13.09f);

                    GetComponentInChildren<Rock_Enemy_AI>().detectionCollider.offset = new Vector2(45.5f, 8.66f);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                curr_state = STATE.REEL_BACK;
                hasAttacked = true;
                rend.sprite = image_reel_back;
            }
        }
    }

    bool BelowHalfOfHop(float end_time)
    {
        return end_time / 2.0f < curr_time;
    }

    public void BeginAttack()
    {
        curr_state = STATE.REEL_BACK;
        hasAttacked = true;
        rend.sprite = image_reel_back;
    }

    public void BeginMoveLeft()
    {
        curr_state = STATE.MOVE_LEFT;
        rb.velocity = new Vector3(1, 3, 0);
        hasHopped = true;
        rend.flipX = true;
        rend.sprite = image_jump;
        rock_collider.offset = new Vector2(-3.2f, 1.87f);
        rock_collider.size = new Vector2(14.15f, 13.09f);

        GetComponentInChildren<Rock_Enemy_AI>().detectionCollider.offset = new Vector2(45.5f, 8.66f);
    }

    public void BeginMoveRight()
    {
        curr_state = STATE.MOVE_RIGHT;
        rb.velocity = new Vector3(-1, 3, 0);
        hasHopped = true;
        rend.flipX = false;
        rend.sprite = image_jump;
        rock_collider.offset = new Vector2(-3.2f, 1.87f);
        rock_collider.size = new Vector2(14.15f, 13.09f);

        GetComponentInChildren<Rock_Enemy_AI>().detectionCollider.offset = new Vector2(-45.5f, 8.66f);
    }
}
