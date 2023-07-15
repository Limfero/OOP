@echo off

set PROGRAM="bin\Debug\net6.0\flipbyte.exe %~1"

set OUT="%TEMP%\out.txt"

::Тест цифры 6
%PROGRAM% 6 > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\6-out.txt
if ERRORLEVEL 1 goto err

::Тест цифры 256
%PROGRAM% 256 > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\256-out.txt
if ERRORLEVEL 1 goto err

::Тест не цифры
%PROGRAM% a > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\a-out.txt
if ERRORLEVEL 1 goto err

::Тест без аргументов
%PROGRAM% > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\-out.txt
if ERRORLEVEL 1 goto err


echo All tests passed
exit /B 0

:err
echo Program testing failed
exit /B 1

