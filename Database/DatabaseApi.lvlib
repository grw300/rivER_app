<?xml version='1.0' encoding='UTF-8'?>
<Library LVVersion="15008000">
	<Property Name="NI.Lib.Icon" Type="Bin">&amp;1#!!!!!!!)!"1!&amp;!!!-!%!!!@````]!!!!"!!%!!!(]!!!*Q(C=\&gt;8"=&gt;MQ%!8143;(8.6"2CVM#WJ",7Q,SN&amp;(N&lt;!NK!7VM#WI"&lt;8A0$%94UZ2$P%E"Y.?G@I%A7=11U&gt;M\7P%FXB^VL\`NHV=@X&lt;^39O0^N(_&lt;8NZOEH@@=^_CM?,3)VK63LD-&gt;8LS%=_]J'0@/1N&lt;XH,7^\SFJ?]Z#5P?=F,HP+5JTTF+5`Z&gt;MB$(P+1)YX*RU2DU$(![)Q3YW.YBG&gt;YBM@8'*\B':\B'2Z&gt;9HC':XC':XD=&amp;M-T0--T0-.DK%USWS(H'2\$2`-U4`-U4`/9-JKH!&gt;JE&lt;?!W#%;UC_WE?:KH?:R']T20]T20]\A=T&gt;-]T&gt;-]T?/7&lt;66[UTQ//9^BIHC+JXC+JXA-(=640-640-6DOCC?YCG)-G%:(#(+4;6$_6)]R?.8&amp;%`R&amp;%`R&amp;)^,WR/K&lt;75?GM=BZUG?Z%G?Z%E?1U4S*%`S*%`S'$;3*XG3*XG3RV320-G40!G3*D6^J-(3D;F4#J,(T\:&lt;=HN+P5FS/S,7ZIWV+7.NNFC&lt;+.&lt;GC0819TX-7!]JVO,(7N29CR6L%7,^=&lt;(1M4#R*IFV][.DX(X?V&amp;6&gt;V&amp;G&gt;V&amp;%&gt;V&amp;\N(L@_Z9\X_TVONVN=L^?Y8#ZR0J`D&gt;$L&amp;]8C-Q_%1_`U_&gt;LP&gt;WWPAG_0NB@$TP@4C`%`KH@[8`A@PRPA=PYZLD8Y!#/7SO!!!!!!</Property>
	<Property Name="NI.Lib.SourceVersion" Type="Int">352354304</Property>
	<Property Name="NI.Lib.Version" Type="Str">1.0.0.0</Property>
	<Property Name="NI.LV.All.SourceOnly" Type="Bool">false</Property>
	<Item Name="API" Type="Folder">
		<Item Name="Reports" Type="Folder">
			<Item Name="GetAvgFulfillmentTime.vi" Type="VI" URL="../API/Reports/GetAvgFulfillmentTime.vi"/>
			<Item Name="GetAvgPatientStayTimeMultipleRooms.vi" Type="VI" URL="../API/Reports/GetAvgPatientStayTimeMultipleRooms.vi"/>
			<Item Name="GetAvgPatientStayTimeSingleRoom.vi" Type="VI" URL="../API/Reports/GetAvgPatientStayTimeSingleRoom.vi"/>
			<Item Name="GetPersonAvgTime.vi" Type="VI" URL="../API/Reports/GetPersonAvgTime.vi"/>
		</Item>
		<Item Name="Request" Type="Folder">
			<Item Name="FilterRequests.vi" Type="VI" URL="../API/Request/FilterRequests.vi"/>
			<Item Name="InsertNewRequest.vi" Type="VI" URL="../API/Request/InsertNewRequest.vi"/>
			<Item Name="ReadRequests.vi" Type="VI" URL="../API/Request/ReadRequests.vi"/>
			<Item Name="UpdateRequestAlarm.vi" Type="VI" URL="../API/Request/UpdateRequestAlarm.vi"/>
			<Item Name="UpdateRequestName.vi" Type="VI" URL="../API/Request/UpdateRequestName.vi"/>
			<Item Name="UpdateRequestTime.vi" Type="VI" URL="../API/Request/UpdateRequestTime.vi"/>
		</Item>
		<Item Name="Room" Type="Folder">
			<Item Name="FilterRoomEvents.vi" Type="VI" URL="../API/Room/FilterRoomEvents.vi"/>
			<Item Name="InsertNewRoomEvent.vi" Type="VI" URL="../API/Room/InsertNewRoomEvent.vi"/>
			<Item Name="ReadRoomEvents.vi" Type="VI" URL="../API/Room/ReadRoomEvents.vi"/>
		</Item>
	</Item>
	<Item Name="Helpers" Type="Folder">
		<Property Name="NI.LibItem.Scope" Type="Int">2</Property>
		<Item Name="Reports" Type="Folder">
			<Item Name="FlagIsOn.vi" Type="VI" URL="../Helpers/Reports/FlagIsOn.vi"/>
		</Item>
		<Item Name="Request" Type="Folder">
			<Item Name="BuildRequestFilter.vi" Type="VI" URL="../Helpers/Request/BuildRequestFilter.vi"/>
			<Item Name="CreateRequestTable.vi" Type="VI" URL="../Helpers/Request/CreateRequestTable.vi"/>
			<Item Name="DeleteRequestRow.vi" Type="VI" URL="../Helpers/Request/DeleteRequestRow.vi"/>
			<Item Name="DeleteRequestTable.vi" Type="VI" URL="../Helpers/Request/DeleteRequestTable.vi"/>
			<Item Name="UpdateRequestRaw.vi" Type="VI" URL="../Helpers/Request/UpdateRequestRaw.vi"/>
		</Item>
		<Item Name="Room" Type="Folder">
			<Item Name="BuildRoomFilter.vi" Type="VI" URL="../Helpers/Room/BuildRoomFilter.vi"/>
			<Item Name="ClusterToFlags.vi" Type="VI" URL="../Helpers/Room/ClusterToFlags.vi"/>
			<Item Name="CreateRoomTable.vi" Type="VI" URL="../Helpers/Room/CreateRoomTable.vi"/>
			<Item Name="DbRoomClusterToRoom.vi" Type="VI" URL="../Helpers/Room/DbRoomClusterToRoom.vi"/>
			<Item Name="DeleteRoomRow.vi" Type="VI" URL="../Helpers/Room/DeleteRoomRow.vi"/>
			<Item Name="DeleteRoomTable.vi" Type="VI" URL="../Helpers/Room/DeleteRoomTable.vi"/>
			<Item Name="RoomToDbCluster.vi" Type="VI" URL="../Helpers/Room/RoomToDbCluster.vi"/>
		</Item>
		<Item Name="Database_String_Converter_LV86.vi" Type="VI" URL="../Helpers/Database_String_Converter_LV86.vi"/>
		<Item Name="GetUDL_FilePath.vi" Type="VI" URL="../Helpers/GetUDL_FilePath.vi"/>
		<Item Name="ReadAllTableData.vi" Type="VI" URL="/&lt;resource&gt;/dialog/NewProjectWizard/ReadAllTableData.vi"/>
	</Item>
	<Item Name="TypeDef" Type="Folder">
		<Item Name="Request" Type="Folder">
			<Item Name="RequestsFilter.ctl" Type="VI" URL="../TypeDef/Request/RequestsFilter.ctl"/>
			<Item Name="RequestsTableColumnNames.ctl" Type="VI" URL="../TypeDef/Request/RequestsTableColumnNames.ctl"/>
			<Item Name="RequestsTableColumnNamesRing.ctl" Type="VI" URL="../TypeDef/Request/RequestsTableColumnNamesRing.ctl"/>
			<Item Name="RequestsTableDbTableName.ctl" Type="VI" URL="../TypeDef/Request/RequestsTableDbTableName.ctl"/>
		</Item>
		<Item Name="Room" Type="Folder">
			<Item Name="RoomFilter.ctl" Type="VI" URL="../TypeDef/Room/RoomFilter.ctl"/>
			<Item Name="RoomTableCluster.ctl" Type="VI" URL="../TypeDef/Room/RoomTableCluster.ctl"/>
			<Item Name="RoomTableColumnNames.ctl" Type="VI" URL="../TypeDef/Room/RoomTableColumnNames.ctl"/>
			<Item Name="RoomTableDbTableName.ctl" Type="VI" URL="../TypeDef/Room/RoomTableDbTableName.ctl"/>
			<Item Name="RoomTableFilterRing.ctl" Type="VI" URL="../TypeDef/Room/RoomTableFilterRing.ctl"/>
		</Item>
	</Item>
</Library>
