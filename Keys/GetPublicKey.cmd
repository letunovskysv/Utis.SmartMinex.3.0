@ECHO OFF

SET sn="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe"

%sn% -k %~dp0\Utis.SmartMinex.snk
%sn% -p %~dp0\Utis.SmartMinex.snk %~dp0\Utis.SmartMinex.PublicKey
%sn% -tp %~dp0\Utis.SmartMinex.PublicKey
PAUSE