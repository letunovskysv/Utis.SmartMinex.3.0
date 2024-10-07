//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Inspector – Боковая панель навигации по конфигурации Системы.
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Utis.SmartMinex.Archestra.Controls;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Archestra.Components.Shared;

public partial class Inspector : UtisPage
{
    #region Declarations

    const string IMGPATH = "i-";
    const string IMGEXT = ".webp";
    const string COLIMGEXT = "s" + IMGEXT;

    XState _state;
    List<InspectorNode> _nodes;
    UtisContextMenu _ctxmenu;

    [CascadingParameter]
    InspectorNode _selected { get; set; }

    InspectorNode? _itemedit;
    ElementReference? _input;
    string _input_val;

    string _ds_ctxmenu = $@"
<item name=""Открыть"" value=""{ZCommand.Open}""/>
<item name=""Удалить"" value=""DELETE""/>
<item name=""Переименовать"" value=""{ZCommand.Rename}""/>
<split/>
<item name=""Выгрузить"" value=""DATAEXPORT"">
  <item name=""В файл формата XML"" value=""{ZCommand.DataExportToXml}""/>
  <item name=""В файл формата JSON"" value=""{ZCommand.DataExportToJson}""/>
</item>
<item name=""Показать"" value=""DATAVIEW"">
  <item name=""Все записи"" value=""VIEWALL""/>
  <item name=""Первые 100 записей"" value=""VIEWFIRST""/>
  <item name=""Последние 100 записей"" value=""VIEWLAST""/>
</item>";

    #endregion Declarations

    protected override Task OnInitializedAsync()
    {
        _nodes ??= GetInspectorTree();
        _dsp.MetadataChanged += OnMetadataChanged;
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _dsp.MetadataChanged -= OnMetadataChanged;
        base.Dispose();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await _jsr.InvokeVoidAsync(WellKnownJS.RegistrySelf, DotNetObjectReference.Create(this));
    }

    protected override void OnAfterRender(bool firstRender)
    {
        _input?.FocusAsync();
    }

    Task OnItemClick(InspectorNode e)
    {
        _selected = e;
        _selected.Expanded = !e.Expanded;
        return Task.CompletedTask;
    }

    Task OnItemDblClick(InspectorNode e)
    {
        OpenNode(_selected = e);
        return Task.CompletedTask;
    }

    void OpenNode(InspectorNode node)
    {
        if (node.Editor != null)
            _session.ActivatePage(new TabPageItem
            {
                Name = node.Name,
                Icon = node.Icon,
                Type = node.Editor,
                Parameters = node.Parameters
            });
    }

    #region Events

    async Task OnMetadataChanged(long objid, TEntity? entity)
    {
        if (_nodes.RecursiveBy(n => n.Nodes).FirstOrDefault(n => n.Target.Id == objid) is InspectorNode node)
        {
            node.Target = entity;
            await InvokeAsync(StateHasChanged);
        }
    }

    #endregion Events

    #region Context menu

    async Task OnContextMenu(InspectorItemEventArgs e)
    {
        await _jsr.InvokeVoidAsync(WellKnownJS.RaiseWindowClick, nameof(OnContextMenuClose));
        await _ctxmenu.ShowModal(e.Item, e.Mouse);
    }

    async Task OnMenuClick(UtisMenuItemEventArgs e)
    {
        switch (e.Item.Value)
        {
            case ZCommand.Open:
                await OnItemDblClick(e.Target as InspectorNode);
                break;

            case ZCommand.Rename:
                {
                    if (e.Target is InspectorNode item)
                        RenameNode(item);
                }
                break;

            case ZCommand.DataExportToXml:
                {
                    if (e.Target is InspectorNode item)
                        await Download(string.Concat(item.Name, ".xml"), () => UtisDataExporter.ExportToXml(_dsp, item.Id));
                }
                break;

            case ZCommand.DataExportToJson:
                {
                    if (e.Target is InspectorNode item)
                        await Download(string.Concat(item.Name, ".json"), () => UtisDataExporter.ExportToJson(_dsp, item.Id));
                }
                break;
        }
    }

    [JSInvokable]
    public Task OnContextMenuClose() =>
        _ctxmenu.Close();

    #endregion Context menu

    #region Inspector

