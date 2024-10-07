//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SessionData –
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Archestra.Components;

class SessionDataEventArgs(TabPageItem page, bool isnew) : EventArgs
{
    public bool IsNew { get; set; } = isnew;
    public TabPageItem Page { get; set; } = page;
}

class SessionData
{
    public List<TabPageItem> Pages { get; } = [];

    public event EventHandler<SessionDataEventArgs> SessionChanged;

    public void ActivatePage(TabPageItem page)
    {
        if (Pages.Any(p => p.Name.Equals(page.Name)))
            SessionChanged?.Invoke(this, new SessionDataEventArgs(Pages.First(p => p.Name.Equals(page.Name)), false));
        else
        {
            Pages.Add(page);
            SessionChanged?.Invoke(this, new SessionDataEventArgs(page, true));
        }
    }
}
