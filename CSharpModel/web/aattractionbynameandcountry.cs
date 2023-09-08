using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aattractionbynameandcountry : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "CountryId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8CountryId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9NameForm = GetPar( "NameForm");
                  AV10NameTo = GetPar( "NameTo");
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aattractionbynameandcountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aattractionbynameandcountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CountryId ,
                           ref string aP1_NameForm ,
                           string aP2_NameTo )
      {
         this.AV8CountryId = aP0_CountryId;
         this.AV9NameForm = aP1_NameForm;
         this.AV10NameTo = aP2_NameTo;
         initialize();
         executePrivate();
         aP1_NameForm=this.AV9NameForm;
      }

      public void executeSubmit( short aP0_CountryId ,
                                 ref string aP1_NameForm ,
                                 string aP2_NameTo )
      {
         aattractionbynameandcountry objaattractionbynameandcountry;
         objaattractionbynameandcountry = new aattractionbynameandcountry();
         objaattractionbynameandcountry.AV8CountryId = aP0_CountryId;
         objaattractionbynameandcountry.AV9NameForm = aP1_NameForm;
         objaattractionbynameandcountry.AV10NameTo = aP2_NameTo;
         objaattractionbynameandcountry.context.SetSubmitInitialConfig(context);
         objaattractionbynameandcountry.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaattractionbynameandcountry);
         aP1_NameForm=this.AV9NameForm;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aattractionbynameandcountry)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0M0( false, 123) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 18, true, false, false, false, 0, 0, 0, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Attraction List", 367, Gx_line+50, 542, Gx_line+80, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "864b7102-42cc-44e8-af09-42afb8d6270d", "", context.GetTheme( )), 200, Gx_line+17, 342, Gx_line+117) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+123);
            H0M0( false, 38) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Name", 250, Gx_line+17, 292, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Photo", 642, Gx_line+17, 684, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(192, Gx_line+33, 700, Gx_line+33, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Id", 192, Gx_line+17, 217, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Country", 442, Gx_line+17, 484, Gx_line+31, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+38);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV9NameForm ,
                                                 AV10NameTo ,
                                                 AV8CountryId ,
                                                 A8AttractionName ,
                                                 A9CountryId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P000M2 */
            pr_default.execute(0, new Object[] {AV9NameForm, AV10NameTo, AV8CountryId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A9CountryId = P000M2_A9CountryId[0];
               A8AttractionName = P000M2_A8AttractionName[0];
               A40000AttractionPhoto_GXI = P000M2_A40000AttractionPhoto_GXI[0];
               A7AttractionId = P000M2_A7AttractionId[0];
               A10CountryName = P000M2_A10CountryName[0];
               A13AttractionPhoto = P000M2_A13AttractionPhoto[0];
               A10CountryName = P000M2_A10CountryName[0];
               H0M0( false, 89) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")), 192, Gx_line+33, 218, Gx_line+48, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), 250, Gx_line+33, 425, Gx_line+48, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : A13AttractionPhoto);
               getPrinter().GxDrawBitMap(sImgUrl, 633, Gx_line+17, 700, Gx_line+84) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), 442, Gx_line+33, 592, Gx_line+48, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+89);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0M0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0M0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         A8AttractionName = "";
         P000M2_A9CountryId = new short[1] ;
         P000M2_A8AttractionName = new string[] {""} ;
         P000M2_A40000AttractionPhoto_GXI = new string[] {""} ;
         P000M2_A7AttractionId = new short[1] ;
         P000M2_A10CountryName = new string[] {""} ;
         P000M2_A13AttractionPhoto = new string[] {""} ;
         A40000AttractionPhoto_GXI = "";
         A10CountryName = "";
         A13AttractionPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aattractionbynameandcountry__default(),
            new Object[][] {
                new Object[] {
               P000M2_A9CountryId, P000M2_A8AttractionName, P000M2_A40000AttractionPhoto_GXI, P000M2_A7AttractionId, P000M2_A10CountryName, P000M2_A13AttractionPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8CountryId ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A7AttractionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9NameForm ;
      private string AV10NameTo ;
      private string scmdbuf ;
      private string A8AttractionName ;
      private string A10CountryName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000AttractionPhoto_GXI ;
      private string A13AttractionPhoto ;
      private IGxDataStore dsDefault ;
      private string aP1_NameForm ;
      private IDataStoreProvider pr_default ;
      private short[] P000M2_A9CountryId ;
      private string[] P000M2_A8AttractionName ;
      private string[] P000M2_A40000AttractionPhoto_GXI ;
      private short[] P000M2_A7AttractionId ;
      private string[] P000M2_A10CountryName ;
      private string[] P000M2_A13AttractionPhoto ;
   }

   public class aattractionbynameandcountry__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000M2( IGxContext context ,
                                             string AV9NameForm ,
                                             string AV10NameTo ,
                                             short AV8CountryId ,
                                             string A8AttractionName ,
                                             short A9CountryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CountryId], T1.[AttractionName], T1.[AttractionPhoto_GXI], T1.[AttractionId], T2.[CountryName], T1.[AttractionPhoto] FROM ([Attraction] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9NameForm)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] >= @AV9NameForm)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10NameTo)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] <= @AV10NameTo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8CountryId) )
         {
            AddWhere(sWhereString, "(T1.[CountryId] = @AV8CountryId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[CountryName]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000M2;
          prmP000M2 = new Object[] {
          new ParDef("@AV9NameForm",GXType.Char,50,0) ,
          new ParDef("@AV10NameTo",GXType.Char,50,0) ,
          new ParDef("@AV8CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
       }
    }

 }

}
