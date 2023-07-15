@echo off

set PROGRAM="bin\Debug\net6.0\findtext.exe %~1"

set OUT="%TEMP%\out.txt"

::Тест с нужными словами в нескольких строках
%PROGRAM% "wordsInSeveralLine.txt" "hello" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\wordsInSeveralLine-out.txt
if ERRORLEVEL 1 goto err

::Тест с лишним аргументом
%PROGRAM% "test.txt" "test" "err" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\errCountArgs-out.txt
if ERRORLEVEL 1 goto err

::Тест с отсутсвующим входным файлом
%PROGRAM% "gf.txt" "hello" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\errFile-out.txt
if ERRORLEVEL 1 goto err

::Тест в файле отсутвуют слова, которые нужно найти
%PROGRAM% "nullFindWord.txt" "test" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\nullFindWord-out.txt
if ERRORLEVEL 1 goto err

::Тест в одной стоке несколько слов, которые нужно найти
%PROGRAM% "severalWords.txt" "hello" > %OUT%
if NOT ERRORLEVEL 0 goto err
fc %OUT% test_data\severalWords-out.txt
if ERRORLEVEL 1 goto err

echo All tests passed
exit /B 0

:err
echo Program testing failed
exit /B 1