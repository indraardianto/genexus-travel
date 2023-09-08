using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Attraction" )]
   [XmlType(TypeName =  "Attraction" , Namespace = "Traveling" )]
   [Serializable]
   public class SdtAttraction : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAttraction( )
      {
      }

      public SdtAttraction( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV7AttractionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV7AttractionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AttractionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Attraction");
         metadata.Set("BT", "Attraction");
         metadata.Set("PK", "[ \"AttractionId\" ]");
         metadata.Set("PKAssigned", "[ \"AttractionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoryId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CountryId\",\"CityId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Attractionphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Attractionid_Z");
         state.Add("gxTpr_Attractionname_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Cityid_Z");
         state.Add("gxTpr_Cityname_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         state.Add("gxTpr_Attractionaddress_Z");
         state.Add("gxTpr_Attractionphoto_gxi_Z");
         state.Add("gxTpr_Categoryid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAttraction sdt;
         sdt = (SdtAttraction)(source);
         gxTv_SdtAttraction_Attractionid = sdt.gxTv_SdtAttraction_Attractionid ;
         gxTv_SdtAttraction_Attractionname = sdt.gxTv_SdtAttraction_Attractionname ;
         gxTv_SdtAttraction_Countryid = sdt.gxTv_SdtAttraction_Countryid ;
         gxTv_SdtAttraction_Countryname = sdt.gxTv_SdtAttraction_Countryname ;
         gxTv_SdtAttraction_Cityid = sdt.gxTv_SdtAttraction_Cityid ;
         gxTv_SdtAttraction_Cityname = sdt.gxTv_SdtAttraction_Cityname ;
         gxTv_SdtAttraction_Categoryid = sdt.gxTv_SdtAttraction_Categoryid ;
         gxTv_SdtAttraction_Categoryname = sdt.gxTv_SdtAttraction_Categoryname ;
         gxTv_SdtAttraction_Attractionphoto = sdt.gxTv_SdtAttraction_Attractionphoto ;
         gxTv_SdtAttraction_Attractionphoto_gxi = sdt.gxTv_SdtAttraction_Attractionphoto_gxi ;
         gxTv_SdtAttraction_Attractionaddress = sdt.gxTv_SdtAttraction_Attractionaddress ;
         gxTv_SdtAttraction_Mode = sdt.gxTv_SdtAttraction_Mode ;
         gxTv_SdtAttraction_Initialized = sdt.gxTv_SdtAttraction_Initialized ;
         gxTv_SdtAttraction_Attractionid_Z = sdt.gxTv_SdtAttraction_Attractionid_Z ;
         gxTv_SdtAttraction_Attractionname_Z = sdt.gxTv_SdtAttraction_Attractionname_Z ;
         gxTv_SdtAttraction_Countryid_Z = sdt.gxTv_SdtAttraction_Countryid_Z ;
         gxTv_SdtAttraction_Countryname_Z = sdt.gxTv_SdtAttraction_Countryname_Z ;
         gxTv_SdtAttraction_Cityid_Z = sdt.gxTv_SdtAttraction_Cityid_Z ;
         gxTv_SdtAttraction_Cityname_Z = sdt.gxTv_SdtAttraction_Cityname_Z ;
         gxTv_SdtAttraction_Categoryid_Z = sdt.gxTv_SdtAttraction_Categoryid_Z ;
         gxTv_SdtAttraction_Categoryname_Z = sdt.gxTv_SdtAttraction_Categoryname_Z ;
         gxTv_SdtAttraction_Attractionaddress_Z = sdt.gxTv_SdtAttraction_Attractionaddress_Z ;
         gxTv_SdtAttraction_Attractionphoto_gxi_Z = sdt.gxTv_SdtAttraction_Attractionphoto_gxi_Z ;
         gxTv_SdtAttraction_Categoryid_N = sdt.gxTv_SdtAttraction_Categoryid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("AttractionId", gxTv_SdtAttraction_Attractionid, false, includeNonInitialized);
         AddObjectProperty("AttractionName", gxTv_SdtAttraction_Attractionname, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtAttraction_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtAttraction_Countryname, false, includeNonInitialized);
         AddObjectProperty("CityId", gxTv_SdtAttraction_Cityid, false, includeNonInitialized);
         AddObjectProperty("CityName", gxTv_SdtAttraction_Cityname, false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtAttraction_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryId_N", gxTv_SdtAttraction_Categoryid_N, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtAttraction_Categoryname, false, includeNonInitialized);
         AddObjectProperty("AttractionPhoto", gxTv_SdtAttraction_Attractionphoto, false, includeNonInitialized);
         AddObjectProperty("AttractionAddress", gxTv_SdtAttraction_Attractionaddress, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("AttractionPhoto_GXI", gxTv_SdtAttraction_Attractionphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtAttraction_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAttraction_Initialized, false, includeNonInitialized);
            AddObjectProperty("AttractionId_Z", gxTv_SdtAttraction_Attractionid_Z, false, includeNonInitialized);
            AddObjectProperty("AttractionName_Z", gxTv_SdtAttraction_Attractionname_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtAttraction_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtAttraction_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("CityId_Z", gxTv_SdtAttraction_Cityid_Z, false, includeNonInitialized);
            AddObjectProperty("CityName_Z", gxTv_SdtAttraction_Cityname_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtAttraction_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtAttraction_Categoryname_Z, false, includeNonInitialized);
            AddObjectProperty("AttractionAddress_Z", gxTv_SdtAttraction_Attractionaddress_Z, false, includeNonInitialized);
            AddObjectProperty("AttractionPhoto_GXI_Z", gxTv_SdtAttraction_Attractionphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_N", gxTv_SdtAttraction_Categoryid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAttraction sdt )
      {
         if ( sdt.IsDirty("AttractionId") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionid = sdt.gxTv_SdtAttraction_Attractionid ;
         }
         if ( sdt.IsDirty("AttractionName") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionname = sdt.gxTv_SdtAttraction_Attractionname ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryid = sdt.gxTv_SdtAttraction_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryname = sdt.gxTv_SdtAttraction_Countryname ;
         }
         if ( sdt.IsDirty("CityId") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityid = sdt.gxTv_SdtAttraction_Cityid ;
         }
         if ( sdt.IsDirty("CityName") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityname = sdt.gxTv_SdtAttraction_Cityname ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            gxTv_SdtAttraction_Categoryid_N = 0;
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryid = sdt.gxTv_SdtAttraction_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryname = sdt.gxTv_SdtAttraction_Categoryname ;
         }
         if ( sdt.IsDirty("AttractionPhoto") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionphoto = sdt.gxTv_SdtAttraction_Attractionphoto ;
         }
         if ( sdt.IsDirty("AttractionPhoto") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionphoto_gxi = sdt.gxTv_SdtAttraction_Attractionphoto_gxi ;
         }
         if ( sdt.IsDirty("AttractionAddress") )
         {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionaddress = sdt.gxTv_SdtAttraction_Attractionaddress ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AttractionId" )]
      [  XmlElement( ElementName = "AttractionId"   )]
      public short gxTpr_Attractionid
      {
         get {
            return gxTv_SdtAttraction_Attractionid ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            if ( gxTv_SdtAttraction_Attractionid != value )
            {
               gxTv_SdtAttraction_Mode = "INS";
               this.gxTv_SdtAttraction_Attractionid_Z_SetNull( );
               this.gxTv_SdtAttraction_Attractionname_Z_SetNull( );
               this.gxTv_SdtAttraction_Countryid_Z_SetNull( );
               this.gxTv_SdtAttraction_Countryname_Z_SetNull( );
               this.gxTv_SdtAttraction_Cityid_Z_SetNull( );
               this.gxTv_SdtAttraction_Cityname_Z_SetNull( );
               this.gxTv_SdtAttraction_Categoryid_Z_SetNull( );
               this.gxTv_SdtAttraction_Categoryname_Z_SetNull( );
               this.gxTv_SdtAttraction_Attractionaddress_Z_SetNull( );
               this.gxTv_SdtAttraction_Attractionphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtAttraction_Attractionid = value;
            SetDirty("Attractionid");
         }

      }

      [  SoapElement( ElementName = "AttractionName" )]
      [  XmlElement( ElementName = "AttractionName"   )]
      public string gxTpr_Attractionname
      {
         get {
            return gxTv_SdtAttraction_Attractionname ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionname = value;
            SetDirty("Attractionname");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtAttraction_Countryid ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtAttraction_Countryname ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "CityId" )]
      [  XmlElement( ElementName = "CityId"   )]
      public short gxTpr_Cityid
      {
         get {
            return gxTv_SdtAttraction_Cityid ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityid = value;
            SetDirty("Cityid");
         }

      }

      [  SoapElement( ElementName = "CityName" )]
      [  XmlElement( ElementName = "CityName"   )]
      public string gxTpr_Cityname
      {
         get {
            return gxTv_SdtAttraction_Cityname ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityname = value;
            SetDirty("Cityname");
         }

      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtAttraction_Categoryid ;
         }

         set {
            gxTv_SdtAttraction_Categoryid_N = 0;
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryid = value;
            SetDirty("Categoryid");
         }

      }

      public void gxTv_SdtAttraction_Categoryid_SetNull( )
      {
         gxTv_SdtAttraction_Categoryid_N = 1;
         gxTv_SdtAttraction_Categoryid = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Categoryid_IsNull( )
      {
         return (gxTv_SdtAttraction_Categoryid_N==1) ;
      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtAttraction_Categoryname ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryname = value;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "AttractionPhoto" )]
      [  XmlElement( ElementName = "AttractionPhoto"   )]
      [GxUpload()]
      public string gxTpr_Attractionphoto
      {
         get {
            return gxTv_SdtAttraction_Attractionphoto ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionphoto = value;
            SetDirty("Attractionphoto");
         }

      }

      [  SoapElement( ElementName = "AttractionPhoto_GXI" )]
      [  XmlElement( ElementName = "AttractionPhoto_GXI"   )]
      public string gxTpr_Attractionphoto_gxi
      {
         get {
            return gxTv_SdtAttraction_Attractionphoto_gxi ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionphoto_gxi = value;
            SetDirty("Attractionphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "AttractionAddress" )]
      [  XmlElement( ElementName = "AttractionAddress"   )]
      public string gxTpr_Attractionaddress
      {
         get {
            return gxTv_SdtAttraction_Attractionaddress ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionaddress = value;
            SetDirty("Attractionaddress");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAttraction_Mode ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAttraction_Mode_SetNull( )
      {
         gxTv_SdtAttraction_Mode = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAttraction_Initialized ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAttraction_Initialized_SetNull( )
      {
         gxTv_SdtAttraction_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionId_Z" )]
      [  XmlElement( ElementName = "AttractionId_Z"   )]
      public short gxTpr_Attractionid_Z
      {
         get {
            return gxTv_SdtAttraction_Attractionid_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionid_Z = value;
            SetDirty("Attractionid_Z");
         }

      }

      public void gxTv_SdtAttraction_Attractionid_Z_SetNull( )
      {
         gxTv_SdtAttraction_Attractionid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Attractionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionName_Z" )]
      [  XmlElement( ElementName = "AttractionName_Z"   )]
      public string gxTpr_Attractionname_Z
      {
         get {
            return gxTv_SdtAttraction_Attractionname_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionname_Z = value;
            SetDirty("Attractionname_Z");
         }

      }

      public void gxTv_SdtAttraction_Attractionname_Z_SetNull( )
      {
         gxTv_SdtAttraction_Attractionname_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Attractionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtAttraction_Countryid_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtAttraction_Countryid_Z_SetNull( )
      {
         gxTv_SdtAttraction_Countryid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtAttraction_Countryname_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtAttraction_Countryname_Z_SetNull( )
      {
         gxTv_SdtAttraction_Countryname_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CityId_Z" )]
      [  XmlElement( ElementName = "CityId_Z"   )]
      public short gxTpr_Cityid_Z
      {
         get {
            return gxTv_SdtAttraction_Cityid_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityid_Z = value;
            SetDirty("Cityid_Z");
         }

      }

      public void gxTv_SdtAttraction_Cityid_Z_SetNull( )
      {
         gxTv_SdtAttraction_Cityid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Cityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CityName_Z" )]
      [  XmlElement( ElementName = "CityName_Z"   )]
      public string gxTpr_Cityname_Z
      {
         get {
            return gxTv_SdtAttraction_Cityname_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Cityname_Z = value;
            SetDirty("Cityname_Z");
         }

      }

      public void gxTv_SdtAttraction_Cityname_Z_SetNull( )
      {
         gxTv_SdtAttraction_Cityname_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Cityname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtAttraction_Categoryid_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryid_Z = value;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtAttraction_Categoryid_Z_SetNull( )
      {
         gxTv_SdtAttraction_Categoryid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtAttraction_Categoryname_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryname_Z = value;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtAttraction_Categoryname_Z_SetNull( )
      {
         gxTv_SdtAttraction_Categoryname_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionAddress_Z" )]
      [  XmlElement( ElementName = "AttractionAddress_Z"   )]
      public string gxTpr_Attractionaddress_Z
      {
         get {
            return gxTv_SdtAttraction_Attractionaddress_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionaddress_Z = value;
            SetDirty("Attractionaddress_Z");
         }

      }

      public void gxTv_SdtAttraction_Attractionaddress_Z_SetNull( )
      {
         gxTv_SdtAttraction_Attractionaddress_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Attractionaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "AttractionPhoto_GXI_Z"   )]
      public string gxTpr_Attractionphoto_gxi_Z
      {
         get {
            return gxTv_SdtAttraction_Attractionphoto_gxi_Z ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Attractionphoto_gxi_Z = value;
            SetDirty("Attractionphoto_gxi_Z");
         }

      }

      public void gxTv_SdtAttraction_Attractionphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtAttraction_Attractionphoto_gxi_Z = "";
         return  ;
      }

      public bool gxTv_SdtAttraction_Attractionphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_N" )]
      [  XmlElement( ElementName = "CategoryId_N"   )]
      public short gxTpr_Categoryid_N
      {
         get {
            return gxTv_SdtAttraction_Categoryid_N ;
         }

         set {
            gxTv_SdtAttraction_N = 0;
            gxTv_SdtAttraction_Categoryid_N = value;
            SetDirty("Categoryid_N");
         }

      }

      public void gxTv_SdtAttraction_Categoryid_N_SetNull( )
      {
         gxTv_SdtAttraction_Categoryid_N = 0;
         return  ;
      }

      public bool gxTv_SdtAttraction_Categoryid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtAttraction_N = 1;
         gxTv_SdtAttraction_Attractionname = "";
         gxTv_SdtAttraction_Countryname = "";
         gxTv_SdtAttraction_Cityname = "";
         gxTv_SdtAttraction_Categoryname = "";
         gxTv_SdtAttraction_Attractionphoto = "";
         gxTv_SdtAttraction_Attractionphoto_gxi = "";
         gxTv_SdtAttraction_Attractionaddress = "";
         gxTv_SdtAttraction_Mode = "";
         gxTv_SdtAttraction_Attractionname_Z = "";
         gxTv_SdtAttraction_Countryname_Z = "";
         gxTv_SdtAttraction_Cityname_Z = "";
         gxTv_SdtAttraction_Categoryname_Z = "";
         gxTv_SdtAttraction_Attractionaddress_Z = "";
         gxTv_SdtAttraction_Attractionphoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "attraction", "GeneXus.Programs.attraction_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtAttraction_N ;
      }

      private short gxTv_SdtAttraction_Attractionid ;
      private short gxTv_SdtAttraction_N ;
      private short gxTv_SdtAttraction_Countryid ;
      private short gxTv_SdtAttraction_Cityid ;
      private short gxTv_SdtAttraction_Categoryid ;
      private short gxTv_SdtAttraction_Initialized ;
      private short gxTv_SdtAttraction_Attractionid_Z ;
      private short gxTv_SdtAttraction_Countryid_Z ;
      private short gxTv_SdtAttraction_Cityid_Z ;
      private short gxTv_SdtAttraction_Categoryid_Z ;
      private short gxTv_SdtAttraction_Categoryid_N ;
      private string gxTv_SdtAttraction_Attractionname ;
      private string gxTv_SdtAttraction_Countryname ;
      private string gxTv_SdtAttraction_Cityname ;
      private string gxTv_SdtAttraction_Categoryname ;
      private string gxTv_SdtAttraction_Mode ;
      private string gxTv_SdtAttraction_Attractionname_Z ;
      private string gxTv_SdtAttraction_Countryname_Z ;
      private string gxTv_SdtAttraction_Cityname_Z ;
      private string gxTv_SdtAttraction_Categoryname_Z ;
      private string gxTv_SdtAttraction_Attractionphoto_gxi ;
      private string gxTv_SdtAttraction_Attractionaddress ;
      private string gxTv_SdtAttraction_Attractionaddress_Z ;
      private string gxTv_SdtAttraction_Attractionphoto_gxi_Z ;
      private string gxTv_SdtAttraction_Attractionphoto ;
   }

   [DataContract(Name = @"Attraction", Namespace = "Traveling")]
   public class SdtAttraction_RESTInterface : GxGenericCollectionItem<SdtAttraction>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAttraction_RESTInterface( ) : base()
      {
      }

      public SdtAttraction_RESTInterface( SdtAttraction psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AttractionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Attractionid
      {
         get {
            return sdt.gxTpr_Attractionid ;
         }

         set {
            sdt.gxTpr_Attractionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AttractionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Attractionname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Attractionname) ;
         }

         set {
            sdt.gxTpr_Attractionname = value;
         }

      }

      [DataMember( Name = "CountryId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Countryid
      {
         get {
            return sdt.gxTpr_Countryid ;
         }

         set {
            sdt.gxTpr_Countryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CountryName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Countryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Countryname) ;
         }

         set {
            sdt.gxTpr_Countryname = value;
         }

      }

      [DataMember( Name = "CityId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Cityid
      {
         get {
            return sdt.gxTpr_Cityid ;
         }

         set {
            sdt.gxTpr_Cityid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CityName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Cityname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Cityname) ;
         }

         set {
            sdt.gxTpr_Cityname = value;
         }

      }

      [DataMember( Name = "CategoryId" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoryid
      {
         get {
            return sdt.gxTpr_Categoryid ;
         }

         set {
            sdt.gxTpr_Categoryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoryName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Categoryname) ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
         }

      }

      [DataMember( Name = "AttractionPhoto" , Order = 8 )]
      [GxUpload()]
      public string gxTpr_Attractionphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Attractionphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Attractionphoto) : StringUtil.RTrim( sdt.gxTpr_Attractionphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Attractionphoto = value;
         }

      }

      [DataMember( Name = "AttractionAddress" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Attractionaddress
      {
         get {
            return sdt.gxTpr_Attractionaddress ;
         }

         set {
            sdt.gxTpr_Attractionaddress = value;
         }

      }

      public SdtAttraction sdt
      {
         get {
            return (SdtAttraction)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtAttraction() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Attraction", Namespace = "Traveling")]
   public class SdtAttraction_RESTLInterface : GxGenericCollectionItem<SdtAttraction>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAttraction_RESTLInterface( ) : base()
      {
      }

      public SdtAttraction_RESTLInterface( SdtAttraction psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AttractionName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Attractionname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Attractionname) ;
         }

         set {
            sdt.gxTpr_Attractionname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtAttraction sdt
      {
         get {
            return (SdtAttraction)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtAttraction() ;
         }
      }

   }

}
