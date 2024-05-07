using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public KeyCode jumpKey;
    protected bool p_jump;

    public bool blockJump;
    public bool jump
    {
        get
        {
            if(blockJump)
                return false;
            return p_jump;
        }
    }

    private void FixedUpdate() 
    {
        p_jump = Input.GetKey(jumpKey);
    }

    public void releaseJumpKey()
    {
        blockJump = true;
    }

    public void gainJumpKey()
    {
        blockJump = false;
    }

}
