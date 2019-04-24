<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: ShowParam - Win32 (WCE x86) Release--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP25F.tmp" with contents
[
/nologo /W3 /GX- /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "_i386_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /D "NDEBUG" /D "_USRDLL" /D "SHOWPARAM_EXPORTS" /Fp"X86Rel/ShowParam.pch" /Yu"stdafx.h" /Fo"X86Rel/" /Gs8192 /GF /Oxs  /c 
"C:\YaoDurant\Win32\ShowParam\ShowParam.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP25F.tmp" 
Creating temporary file "C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP260.tmp" with contents
[
commctrl.lib coredll.lib corelibc.lib   /nologo /base:"0x00100000" /stack:0x10000,0x1000 /entry:"_DllMainCRTStartup" /dll /incremental:no /pdb:"X86Rel/ShowParam.pdb" /nodefaultlib:"OLDNAMES.lib" /nodefaultlib:libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /nodefaultlib:oldnames.lib /out:"X86Rel/ShowParam.dll" /implib:"X86Rel/ShowParam.lib" /subsystem:windowsce,3.00 /MACHINE:IX86   
.\X86Rel\StdAfx.obj
.\X86Rel\ShowParam.obj
]
Creating command line "link.exe @C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP260.tmp"
<h3>Output Window</h3>
Compiling...
ShowParam.cpp
Linking...
   Creating library X86Rel/ShowParam.lib and object X86Rel/ShowParam.exp
Creating temporary file "C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP264.bat" with contents
[
@echo off
copy .\X86Rel\ShowParam.dll ..\..\cs\PlatformInvoke\CallWin32\ShowParam.dll
]
Creating command line "C:\DOCUME~1\PAULMA~1.000\LOCALS~1\Temp\RSP264.bat"

        1 file(s) copied.



<h3>Results</h3>
ShowParam.dll - 0 error(s), 0 warning(s)
</pre>
</body>
</html>
