using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace mark1.state
{
    public class StartState : PlayerState
    {
        private XRRayInteractor[] _interactors;
        
        public override void InitState(PlayerController c)
        {
            base.InitState(c);
            type = PlayerController.PlayerStateType.Start;
            
            _interactors = FindObjectsOfType<XRRayInteractor>();
        }

        public void JumpToGameState()
        {
            controller.SetActiveState(PlayerController.PlayerStateType.Game);
        }
        
        private void OnEnable()
        {
            controller.transform.position = transform.position;
            controller.transform.rotation = transform.rotation;
            controller.transform.localScale = new Vector3(1, 1, 1);

            foreach (XRRayInteractor xrRayInteractor in _interactors)
            {
                xrRayInteractor.gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (XRRayInteractor xrRayInteractor in _interactors)
            {
                xrRayInteractor.gameObject.SetActive(false);
            }
        }
    }
}