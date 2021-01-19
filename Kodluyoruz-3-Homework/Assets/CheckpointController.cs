using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckPointSystem
{
    public class CheckpointController : MonoBehaviour
    {
        public CheckpointManager checkPointManager;

        [SerializeField] private CheckPointData checkPointData;

        [SerializeField] private Material[] checkPointMaterials;

        public bool isMyTurn;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (isMyTurn)
                {
                    isMyTurn = false;
                    checkPointData.isPassed = true;
                    ChangeColor();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (checkPointData.isPassed)
                {
                    checkPointManager.SetLastPassedCheckPoint(checkPointData.checkPointID);
                }
            }
        }

        public void ResetCheckPoint()
        {
            checkPointData.isPassed = false;
            ChangeColor();
        }

        private void ChangeColor()
        {
            checkPointData.checkPointRenderer.material = checkPointMaterials[(checkPointData.isPassed ? 1 : 0)];
        }
    }

    [System.Serializable]
    public class CheckPointData
    {
        public int checkPointID;
        public bool isPassed;
        public Renderer checkPointRenderer;
    }
}


