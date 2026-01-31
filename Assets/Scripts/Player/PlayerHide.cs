using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerHide : MonoBehaviour
{
   public LayerMask HidingSpot;
   private Collider2D _collider2D;
   private ShadowCaster2D  _shadowCaster2D;
   private Animator _animator;

   private void Start()
   {
      _collider2D = GetComponent<Collider2D>();
      _shadowCaster2D = GetComponent<ShadowCaster2D>();
   }

   private void Update()
   {
      if (UpdateHide())
      {
         Crouch();
      }

      if (!UpdateHide())
      {
         Stand();
      }
      
   }

   private void Crouch()
   {
      
      _collider2D.enabled = false;
      _shadowCaster2D.castsShadows = false;
      //_animator.SetTrigger("Crouch");
      
   
   }
   private void Stand()
   {
      
      _collider2D.enabled = true;
      _shadowCaster2D.castsShadows = true;
   
   }
   private bool UpdateHide()
   {
      return Physics2D.OverlapCircle(transform.position, 0.1f, HidingSpot);
   }
}
