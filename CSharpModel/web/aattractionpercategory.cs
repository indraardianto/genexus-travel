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
   public class aattractionpercategory : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
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

      public aattractionpercategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aattractionpercategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aattractionpercategory objaattractionpercategory;
         objaattractionpercategory = new aattractionpercategory();
         objaattractionpercategory.context.SetSubmitInitialConfig(context);
         objaattractionpercategory.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaattractionpercategory);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aattractionpercategory)stateInfo).executePrivate();
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
            H0G0( false, 121) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 18, true, false, false, false, 0, 0, 0, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Only Category with Attractions", 333, Gx_line+50, 708, Gx_line+80, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "864b7102-42cc-44e8-af09-42afb8d6270d", "", context.GetTheme( )), 167, Gx_line+17, 309, Gx_line+117) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+121);
            /* Using cursor P000G2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0G2 = false;
               A9CountryId = P000G2_A9CountryId[0];
               A11CategoryId = P000G2_A11CategoryId[0];
               n11CategoryId = P000G2_n11CategoryId[0];
               A40000AttractionPhoto_GXI = P000G2_A40000AttractionPhoto_GXI[0];
               A10CountryName = P000G2_A10CountryName[0];
               A8AttractionName = P000G2_A8AttractionName[0];
               A7AttractionId = P000G2_A7AttractionId[0];
               A12CategoryName = P000G2_A12CategoryName[0];
               A13AttractionPhoto = P000G2_A13AttractionPhoto[0];
               A10CountryName = P000G2_A10CountryName[0];
               A12CategoryName = P000G2_A12CategoryName[0];
               H0G0( false, 42) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Category", 92, Gx_line+17, 137, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A12CategoryName, "")), 158, Gx_line+17, 419, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               H0G0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 250, Gx_line+17, 292, Gx_line+31, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Photo", 642, Gx_line+17, 684, Gx_line+31, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(192, Gx_line+33, 700, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Id", 192, Gx_line+17, 217, Gx_line+31, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Country", 442, Gx_line+17, 484, Gx_line+31, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
               while ( (pr_default.getStatus(0) != 101) && ( P000G2_A11CategoryId[0] == A11CategoryId ) )
               {
                  BRK0G2 = false;
                  A9CountryId = P000G2_A9CountryId[0];
                  A40000AttractionPhoto_GXI = P000G2_A40000AttractionPhoto_GXI[0];
                  A10CountryName = P000G2_A10CountryName[0];
                  A8AttractionName = P000G2_A8AttractionName[0];
                  A7AttractionId = P000G2_A7AttractionId[0];
                  A13AttractionPhoto = P000G2_A13AttractionPhoto[0];
                  A10CountryName = P000G2_A10CountryName[0];
                  H0G0( false, 91) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")), 192, Gx_line+33, 218, Gx_line+48, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), 250, Gx_line+33, 425, Gx_line+48, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : A13AttractionPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 633, Gx_line+17, 700, Gx_line+84) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), 442, Gx_line+33, 592, Gx_line+48, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+91);
                  BRK0G2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0G2 )
               {
                  BRK0G2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
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

      protected void H0G0( bool bFoot ,
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
         P000G2_A9CountryId = new short[1] ;
         P000G2_A11CategoryId = new short[1] ;
         P000G2_n11CategoryId = new bool[] {false} ;
         P000G2_A40000AttractionPhoto_GXI = new string[] {""} ;
         P000G2_A10CountryName = new string[] {""} ;
         P000G2_A8AttractionName = new string[] {""} ;
         P000G2_A7AttractionId = new short[1] ;
         P000G2_A12CategoryName = new string[] {""} ;
         P000G2_A13AttractionPhoto = new string[] {""} ;
         A40000AttractionPhoto_GXI = "";
         A10CountryName = "";
         A8AttractionName = "";
         A12CategoryName = "";
         A13AttractionPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aattractionpercategory__default(),
            new Object[][] {
                new Object[] {
               P000G2_A9CountryId, P000G2_A11CategoryId, P000G2_n11CategoryId, P000G2_A40000AttractionPhoto_GXI, P000G2_A10CountryName, P000G2_A8AttractionName, P000G2_A7AttractionId, P000G2_A12CategoryName, P000G2_A13AttractionPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A11CategoryId ;
      private short A7AttractionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A10CountryName ;
      private string A8AttractionName ;
      private string A12CategoryName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0G2 ;
      private bool n11CategoryId ;
      private string A40000AttractionPhoto_GXI ;
      private string A13AttractionPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A9CountryId ;
      private short[] P000G2_A11CategoryId ;
      private bool[] P000G2_n11CategoryId ;
      private string[] P000G2_A40000AttractionPhoto_GXI ;
      private string[] P000G2_A10CountryName ;
      private string[] P000G2_A8AttractionName ;
      private short[] P000G2_A7AttractionId ;
      private string[] P000G2_A12CategoryName ;
      private string[] P000G2_A13AttractionPhoto ;
   }

   public class aattractionpercategory__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[CountryId], T1.[CategoryId], T1.[AttractionPhoto_GXI], T2.[CountryName], T1.[AttractionName], T1.[AttractionId], T3.[CategoryName], T1.[AttractionPhoto] FROM (([Attraction] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) ORDER BY T1.[CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 50);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
       }
    }

 }

}
