//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Windows.Forms;

namespace MultiThreaded
{
   /// <summary>
   /// Summary description for Global.
   /// </summary>
   public class Global
   {
      public Global()
      {
         //
         // TODO: Add constructor logic here
         //
      }

      static internal ArrayList arrForms = new ArrayList();

      static internal Form OpenForm(Type typeForm) 
      {
         //  Check to see if a form of the
         //     requested type already exists.
         foreach( Form frmLoop in arrForms )
         {
            if( frmLoop.GetType() == typeForm )
            {
               return frmLoop;
            }
         }

         //  if it does not exist, create it
         //     and add it to the collection.
         Form frmWork = null;
         if( typeForm == 
            Type.GetType("MultiThreaded.FormTemperature") ) 
         {
            frmWork = new FormTemperature();
         }
         if( typeForm == 
            Type.GetType("MultiThreaded.FormPressure") ) 
         {
            frmWork = new FormPressure();
         }
         if( typeForm == 
            Type.GetType("MultiThreaded.FormPrecipitation") ) 
         {
            frmWork = new FormPrecipitation();
         }
         if( frmWork != null )
         {
            arrForms.Add(frmWork);
         }
         return frmWork;
      }

      static internal void RemoveForm( Form frmRemovee ) 
      {
         arrForms.Remove( frmRemovee );
      }

   }
}
