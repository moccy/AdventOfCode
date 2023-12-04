using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y2022D07;

class Directory
{
    public string Name { get; set; }
    public List<Directory> ChildDirectories { get; set; } = new List<Directory>();
    public List<File> Files { get; set; } = new List<File>();
    public long TopLevelSize { get => Files.Sum(x => x.Size); }
    public long Size { get => TopLevelSize + ChildDirectories.Sum(x => x.Size); }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"- {Name} (dir)");
        foreach(var directory in ChildDirectories)
        {
            stringBuilder.Append($"\t{directory}");
        }
        foreach(var file in Files)
        {
            stringBuilder.Append($"\t- {file.Name} (file, size={file.Size})");
        }

        return stringBuilder.ToString();
    }
}