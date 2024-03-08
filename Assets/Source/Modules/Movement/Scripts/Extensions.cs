using UnityEngine;

 public static class Extensions {
      public static void LimitYVelocity(this Rigidbody2D rb, float limit) {
        int gravityMultiplier = (int)(Mathf.Abs(rb.gravityScale) / rb.gravityScale);

        if (rb.velocity.y * -gravityMultiplier > limit)
            rb.velocity = Vector2.up * -limit * gravityMultiplier;
    }
     
}