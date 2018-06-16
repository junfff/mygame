@echo off
echo protoc -I=$SRC_DIR --cpp_out=$DST_DIR $SRC_DIR/addressbook.proto  --net2 --ctor --lobby  person.proto
echo protoc -I=$SRC_DIR --cpp_out=$DST_DIR $SRC_DIR/addressbook.proto  
echo %toolDir%\protoc-3.5.1-1-windows-x86_64.exe %%f --csharp_out %msgDir%\%%~nf.cs  protoc-3.5.1-1-windows-x86_64.exe

chdir %~dp0

set "curDir=%~dp0"

cd %~d0
cd %~dp0

set "toolDir=%curDir%ProtoGen"

set "protoDir=%curDir%ProtoFile"

set "msgDir=%curDir%ProtoMsg"


set Path=ProtoGen\protoc.exe 

for /f "delims=" %%i in ('dir /b ProtoFile "ProtoFile/*.proto"') do (
 echo %%i
 %Path% ProtoFile/%%i --csharp_out=ProtoMsg
)


echo Íê³É£¡

pause  
