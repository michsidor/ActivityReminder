using System;
using System.Text;

namespace RefOutAnotherExercises
{
    public static  class HelpFunctions
    {
        public static bool CompareToCharacters(this StringBuilder inValue, string character)
        {
            if ((string.Equals(inValue.ToString().ToLower(), character)) || (string.Equals(inValue.ToString().ToUpper(), character)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

