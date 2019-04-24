using System;
using System.Text;
using System.Runtime.InteropServices;

namespace mPrint
{

	/// Possible status values for the mPrint SDK.
	/// This enumeration defines the possible return values for GetLastError when
	/// an mPrint method returns false.
	///
	/// @version 2.0
	/// @since 1.0
	public enum MPRINT_RESULT: byte
	{		
		/** Job was successfully submitted  */
		MPRINT_SUCCESS = 0,

		/** Memory problem - probably out of available memory  */
		MPRINT_MEMORY_ERROR,

		/** The user canceled the request */
		MPRINT_USER_CANCELLED,

		/** There is no content transformation available for the document type */
		MPRINT_CT_NOT_AVAILABLE,

		/** There was a NULL pointer in the mPrint SDK */
		MPRINT_NULL_POINTER,

		/** There was a problem reading the document */
		MPRINT_DOCUMENT_ERROR,

		/** The target printer is currently busy and cannot be used */
		MPRINT_PRINTER_BUSY,

		/** There was in non-recoverable internal error in the mPrint SDK */
		MPRINT_INTERNAL_ERROR,

		/** The background printing process is currently busy and can't be used */
		MPRINT_PRINT_SUBSYSTEM_BUSY,

		/** File I/O failure during Inline CT */
		MPRINT_FILE_IO_ERROR,

		/** The interface called is not supported in this version */
		MPRINT_NOT_IMPLEMENTED
	}; //MPRINT_RESULT	
	
	public class mPrintWrapper
	{
		[DllImport("mPrintWrapper.dll", EntryPoint="PrintJob1")]
		public static extern bool PrintJob(string szContentName);

		[DllImport("mPrintWrapper.dll", EntryPoint="PrintJob3")]
		public static extern bool PrintJob(byte[] pbyMemoryBuffer, System.UInt32 uBufferLen, string szContentType);

		[DllImport("mPrintWrapper.dll", CharSet=CharSet.Unicode)]
		public static extern UInt32 GetVersion(StringBuilder szVersionInfo, UInt32 uBufferSize );

		[DllImport("mPrintWrapper.dll")]
		public static extern MPRINT_RESULT GetLastError();		
	}

	public class mPrintRenderWrapper
	{
		[DllImport("mPrintWrapper.dll")]
		public static extern IntPtr CreatePrinterContext();

		[DllImport("mPrintWrapper.dll")]
		public static extern void DeletePrinterContext( IntPtr hPrinterContext );				
	}

	public class WinCEGDIHelper
	{		
		[DllImport("coredll.dll")]
		public extern static IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("coredll.dll")]
		public extern static Int32 DeleteObject(IntPtr hgdiobj);

		//[DllImport("coredll.dll")] 
		//public extern static bool Rectangle(IntPtr hdc, Int32 nLeftRect, Int32 nTopRect, Int32 nRightRect, Int32 nBottomRect);
				
		[DllImport("mPrintWrapper.dll")]
		public static extern int NativeStartDoc ( IntPtr hPrinterContext, string szDocName );

		[DllImport("mPrintWrapper.dll")]
		public static extern int NativeStartPage ( IntPtr hPrinterContext );

		[DllImport("mPrintWrapper.dll")]
		public static extern int NativeEndPage ( IntPtr hPrinterContext );

		[DllImport("mPrintWrapper.dll")]
		public static extern int NativeEndDoc ( IntPtr hPrinterContext );

		[DllImport("mPrintWrapper.dll")]
		public static extern IntPtr NativeCreatePen (Int32 Red, Int32 Green, Int32 Blue );

		[DllImport("mPrintWrapper.dll")]
		public static extern IntPtr NativeCreateFont (string szFaceName,Int32 height);

		[DllImport("mPrintWrapper.dll")]
		public static extern void NativeSetTextColor (IntPtr hPrinterContext, Int32 Red, Int32 Green, Int32 Blue );

		[DllImport("mPrintWrapper.dll")]
		public static extern void NativeGetTextExtentPoint(IntPtr hPrinterContext, ref Int32 cx, ref Int32 cy);

		[DllImport("mPrintWrapper.dll")]
		public static extern void NativeExtTextOut(IntPtr hPrinterContext, string szLineOfText, Int32 x, Int32 y);		
	}

}
