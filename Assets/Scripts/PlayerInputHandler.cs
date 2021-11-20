using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System.Linq;

namespace Inputs
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] PlayerController motor = null;
        [SerializeField] PlayerCombat combat = null;
        [SerializeField] private Vector2 move;
        [SerializeField] private bool attack;
        [SerializeField] private bool attackH;
        [SerializeField] int index;

        private Controls controls;
        private Controls Controls
        {
        get
            {
                if (controls != null) { return controls; }
                return controls = new Controls();
            }
        }
        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            InputManager.Controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
            InputManager.Controls.Player.Move.canceled += _ => OnMove(Vector2.zero);
        }

        // Update is called once per frame
        private void Start()
        {
            FindPlayer();

        }
        public void FindPlayer()
        {
            index = playerInput.playerIndex;
            var motors = FindObjectsOfType<PlayerController>();
            motor = motors.FirstOrDefault(m => m.GetPlayerIndex() == index);

            var combats = FindObjectsOfType<PlayerCombat>();
            combat = combats.FirstOrDefault(m => m.GetPlayerIndex() == index);
        }
        public void OnMove(CallbackContext context)
        {
            if (motor == null) return;
            move = context.ReadValue<Vector2>();
            motor.Move = move;
        }
        public void OnAttack(CallbackContext context)
        {
            if (combat == null) return;
            attack = !context.canceled; ;
            combat.Attacking = attack;
        }
        public void OnAttackH(CallbackContext context)
        {
            if (combat == null) return;
            attackH = !context.canceled; ;
            combat.AttackingH = attackH;
        }
        public void OnMove(Vector2 move)
        {
            if (motor == null) return;
            motor.Move = move;
        }
    }
}
