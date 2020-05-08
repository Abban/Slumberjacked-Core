using System;

namespace BBX.Utility
{
    public static class ExceptionLogger
    {
        public static void Exception(string message)
        {
#if UNITY_EDITOR
            throw new Exception(message);
#else
            Debug.LogException(new Exception(exception));
#endif
        }
    }
}