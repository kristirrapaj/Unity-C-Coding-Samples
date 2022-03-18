using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CircleRotation : MonoBehaviour
    {
        [SerializeField] private GameObject circle;
        [SerializeField] private float spinSpeed;
        [SerializeField] private float fastSpinSpeed;
        [SerializeField] private bool fasterSpin = false;
        [SerializeField] private float spinDuration;
        

        private void Update()
        {
            if (!fasterSpin)
            {
                ContinuousSpin();
            }
            
        }

        private void ContinuousSpin()
        {
            circle.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        }

        public void FasterSpin()
        {
            fasterSpin = true;
            StartCoroutine(SpinFaster(spinDuration));
        }

        private IEnumerator SpinFaster(float duration)
        {
            for( float time  = 0 ; time < duration ; time += Time.deltaTime )
            {                     
                circle.transform.Rotate(Vector3.forward, fastSpinSpeed * Time.deltaTime);
                yield return null ;
            }
            fasterSpin = false;
            yield return null;
        }
    }