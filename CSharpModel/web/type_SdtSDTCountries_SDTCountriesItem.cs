/*
				   File: type_SdtSDTCountries_SDTCountriesItem
			Description: SDTCountries
				 Author: Nemo 🐠 for C# version 17.0.8.158023
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTCountriesItem")]
	[XmlType(TypeName="SDTCountriesItem" , Namespace="Traveling" )]
	[Serializable]
	public class SdtSDTCountries_SDTCountriesItem : GxUserType
	{
		public SdtSDTCountries_SDTCountriesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCountries_SDTCountriesItem_Name = "";

		}

		public SdtSDTCountries_SDTCountriesItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("AttractionsQuantity", gxTpr_Attractionsquantity, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public short gxTpr_Id
		{
			get {
				return gxTv_SdtSDTCountries_SDTCountriesItem_Id; 
			}
			set {
				gxTv_SdtSDTCountries_SDTCountriesItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTCountries_SDTCountriesItem_Name; 
			}
			set {
				gxTv_SdtSDTCountries_SDTCountriesItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="AttractionsQuantity")]
		[XmlElement(ElementName="AttractionsQuantity")]
		public short gxTpr_Attractionsquantity
		{
			get {
				return gxTv_SdtSDTCountries_SDTCountriesItem_Attractionsquantity; 
			}
			set {
				gxTv_SdtSDTCountries_SDTCountriesItem_Attractionsquantity = value;
				SetDirty("Attractionsquantity");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTCountries_SDTCountriesItem_Name = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCountries_SDTCountriesItem_Id;
		 

		protected string gxTv_SdtSDTCountries_SDTCountriesItem_Name;
		 

		protected short gxTv_SdtSDTCountries_SDTCountriesItem_Attractionsquantity;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTCountriesItem", Namespace="Traveling")]
	public class SdtSDTCountries_SDTCountriesItem_RESTInterface : GxGenericCollectionItem<SdtSDTCountries_SDTCountriesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCountries_SDTCountriesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCountries_SDTCountriesItem_RESTInterface( SdtSDTCountries_SDTCountriesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public short gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="AttractionsQuantity", Order=2)]
		public short gxTpr_Attractionsquantity
		{
			get { 
				return sdt.gxTpr_Attractionsquantity;

			}
			set { 
				sdt.gxTpr_Attractionsquantity = value;
			}
		}


		#endregion

		public SdtSDTCountries_SDTCountriesItem sdt
		{
			get { 
				return (SdtSDTCountries_SDTCountriesItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTCountries_SDTCountriesItem() ;
			}
		}
	}
	#endregion
}