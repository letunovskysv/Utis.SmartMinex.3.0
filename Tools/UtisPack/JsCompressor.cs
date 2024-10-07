//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: JsCompressor – Сжатие и объединение JS-файлов.
// commandLineArgs: "$(SolutionDir)Tools\Utis.SmartMinex.Configurator\wwwroot\scripts\elements" "$(SolutionDir)Tools\Utis.SmartMinex.Configurator\wwwroot\scripts\utis.js"
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Utils
{
    #region Using
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    #endregion Using

    class JsCompressor
    {
        public static void Concat(string sources, string target, bool compress)
        {
            const string REMARKS = @"//.*?$|/\*.*\*/";
            StringBuilder res = new();
            foreach (var filename in Directory.GetFiles(sources, "*.js", SearchOption.AllDirectories).OrderBy(f => f))
            {
                if (compress)
                {
                    foreach (string str in File.ReadAllLines(filename, Encoding.UTF8))
                    {
                        var line = str.Trim();
                        if (Regex.IsMatch(line, REMARKS, RegexOptions.RightToLeft))
                            line = Regex.Replace(line, REMARKS, string.Empty, RegexOptions.RightToLeft).Trim();

                        if (line != string.Empty)
                            res.AppendLine(line);
                    }
                }
                else res.Append(File.ReadAllText(filename, Encoding.UTF8));
            }
            var output = string.IsNullOrEmpty(Path.GetDirectoryName(target))
                ? Path.Combine(Environment.CurrentDirectory, target)
                : target;

            File.WriteAllText(output, res.ToString(), Encoding.UTF8);
            Console.WriteLine(string.Concat("JS OUTPUT: ", output));
        }
    }
}
