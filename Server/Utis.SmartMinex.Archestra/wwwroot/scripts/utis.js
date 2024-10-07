var dotnet;
$ = (id) => document.getElementById(id);
$alert = (e) => alert(JSON.stringify(e, null, 2));
$invokeAsync = (a) => DotNet.invokeMethodAsync('Utis.SmartMinex.Archestra', a);
$invokeAsync = (a, p) => DotNet.invokeMethodAsync('Utis.SmartMinex.Archestra', a, p);
invokeAsync = (a) => dotnet.invokeMethodAsync(a);
invokeAsync = (a, p) => dotnet.invokeMethodAsync(a, p);
initDN = (e) => dotnet = e;
raiseWindowClick = (method) =>
window.onclick = () => invokeAsync(method);
resetWindowClick = () =>
window.onclick = () => window.onclick = null;
downloadStream = async (filename, stream) => {
const buf = await stream.arrayBuffer();
const a = document.createElement('a');
a.href = URL.createObjectURL(new Blob([buf]));
a.download = filename ?? '';
a.click();
a.remove();
URL.revokeObjectURL(url);
}
