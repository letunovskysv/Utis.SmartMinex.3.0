REM Запускать в среде Developer Command Prompt for vs 2022
REM Создание и установка с приватным ключом доступным для экcпорта:
makecert -r -sv "D:\Projects\Utis.SmartMinex.3.0\Keys\Utis.SmartMinex.pvk" -pe -n CN=Utis.SmartMinex -sr LocalMachine -ss root -# 16121972 -$ commercial -a sha256 -e 12/31/2049 -l www.lesev.ru -sky exchange "D:\Projects\Utis.SmartMinex.3.0\Keys\Utis.SmartMinex.cer"

REM Создание сертификата с включённым приватным ключом и паролем:
pvk2pfx -pvk "D:\Projects\Utis.SmartMinex.3.0\Keys\Utis.SmartMinex.pvk" -spc "D:\Projects\Utis.SmartMinex.3.0\Keys\Utis.SmartMinex.cer" -pfx "D:\Projects\Utis.SmartMinex.3.0\Keys\Utis.SmartMinex.pfx" -pi 7HfpJnvthm!

REM Создание PFX файла:
rem sn -k D:\Projects\Utis.SmartMinex.3.0\Keys\SmartMinex.snk