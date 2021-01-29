using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpFore = 10f;

    public float gravityModifier;

    private bool isGrounded = true;

    public bool isGameOver = false;

    private Animator animatorController;

    private AudioSource playerAudioSource;

    [SerializeField] ParticleSystem explodeParticle;

    [SerializeField] ParticleSystem driftParticle;

    [SerializeField] AudioClip jumpSound;

    [SerializeField] AudioClip crashSound;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        animatorController = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpFore, ForceMode.Impulse);
            isGrounded = false;
            animatorController.SetTrigger("Jump_trig");
            driftParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 1.0f); ;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            driftParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            animatorController.SetBool("Death_b", true);
            animatorController.SetInteger("DeathType_int", 1);
            playerAudioSource.PlayOneShot(crashSound, 1.0f);
            explodeParticle.Play();
            driftParticle.Stop();
        }
    }
}
