//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisClock –
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
#endregion Using

namespace Utis.SmartMinex.Client;

public partial class UtisClock : UtisComponent
{
    #region Declarations

    Timer _timer;
    MarkupString _dial;
    int _hour = 0;
    int _minute = 0;
    int _second = 0;

    string AsStr(double v) => v.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);

    #endregion Declarations

    protected override Task OnInitializedAsync()
    {
        var canvas = new System.Text.StringBuilder();
        for (int i = -29; i <= 30; i++)
        {
            var ang = Math.PI / 30 * i;
            var a = i % 5 == 0 ? 35d : 40d;
            var x1 = a * Math.Cos(ang);
            var y1 = a * Math.Sin(ang);
            var x2 = 45d * Math.Cos(ang);
            var y2 = 45d * Math.Sin(ang);
            if (i % 5 == 0)
                canvas.Append($"<line x1=\"{AsStr(50d + x1)}\" y1=\"{AsStr(50d + y1)}\" x2=\"{AsStr(50d + x2)}\" y2=\"{AsStr(50d + y2)}\" stroke=\"black\" stroke-width=\"3\"/>");
            else
                canvas.Append($"<line x1=\"{AsStr(50d + x1)}\" y1=\"{AsStr(50d + y1)}\" x2=\"{AsStr(50d + x2)}\" y2=\"{AsStr(50d + y2)}\" stroke=\"black\"/>");
        }
        canvas.Append("<text x=\"34\" y=\"75\" style=\"font-size:12px\">УТИС</text>");
        _dial = new MarkupString(canvas.ToString());
        Tick();
        _timer = new Timer((e) => InvokeAsync(() => Tick()), null, 1000, 1000);
        return base.OnInitializedAsync();
    }

    public void Tick()
    {
        var now = DateTime.Now;
        _hour = (now.Hour > 12 ? now.Hour - 12 : now.Hour) * 30 + now.Minute / 2;
        _minute = now.Minute * 6;
        _second = now.Second * 6;
        StateHasChanged();
    }

    public override void Dispose()
    {
        _timer.Dispose();
        base.Dispose();
    }
}