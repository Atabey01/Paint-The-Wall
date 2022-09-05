using System.Collections;
using System.Collections.Generic;
using TPSRunerGame.Controllers;
using UnityEngine;


namespace TPSRunerGame.Movements
{
    public class Mover
    {
        Rigidbody _playerRigidbody;


        public Mover(Rigidbody playerRigidbody)
        {
            _playerRigidbody = playerRigidbody;
        }
        public void TickFixed(float horizontal, float vertical, float moveSpeedx, float speedZ)
        {
            Vector3 verticalDirection = Vector3.forward * vertical * speedZ;
            // _playerRigidbody.transform.Translate(verticalDirection);

            Vector3 horizontalDirection = Vector3.right * horizontal * moveSpeedx;
            _playerRigidbody.velocity = horizontalDirection + verticalDirection;
        }
    }

}
