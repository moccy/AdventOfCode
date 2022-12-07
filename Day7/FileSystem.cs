using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal class FileSystem
    {
        public Directory RootDirectory;
        Stack<Directory> directoryStack = new Stack<Directory>();
        public List<Directory> Directories = new List<Directory>();

        internal void Process(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (line[0] == '$')
                {
                    ProcessCommand(line[2..]);
                }
                else
                {
                    var splitLine = line.Split(" ");
                    var currentDir = directoryStack.Peek();
                    if (splitLine[0] == "dir")
                    {
                        var newDir = new Directory { Name = splitLine[1] };
                        currentDir.ChildDirectories.Add(newDir);
                        Directories.Add(newDir);
                    }
                    else
                    {
                        currentDir.Files.Add(new File { Name = splitLine[1], Size = long.Parse(splitLine[0]) });
                    }
                }
            }
        }

        private void ProcessCommand(string command)
        {
            var splitCommand = command.Split(" ");
            switch (splitCommand[0])
            {
                case "cd":
                    ChangeDirectory(splitCommand[1]);
                    break;
                case "ls":
                    break;
                default:
                    throw new ArgumentException($"Invalid command: {command}");
            }
        }

        private void ChangeDirectory(string dir)
        {
            if (dir == "..")
            {
                directoryStack.Pop();
            } 
            else if (dir == "/")
            {
                for (int i = 0; i < directoryStack.Count - 1; i++)
                {
                    directoryStack.Pop();
                }
                RootDirectory = new Directory { Name = dir };
                directoryStack.Push(RootDirectory);
            }
            else
            {
                var currentDirectory = directoryStack.Peek();
                var matchingChildDir = currentDirectory.ChildDirectories.FirstOrDefault(x => x.Name == dir);
                if (matchingChildDir != null)
                {
                    directoryStack.Push(matchingChildDir);
                } else
                {
                    directoryStack.Push(new Directory { Name = dir });
                }
            }
        }
    }
}