//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TStringWriter – Аналог StringWriter поддерживающий кодовую страницу.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Аналог StringWriter поддерживающий кодовую страницу.</summary>
public class TStringWriter : StringWriter
{
    readonly Encoding _encoding;

    public TStringWriter() : this(Encoding.Default)
    { }

    public TStringWriter(Encoding encoding)
    {
        _encoding = encoding;
    }

    public override Encoding Encoding => _encoding;
}
