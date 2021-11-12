using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace mark1.world
{
    public class PlayArea : MonoBehaviour
    {
        //public UnityEvent playerEnterCenter;
        //public UnityEvent playerLeaveCenter;

        private Transform _rig;

        public Slider xPosSlider;
        public Slider yPosSlider;
        public Slider rotSlider;
        public Slider scaleSlider;

        private void Start()
        {
            _rig = GetComponentInChildren<XRRig>().gameObject.transform;
            
            xPosSlider.onValueChanged.AddListener(ChangeXPos);
            yPosSlider.onValueChanged.AddListener(ChangeYPos);
            rotSlider.onValueChanged.AddListener(ChangeRotation);
            scaleSlider.onValueChanged.AddListener(ChangeScale);

            xPosSlider.value = PlayerPrefs.GetFloat("area_pos_x", 0.0f);
            yPosSlider.value = PlayerPrefs.GetFloat("area_pos_y", 0.0f);
            rotSlider.value = PlayerPrefs.GetFloat("area_rotation", 0.0f);
            scaleSlider.value = PlayerPrefs.GetFloat("area_scale", 1.3f);
        }

        public void ChangeXPos(float x)
        {
            PlayerPrefs.SetFloat("area_pos_x", x);
            Vector3 pos = _rig.position;
            pos.x = x;
            _rig.position = pos;
        }

        public void ChangeYPos(float y)
        {
            PlayerPrefs.SetFloat("area_pos_y", y);
            Vector3 pos = _rig.position;
            pos.z = y;
            _rig.position = pos;            
        }

        public void ChangeRotation(float x)
        {
            PlayerPrefs.SetFloat("area_rotation", x);
            _rig.rotation = Quaternion.AngleAxis(x, Vector3.up);
        }

        public void ChangeScale(float scale)
        {
            PlayerPrefs.SetFloat("area_scale", scale);
            _rig.localScale = new Vector3(scale, scale, scale);
        }
    }
}