using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Controllers 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private GameObject Player;
        Animator anim;
        CharacterController charController;

        private Vector3 moveRotation;
        private Vector3 moveDirection;

        

        private bool isJumping;
        private float horizontalValue;
        private float verticalValue;
        private float currentYRotationValue;

        

        void Start()
        {
            anim = GetComponent<Animator>();
            charController = GetComponent<CharacterController>();
            isJumping = false;
            
        }


        void Update()
        {
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");
            if(horizontalValue != 0 || verticalValue != 0)
            {
                RunAnimation();
            }
            else
            {
                anim.SetBool("Walk", false);
            }
            

            if (!isJumping)
            {
                
                moveDirection = new Vector3(horizontalValue, 0f, verticalValue);
                               
            }
            else
            {
                moveDirection = new Vector3(0, playerSettings.jumpForce, 0);
            }
            
            
            if(charController.isGrounded && isJumping)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(Jump());
                }
            }

            //currentYRotationValue += horizontalValue;

           //moveRotation = new Vector3(0, currentYRotationValue, 0);
            //moveDirection = Quaternion.Euler(moveRotation) * moveDirection;
            
                charController.Move(moveDirection * playerSettings.moveSpeed * Time.deltaTime);
                Debug.Log(horizontalValue);


            //RESTART SCENE
            if (Player.gameObject.transform.position.y < -40f)
            {
                Debug.Log("DEAD");
                Dead();
            }
        }

        private void Dead()
        {
            SceneLoader.Load(SceneLoader.Scenes.RestartScene);
        }

        private void RunAnimation()
        {
            anim.SetBool("Walk", true);
        }

        private IEnumerator Jump()
        {
            isJumping = true;
            yield return new WaitForSeconds(playerSettings.jumpTime);
            isJumping = false;
        }

        [System.Serializable]
        public struct PlayerSettings
        {
            public float moveSpeed;
            public float jumpForce;
            public float jumpTime;
            public float gravityScale;
        }
    }
}






