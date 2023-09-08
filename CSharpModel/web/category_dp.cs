using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class category_dp : GXProcedure
   {
      public category_dp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public category_dp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCategory> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategory>( context, "Category", "Traveling") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCategory> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCategory> aP0_Gxm2rootcol )
      {
         category_dp objcategory_dp;
         objcategory_dp = new category_dp();
         objcategory_dp.Gxm2rootcol = new GXBCCollection<SdtCategory>( context, "Category", "Traveling") ;
         objcategory_dp.context.SetSubmitInitialConfig(context);
         objcategory_dp.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcategory_dp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((category_dp)stateInfo).executePrivate();
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
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Museum";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Monument";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Tourist site";
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
         Gxm1category = new SdtCategory(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtCategory> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCategory> Gxm2rootcol ;
      private SdtCategory Gxm1category ;
   }

}
