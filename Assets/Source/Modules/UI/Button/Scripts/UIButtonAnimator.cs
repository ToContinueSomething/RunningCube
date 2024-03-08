using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class UIButtonAnimator : MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
   private Animator _animator;
   private readonly int _pressNameParameter = Animator.StringToHash("IsPress");

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

 /*  public void OnPointerEnter(PointerEventData eventData)
   {
      _animator.SetBool(_pressNameParameter,true);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      _animator.SetBool(_pressNameParameter,false);
   }*/
   

   public void OnPointerUp(PointerEventData eventData)
   {
      _animator.SetBool(_pressNameParameter,false);
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      _animator.SetBool(_pressNameParameter,true);
   }
}
