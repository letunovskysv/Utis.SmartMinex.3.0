using Utis.SmartMinex.Utils;

if (args.Length > 0 && args[0] == "model")
{
    var cfg = MinexModelTypeConverter.Build("ZoneType",
        @"D:\Projects\Utis.SmartMinex.3.0\Server\Utis.SmartMinex.Configuration\solutions\dispatcher\data\catalogs\",
        "Host=localhost;Database=PTKGD001;Username=postgres;Password=qwe890-;Include Error Detail=true",
        "Host=localhost;Database=ProductionDB_LS;Username=postgres;Password=qwe890-;Include Error Detail=true",
        "Host=localhost;Database=MetadataDB_LS;Username=postgres;Password=qwe890-;Include Error Detail=true");
}
else if (args.Length > 0 && args[0] == "spgt")
{
    var cfg = SpgtModelTypeConverter.Build("Utis.Spgt.ProductionModel",
        @"D:\Projects\Utis.SmartMinex.3.0\Server\Utis.SmartMinex.Configuration\solutions\seniorlamp\data\spgt\",
        "Host=localhost;Database=PTKLP001;Username=postgres;Password=qwe890-;Include Error Detail=true");
}
else if (args.Length > 0 && args[0] == "map")
{
    MapMinexConverter.ReadScheme(@"D:\Projects\Utis.SmartMinex.3.0\Server\Utis.SmartMinex.Configuration\maps\Рудник Октябрьский.mapx", false);
}
else
    DbInitFileMaker.Build(
        args.Length > 0 ? args[0] : Path.Combine("D:\\Projects\\Utis.SmartMinex.3.0\\Server\\Utis.SmartMinex.Configuration", "config\\"),
        args.Length > 1 ? args[1] : Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "dbinit.smx"),
        args.Length > 2 ? args[2] : "-release");
