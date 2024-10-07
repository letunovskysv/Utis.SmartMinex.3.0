using Microsoft.JSInterop;

namespace Utis.SmartMinex.Client;

public class BabylonInstance
{
    readonly IJSRuntime _jsr;
    readonly IJSObjectReference _wrapper;

    public BabylonInstance(IJSRuntime jsr, IJSObjectReference babylonWrapper)
    {
        _jsr = jsr;
        _wrapper = babylonWrapper;
    }

    public async Task CreateScheme(string id, GData data) =>
        await _wrapper.InvokeVoidAsync("createScheme", id, data);

    public async Task Test() =>
        await _wrapper.InvokeVoidAsync("testScheme");
}
