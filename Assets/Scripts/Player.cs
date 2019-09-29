using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody rb;
    private Animator animator;
    private float moveSpeed = 4;
    [SerializeField]
    private Material material;
    private Color baseColor;

    public float HideTime { get; private set; }
    public bool hidden = false;

    void Awake()
    {
        HideTime = 20;
        instance = this;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        baseColor = material.color;
    }

    void Update()
    {
        rb.angularVelocity = Vector3.zero;
        var dx = Input.GetAxisRaw("Horizontal");
        var dz = Input.GetAxisRaw("Vertical");

        if (dx == 0 && dz == 0)
        {
            animator.SetBool("Running", false);
            rb.velocity = Vector3.zero;
        }
        else
        {
            animator.SetBool("Running", true);

            var deg = Vector3.Angle(Vector3.forward, new Vector3(dx, 0, dz));
            if (dx == -1) deg *= -1;
            transform.forward = Quaternion.Euler(0, deg, 0) * CameraController.instance.transform.forward;

            rb.velocity = transform.forward * moveSpeed *(hidden?0.25f:1);
        }

        if (hidden)
        {
            HideTime -= Time.deltaTime;
            if (HideTime < 0)
            {
                HideTime = 0;
                hidden = false;
                baseColor.a = 1f;
                material.color = baseColor;
            }
        }

        if (Input.GetButtonDown("Fire1") && HideTime > 0)
        {
            hidden = true;
            baseColor.a = 0.1f;
            material.color = baseColor;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            hidden = false;
            baseColor.a = 1f;
            material.color = baseColor;
        }
    }
}
