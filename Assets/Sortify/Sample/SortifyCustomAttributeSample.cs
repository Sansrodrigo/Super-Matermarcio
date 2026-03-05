#if UNITY_EDITOR
using UnityEngine;

namespace Sortify
{
    public class SortifyCustomAttributeSample : MonoBehaviour
    {
#if SORTIFY_ATTRIBUTES
        [Button("Change Bool Button")]
        public bool Button = false;

        [ShowIf("Button", null, true)]
        public string buttonFalse = "This is shown when Button is false.";

        [ShowIf("Button")]
        public string buttonTrue = "This is shown when Button is true.";

        [Space(5)]
        [Message(MessageAttribute.MessageType.Info, "Example info message.")]
        public string InfoMessage = "Info Message";

        [Space(5)]
        [Message(MessageAttribute.MessageType.Warning, "Example warning message.")]
        public string WarningMessage = "Warning Message";

        [Space(5)]
        [Message(MessageAttribute.MessageType.Error, "Example error message.")]
        public string ErrorMessage = "Error Message";

        [Space(5)]
        [MinMaxSlider(0, 1)]
        public Vector2 MinMaxSlider;

        [Space(5)]
        [ReadOnly]
        public float ReadOnly = 5;

        [Space(5)]
        [BetterHeader("Better Header Default")]
        public float BetterHeader_Default;

        [Space(5)]
        [BetterHeader("Better Header Middle Center", 16, TextAnchor.MiddleCenter)]
        public float BetterHeader_MiddleCenter;

        [Space(5)]
        [BetterHeader("Better Header Middle Right", 22, TextAnchor.MiddleRight)]
        public float BetterHeader_MiddleRight;

        [Space(5)]

        [Tag]
        public string tag;
        [Layer]
        public int layer;

        [Space(5)]
        [Validate("CheckValidateFloat", "Variable is negative!")]
        public float ValidateFloat = 1f;
        private bool CheckValidateFloat()
        {
            return ValidateFloat > 0;
        }

        [Space(5)]
        [Unit("kg")]
        public float Weight = 60f;
        [Unit("m")]
        public float Height = 1.75f;
        [Unit("cm")]
        public float Width = 45f;

        [Button("Invoke Methode")]
        public void ButtonMethode()
        {
            Debug.Log("Invoke!");
        }
#endif
    }
}
#endif