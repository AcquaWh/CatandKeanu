namespace Platform2DUtils.GameplaySystem
{
    using UnityEngine;
    
    public class GameplaySystem
    {
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
    }
}