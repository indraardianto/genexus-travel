using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
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
   public class attractionbyname : GXProcedure
   {
      public attractionbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_NameForm ,
                           string aP1_NameTo )
      {
         this.AV2NameForm = aP0_NameForm;
         this.AV3NameTo = aP1_NameTo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_NameForm ,
                                 string aP1_NameTo )
      {
         attractionbyname objattractionbyname;
         objattractionbyname = new attractionbyname();
         objattractionbyname.AV2NameForm = aP0_NameForm;
         objattractionbyname.AV3NameTo = aP1_NameTo;
         objattractionbyname.context.SetSubmitInitialConfig(context);
         objattractionbyname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objattractionbyname);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((attractionbyname)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2NameForm,(string)AV3NameTo} ;
         ClassLoader.Execute("aattractionbyname","GeneXus.Programs","aattractionbyname", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV2NameForm ;
      private string AV3NameTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
