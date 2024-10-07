//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Compress – Сжатие и объединение CSS-файлов.
// commandLineArgs: "$(SolutionDir)Tools\Utis.SmartMinex.Configurator\wwwroot\styles\elements" "$(SolutionDir)Tools\Utis.SmartMinex.Configurator\wwwroot\styles\utis.css"
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Utils
{
    #region Using
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    #endregion Using

    class CssCompressor
    {
        public static void Concat(string sources, string target, bool compress)
        {
            StringBuilder res = new();
            foreach (var filename in Directory.GetFiles(sources, "*.css", SearchOption.AllDirectories).OrderBy(f => f))
                if (compress)
                {
                    Mode last = Mode.None, mode = Mode.None;
                    var line = string.Empty;
                    char prev = '\0';
                    foreach (char next in File.ReadAllText(filename, Encoding.UTF8))
                    {
                        if (mode == Mode.Skip)
                        {
                            if (prev == '*' && next == '/')
                                mode = Mode.None;

                            prev = next;
                            continue;
                        }
                        if (next == 13)
                        {
                            res.Append(line.Trim());
                            line = string.Empty;
                            continue;
                        }
                        if (next < 32) continue;
                        if (next == 32 && (
                            mode == Mode.None && (prev < 48)
                            || mode == Mode.Value && (prev == ',' || prev == ':' || prev == 32)))
                            continue;

                        if (next == '{' && prev == 32)
                            line = line.TrimEnd();

                        line += next;
                        if (next == '"')
                        {
                            mode = mode != Mode.All ? Mode.All : last;
                            if (mode != Mode.All) last = mode;
                        }
                        else if (next == ':')
                            mode = Mode.Value;

                        else if (next == ';' || next == '}')
                            mode = Mode.None;

                        else if (prev == '/' && next == '*')
                        {
                            line = line[..^2];
                            mode = Mode.Skip;
                        }
                        prev = next;
                    }
                    res.Append(line.Trim());
                }
                else
                    res.Append(File.ReadAllText(filename, Encoding.UTF8));

            var output = string.IsNullOrEmpty(Path.GetDirectoryName(target))
                ? Path.Combine(Environment.CurrentDirectory, target)
                : target;

            File.WriteAllText(output, res.ToString(), new UTF8Encoding(false));
            Console.WriteLine(string.Concat("CSS OUTPUT: ", output));
        }
    }

    enum Mode
    {
        None,
        All,
        Value,
        Skip
    }
}
