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
   public class attraction_dp : GXProcedure
   {
      public attraction_dp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public attraction_dp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtAttraction> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtAttraction>( context, "Attraction", "Traveling") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtAttraction> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtAttraction> aP0_Gxm2rootcol )
      {
         attraction_dp objattraction_dp;
         objattraction_dp = new attraction_dp();
         objattraction_dp.Gxm2rootcol = new GXBCCollection<SdtAttraction>( context, "Attraction", "Traveling") ;
         objattraction_dp.context.SetSubmitInitialConfig(context);
         objattraction_dp.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objattraction_dp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((attraction_dp)stateInfo).executePrivate();
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
         /* Using cursor P00053 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000CountryId = P00053_A40000CountryId[0];
            n40000CountryId = P00053_n40000CountryId[0];
         }
         else
         {
            A40000CountryId = 0;
            n40000CountryId = false;
         }
         pr_default.close(0);
         /* Using cursor P00055 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001CityId = P00055_A40001CityId[0];
            n40001CityId = P00055_n40001CityId[0];
         }
         else
         {
            A40001CityId = 0;
            n40001CityId = false;
         }
         pr_default.close(1);
         /* Using cursor P00057 */
         pr_default.execute(2);
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40002CategoryId = P00057_A40002CategoryId[0];
            n40002CategoryId = P00057_n40002CategoryId[0];
         }
         else
         {
            A40002CategoryId = 0;
            n40002CategoryId = false;
         }
         pr_default.close(2);
         /* Using cursor P00059 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40003CountryId = P00059_A40003CountryId[0];
            n40003CountryId = P00059_n40003CountryId[0];
         }
         else
         {
            A40003CountryId = 0;
            n40003CountryId = false;
         }
         pr_default.close(3);
         /* Using cursor P000511 */
         pr_default.execute(4);
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40004CityId = P000511_A40004CityId[0];
            n40004CityId = P000511_n40004CityId[0];
         }
         else
         {
            A40004CityId = 0;
            n40004CityId = false;
         }
         pr_default.close(4);
         /* Using cursor P000513 */
         pr_default.execute(5);
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40005CategoryId = P000513_A40005CategoryId[0];
            n40005CategoryId = P000513_n40005CategoryId[0];
         }
         else
         {
            A40005CategoryId = 0;
            n40005CategoryId = false;
         }
         pr_default.close(5);
         /* Using cursor P000515 */
         pr_default.execute(6);
         if ( (pr_default.getStatus(6) != 101) )
         {
            A40006CountryId = P000515_A40006CountryId[0];
            n40006CountryId = P000515_n40006CountryId[0];
         }
         else
         {
            A40006CountryId = 0;
            n40006CountryId = false;
         }
         pr_default.close(6);
         /* Using cursor P000517 */
         pr_default.execute(7);
         if ( (pr_default.getStatus(7) != 101) )
         {
            A40007CityId = P000517_A40007CityId[0];
            n40007CityId = P000517_n40007CityId[0];
         }
         else
         {
            A40007CityId = 0;
            n40007CityId = false;
         }
         pr_default.close(7);
         /* Using cursor P000519 */
         pr_default.execute(8);
         if ( (pr_default.getStatus(8) != 101) )
         {
            A40008CategoryId = P000519_A40008CategoryId[0];
            n40008CategoryId = P000519_n40008CategoryId[0];
         }
         else
         {
            A40008CategoryId = 0;
            n40008CategoryId = false;
         }
         pr_default.close(8);
         /* Using cursor P000521 */
         pr_default.execute(9);
         if ( (pr_default.getStatus(9) != 101) )
         {
            A40009CityId = P000521_A40009CityId[0];
            n40009CityId = P000521_n40009CityId[0];
         }
         else
         {
            A40009CityId = 0;
            n40009CityId = false;
         }
         pr_default.close(9);
         Gxm1attraction = new SdtAttraction(context);
         Gxm2rootcol.Add(Gxm1attraction, 0);
         Gxm1attraction.gxTpr_Attractionname = "Louvre Museum";
         Gxm1attraction.gxTpr_Countryid = A40000CountryId;
         Gxm1attraction.gxTpr_Cityid = A40001CityId;
         Gxm1attraction.gxTpr_Categoryid = A40002CategoryId;
         Gxm1attraction.gxTpr_Attractionphoto = context.convertURL( (string)(context.GetImagePath( "f752527e-2cba-4783-914e-495b80bba7c9", "", context.GetTheme( ))));
         Gxm1attraction = new SdtAttraction(context);
         Gxm2rootcol.Add(Gxm1attraction, 0);
         Gxm1attraction.gxTpr_Attractionname = "The Great Wall";
         Gxm1attraction.gxTpr_Countryid = A40003CountryId;
         Gxm1attraction.gxTpr_Cityid = A40004CityId;
         Gxm1attraction.gxTpr_Categoryid = A40005CategoryId;
         Gxm1attraction.gxTpr_Attractionphoto = context.convertURL( (string)(context.GetImagePath( "f252ced7-f6b6-4138-82fb-c2ff57800096", "", context.GetTheme( ))));
         Gxm1attraction = new SdtAttraction(context);
         Gxm2rootcol.Add(Gxm1attraction, 0);
         Gxm1attraction.gxTpr_Attractionname = "Eiffel Tower";
         Gxm1attraction.gxTpr_Countryid = A40006CountryId;
         Gxm1attraction.gxTpr_Cityid = A40007CityId;
         Gxm1attraction.gxTpr_Categoryid = A40008CategoryId;
         Gxm1attraction.gxTpr_Attractionphoto = context.convertURL( (string)(context.GetImagePath( "f3370015-da97-4cc8-9a83-60448fa1f8d8", "", context.GetTheme( ))));
         Gxm1attraction = new SdtAttraction(context);
         Gxm2rootcol.Add(Gxm1attraction, 0);
         Gxm1attraction.gxTpr_Attractionname = "Christ the Redemmer";
         Gxm1attraction.gxTpr_Countryid = A40000CountryId;
         Gxm1attraction.gxTpr_Cityid = A40009CityId;
         Gxm1attraction.gxTpr_Categoryid = A40002CategoryId;
         Gxm1attraction.gxTpr_Attractionphoto = context.convertURL( (string)(context.GetImagePath( "19296ed5-d328-4e94-ae5e-6770ff27c174", "", context.GetTheme( ))));
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
         P00053_A40000CountryId = new short[1] ;
         P00053_n40000CountryId = new bool[] {false} ;
         P00055_A40001CityId = new short[1] ;
         P00055_n40001CityId = new bool[] {false} ;
         P00057_A40002CategoryId = new short[1] ;
         P00057_n40002CategoryId = new bool[] {false} ;
         P00059_A40003CountryId = new short[1] ;
         P00059_n40003CountryId = new bool[] {false} ;
         P000511_A40004CityId = new short[1] ;
         P000511_n40004CityId = new bool[] {false} ;
         P000513_A40005CategoryId = new short[1] ;
         P000513_n40005CategoryId = new bool[] {false} ;
         P000515_A40006CountryId = new short[1] ;
         P000515_n40006CountryId = new bool[] {false} ;
         P000517_A40007CityId = new short[1] ;
         P000517_n40007CityId = new bool[] {false} ;
         P000519_A40008CategoryId = new short[1] ;
         P000519_n40008CategoryId = new bool[] {false} ;
         P000521_A40009CityId = new short[1] ;
         P000521_n40009CityId = new bool[] {false} ;
         Gxm1attraction = new SdtAttraction(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.attraction_dp__default(),
            new Object[][] {
                new Object[] {
               P00053_A40000CountryId, P00053_n40000CountryId
               }
               , new Object[] {
               P00055_A40001CityId, P00055_n40001CityId
               }
               , new Object[] {
               P00057_A40002CategoryId, P00057_n40002CategoryId
               }
               , new Object[] {
               P00059_A40003CountryId, P00059_n40003CountryId
               }
               , new Object[] {
               P000511_A40004CityId, P000511_n40004CityId
               }
               , new Object[] {
               P000513_A40005CategoryId, P000513_n40005CategoryId
               }
               , new Object[] {
               P000515_A40006CountryId, P000515_n40006CountryId
               }
               , new Object[] {
               P000517_A40007CityId, P000517_n40007CityId
               }
               , new Object[] {
               P000519_A40008CategoryId, P000519_n40008CategoryId
               }
               , new Object[] {
               P000521_A40009CityId, P000521_n40009CityId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A40000CountryId ;
      private short A40001CityId ;
      private short A40002CategoryId ;
      private short A40003CountryId ;
      private short A40004CityId ;
      private short A40005CategoryId ;
      private short A40006CountryId ;
      private short A40007CityId ;
      private short A40008CategoryId ;
      private short A40009CityId ;
      private string scmdbuf ;
      private bool n40000CountryId ;
      private bool n40001CityId ;
      private bool n40002CategoryId ;
      private bool n40003CountryId ;
      private bool n40004CityId ;
      private bool n40005CategoryId ;
      private bool n40006CountryId ;
      private bool n40007CityId ;
      private bool n40008CategoryId ;
      private bool n40009CityId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00053_A40000CountryId ;
      private bool[] P00053_n40000CountryId ;
      private short[] P00055_A40001CityId ;
      private bool[] P00055_n40001CityId ;
      private short[] P00057_A40002CategoryId ;
      private bool[] P00057_n40002CategoryId ;
      private short[] P00059_A40003CountryId ;
      private bool[] P00059_n40003CountryId ;
      private short[] P000511_A40004CityId ;
      private bool[] P000511_n40004CityId ;
      private short[] P000513_A40005CategoryId ;
      private bool[] P000513_n40005CategoryId ;
      private short[] P000515_A40006CountryId ;
      private bool[] P000515_n40006CountryId ;
      private short[] P000517_A40007CityId ;
      private bool[] P000517_n40007CityId ;
      private short[] P000519_A40008CategoryId ;
      private bool[] P000519_n40008CategoryId ;
      private short[] P000521_A40009CityId ;
      private bool[] P000521_n40009CityId ;
      private GXBCCollection<SdtAttraction> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtAttraction> Gxm2rootcol ;
      private SdtAttraction Gxm1attraction ;
   }

   public class attraction_dp__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00053;
          prmP00053 = new Object[] {
          };
          Object[] prmP00055;
          prmP00055 = new Object[] {
          };
          Object[] prmP00057;
          prmP00057 = new Object[] {
          };
          Object[] prmP00059;
          prmP00059 = new Object[] {
          };
          Object[] prmP000511;
          prmP000511 = new Object[] {
          };
          Object[] prmP000513;
          prmP000513 = new Object[] {
          };
          Object[] prmP000515;
          prmP000515 = new Object[] {
          };
          Object[] prmP000517;
          prmP000517 = new Object[] {
          };
          Object[] prmP000519;
          prmP000519 = new Object[] {
          };
          Object[] prmP000521;
          prmP000521 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00053", "SELECT COALESCE( T1.[CountryId], 0) AS CountryId FROM (SELECT MIN([CountryId]) AS CountryId FROM [Country] WHERE [CountryName] = 'Indonesia' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00055", "SELECT COALESCE( T1.[CityId], 0) AS CityId FROM (SELECT MIN([CityId]) AS CityId FROM [CountryCity] WHERE [CityName] = 'Jakarta' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00057", "SELECT COALESCE( T1.[CategoryId], 0) AS CategoryId FROM (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Museum' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00059", "SELECT COALESCE( T1.[CountryId], 0) AS CountryId FROM (SELECT MIN([CountryId]) AS CountryId FROM [Country] WHERE [CountryName] = 'Malaysia' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000511", "SELECT COALESCE( T1.[CityId], 0) AS CityId FROM (SELECT MIN([CityId]) AS CityId FROM [CountryCity] WHERE [CityName] = 'Kuala Lumpur' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000513", "SELECT COALESCE( T1.[CategoryId], 0) AS CategoryId FROM (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Tourist site' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000513,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000515", "SELECT COALESCE( T1.[CountryId], 0) AS CountryId FROM (SELECT MIN([CountryId]) AS CountryId FROM [Country] WHERE [CountryName] = 'Brazil' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000517", "SELECT COALESCE( T1.[CityId], 0) AS CityId FROM (SELECT MIN([CityId]) AS CityId FROM [CountryCity] WHERE [CityName] = 'Sao Paulo' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000519", "SELECT COALESCE( T1.[CategoryId], 0) AS CategoryId FROM (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Monument' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000519,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000521", "SELECT COALESCE( T1.[CityId], 0) AS CityId FROM (SELECT MIN([CityId]) AS CityId FROM [CountryCity] WHERE [CityName] = 'Surabaya' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000521,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
