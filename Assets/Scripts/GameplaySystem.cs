namespace Platform2DUtils.GameplaySystem
{
    using UnityEngine;
    
    public class GameplaySystem
    {
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public static Vector2 AxisDelta
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * Time.deltaTime);
        }

        ///<summary>
        /// Botón de saltar
        ///</summary>
        public static bool JumpButton
        {
            get => Input.GetButtonDown("Jump");
        }

        public static void MovementT(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed);
        }

        public static void MovementTdelta(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        }

        public static void PhysicsMovement(Rigidbody2D rb2d, float moveSpeed, float maxVelX)
        {
            rb2d.AddForce(Vector2.right * AxisDelta.x, ForceMode2D.Impulse);
            rb2d.velocity = new Vector2(Vector2.ClampMagnitude(rb2d.velocity, maxVelX).x, rb2d.velocity.y);
        }

        public static void PhysicsMovementVel(Rigidbody2D rb2d, float moveSpeed, float maxVelX)
        {
            rb2d.velocity = new Vector2(AxisDelta.x * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = new Vector2(Vector2.ClampMagnitude(rb2d.velocity, maxVelX).x, rb2d.velocity.y);
        }
    }
}