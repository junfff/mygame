@echo off
echo protoc -I=$SRC_DIR --cpp_out=$DST_DIR $SRC_DIR/addressbook.proto  --net2 --ctor --lobby  person.proto
echo protoc -I=$SRC_DIR --cpp_out=$DST_DIR $SRC_DIR/addressbook.proto  
echo %toolDir%\protoc-3.5.1-1-windows-x86_64.exe %%f --csharp_out %msgDir%\%%~nf.cs 

chdir %~dp0

set "curDir=%~dp0"

cd %~d0
cd %~dp0

set "toolDir=%curDir%ProtoGen"

set "protoDir=%curDir%ProtoFile"

set "msgDir=%curDir%ProtoMsg"


%toolDir%\protoc-3.5.1-1-windows-x86_64.exe -I=./ProtoFile --csharp_out=./ProtoMsg ./ProtoFile/person.proto


echo Íê³É£¡

pause  
