using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckPointSystem
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField] private List<CheckpointController> checkPoints = new List<CheckpointController>();
        private int lastPassedCheckPoint;

        void Start()
        {
            for (int i = 0; i < checkPoints.Count; i++)
            {
                checkPoints[i].checkPointManager = this;
                if (i == 0)
                {
                    checkPoints[i].isMyTurn = true;
                }
            }
        }

        public void SetLastPassedCheckPoint(int id)
        {
            lastPassedCheckPoint = id;
            //GameManager.Instance().ChangeCheckPoint(lastPassedCheckPoint);

            if (checkPoints.Count-1 > id)
            {
                checkPoints[id + 1].isMyTurn = true;
            }
            else
            {
                EndGame();
            }
        
        
        }

        private void EndGame()
        {
            Debug.Log("Level Complete");
        }



        
    }

}
