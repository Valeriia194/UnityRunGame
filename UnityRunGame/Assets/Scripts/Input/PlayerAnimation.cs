using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
    {
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement input;
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Update()
    {
        var direction = input.MovementDirection;

        animator.SetFloat(MoveX, direction.x);
        animator.SetFloat(MoveY, direction.y);
        animator.SetBool(IsMoving, direction.magnitude>0f);

    }
}

