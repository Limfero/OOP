@echo off

set PROGRAM="bin\Debug\net6.0\multmatrix.exe %~1"

set OUT="%TEMP%\out.txt"

::Тест двух матриц
%PROGRAM% "1.txt" "1.txt" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\11-out.txt
if ERRORLEVEL 1 goto err

::Тест файла не существует
%PROGRAM% "1.txt" "3.txt" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\13-out.txt
if ERRORLEVEL 1 goto err

echo All tests passed
exit /B 0

:err
echo Program testing failed
exit /B 1

