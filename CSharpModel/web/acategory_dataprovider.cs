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
   public class acategory_dataprovider : GXProcedure
   {
      public acategory_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acategory_dataprovider( IGxContext context )
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
         acategory_dataprovider objacategory_dataprovider;
         objacategory_dataprovider = new acategory_dataprovider();
         objacategory_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCategory>( context, "Category", "Traveling") ;
         objacategory_dataprovider.context.SetSubmitInitialConfig(context);
         objacategory_dataprovider.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objacategory_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acategory_dataprovider)stateInfo).executePrivate();
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
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Square";
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
