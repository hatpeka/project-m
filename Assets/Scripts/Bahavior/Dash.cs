using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementBehavior
{
    [Header("Stats")]
    [SerializeField] float dashPower;
    [SerializeField] float dashTime;
    [SerializeField] float dashCoolDown;

    [Header("Trail Renderer")]
    [SerializeField] TrailRenderer tr;

    //Must-have variables for movements
    public IDashInput dashInput { get; private set; }
    public bool triggerDash { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dashInput = GetComponent<IDashInput>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Dashing();
    }

    public virtual void Dashing()
    {
        //Input
        bool trigger = dashInput.trigger;
        triggerDash = dashInput.RequestDash(trigger, dashCoolDown, isGrounded);

        //Dash
        if (triggerDash)
        {
            StartCoroutine(Pushing());
        }
    }

    IEnumerator Pushing()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(movingObject.transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
    }

    public bool IsDashing()
    {
        return rb.gravityScale == 0;
    }

    public bool CanDash()
    {
        return dashInput.CanDash();
    }
}
