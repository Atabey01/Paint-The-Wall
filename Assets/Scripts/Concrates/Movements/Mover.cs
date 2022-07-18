using System.Collections;
using System.Collections.Generic;
using TPSRunerGame.Controllers;
using UnityEngine;


namespace TPSRunerGame.Movements
{
    public class Mover
    {
        PlayerController _playerController;
        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void TickFixed(float horizontal, float vertical, float moveSpeedx, float speedZ)
        {
            _playerController.transform.Translate(new Vector3(horizontal * Time.deltaTime * moveSpeedx, 0, vertical * speedZ * Time.deltaTime), Space.World);
        }
    }

}
