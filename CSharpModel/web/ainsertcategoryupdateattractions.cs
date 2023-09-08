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
   public class ainsertcategoryupdateattractions : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public ainsertcategoryupdateattractions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public ainsertcategoryupdateattractions( IGxContext context )
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
         ainsertcategoryupdateattractions objainsertcategoryupdateattractions;
         objainsertcategoryupdateattractions = new ainsertcategoryupdateattractions();
         objainsertcategoryupdateattractions.context.SetSubmitInitialConfig(context);
         objainsertcategoryupdateattractions.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objainsertcategoryupdateattractions);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ainsertcategoryupdateattractions)stateInfo).executePrivate();
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
         AV12category.gxTpr_Categoryname = "Tourist site";
         if ( AV12category.Insert() )
         {
            /* Using cursor P000U2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A9CountryId = P000U2_A9CountryId[0];
               A15CityId = P000U2_A15CityId[0];
               A11CategoryId = P000U2_A11CategoryId[0];
               n11CategoryId = P000U2_n11CategoryId[0];
               A12CategoryName = P000U2_A12CategoryName[0];
               A16CityName = P000U2_A16CityName[0];
               A7AttractionId = P000U2_A7AttractionId[0];
               A16CityName = P000U2_A16CityName[0];
               A12CategoryName = P000U2_A12CategoryName[0];
               AV9attraction.Load(A7AttractionId);
               AV9attraction.gxTpr_Categoryid = AV12category.gxTpr_Categoryid;
               AV9attraction.Update();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            context.CommitDataStores("insertcategoryupdateattractions",pr_default);
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV12category = new SdtCategory(context);
         scmdbuf = "";
         P000U2_A9CountryId = new short[1] ;
         P000U2_A15CityId = new short[1] ;
         P000U2_A11CategoryId = new short[1] ;
         P000U2_n11CategoryId = new bool[] {false} ;
         P000U2_A12CategoryName = new string[] {""} ;
         P000U2_A16CityName = new string[] {""} ;
         P000U2_A7AttractionId = new short[1] ;
         A12CategoryName = "";
         A16CityName = "";
         AV9attraction = new SdtAttraction(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainsertcategoryupdateattractions__default(),
            new Object[][] {
                new Object[] {
               P000U2_A9CountryId, P000U2_A15CityId, P000U2_A11CategoryId, P000U2_n11CategoryId, P000U2_A12CategoryName, P000U2_A16CityName, P000U2_A7AttractionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A15CityId ;
      private short A11CategoryId ;
      private short A7AttractionId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A12CategoryName ;
      private string A16CityName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n11CategoryId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000U2_A9CountryId ;
      private short[] P000U2_A15CityId ;
      private short[] P000U2_A11CategoryId ;
      private bool[] P000U2_n11CategoryId ;
      private string[] P000U2_A12CategoryName ;
      private string[] P000U2_A16CityName ;
      private short[] P000U2_A7AttractionId ;
      private SdtAttraction AV9attraction ;
      private SdtCategory AV12category ;
   }

   public class ainsertcategoryupdateattractions__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000U2;
          prmP000U2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000U2", "SELECT T1.[CountryId], T1.[CityId], T1.[CategoryId], T3.[CategoryName], T2.[CityName], T1.[AttractionId] FROM (([Attraction] T1 INNER JOIN [CountryCity] T2 ON T2.[CountryId] = T1.[CountryId] AND T2.[CityId] = T1.[CityId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) WHERE (T2.[CityName] = 'Maumere') AND (T3.[CategoryName] = 'Museum') ORDER BY T1.[AttractionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
