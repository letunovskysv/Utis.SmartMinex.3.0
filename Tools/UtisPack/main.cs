//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WebPack – Сжатие и объединение JS,CSS-файлов.
//--------------------------------------------------------------------------------------------------
using Utis.SmartMinex.Utils;

bool compress = true;
for (int i = 0; i < args.Length; i += 2)
{
    if (args[0] == "-no")
    {
        compress = false;
        i--;
        continue;
    }
    switch (Path.GetExtension(args[i + 1]))
    {
        case ".js":
            JsCompressor.Concat(args[i], args[i + 1], compress);
            break;
        case ".css":
            CssCompressor.Concat(args[i], args[i + 1], compress);
            break;
    }
}