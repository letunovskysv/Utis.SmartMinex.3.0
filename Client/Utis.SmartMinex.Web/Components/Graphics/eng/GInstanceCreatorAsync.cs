using Microsoft.JSInterop;

namespace Utis.SmartMinex.Client;

public class GInstanceCreatorAsync(IJSRuntime jsr)
{
    protected IJSRuntime _jsr { get; } = jsr;

    public async Task<BabylonInstance> CreateBabylonAsync() =>
        new(_jsr, await _jsr.InvokeAsync<IJSObjectReference>("import", "./scripts/babylonInterop.js"));
}
