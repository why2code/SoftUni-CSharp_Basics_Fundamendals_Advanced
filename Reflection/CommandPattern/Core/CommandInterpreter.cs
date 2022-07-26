namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Common;
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.Split();
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            //Create assembly and get the command type name (the commant itself is a class)
            Assembly assebmly = Assembly.GetCallingAssembly();
            Type cmdType = assebmly?.GetTypes().FirstOrDefault(x => x.Name == $"{cmdName}Command"
            && x.GetInterfaces().Any(i => i == typeof(ICommand)));

            //Throw exception if no such command exists
            if (cmdType == null)
            {
                throw new InvalidOperationException(
                  String.Format(ErrorMessages.InvalidCommandType, $"{cmdName}Command"));
            }

            //Get the methods, specifically the one named Execute
            MethodInfo executeMethod = cmdType.GetMethods()
                .First(m => m.Name == "Execute");
            //Create instancce of the object type
            var cmdInstance = Activator.CreateInstance(cmdType);

            //Invoke the method we found using the instance we created, and return the output
            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });
            return result;
        }
    }
}
