using System.Collections.Generic;
using UnityEngine;
using System;


namespace ExtensionMethods
{
    public static class AnimationExtesion
    {
        private enum VariablesType
        {
            Float,
            Int,
            Bool,
        }

        private static Dictionary<Type, VariablesType> typeDict = new Dictionary<Type, VariablesType>
        {
        {typeof(float), VariablesType.Float},
        {typeof(int), VariablesType.Int},
        {typeof(bool), VariablesType.Bool},
        };


        public static void SetAnim(this Animator animator, string animName, object value = null)
        {
            if (value != null)
            {
                switch (typeDict[value.GetType()])
                {
                    case VariablesType.Bool:
                        animator.SetBool(animName, (bool)value);
                        break;

                    case VariablesType.Float:
                        animator.SetFloat(animName, (float)value);
                        break;

                    case VariablesType.Int:
                        animator.SetInteger(animName, (int)value);
                        break;
                }
            }

            if (value == null)
                animator.SetTrigger(animName);
        }
    }
}