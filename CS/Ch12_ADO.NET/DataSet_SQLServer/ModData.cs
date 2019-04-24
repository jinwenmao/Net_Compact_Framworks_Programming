//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;

namespace CreateDatabase
{
	/// <summary>
	/// Summary description for ModData.
	/// </summary>
	public class ModData
	{
      static internal DataSet dsetDB;
      static internal SqlDataAdapter daptProducts;
      static internal SqlDataAdapter daptCategories;
   } 
}
