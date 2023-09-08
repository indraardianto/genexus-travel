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
   public class rankingcountrieswithattracitonsqty : GXProcedure
   {
      public rankingcountrieswithattracitonsqty( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public rankingcountrieswithattracitonsqty( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTCountries_SDTCountriesItem>( context, "SDTCountriesItem", "Traveling") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTCountries_SDTCountriesItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol )
      {
         rankingcountrieswithattracitonsqty objrankingcountrieswithattracitonsqty;
         objrankingcountrieswithattracitonsqty = new rankingcountrieswithattracitonsqty();
         objrankingcountrieswithattracitonsqty.Gxm2rootcol = new GXBaseCollection<SdtSDTCountries_SDTCountriesItem>( context, "SDTCountriesItem", "Traveling") ;
         objrankingcountrieswithattracitonsqty.context.SetSubmitInitialConfig(context);
         objrankingcountrieswithattracitonsqty.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrankingcountrieswithattracitonsqty);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rankingcountrieswithattracitonsqty)stateInfo).executePrivate();
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
         /* Using cursor P00013 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A10CountryName = P00013_A10CountryName[0];
            A9CountryId = P00013_A9CountryId[0];
            A40000GXC1 = P00013_A40000GXC1[0];
            n40000GXC1 = P00013_n40000GXC1[0];
            A40000GXC1 = P00013_A40000GXC1[0];
            n40000GXC1 = P00013_n40000GXC1[0];
            Gxm1sdtcountries = new SdtSDTCountries_SDTCountriesItem(context);
            Gxm2rootcol.Add(Gxm1sdtcountries, 0);
            Gxm1sdtcountries.gxTpr_Id = A9CountryId;
            Gxm1sdtcountries.gxTpr_Name = A10CountryName;
            Gxm1sdtcountries.gxTpr_Attractionsquantity = (short)(A40000GXC1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
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
         scmdbuf = "";
         P00013_A10CountryName = new string[] {""} ;
         P00013_A9CountryId = new short[1] ;
         P00013_A40000GXC1 = new int[1] ;
         P00013_n40000GXC1 = new bool[] {false} ;
         A10CountryName = "";
         Gxm1sdtcountries = new SdtSDTCountries_SDTCountriesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rankingcountrieswithattracitonsqty__default(),
            new Object[][] {
                new Object[] {
               P00013_A10CountryName, P00013_A9CountryId, P00013_A40000GXC1, P00013_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9CountryId ;
      private int A40000GXC1 ;
      private string scmdbuf ;
      private string A10CountryName ;
      private bool n40000GXC1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00013_A10CountryName ;
      private short[] P00013_A9CountryId ;
      private int[] P00013_A40000GXC1 ;
      private bool[] P00013_n40000GXC1 ;
      private GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTCountries_SDTCountriesItem> Gxm2rootcol ;
      private SdtSDTCountries_SDTCountriesItem Gxm1sdtcountries ;
   }

   public class rankingcountrieswithattracitonsqty__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00013;
          prmP00013 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00013", "SELECT T1.[CountryName], T1.[CountryId], COALESCE( T2.[GXC1], 0) AS GXC1 FROM ([Country] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [CountryId] FROM [Attraction] GROUP BY [CountryId] ) T2 ON T2.[CountryId] = T1.[CountryId]) WHERE T1.[CountryName] <> 'Brazil' ORDER BY T1.[CountryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00013,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
