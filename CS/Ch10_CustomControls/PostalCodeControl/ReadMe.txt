======================================================================
Postal Code Custom Control
Developed for Windows Mobile Developer Conference
San Francisco, CA
March 2004

======================================================================
(c) Copyright 2004 Paul Yao and David Durant
All rights reserved.

======================================================================
An extra sample provided for readers of:
.NET Compact Framework Programming with C#
By Paul Yao and David Durant
Published by Addison Wesley

For details on this book and its source code, browse to the book's
web site: http://www.paulyao.com/cfbook
======================================================================
The Postal Code Custom Control shows a custom control that is created
by inheriting from the TextBox class. The control provides some degree
of filtering for postal codes. In some cases, postal codes are just
digits (as in USA, Mexico, Singapore, etc.); in some cases, postal
codes can contain letters (as in Canada, and United Kingdom) as well
as spaces and hyphens. 

Each country has rules about the format for a "correct" postal code.
While this sample control uses a very simple rule - that the maximum
number of characters has been entered - with a bit of work this can
be extended to help validate the postal codes by the custom control.
(For details on Postal Code formats, visit the Universal Postal Union
web site, http://www.upu.org.)

This sample shows four steps in the creation of a custom control:
1) Start_SimpleApp
2) Step1_Control_In_App
3) Step2_Control_In_Dll
4) Step3_Control_In_Designer

Details of each step appear below:
======================================================================
1) Start_SimpleApp
This is a simple Pocket PC program that has uses a TextBox to 
accept the postal code.

======================================================================
2) Step1_Control_In_App
In this step, a new class has been created to provide validation for
postal codes. The class is still built into the application, but is in
a separate class (which makes it easier to move it to its own DLL).

======================================================================
3) Step2_Control_In_Dll
In this step, the control class is put in a separate DLL. This is the
first step in giving a control a life of its own separate from its
application. But one more step is needed still...

======================================================================
4) Step3_Control_In_Designer
To create support for a custom control in the Visual Studio .NET Designer,
we must build a version of the DLL that relies on the desktop .NET 
Framework. And so getting designer support for a custom control involves 
creating two separate DLLs from the same (or similar) source files: a 
device-side DLL (which was done in step 3), and a designer-side DLL.

These DLLs are copied to known locations for the Designer to find 
them, namely:

Location of Device-Side DLL:
	..\CompactFrameworkSDK\v1.0.5000\Windows CE
Location of Designer DLL: 
	..\CompactFrameworkSDK\v1.0.5000\Windows CE\Designer

Both directories are installed within the Microsoft Visual Studio .NET 
2003 program files directory tree.

======================================================================

