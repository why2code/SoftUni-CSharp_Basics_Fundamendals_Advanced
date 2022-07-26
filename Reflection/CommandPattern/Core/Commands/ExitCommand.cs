namespace CommandPattern.Core.Commands
{
    using System;
    using Contracts;
    public class ExitCommand : ICommand
    {
        private const int exitParamCodeSuccess = 0;
        public string Execute(string[] args)
        {
            System.Environment.Exit(exitParamCodeSuccess);
            return null;
        }
    }
}
