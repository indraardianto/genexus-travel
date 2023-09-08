/*
				   File: type_SdtSDTCountry
			Description: SDTCountry
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
	[XmlRoot(ElementName="SDTCountry")]
	[XmlType(TypeName="SDTCountry" , Namespace="Traveling" )]
	[Serializable]
	public class SdtSDTCountry : GxUserType
	{
		public SdtSDTCountry( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCountry_Name = "";

		}

		public SdtSDTCountry(IGxContext context)
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
				return gxTv_SdtSDTCountry_Id; 
			}
			set {
				gxTv_SdtSDTCountry_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTCountry_Name; 
			}
			set {
				gxTv_SdtSDTCountry_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="AttractionsQuantity")]
		[XmlElement(ElementName="AttractionsQuantity")]
		public short gxTpr_Attractionsquantity
		{
			get {
				return gxTv_SdtSDTCountry_Attractionsquantity; 
			}
			set {
				gxTv_SdtSDTCountry_Attractionsquantity = value;
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
			gxTv_SdtSDTCountry_Name = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCountry_Id;
		 

		protected string gxTv_SdtSDTCountry_Name;
		 

		protected short gxTv_SdtSDTCountry_Attractionsquantity;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTCountry", Namespace="Traveling")]
	public class SdtSDTCountry_RESTInterface : GxGenericCollectionItem<SdtSDTCountry>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCountry_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCountry_RESTInterface( SdtSDTCountry psdt ) : base(psdt)
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

		public SdtSDTCountry sdt
		{
			get { 
				return (SdtSDTCountry)Sdt;
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
				sdt = new SdtSDTCountry() ;
			}
		}
	}
	#endregion
}