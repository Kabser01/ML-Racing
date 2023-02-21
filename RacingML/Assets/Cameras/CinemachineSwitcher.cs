using UnityEngine.InputSystem;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action; 
    private Animator animator; 
    private bool FreeLookCamera = true; 
    
    private void Awake() {
        animator = GetComponent<Animator>(); 
    }
    private void OnEnable() {
        action.Enable();
    }

    private void OnDisable() {
        action.Disable(); 
    }

    void Start()
    {
        action.performed += _ => SwitchState(); 
    }

    private void SwitchState() {
        if(FreeLookCamera) {
            animator.Play("First Person View");
        }
        else {
            animator.Play("FreeLook");
        }
        FreeLookCamera = !FreeLookCamera;
    }
}
