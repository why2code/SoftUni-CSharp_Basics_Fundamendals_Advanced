namespace CommandPattern.Common
{
    using System;
    public static class ErrorMessages
    {
        public const string InvalidCommandType =
           "Provided type {0} does not exist or it does not implement ICommand interface!";
    }
}
