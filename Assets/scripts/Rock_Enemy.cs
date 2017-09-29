using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Enemy : ClassBase {

    enum STATE {MOVE_LEFT, MOVE_RIGHT, STAND_STILL, LANDING}


    STATE curr_state = STATE.STAND_STILL;
    float curr_time;
    bool hasHopped;
    public float end_time_landing = 0.25f, end_jump_height = 2.0f, end_scale_y, end_image_y;
    Rigidbody rb;
    Shader shader_handle;
    public Texture image_idle, image_jump, image_land;

    // Use this for initialization
    public override void Start() {
        hasHopped = false;
        rb = GetComponent<Rigidbody>();
        shader_handle = GetComponent<Shader>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (hasHopped && rb.velocity.y == 0)
        {
            hasHopped = false;
            curr_state = STATE.LANDING;
        }

        if (curr_state != STATE.STAND_STILL)
        {
            if(curr_state == STATE.LANDING)
            {
                curr_time += Time.deltaTime;
                if (curr_time > end_time_landing)
                {
                    curr_time = 0;
                    curr_state = STATE.STAND_STILL;
                }
            }
        }
        else if(!hasHopped)
        {
            if (Input.GetKey(KeyCode.A))
            {
                curr_state = STATE.MOVE_RIGHT;
                rb.velocity = new Vector3(-1, 3, 0);
                hasHopped = true;
                //GetComponent<Renderer>().SetTexture(shader_handle.name, image_jump);
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                curr_state = STATE.MOVE_LEFT;
                rb.velocity = new Vector3(1, 3, 0);
                hasHopped = true;
                //texture_handle.
            }
        }
    }

    bool BelowHalfOfHop(float end_time)
    {
        return end_time / 2.0f < curr_time;
    }
}
