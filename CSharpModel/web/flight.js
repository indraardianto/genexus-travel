gx.evt.autoSkip=!1;gx.define("flight",!1,function(){var n,t;this.ServerClass="flight";this.PackageName="GeneXus.Programs";this.ServerFullClass="flight.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Flightid=function(){return this.validSrvEvt("Valid_Flightid",0).then(function(n){return n}.closure(this))};this.Valid_Flightdepartureairportid=function(){return this.validSrvEvt("Valid_Flightdepartureairportid",0).then(function(n){return n}.closure(this))};this.Valid_Flightdeparturecountryid=function(){return this.validCliEvt("Valid_Flightdeparturecountryid",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTDEPARTURECOUNTRYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightdeparturecityid=function(){return this.validCliEvt("Valid_Flightdeparturecityid",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTDEPARTURECITYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightarrivalairportid=function(){return this.validSrvEvt("Valid_Flightarrivalairportid",0).then(function(n){return n}.closure(this))};this.Valid_Flightarrivalcountryid=function(){return this.validCliEvt("Valid_Flightarrivalcountryid",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTARRIVALCOUNTRYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightarrivalcityid=function(){return this.validCliEvt("Valid_Flightarrivalcityid",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTARRIVALCITYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightprice=function(){return this.validCliEvt("Valid_Flightprice",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTPRICE");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightdiscountpercentage=function(){return this.validCliEvt("Valid_Flightdiscountpercentage",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTDISCOUNTPERCENTAGE");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Airlineid=function(){return this.validSrvEvt("Valid_Airlineid",0).then(function(n){return n}.closure(this))};this.Valid_Airlinediscountpercentage=function(){return this.validCliEvt("Valid_Airlinediscountpercentage",0,function(){try{var n=gx.util.balloon.getNew("AIRLINEDISCOUNTPERCENTAGE");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightcapacity=function(){return this.validCliEvt("Valid_Flightcapacity",0,function(){try{var n=gx.util.balloon.getNew("FLIGHTCAPACITY");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Flightseatid=function(){var n=gx.fn.currentGridRowImpl(138);return this.validCliEvt("Valid_Flightseatid",138,function(){try{if(gx.fn.currentGridRowImpl(138)===0)return!0;var n=gx.util.balloon.getNew("FLIGHTSEATID",gx.fn.currentGridRowImpl(138));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,138);this.standaloneModal0510();this.standaloneNotModal0510()}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Flightseatchar=function(){var n=gx.fn.currentGridRowImpl(138);return this.validCliEvt("Valid_Flightseatchar",138,function(){try{if(gx.fn.currentGridRowImpl(138)===0)return!0;var n=gx.util.balloon.getNew("FLIGHTSEATCHAR",gx.fn.currentGridRowImpl(138));if(this.AnyError=0,this.sMode10=this.Gx_mode,this.Gx_mode=gx.fn.getGridRowMode(10,138),gx.fn.gridDuplicateKey(140)&&(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Seat","","","","","","","","")),this.AnyError=gx.num.trunc(1,0)),!(gx.text.compare(this.A43FlightSeatChar,"A")==0||gx.text.compare(this.A43FlightSeatChar,"B")==0||gx.text.compare(this.A43FlightSeatChar,"C")==0||gx.text.compare(this.A43FlightSeatChar,"D")==0||gx.text.compare(this.A43FlightSeatChar,"E")==0||gx.text.compare(this.A43FlightSeatChar,"F")==0))try{n.setError("Field Flight Seat Char is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Flightseatlocation=function(){var n=gx.fn.currentGridRowImpl(138);return this.validCliEvt("Valid_Flightseatlocation",138,function(){try{if(gx.fn.currentGridRowImpl(138)===0)return!0;var t=gx.util.balloon.getNew("FLIGHTSEATLOCATION",gx.fn.currentGridRowImpl(138));if(this.AnyError=0,this.sMode10=this.Gx_mode,this.Gx_mode=gx.fn.getGridRowMode(10,138),!(gx.text.compare(this.A41FlightSeatLocation,"W")==0||gx.text.compare(this.A41FlightSeatLocation,"M")==0||gx.text.compare(this.A41FlightSeatLocation,"A")==0))try{t.setError("Field Flight Seat Location is out of range");this.AnyError=gx.num.trunc(1,0)}catch(i){}try{this.A42FlightCapacity=gx.num.trunc(gx.fn.countFrm("A41FlightSeatLocation",0,138,n,gx.trueFn,[]),0)}catch(i){}gx.text.compare(this.Gx_mode,"UPD")==0}catch(i){}try{return(this.Gx_mode=this.sMode10,t==null)?!0:t.show()}catch(i){}return!0})};this.standaloneModal0510=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("FLIGHTSEATID","Enabled",0):gx.fn.setCtrlProperty("FLIGHTSEATID","Enabled",1)}catch(n){}try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("FLIGHTSEATCHAR","Enabled",0):gx.fn.setCtrlProperty("FLIGHTSEATCHAR","Enabled",1)}catch(n){}};this.standaloneNotModal0510=function(){};this.e11056_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12056_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153];this.GXLastCtrlId=153;this.Gridflight_seatContainer=new gx.grid.grid(this,10,"Seat",138,"Gridflight_seat","Gridflight_seat","Gridflight_seatContainer",this.CmpContext,this.IsMasterPage,"flight",[40,43],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridflight_seatContainer;t.addSingleLineEdit(40,139,"FLIGHTSEATID","Seat Id","","FlightSeatId","int",0,"px",4,4,"right",null,[],40,"FlightSeatId",!0,0,!1,!1,"Attribute",1,"");t.addComboBox(43,140,"FLIGHTSEATCHAR","Seat Char","FlightSeatChar","char",null,1,!0,!1,0,"px","");t.addComboBox(41,141,"FLIGHTSEATLOCATION","Seat Location","FlightSeatLocation","char",null,0,!0,!1,0,"px","");this.Gridflight_seatContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e13056_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e14056_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e15056_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e16056_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e17056_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Flightid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridflight_seatContainer],fld:"FLIGHTID",gxz:"Z19FlightId",gxold:"O19FlightId",gxvar:"A19FlightId",ucs:[],op:[129,69,39,109,104,99],ip:[129,69,39,109,104,99,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A19FlightId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z19FlightId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTID",gx.O.A19FlightId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A19FlightId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Flightdepartureairportid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTUREAIRPORTID",gxz:"Z22FlightDepartureAirportId",gxold:"O22FlightDepartureAirportId",gxvar:"A22FlightDepartureAirportId",ucs:[],op:[64,54,59,49,44],ip:[64,54,44,59,49,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A22FlightDepartureAirportId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z22FlightDepartureAirportId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTUREAIRPORTID",gx.O.A22FlightDepartureAirportId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A22FlightDepartureAirportId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTDEPARTUREAIRPORTID",",")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTUREAIRPORTNAME",gxz:"Z23FlightDepartureAirportName",gxold:"O23FlightDepartureAirportName",gxvar:"A23FlightDepartureAirportName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23FlightDepartureAirportName=n)},v2z:function(n){n!==undefined&&(gx.O.Z23FlightDepartureAirportName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTUREAIRPORTNAME",gx.O.A23FlightDepartureAirportName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A23FlightDepartureAirportName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTDEPARTUREAIRPORTNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Flightdeparturecountryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTURECOUNTRYID",gxz:"Z26FlightDepartureCountryId",gxold:"O26FlightDepartureCountryId",gxvar:"A26FlightDepartureCountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A26FlightDepartureCountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z26FlightDepartureCountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTURECOUNTRYID",gx.O.A26FlightDepartureCountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A26FlightDepartureCountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTDEPARTURECOUNTRYID",",")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTURECOUNTRYNAME",gxz:"Z27FlightDepartureCountryName",gxold:"O27FlightDepartureCountryName",gxvar:"A27FlightDepartureCountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27FlightDepartureCountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z27FlightDepartureCountryName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTURECOUNTRYNAME",gx.O.A27FlightDepartureCountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27FlightDepartureCountryName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTDEPARTURECOUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Flightdeparturecityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTURECITYID",gxz:"Z28FlightDepartureCityId",gxold:"O28FlightDepartureCityId",gxvar:"A28FlightDepartureCityId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28FlightDepartureCityId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z28FlightDepartureCityId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTURECITYID",gx.O.A28FlightDepartureCityId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A28FlightDepartureCityId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTDEPARTURECITYID",",")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDEPARTURECITYNAME",gxz:"Z29FlightDepartureCityName",gxold:"O29FlightDepartureCityName",gxvar:"A29FlightDepartureCityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29FlightDepartureCityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z29FlightDepartureCityName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTDEPARTURECITYNAME",gx.O.A29FlightDepartureCityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A29FlightDepartureCityName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTDEPARTURECITYNAME")},nac:gx.falseFn};this.declareDomainHdlr(64,function(){});n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Flightarrivalairportid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALAIRPORTID",gxz:"Z24FlightArrivalAirportId",gxold:"O24FlightArrivalAirportId",gxvar:"A24FlightArrivalAirportId",ucs:[],op:[94,84,89,79,74],ip:[94,84,74,89,79,69],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A24FlightArrivalAirportId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24FlightArrivalAirportId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALAIRPORTID",gx.O.A24FlightArrivalAirportId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A24FlightArrivalAirportId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTARRIVALAIRPORTID",",")},nac:gx.falseFn};this.declareDomainHdlr(69,function(){});n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALAIRPORTNAME",gxz:"Z25FlightArrivalAirportName",gxold:"O25FlightArrivalAirportName",gxvar:"A25FlightArrivalAirportName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A25FlightArrivalAirportName=n)},v2z:function(n){n!==undefined&&(gx.O.Z25FlightArrivalAirportName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALAIRPORTNAME",gx.O.A25FlightArrivalAirportName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A25FlightArrivalAirportName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTARRIVALAIRPORTNAME")},nac:gx.falseFn};this.declareDomainHdlr(74,function(){});n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Flightarrivalcountryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALCOUNTRYID",gxz:"Z30FlightArrivalCountryId",gxold:"O30FlightArrivalCountryId",gxvar:"A30FlightArrivalCountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30FlightArrivalCountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30FlightArrivalCountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALCOUNTRYID",gx.O.A30FlightArrivalCountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A30FlightArrivalCountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTARRIVALCOUNTRYID",",")},nac:gx.falseFn};this.declareDomainHdlr(79,function(){});n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALCOUNTRYNAME",gxz:"Z31FlightArrivalCountryName",gxold:"O31FlightArrivalCountryName",gxvar:"A31FlightArrivalCountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31FlightArrivalCountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z31FlightArrivalCountryName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALCOUNTRYNAME",gx.O.A31FlightArrivalCountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A31FlightArrivalCountryName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTARRIVALCOUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Flightarrivalcityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALCITYID",gxz:"Z32FlightArrivalCityId",gxold:"O32FlightArrivalCityId",gxvar:"A32FlightArrivalCityId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A32FlightArrivalCityId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z32FlightArrivalCityId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALCITYID",gx.O.A32FlightArrivalCityId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A32FlightArrivalCityId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTARRIVALCITYID",",")},nac:gx.falseFn};this.declareDomainHdlr(89,function(){});n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTARRIVALCITYNAME",gxz:"Z33FlightArrivalCityName",gxold:"O33FlightArrivalCityName",gxvar:"A33FlightArrivalCityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A33FlightArrivalCityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z33FlightArrivalCityName=n)},v2c:function(){gx.fn.setControlValue("FLIGHTARRIVALCITYNAME",gx.O.A33FlightArrivalCityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A33FlightArrivalCityName=this.val())},val:function(){return gx.fn.getControlValue("FLIGHTARRIVALCITYNAME")},nac:gx.falseFn};this.declareDomainHdlr(94,function(){});n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,lvl:0,type:"decimal",len:9,dec:2,sign:!1,pic:"ZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Flightprice,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTPRICE",gxz:"Z34FlightPrice",gxold:"O34FlightPrice",gxvar:"A34FlightPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34FlightPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z34FlightPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("FLIGHTPRICE",gx.O.A34FlightPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A34FlightPrice=this.val())},val:function(){return gx.fn.getDecimalValue("FLIGHTPRICE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(99,function(){});n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Flightdiscountpercentage,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTDISCOUNTPERCENTAGE",gxz:"Z35FlightDiscountPercentage",gxold:"O35FlightDiscountPercentage",gxvar:"A35FlightDiscountPercentage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A35FlightDiscountPercentage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z35FlightDiscountPercentage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTDISCOUNTPERCENTAGE",gx.O.A35FlightDiscountPercentage,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A35FlightDiscountPercentage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTDISCOUNTPERCENTAGE",",")},nac:gx.falseFn};this.declareDomainHdlr(104,function(){});n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"",grid:0};n[109]={id:109,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Airlineid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINEID",gxz:"Z37AirlineId",gxold:"O37AirlineId",gxvar:"A37AirlineId",ucs:[],op:[124,119,114],ip:[124,114,104,119,99,109],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A37AirlineId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z37AirlineId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AIRLINEID",gx.O.A37AirlineId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A37AirlineId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AIRLINEID",",")},nac:gx.falseFn};this.declareDomainHdlr(109,function(){});n[110]={id:110,fld:"",grid:0};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[113]={id:113,fld:"",grid:0};n[114]={id:114,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINENAME",gxz:"Z38AirlineName",gxold:"O38AirlineName",gxvar:"A38AirlineName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38AirlineName=n)},v2z:function(n){n!==undefined&&(gx.O.Z38AirlineName=n)},v2c:function(){gx.fn.setControlValue("AIRLINENAME",gx.O.A38AirlineName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A38AirlineName=this.val())},val:function(){return gx.fn.getControlValue("AIRLINENAME")},nac:gx.falseFn};this.declareDomainHdlr(114,function(){});n[115]={id:115,fld:"",grid:0};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[118]={id:118,fld:"",grid:0};n[119]={id:119,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Airlinediscountpercentage,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINEDISCOUNTPERCENTAGE",gxz:"Z39AirlineDiscountPercentage",gxold:"O39AirlineDiscountPercentage",gxvar:"A39AirlineDiscountPercentage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A39AirlineDiscountPercentage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z39AirlineDiscountPercentage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AIRLINEDISCOUNTPERCENTAGE",gx.O.A39AirlineDiscountPercentage,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A39AirlineDiscountPercentage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AIRLINEDISCOUNTPERCENTAGE",",")},nac:gx.falseFn};this.declareDomainHdlr(119,function(){});n[120]={id:120,fld:"",grid:0};n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"",grid:0};n[123]={id:123,fld:"",grid:0};n[124]={id:124,lvl:0,type:"decimal",len:9,dec:2,sign:!1,pic:"ZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTFINALPRICE",gxz:"Z36FlightFinalPrice",gxold:"O36FlightFinalPrice",gxvar:"A36FlightFinalPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A36FlightFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z36FlightFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("FLIGHTFINALPRICE",gx.O.A36FlightFinalPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A36FlightFinalPrice=this.val())},val:function(){return gx.fn.getDecimalValue("FLIGHTFINALPRICE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(124,function(){});n[125]={id:125,fld:"",grid:0};n[126]={id:126,fld:"",grid:0};n[127]={id:127,fld:"",grid:0};n[128]={id:128,fld:"",grid:0};n[129]={id:129,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Flightcapacity,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTCAPACITY",gxz:"Z42FlightCapacity",gxold:"O42FlightCapacity",gxvar:"A42FlightCapacity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A42FlightCapacity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z42FlightCapacity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FLIGHTCAPACITY",gx.O.A42FlightCapacity,0)},c2v:function(){this.val()!==undefined&&(gx.O.A42FlightCapacity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FLIGHTCAPACITY",",")},nac:gx.falseFn};n[130]={id:130,fld:"",grid:0};n[131]={id:131,fld:"",grid:0};n[132]={id:132,fld:"SEATTABLE",grid:0};n[133]={id:133,fld:"",grid:0};n[134]={id:134,fld:"",grid:0};n[135]={id:135,fld:"TITLESEAT",format:0,grid:0,ctrltype:"textblock"};n[136]={id:136,fld:"",grid:0};n[137]={id:137,fld:"",grid:0};n[139]={id:139,lvl:10,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:138,gxgrid:this.Gridflight_seatContainer,fnc:this.Valid_Flightseatid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTSEATID",gxz:"Z40FlightSeatId",gxold:"O40FlightSeatId",gxvar:"A40FlightSeatId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A40FlightSeatId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z40FlightSeatId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FLIGHTSEATID",n||gx.fn.currentGridRowImpl(138),gx.O.A40FlightSeatId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A40FlightSeatId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FLIGHTSEATID",n||gx.fn.currentGridRowImpl(138),",")},nac:gx.falseFn};n[140]={id:140,lvl:10,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:1,grid:138,gxgrid:this.Gridflight_seatContainer,fnc:this.Valid_Flightseatchar,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTSEATCHAR",gxz:"Z43FlightSeatChar",gxold:"O43FlightSeatChar",gxvar:"A43FlightSeatChar",ucs:[],op:[140],ip:[140],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A43FlightSeatChar=n)},v2z:function(n){n!==undefined&&(gx.O.Z43FlightSeatChar=n)},v2c:function(n){gx.fn.setGridComboBoxValue("FLIGHTSEATCHAR",n||gx.fn.currentGridRowImpl(138),gx.O.A43FlightSeatChar);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A43FlightSeatChar=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FLIGHTSEATCHAR",n||gx.fn.currentGridRowImpl(138))},nac:gx.falseFn};n[141]={id:141,lvl:10,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:1,grid:138,gxgrid:this.Gridflight_seatContainer,fnc:this.Valid_Flightseatlocation,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FLIGHTSEATLOCATION",gxz:"Z41FlightSeatLocation",gxold:"O41FlightSeatLocation",gxvar:"A41FlightSeatLocation",ucs:[],op:[141,129],ip:[129,141],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A41FlightSeatLocation=n)},v2z:function(n){n!==undefined&&(gx.O.Z41FlightSeatLocation=n)},v2c:function(n){gx.fn.setGridComboBoxValue("FLIGHTSEATLOCATION",n||gx.fn.currentGridRowImpl(138),gx.O.A41FlightSeatLocation);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A41FlightSeatLocation=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FLIGHTSEATLOCATION",n||gx.fn.currentGridRowImpl(138))},nac:gx.falseFn};n[142]={id:142,fld:"",grid:0};n[143]={id:143,fld:"",grid:0};n[144]={id:144,fld:"",grid:0};n[145]={id:145,fld:"",grid:0};n[146]={id:146,fld:"BTN_ENTER",grid:0,evt:"e11056_client",std:"ENTER"};n[147]={id:147,fld:"",grid:0};n[148]={id:148,fld:"BTN_CANCEL",grid:0,evt:"e12056_client"};n[149]={id:149,fld:"",grid:0};n[150]={id:150,fld:"BTN_DELETE",grid:0,evt:"e18056_client",std:"DELETE"};n[151]={id:151,fld:"PROMPT_22",grid:6};n[152]={id:152,fld:"PROMPT_24",grid:6};n[153]={id:153,fld:"PROMPT_37",grid:6};this.A19FlightId=0;this.Z19FlightId=0;this.O19FlightId=0;this.A22FlightDepartureAirportId=0;this.Z22FlightDepartureAirportId=0;this.O22FlightDepartureAirportId=0;this.A23FlightDepartureAirportName="";this.Z23FlightDepartureAirportName="";this.O23FlightDepartureAirportName="";this.A26FlightDepartureCountryId=0;this.Z26FlightDepartureCountryId=0;this.O26FlightDepartureCountryId=0;this.A27FlightDepartureCountryName="";this.Z27FlightDepartureCountryName="";this.O27FlightDepartureCountryName="";this.A28FlightDepartureCityId=0;this.Z28FlightDepartureCityId=0;this.O28FlightDepartureCityId=0;this.A29FlightDepartureCityName="";this.Z29FlightDepartureCityName="";this.O29FlightDepartureCityName="";this.A24FlightArrivalAirportId=0;this.Z24FlightArrivalAirportId=0;this.O24FlightArrivalAirportId=0;this.A25FlightArrivalAirportName="";this.Z25FlightArrivalAirportName="";this.O25FlightArrivalAirportName="";this.A30FlightArrivalCountryId=0;this.Z30FlightArrivalCountryId=0;this.O30FlightArrivalCountryId=0;this.A31FlightArrivalCountryName="";this.Z31FlightArrivalCountryName="";this.O31FlightArrivalCountryName="";this.A32FlightArrivalCityId=0;this.Z32FlightArrivalCityId=0;this.O32FlightArrivalCityId=0;this.A33FlightArrivalCityName="";this.Z33FlightArrivalCityName="";this.O33FlightArrivalCityName="";this.A34FlightPrice=0;this.Z34FlightPrice=0;this.O34FlightPrice=0;this.A35FlightDiscountPercentage=0;this.Z35FlightDiscountPercentage=0;this.O35FlightDiscountPercentage=0;this.A37AirlineId=0;this.Z37AirlineId=0;this.O37AirlineId=0;this.A38AirlineName="";this.Z38AirlineName="";this.O38AirlineName="";this.A39AirlineDiscountPercentage=0;this.Z39AirlineDiscountPercentage=0;this.O39AirlineDiscountPercentage=0;this.A36FlightFinalPrice=0;this.Z36FlightFinalPrice=0;this.O36FlightFinalPrice=0;this.A42FlightCapacity=0;this.Z42FlightCapacity=0;this.O42FlightCapacity=0;this.Z40FlightSeatId=0;this.O40FlightSeatId=0;this.Z43FlightSeatChar="";this.O43FlightSeatChar="";this.Z41FlightSeatLocation="";this.O41FlightSeatLocation="";this.A40FlightSeatId=0;this.A43FlightSeatChar="";this.A41FlightSeatLocation="";this.A19FlightId=0;this.A36FlightFinalPrice=0;this.A22FlightDepartureAirportId=0;this.A23FlightDepartureAirportName="";this.A26FlightDepartureCountryId=0;this.A27FlightDepartureCountryName="";this.A28FlightDepartureCityId=0;this.A29FlightDepartureCityName="";this.A24FlightArrivalAirportId=0;this.A25FlightArrivalAirportName="";this.A30FlightArrivalCountryId=0;this.A31FlightArrivalCountryName="";this.A32FlightArrivalCityId=0;this.A33FlightArrivalCityName="";this.A34FlightPrice=0;this.A35FlightDiscountPercentage=0;this.A37AirlineId=0;this.A38AirlineName="";this.A39AirlineDiscountPercentage=0;this.A42FlightCapacity=0;this.Events={e11056_client:["ENTER",!0],e12056_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_FLIGHTID=[[{av:"A19FlightId",fld:"FLIGHTID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A22FlightDepartureAirportId",fld:"FLIGHTDEPARTUREAIRPORTID",pic:"ZZZ9"},{av:"A24FlightArrivalAirportId",fld:"FLIGHTARRIVALAIRPORTID",pic:"ZZZ9"},{av:"A34FlightPrice",fld:"FLIGHTPRICE",pic:"ZZZZZ9.99"},{av:"A35FlightDiscountPercentage",fld:"FLIGHTDISCOUNTPERCENTAGE",pic:"ZZ9"},{av:"A37AirlineId",fld:"AIRLINEID",pic:"ZZZ9"},{av:"A42FlightCapacity",fld:"FLIGHTCAPACITY",pic:"ZZZ9"},{av:"A23FlightDepartureAirportName",fld:"FLIGHTDEPARTUREAIRPORTNAME",pic:""},{av:"A26FlightDepartureCountryId",fld:"FLIGHTDEPARTURECOUNTRYID",pic:"ZZZ9"},{av:"A28FlightDepartureCityId",fld:"FLIGHTDEPARTURECITYID",pic:"ZZZ9"},{av:"A27FlightDepartureCountryName",fld:"FLIGHTDEPARTURECOUNTRYNAME",pic:""},{av:"A29FlightDepartureCityName",fld:"FLIGHTDEPARTURECITYNAME",pic:""},{av:"A25FlightArrivalAirportName",fld:"FLIGHTARRIVALAIRPORTNAME",pic:""},{av:"A30FlightArrivalCountryId",fld:"FLIGHTARRIVALCOUNTRYID",pic:"ZZZ9"},{av:"A32FlightArrivalCityId",fld:"FLIGHTARRIVALCITYID",pic:"ZZZ9"},{av:"A31FlightArrivalCountryName",fld:"FLIGHTARRIVALCOUNTRYNAME",pic:""},{av:"A33FlightArrivalCityName",fld:"FLIGHTARRIVALCITYNAME",pic:""},{av:"A38AirlineName",fld:"AIRLINENAME",pic:""},{av:"A39AirlineDiscountPercentage",fld:"AIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"},{av:"A36FlightFinalPrice",fld:"FLIGHTFINALPRICE",pic:"ZZZZZ9.99"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z19FlightId"},{av:"Z22FlightDepartureAirportId"},{av:"Z24FlightArrivalAirportId"},{av:"Z34FlightPrice"},{av:"Z35FlightDiscountPercentage"},{av:"Z37AirlineId"},{av:"Z42FlightCapacity"},{av:"Z23FlightDepartureAirportName"},{av:"Z26FlightDepartureCountryId"},{av:"Z28FlightDepartureCityId"},{av:"Z27FlightDepartureCountryName"},{av:"Z29FlightDepartureCityName"},{av:"Z25FlightArrivalAirportName"},{av:"Z30FlightArrivalCountryId"},{av:"Z32FlightArrivalCityId"},{av:"Z31FlightArrivalCountryName"},{av:"Z33FlightArrivalCityName"},{av:"Z38AirlineName"},{av:"Z39AirlineDiscountPercentage"},{av:"Z36FlightFinalPrice"},{av:"O42FlightCapacity"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_FLIGHTDEPARTUREAIRPORTID=[[{av:"A22FlightDepartureAirportId",fld:"FLIGHTDEPARTUREAIRPORTID",pic:"ZZZ9"},{av:"A26FlightDepartureCountryId",fld:"FLIGHTDEPARTURECOUNTRYID",pic:"ZZZ9"},{av:"A28FlightDepartureCityId",fld:"FLIGHTDEPARTURECITYID",pic:"ZZZ9"},{av:"A23FlightDepartureAirportName",fld:"FLIGHTDEPARTUREAIRPORTNAME",pic:""},{av:"A27FlightDepartureCountryName",fld:"FLIGHTDEPARTURECOUNTRYNAME",pic:""},{av:"A29FlightDepartureCityName",fld:"FLIGHTDEPARTURECITYNAME",pic:""}],[{av:"A23FlightDepartureAirportName",fld:"FLIGHTDEPARTUREAIRPORTNAME",pic:""},{av:"A26FlightDepartureCountryId",fld:"FLIGHTDEPARTURECOUNTRYID",pic:"ZZZ9"},{av:"A28FlightDepartureCityId",fld:"FLIGHTDEPARTURECITYID",pic:"ZZZ9"},{av:"A27FlightDepartureCountryName",fld:"FLIGHTDEPARTURECOUNTRYNAME",pic:""},{av:"A29FlightDepartureCityName",fld:"FLIGHTDEPARTURECITYNAME",pic:""}]];this.EvtParms.VALID_FLIGHTDEPARTURECOUNTRYID=[[],[]];this.EvtParms.VALID_FLIGHTDEPARTURECITYID=[[],[]];this.EvtParms.VALID_FLIGHTARRIVALAIRPORTID=[[{av:"A24FlightArrivalAirportId",fld:"FLIGHTARRIVALAIRPORTID",pic:"ZZZ9"},{av:"A30FlightArrivalCountryId",fld:"FLIGHTARRIVALCOUNTRYID",pic:"ZZZ9"},{av:"A32FlightArrivalCityId",fld:"FLIGHTARRIVALCITYID",pic:"ZZZ9"},{av:"A25FlightArrivalAirportName",fld:"FLIGHTARRIVALAIRPORTNAME",pic:""},{av:"A31FlightArrivalCountryName",fld:"FLIGHTARRIVALCOUNTRYNAME",pic:""},{av:"A33FlightArrivalCityName",fld:"FLIGHTARRIVALCITYNAME",pic:""}],[{av:"A25FlightArrivalAirportName",fld:"FLIGHTARRIVALAIRPORTNAME",pic:""},{av:"A30FlightArrivalCountryId",fld:"FLIGHTARRIVALCOUNTRYID",pic:"ZZZ9"},{av:"A32FlightArrivalCityId",fld:"FLIGHTARRIVALCITYID",pic:"ZZZ9"},{av:"A31FlightArrivalCountryName",fld:"FLIGHTARRIVALCOUNTRYNAME",pic:""},{av:"A33FlightArrivalCityName",fld:"FLIGHTARRIVALCITYNAME",pic:""}]];this.EvtParms.VALID_FLIGHTARRIVALCOUNTRYID=[[],[]];this.EvtParms.VALID_FLIGHTARRIVALCITYID=[[],[]];this.EvtParms.VALID_FLIGHTPRICE=[[],[]];this.EvtParms.VALID_FLIGHTDISCOUNTPERCENTAGE=[[],[]];this.EvtParms.VALID_AIRLINEID=[[{av:"A37AirlineId",fld:"AIRLINEID",pic:"ZZZ9"},{av:"A34FlightPrice",fld:"FLIGHTPRICE",pic:"ZZZZZ9.99"},{av:"A39AirlineDiscountPercentage",fld:"AIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"},{av:"A35FlightDiscountPercentage",fld:"FLIGHTDISCOUNTPERCENTAGE",pic:"ZZ9"},{av:"A38AirlineName",fld:"AIRLINENAME",pic:""},{av:"A36FlightFinalPrice",fld:"FLIGHTFINALPRICE",pic:"ZZZZZ9.99"}],[{av:"A38AirlineName",fld:"AIRLINENAME",pic:""},{av:"A39AirlineDiscountPercentage",fld:"AIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"},{av:"A36FlightFinalPrice",fld:"FLIGHTFINALPRICE",pic:"ZZZZZ9.99"}]];this.EvtParms.VALID_AIRLINEDISCOUNTPERCENTAGE=[[],[]];this.EvtParms.VALID_FLIGHTCAPACITY=[[],[]];this.EvtParms.VALID_FLIGHTSEATID=[[],[]];this.EvtParms.VALID_FLIGHTSEATCHAR=[[{ctrl:"FLIGHTSEATCHAR"},{av:"A43FlightSeatChar",fld:"FLIGHTSEATCHAR",pic:""}],[{ctrl:"FLIGHTSEATCHAR"},{av:"A43FlightSeatChar",fld:"FLIGHTSEATCHAR",pic:""}]];this.EvtParms.VALID_FLIGHTSEATLOCATION=[[{av:"A42FlightCapacity",fld:"FLIGHTCAPACITY",pic:"ZZZ9"},{ctrl:"FLIGHTSEATLOCATION"},{av:"A41FlightSeatLocation",fld:"FLIGHTSEATLOCATION",pic:""}],[{ctrl:"FLIGHTSEATLOCATION"},{av:"A41FlightSeatLocation",fld:"FLIGHTSEATLOCATION",pic:""},{av:"A42FlightCapacity",fld:"FLIGHTCAPACITY",pic:"ZZZ9"}]];this.setPrompt("PROMPT_22",[39]);this.setPrompt("PROMPT_24",[69]);this.setPrompt("PROMPT_37",[109]);this.EnterCtrl=["BTN_ENTER"];t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize();this.LvlOlds[6]=["O42FlightCapacity"]});gx.wi(function(){gx.createParentObj(this.flight)})