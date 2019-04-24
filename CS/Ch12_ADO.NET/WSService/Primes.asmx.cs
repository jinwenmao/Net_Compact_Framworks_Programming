//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace WSService
{
	/// <summary>
	/// Summary description for Primes.
	/// </summary>
	public class Primes : System.Web.Services.WebService
	{
		public Primes()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

      [WebMethod] public int GetFloorPrime( int Target ) 
      {
         if( Target <= 1 ) 
         {
            return 1;
         }
         if( Target == 2 ) 
         {
            return 2;
         }
         int k = Target - (Target % 2 == 0 ? 1 : 0);
         for( int j=k; j>=1; j-=2 )
         {
            if( IsPrime(j) ) 
            {
               return j;
            }
         }
         return 1;
      }

      private bool IsPrime( int Candidate) 
      {
         for( int j=3; j<=Candidate - 1; j+=2 )
         {
            if( Candidate % j == 0 ) 
            {
               return false;
            }
            if( j * j >= Candidate ) 
            {
               break;
            }
         } 
         return true;
      }
	}
}
