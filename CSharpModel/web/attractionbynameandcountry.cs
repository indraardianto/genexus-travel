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
   public class attractionbynameandcountry : GXProcedure
   {
      public attractionbynameandcountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionbynameandcountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CountryId ,
                           ref string aP1_NameForm ,
                           string aP2_NameTo )
      {
         this.AV2CountryId = aP0_CountryId;
         this.AV3NameForm = aP1_NameForm;
         this.AV4NameTo = aP2_NameTo;
         initialize();
         executePrivate();
         aP1_NameForm=this.AV3NameForm;
      }

      public void executeSubmit( short aP0_CountryId ,
                                 ref string aP1_NameForm ,
                                 string aP2_NameTo )
      {
         attractionbynameandcountry objattractionbynameandcountry;
         objattractionbynameandcountry = new attractionbynameandcountry();
         objattractionbynameandcountry.AV2CountryId = aP0_CountryId;
         objattractionbynameandcountry.AV3NameForm = aP1_NameForm;
         objattractionbynameandcountry.AV4NameTo = aP2_NameTo;
         objattractionbynameandcountry.context.SetSubmitInitialConfig(context);
         objattractionbynameandcountry.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objattractionbynameandcountry);
         aP1_NameForm=this.AV3NameForm;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((attractionbynameandcountry)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2CountryId,(string)AV3NameForm,(string)AV4NameTo} ;
         ClassLoader.Execute("aattractionbynameandcountry","GeneXus.Programs","aattractionbynameandcountry", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3NameForm = (string)(args[1]) ;
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

      private short AV2CountryId ;
      private string AV3NameForm ;
      private string AV4NameTo ;
      private IGxDataStore dsDefault ;
      private string aP1_NameForm ;
      private Object[] args ;
   }

}
