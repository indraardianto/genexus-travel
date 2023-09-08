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
   public class newtrip : GXProcedure
   {
      public newtrip( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public newtrip( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AttractionId ,
                           out short aP1_trips )
      {
         this.AV8AttractionId = aP0_AttractionId;
         this.AV10trips = 0 ;
         initialize();
         executePrivate();
         aP1_trips=this.AV10trips;
      }

      public short executeUdp( short aP0_AttractionId )
      {
         execute(aP0_AttractionId, out aP1_trips);
         return AV10trips ;
      }

      public void executeSubmit( short aP0_AttractionId ,
                                 out short aP1_trips )
      {
         newtrip objnewtrip;
         objnewtrip = new newtrip();
         objnewtrip.AV8AttractionId = aP0_AttractionId;
         objnewtrip.AV10trips = 0 ;
         objnewtrip.context.SetSubmitInitialConfig(context);
         objnewtrip.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnewtrip);
         aP1_trips=this.AV10trips;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((newtrip)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE Trip

         */
         A49TripDate = DateTimeUtil.Today( context);
         A50TripDescription = "Create automatically from WWAttractionsFromScratch";
         /* Using cursor P000V2 */
         pr_default.execute(0, new Object[] {A49TripDate, A50TripDescription});
         A48TripId = P000V2_A48TripId[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Trip");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         AV9TripId = A48TripId;
         /*
            INSERT RECORD ON TABLE TripAttraction

         */
         A48TripId = AV9TripId;
         A7AttractionId = AV8AttractionId;
         /* Using cursor P000V3 */
         pr_default.execute(1, new Object[] {A48TripId, A7AttractionId});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TripAttraction");
         if ( (pr_default.getStatus(1) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /* Using cursor P000V5 */
         pr_default.execute(2, new Object[] {AV8AttractionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P000V5_A40000GXC1[0];
            n40000GXC1 = P000V5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV10trips = (short)(A40000GXC1);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("newtrip",pr_default);
         CloseOpenCursors();
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
         A49TripDate = DateTime.MinValue;
         A50TripDescription = "";
         P000V2_A48TripId = new short[1] ;
         Gx_emsg = "";
         scmdbuf = "";
         P000V5_A40000GXC1 = new int[1] ;
         P000V5_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.newtrip__default(),
            new Object[][] {
                new Object[] {
               P000V2_A48TripId
               }
               , new Object[] {
               }
               , new Object[] {
               P000V5_A40000GXC1, P000V5_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8AttractionId ;
      private short AV10trips ;
      private short A48TripId ;
      private short AV9TripId ;
      private short A7AttractionId ;
      private int GX_INS13 ;
      private int GX_INS14 ;
      private int A40000GXC1 ;
      private string A50TripDescription ;
      private string Gx_emsg ;
      private string scmdbuf ;
      private DateTime A49TripDate ;
      private bool n40000GXC1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000V2_A48TripId ;
      private int[] P000V5_A40000GXC1 ;
      private bool[] P000V5_n40000GXC1 ;
      private short aP1_trips ;
   }

   public class newtrip__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000V2;
          prmP000V2 = new Object[] {
          new ParDef("@TripDate",GXType.Date,8,0) ,
          new ParDef("@TripDescription",GXType.NChar,20,0)
          };
          Object[] prmP000V3;
          prmP000V3 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmP000V5;
          prmP000V5 = new Object[] {
          new ParDef("@AV8AttractionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000V2", "INSERT INTO [Trip]([TripDate], [TripDescription]) VALUES(@TripDate, @TripDescription); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP000V2)
             ,new CursorDef("P000V3", "INSERT INTO [TripAttraction]([TripId], [AttractionId]) VALUES(@TripId, @AttractionId)", GxErrorMask.GX_NOMASK,prmP000V3)
             ,new CursorDef("P000V5", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM ([TripAttraction] T2 INNER JOIN [Trip] T3 ON T3.[TripId] = T2.[TripId]) WHERE T2.[AttractionId] = @AV8AttractionId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V5,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