    /// <summary> Возвращает дерево конфигурации.</summary>
    List<InspectorNode> GetInspectorTree()
    {
        var nodes = _dsp.Select<TManifest>().Select(ent => new InspectorNode(ent, 0, string.Concat(IMGPATH, ent.Type.ToString().ToLower(), IMGEXT))).ToList();
        nodes[0].Nodes = _dsp.Select(TType.Object, TType.Component)
            .OrderBy(ent => ent.Ordinal)
            .Select(ent => new InspectorNode(ent, 1, string.Concat(IMGPATH, ((TType)ent.Id).ToString().ToLower(), COLIMGEXT))).ToList();

        var attrs = _dsp.GetObject(TType.Attribute);
        nodes[0].Nodes.ForEach(p => p.Nodes = ReadNodes(_dsp.ParentBy(p.Id), 2, attrs));

        nodes[0].Expanded = true;
        return nodes;
    }

    List<InspectorNode> ReadNodes(List<TEntity> entities, int level, TEntity attrs) =>
        entities
            .Where(ent => ent.Type > TType.Helper)
            .OrderBy(ent => ent.Type)
            .ThenBy(ent => ent.Name)
            .Select(ent =>
            {
                var node = new InspectorNode(ent, level, string.Concat(IMGPATH, ent.Type.ToString().ToLower(), IMGEXT));
                if (ent is TObject obj && obj.Attributes != null)
                {
                    var iattr = new InspectorNode(attrs, level + 1, string.Concat(IMGPATH, ((TType)attrs.Id).ToString().ToLower(), COLIMGEXT))
                    {
                        Nodes = []
                    };
                    node.Nodes = [iattr];
                    obj.Attributes.OrderBy(ai => ai.Ordinal).ToList().ForEach(ai =>
                        iattr.Nodes.Add(new InspectorNode(ai, level + 2, string.Concat(IMGPATH, ((TType)attrs.Id).ToString().ToLower(), IMGEXT))));
                }
                var childs = _dsp.ParentBy(ent.Id);
                if (childs.Count > 0)
                    node.Nodes = ReadNodes(childs, level + 1, attrs);

                return node;
            }
        ).ToList();

    void RenameNode(InspectorNode item)
    {
        _state = XState.Edit;
        _itemedit = item;
    }

    void CloseEdit(bool saved)
    {
        if (_itemedit != null)
        {
            _input = null;
            if (saved)
            {
                _itemedit.Name = _input_val;
                _dsp.Update(_itemedit.Target);
            }
            _itemedit = null;
        }
    }

    #endregion Inspector

    #region Navigation

    Task OnKeyDown(KeyboardEventArgs e)
    {
        if (_state != XState.Edit)
        {
            if (e.Key == Keyboard.Left && _selected.Expanded)
                _selected.Expanded = false;

            else if (e.Key == Keyboard.Right && !_selected.Expanded)
                _selected.Expanded = true;

            else if (e.Key == Keyboard.Up || e.Key == Keyboard.Left)
            {
                InspectorNode? prev = null;
                if (PrevNode(_nodes, false, ref prev))
                    _selected = prev == null ? LastNode(_nodes) : prev;
            }
            else if ((e.Key == Keyboard.Down || e.Key == Keyboard.Right) && NextNode(_nodes, false, out var next))
                _selected = next == null ? _nodes[0] : next;

            else if (e.Key == Keyboard.Enter)
                OpenNode(_selected);

            else if (e.Key == Keyboard.F2 && _selected != null)
                RenameNode(_selected);
        }
        else
        {
            if (e.Key == Keyboard.Escape)
                CloseEdit(false);

            else if (e.Key == Keyboard.Enter)
                CloseEdit(true);
        }
        LastNode(_nodes);

        return Task.CompletedTask;
    }

    bool PrevNode(List<InspectorNode> nodes, bool find, ref InspectorNode? prev)
    {
        foreach (var node in nodes)
        {
            find = node == _selected;
            if (find) return true;
            prev = node;
            if (node.Expanded && (find = PrevNode(node.Nodes, find, ref prev)) && prev != null)
                return true;
        }
        return find;
    }

    bool NextNode(List<InspectorNode> nodes, bool find, out InspectorNode? next)
    {
        next = null;
        foreach (var node in nodes)
        {
            if (find)
            {
                next = node;
                return true;
            }
            find = node == _selected;
            if (node.Expanded && (find = NextNode(node.Nodes, find, out next)) && next != null)
                return true;
        }
        return find;
    }

    InspectorNode LastNode(List<InspectorNode> nodes)
    {
        InspectorNode? last;
        while ((last = nodes.Last()).Expanded)
            nodes = last.Nodes;

        return last;
    }

    #endregion Navigation

    #region Nested types

    enum XState
    {
        None, Edit
    }

    class ZCommand
    {
        public const string Open = "OPEN";
        public const string Rename = "RENAME";
        public const string DataExportToXml = "DATAEXPORTXML";
        public const string DataExportToJson = "DATAEXPORTJSON";
    }

    #endregion Nested types
}
