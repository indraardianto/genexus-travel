gx.evt.autoSkip=!1;gx.define("wwattraction",!1,function(){var n,t;this.ServerClass="wwattraction";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwattraction.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV16OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE");this.A9CountryId=gx.fn.getIntegerValue("COUNTRYID",",");this.AV16OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE")};this.Valid_Attractionid=function(){var n=gx.fn.currentGridRowImpl(56);return this.validCliEvt("Valid_Attractionid",56,function(){try{if(gx.fn.currentGridRowImpl(56)===0)return!0;var n=gx.util.balloon.getNew("ATTRACTIONID",gx.fn.currentGridRowImpl(56));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110k1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FILTERSCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCell"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","HideFiltersButton"),gx.fn.setCtrlProperty("BTNTOGGLE","Caption","Hide Filters"),gx.fn.setCtrlProperty("BTNTOGGLE","Tooltiptext","Hide Filters")):(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCellExpanded"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","ShowFiltersButton"),gx.fn.setCtrlProperty("BTNTOGGLE","Caption","Show Filters"),gx.fn.setCtrlProperty("BTNTOGGLE","Tooltiptext","Show Filters")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Caption"},{ctrl:"BTNTOGGLE",prop:"Tooltiptext"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120k1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("ORDERBYCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("ORDERBYCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:"ORDERBYCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130k1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCOUNTRYNAME","Visible",!0)):(gx.fn.setCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCOUNTRYNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCOUNTRYNAME","Visible")',ctrl:"vCOUNTRYNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140k2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150k2_client=function(){return this.executeServerEvent("'DOATTRACTIONLIST'",!1,null,!1,!1)};this.e160k2_client=function(){return this.executeServerEvent("ORDERBY1.CLICK",!0,null,!1,!0)};this.e170k2_client=function(){return this.executeServerEvent("ORDERBY2.CLICK",!0,null,!1,!0)};this.e210k2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220k2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,54,55,57,58,59,60,61,62,63,64,65,66];this.GXLastCtrlId=66;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",56,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwattraction",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(7,57,"ATTRACTIONID","Id","","AttractionId","int",0,"px",4,4,"right",null,[],7,"AttractionId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(8,58,"ATTRACTIONNAME","Name","","AttractionName","char",0,"px",50,50,"left",null,[],8,"AttractionName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(10,59,"COUNTRYNAME","Country Name","","CountryName","char",0,"px",50,50,"left",null,[],10,"CountryName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(16,60,"CITYNAME","City Name","","CityName","char",0,"px",50,50,"left",null,[],16,"CityName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(12,61,"CATEGORYNAME","Category Name","","CategoryName","char",0,"px",50,50,"left",null,[],12,"CategoryName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addBitmap(13,"ATTRACTIONPHOTO",62,0,"px",17,"px",null,"","Photo","ImageAttribute","WWColumn WWOptionalColumn");t.addSingleLineEdit(18,63,"ATTRACTIONADDRESS","Address","","AttractionAddress","svchar",0,"px",1024,80,"left",null,[],18,"AttractionAddress",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Trips",64,"vTRIPS","Trips","","Trips","int",0,"px",4,4,"right",null,[],"Trips","Trips",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",65,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",66,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"BTNTOGGLE",grid:0,evt:"e110k1_client"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"ACTIONS_INNER",grid:0};n[17]={id:17,fld:"BTNINSERT",grid:0,evt:"e140k2_client"};n[18]={id:18,fld:"BTNATTRACTIONLIST",grid:0,evt:"e150k2_client"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vATTRACTIONNAME",gxz:"ZV11AttractionName",gxold:"OV11AttractionName",gxvar:"AV11AttractionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11AttractionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11AttractionName=n)},v2c:function(){gx.fn.setControlValue("vATTRACTIONNAME",gx.O.AV11AttractionName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11AttractionName=this.val())},val:function(){return gx.fn.getControlValue("vATTRACTIONNAME")},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"FILTERSCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"ORDERBYCONTAINER",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"LBLORDERBY",format:1,grid:0,evt:"e120k1_client",ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"ORDERBYCONTAINER2",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"ORDERBY1",format:0,grid:0,evt:"e160k2_client",ctrltype:"textblock"};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"ORDERBY2",format:0,grid:0,evt:"e170k2_client",ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"COUNTRYNAMEFILTERCONTAINER",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"LBLCOUNTRYNAMEFILTER",format:1,grid:0,evt:"e130k1_client",ctrltype:"textblock"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vCOUNTRYNAME",gxz:"ZV15CountryName",gxold:"OV15CountryName",gxvar:"AV15CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15CountryName=n)},v2c:function(){gx.fn.setControlValue("vCOUNTRYNAME",gx.O.AV15CountryName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15CountryName=this.val())},val:function(){return gx.fn.getControlValue("vCOUNTRYNAME")},nac:gx.falseFn};n[49]={id:49,fld:"GRIDCELL",grid:0};n[50]={id:50,fld:"GRIDTABLE",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[57]={id:57,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:this.Valid_Attractionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONID",gxz:"Z7AttractionId",gxold:"O7AttractionId",gxvar:"A7AttractionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7AttractionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7AttractionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(56),gx.O.A7AttractionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7AttractionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(56),",")},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONNAME",gxz:"Z8AttractionName",gxold:"O8AttractionName",gxvar:"A8AttractionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8AttractionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8AttractionName=n)},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(56),gx.O.A8AttractionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8AttractionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z10CountryName",gxold:"O10CountryName",gxvar:"A10CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A10CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10CountryName=n)},v2c:function(n){gx.fn.setGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(56),gx.O.A10CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10CountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[60]={id:60,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CITYNAME",gxz:"Z16CityName",gxold:"O16CityName",gxvar:"A16CityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16CityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16CityName=n)},v2c:function(n){gx.fn.setGridControlValue("CITYNAME",n||gx.fn.currentGridRowImpl(56),gx.O.A16CityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16CityName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CITYNAME",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[61]={id:61,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYNAME",gxz:"Z12CategoryName",gxold:"O12CategoryName",gxvar:"A12CategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A12CategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z12CategoryName=n)},v2c:function(n){gx.fn.setGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(56),gx.O.A12CategoryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12CategoryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[62]={id:62,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONPHOTO",gxz:"Z13AttractionPhoto",gxold:"O13AttractionPhoto",gxvar:"A13AttractionPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A13AttractionPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z13AttractionPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ATTRACTIONPHOTO",n||gx.fn.currentGridRowImpl(56),gx.O.A13AttractionPhoto,gx.O.A40001AttractionPhoto_GXI)},c2v:function(n){gx.O.A40001AttractionPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A13AttractionPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONPHOTO",n||gx.fn.currentGridRowImpl(56))},val_GXI:function(n){return gx.fn.getGridControlValue("ATTRACTIONPHOTO_GXI",n||gx.fn.currentGridRowImpl(56))},gxvar_GXI:"A40001AttractionPhoto_GXI",nac:gx.falseFn};n[63]={id:63,lvl:2,type:"svchar",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONADDRESS",gxz:"Z18AttractionAddress",gxold:"O18AttractionAddress",gxvar:"A18AttractionAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A18AttractionAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z18AttractionAddress=n)},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONADDRESS",n||gx.fn.currentGridRowImpl(56),gx.O.A18AttractionAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18AttractionAddress=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONADDRESS",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[64]={id:64,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRIPS",gxz:"ZV17Trips",gxold:"OV17Trips",gxvar:"AV17Trips",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV17Trips=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17Trips=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vTRIPS",n||gx.fn.currentGridRowImpl(56),gx.O.AV17Trips,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17Trips=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vTRIPS",n||gx.fn.currentGridRowImpl(56),",")},nac:gx.falseFn};n[65]={id:65,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(56),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};n[66]={id:66,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:56,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(56),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(56))},nac:gx.falseFn};this.AV11AttractionName="";this.ZV11AttractionName="";this.OV11AttractionName="";this.AV15CountryName="";this.ZV15CountryName="";this.OV15CountryName="";this.Z7AttractionId=0;this.O7AttractionId=0;this.Z8AttractionName="";this.O8AttractionName="";this.Z10CountryName="";this.O10CountryName="";this.Z16CityName="";this.O16CityName="";this.Z12CategoryName="";this.O12CategoryName="";this.Z13AttractionPhoto="";this.O13AttractionPhoto="";this.Z18AttractionAddress="";this.O18AttractionAddress="";this.ZV17Trips=0;this.OV17Trips=0;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11AttractionName="";this.AV15CountryName="";this.A40001AttractionPhoto_GXI="";this.A9CountryId=0;this.A40000GXC1=0;this.A15CityId=0;this.A11CategoryId=0;this.A7AttractionId=0;this.A8AttractionName="";this.A10CountryName="";this.A16CityName="";this.A12CategoryName="";this.A13AttractionPhoto="";this.A18AttractionAddress="";this.AV17Trips=0;this.AV12Update="";this.AV13Delete="";this.AV16OrderedBy=0;this.AV14ADVANCED_LABEL_TEMPLATE="";this.Events={e140k2_client:["'DOINSERT'",!0],e150k2_client:["'DOATTRACTIONLIST'",!0],e160k2_client:["ORDERBY1.CLICK",!0],e170k2_client:["ORDERBY2.CLICK",!0],e210k2_client:["ENTER",!0],e220k2_client:["CANCEL",!0],e110k1_client:["'TOGGLE'",!1],e120k1_client:["LBLORDERBY.CLICK",!1],e130k1_client:["LBLCOUNTRYNAMEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms.START=[[{av:"AV20Pgmname",fld:"vPGMNAME",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("vCOUNTRYNAME","Visible")',ctrl:"vCOUNTRYNAME",prop:"Visible"},{ctrl:"FORM",prop:"Caption"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Caption"},{ctrl:"BTNTOGGLE",prop:"Tooltiptext"}]];this.EvtParms["LBLORDERBY.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:"ORDERBYCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:"ORDERBYCONTAINER",prop:"Class"}]];this.EvtParms["ORDERBY1.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:"ORDERBY1",prop:"Class"},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:"ORDERBY2",prop:"Class"},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms["ORDERBY2.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:"ORDERBY1",prop:"Class"},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:"ORDERBY2",prop:"Class"},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms["LBLCOUNTRYNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COUNTRYNAMEFILTERCONTAINER","Class")',ctrl:"COUNTRYNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCOUNTRYNAME","Visible")',ctrl:"vCOUNTRYNAME",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9",hsh:!0},{av:"A9CountryId",fld:"COUNTRYID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("ATTRACTIONNAME","Link")',ctrl:"ATTRACTIONNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("COUNTRYNAME","Link")',ctrl:"COUNTRYNAME",prop:"Link"},{av:"AV17Trips",fld:"vTRIPS",pic:"ZZZ9"},{av:"A40000GXC1",fld:"GXC1",pic:"999999999"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["'DOATTRACTIONLIST'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11AttractionName",fld:"vATTRACTIONNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"AV16OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14ADVANCED_LABEL_TEMPLATE",fld:"vADVANCED_LABEL_TEMPLATE",pic:"",hsh:!0},{av:"AV15CountryName",fld:"vCOUNTRYNAME",pic:""}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:"LBLORDERBY",prop:"Caption"},{av:'gx.fn.getCtrlProperty("LBLCOUNTRYNAMEFILTER","Caption")',ctrl:"LBLCOUNTRYNAMEFILTER",prop:"Caption"}]];this.EvtParms.VALID_ATTRACTIONID=[[],[]];this.setVCMap("AV16OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);this.setVCMap("A9CountryId","COUNTRYID",0,"int",4,0);this.setVCMap("AV16OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);this.setVCMap("AV16OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14ADVANCED_LABEL_TEMPLATE","vADVANCED_LABEL_TEMPLATE",0,"char",20,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[21]);t.addRefreshingVar(this.GXValidFnc[48]);t.addRefreshingVar({rfrVar:"AV16OrderedBy"});t.addRefreshingVar({rfrVar:"AV14ADVANCED_LABEL_TEMPLATE"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[21]);t.addRefreshingParm(this.GXValidFnc[48]);t.addRefreshingParm({rfrVar:"AV16OrderedBy"});t.addRefreshingParm({rfrVar:"AV14ADVANCED_LABEL_TEMPLATE"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwattraction)})