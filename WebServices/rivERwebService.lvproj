<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="15008000">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="NI.SortType" Type="Int">3</Property>
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="TypeDef" Type="Folder">
			<Item Name="RoomsStateCluster.ctl" Type="VI" URL="../TypeDef/RoomsStateCluster.ctl"/>
			<Item Name="RequestStateCluster.ctl" Type="VI" URL="../TypeDef/RequestStateCluster.ctl"/>
			<Item Name="RoomsActionEnum.ctl" Type="VI" URL="../TypeDef/RoomsActionEnum.ctl"/>
			<Item Name="RequestActionEnum.ctl" Type="VI" URL="../TypeDef/RequestActionEnum.ctl"/>
			<Item Name="PersonnelActions.ctl" Type="VI" URL="../TypeDef/PersonnelActions.ctl"/>
			<Item Name="BedStateCluster.ctl" Type="VI" URL="../TypeDef/BedStateCluster.ctl"/>
			<Item Name="PersonnelState.ctl" Type="VI" URL="../TypeDef/PersonnelState.ctl"/>
			<Item Name="PersonnelAndTime.ctl" Type="VI" URL="../TypeDef/PersonnelAndTime.ctl"/>
		</Item>
		<Item Name="Classes" Type="Folder">
			<Item Name="Flags.lvclass" Type="LVClass" URL="../../LVClasses/Flags/Flags.lvclass"/>
			<Item Name="Personnel.lvclass" Type="LVClass" URL="../../LVClasses/Personnel/Personnel.lvclass"/>
			<Item Name="Room.lvclass" Type="LVClass" URL="../../LVClasses/Room/Room.lvclass"/>
			<Item Name="Request.lvclass" Type="LVClass" URL="../../LVClasses/Request/Request.lvclass"/>
		</Item>
		<Item Name="Helpers" Type="Folder">
			<Item Name="FindRequestBySummary.vi" Type="VI" URL="../Helpers/FindRequestBySummary.vi"/>
			<Item Name="GetBedStatus.vi" Type="VI" URL="../Helpers/GetBedStatus.vi"/>
			<Item Name="RoomNumbertoIndex.vi" Type="VI" URL="../Helpers/RoomNumbertoIndex.vi"/>
			<Item Name="RoomBeaconToIndex.vi" Type="VI" URL="../../LVClasses/Room/RoomBeaconToIndex.vi"/>
			<Item Name="RoomsFGVLocalErrorH.vi" Type="VI" URL="../../LVRestAPI/RoomsFGVLocalErrorH.vi"/>
			<Item Name="GedBedsStatus.vi" Type="VI" URL="../../NurseStation/Helpers/GedBedsStatus.vi"/>
			<Item Name="PersonnelUIDtoIndex.vi" Type="VI" URL="../Helpers/PersonnelUIDtoIndex.vi"/>
			<Item Name="PDUsJasonToArray.vi" Type="VI" URL="../Helpers/PDUsJasonToArray.vi"/>
			<Item Name="PDUJsonToString.vi" Type="VI" URL="../Helpers/PDUJsonToString.vi"/>
			<Item Name="RoomPersonnelJasonToArray.vi" Type="VI" URL="../Helpers/RoomPersonnelJasonToArray.vi"/>
			<Item Name="RequestIDtoIndex.vi" Type="VI" URL="../Helpers/RequestIDtoIndex.vi"/>
			<Item Name="RoomPersonneltoJsonToString.vi" Type="VI" URL="../Helpers/RoomPersonneltoJsonToString.vi"/>
			<Item Name="RoomRequestsJasonToArray.vi" Type="VI" URL="../Helpers/RoomRequestsJasonToArray.vi"/>
			<Item Name="RequestJsonToString.vi" Type="VI" URL="../Helpers/RequestJsonToString.vi"/>
			<Item Name="RequestsJasonToArray.vi" Type="VI" URL="../Helpers/RequestsJasonToArray.vi"/>
			<Item Name="RequestsJasonToRequestObjectArray.vi" Type="VI" URL="../Helpers/RequestsJasonToRequestObjectArray.vi"/>
			<Item Name="NameJSONtoPersonnelJSON.vi" Type="VI" URL="../Helpers/NameJSONtoPersonnelJSON.vi"/>
		</Item>
		<Item Name="Tests" Type="Folder">
			<Item Name="FGV" Type="Folder">
				<Item Name="Room" Type="Folder">
					<Item Name="TestRFGVFlag Status.lvtest" Type="TestItem" URL="../Test/TestRFGVFlag Status.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVFlag Status.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">E14852CB-B3E4-EB61-9787-850CDEE62223</Property>
					</Item>
					<Item Name="TestRFGVFlag Status.vi" Type="VI" URL="../Test/TestRFGVFlag Status.vi"/>
					<Item Name="TestRFGVBedVacant.lvtest" Type="TestItem" URL="../Test/TestRFGVBedVacant.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVBedVacant.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">5988C8ED-8195-94FC-9401-C2C89E4C8BF9</Property>
					</Item>
					<Item Name="TestRFGVBedVacant.vi" Type="VI" URL="../Test/TestRFGVBedVacant.vi"/>
					<Item Name="TestRFGVRequests.lvtest" Type="TestItem" URL="../Test/TestRFGVRequests.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVRequests.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">03455D81-66C8-F757-3624-1BC140EFBD82</Property>
					</Item>
					<Item Name="TestRFGVRequests.vi" Type="VI" URL="../Test/TestRFGVRequests.vi"/>
					<Item Name="TestRFGVPersonnel.lvtest" Type="TestItem" URL="../Test/TestRFGVPersonnel.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVPersonnel.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">9A7124D5-985D-A2D3-EC8E-911C7320913D</Property>
					</Item>
					<Item Name="TestRFGVPersonnel.vi" Type="VI" URL="../Test/TestRFGVPersonnel.vi"/>
					<Item Name="TestRFGVBedURL.lvtest" Type="TestItem" URL="../Test/TestRFGVBedURL.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVBedURL.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">05E853EA-AB9E-DB64-C18C-10915464E2A6</Property>
					</Item>
					<Item Name="TestRFGVBedURL.vi" Type="VI" URL="../Test/TestRFGVBedURL.vi"/>
					<Item Name="TestRFGVRoom.lvtest" Type="TestItem" URL="../Test/TestRFGVRoom.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVRoom.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">4BE07E69-EFBC-A24A-43DF-CAC4409560D6</Property>
					</Item>
					<Item Name="TestRFGVRoom.vi" Type="VI" URL="../Test/TestRFGVRoom.vi"/>
				</Item>
				<Item Name="Personnel" Type="Folder">
					<Item Name="TestPFGVRequests.lvtest" Type="TestItem" URL="../Test/TestPFGVRequests.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestPFGVRequests.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">279D8512-5AD0-8CAD-FD4C-F0146BE2FDEA</Property>
					</Item>
					<Item Name="TestPFGVRequests.vi" Type="VI" URL="../Test/TestPFGVRequests.vi"/>
					<Item Name="TestPFGVReadUIDs.lvtest" Type="TestItem" URL="../Test/TestPFGVReadUIDs.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestPFGVReadUIDs.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">EE42C175-DDF4-18D4-0534-4C0D77FDDEC0</Property>
					</Item>
					<Item Name="TestPFGVReadUIDs.vi" Type="VI" URL="../Test/TestPFGVReadUIDs.vi"/>
					<Item Name="TestPFGVName.lvtest" Type="TestItem" URL="../Test/TestPFGVName.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestPFGVName.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">4CCE72BC-8C94-D7B3-DE46-4B299CC3EAB0</Property>
					</Item>
					<Item Name="TestPFGVName.vi" Type="VI" URL="../Test/TestPFGVName.vi"/>
					<Item Name="TestPFGVRole.lvtest" Type="TestItem" URL="../Test/TestPFGVRole.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestPFGVRole.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">7A1BC717-4D1E-1727-AC12-3449CD378C97</Property>
					</Item>
					<Item Name="TestPFGVRole.vi" Type="VI" URL="../Test/TestPFGVRole.vi"/>
					<Item Name="TestPFGVPersonnelManagment.lvtest" Type="TestItem" URL="../Test/TestPFGVPersonnelManagment.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestPFGVPersonnelManagment.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">3FF3D007-905F-480E-2D85-2F73341F7564</Property>
					</Item>
					<Item Name="TestPFGVPersonnelManagment.vi" Type="VI" URL="../Test/TestPFGVPersonnelManagment.vi"/>
				</Item>
				<Item Name="Requests" Type="Folder">
					<Item Name="TestRFGVRequestManagment.lvtest" Type="TestItem" URL="../Test/TestRFGVRequestManagment.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVRequestManagment.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">DCBA6A96-E900-3424-FAFD-04EA88D36D57</Property>
					</Item>
					<Item Name="TestRFGVRequestManagment.vi" Type="VI" URL="../Test/TestRFGVRequestManagment.vi"/>
					<Item Name="TestRFGVSummary.lvtest" Type="TestItem" URL="../Test/TestRFGVSummary.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVSummary.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">258E0ABD-544D-6349-C92D-B1F3F1BC8CA2</Property>
					</Item>
					<Item Name="TestRFGVSummary.vi" Type="VI" URL="../Test/TestRFGVSummary.vi"/>
					<Item Name="TestRFGVAck.lvtest" Type="TestItem" URL="../Test/TestRFGVAck.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVAck.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">A8EF5653-BBC7-F314-4C7F-BDB1B6961AF3</Property>
					</Item>
					<Item Name="TestRFGVAck.vi" Type="VI" URL="../Test/TestRFGVAck.vi"/>
					<Item Name="TestRFGVComplete.lvtest" Type="TestItem" URL="../Test/TestRFGVComplete.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVComplete.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">79343F3E-58BD-33F8-55DE-CE8D3C515E5B</Property>
					</Item>
					<Item Name="TestRFGVComplete.vi" Type="VI" URL="../Test/TestRFGVComplete.vi"/>
					<Item Name="TestRFGVCheckAlarm.lvtest" Type="TestItem" URL="../Test/TestRFGVCheckAlarm.lvtest">
						<Property Name="utf.test.bind" Type="Str">TestRFGVCheckAlarm.vi</Property>
						<Property Name="utf.vector.test.bind" Type="Str">711C65F1-C2D9-CF3F-19A7-464BF6D83A0B</Property>
					</Item>
					<Item Name="TestRFGVCheckAlarm.vi" Type="VI" URL="../Test/TestRFGVCheckAlarm.vi"/>
				</Item>
			</Item>
			<Item Name="RoomRestApi.lvlib" Type="Library" URL="../../LVRestAPI/RoomRestApi.lvlib"/>
			<Item Name="PersonnelRestApi.lvlib" Type="Library" URL="../../LVRestAPI/PersonnelRestApi.lvlib"/>
			<Item Name="Personnel API Test.vi" Type="VI" URL="../Test/Personnel API Test.vi"/>
			<Item Name="Room API Test.vi" Type="VI" URL="../Test/Room API Test.vi"/>
		</Item>
		<Item Name="FGV" Type="Folder">
			<Item Name="RoomsFGV.vi" Type="VI" URL="../FGV/RoomsFGV.vi"/>
			<Item Name="RequestFGV.vi" Type="VI" URL="../FGV/RequestFGV.vi"/>
			<Item Name="PersonnelFGV.vi" Type="VI" URL="../FGV/PersonnelFGV.vi"/>
		</Item>
		<Item Name="RivERWebService" Type="Web Service">
			<Property Name="Bld_buildSpecName" Type="Str"></Property>
			<Property Name="Bld_version.build" Type="Int">29</Property>
			<Property Name="ws.autoIncrementVersion" Type="Bool">true</Property>
			<Property Name="ws.disconnectInline" Type="Bool">true</Property>
			<Property Name="ws.disconnectTypeDefs" Type="Bool">false</Property>
			<Property Name="ws.guid" Type="Str">{D5AD7176-39EB-4102-A598-38C94D5974AB}</Property>
			<Property Name="ws.modifyLibraryFile" Type="Bool">true</Property>
			<Property Name="ws.remoteDebugging" Type="Bool">false</Property>
			<Property Name="ws.removeLibraryItems" Type="Bool">true</Property>
			<Property Name="ws.removePolyVIs" Type="Bool">true</Property>
			<Property Name="ws.serveDefaultDoc" Type="Bool">true</Property>
			<Property Name="ws.SSE2" Type="Bool">true</Property>
			<Property Name="ws.static_permissions" Type="Str"></Property>
			<Property Name="ws.version.build" Type="Int">29</Property>
			<Property Name="ws.version.fix" Type="Int">0</Property>
			<Property Name="ws.version.major" Type="Int">1</Property>
			<Property Name="ws.version.minor" Type="Int">0</Property>
			<Item Name="Startup VIs" Type="Startup VIs Container">
				<Item Name="WebStartup.vi" Type="VI" URL="../WebStartup.vi">
					<Property Name="ws.type" Type="Int">2</Property>
				</Item>
			</Item>
			<Item Name="Web Resources" Type="HTTP WebResources Container">
				<Item Name="GetRoom.vi" Type="VI" URL="../Methods/GetRoom.vi">
					<Property Name="ws.buffered" Type="Bool">true</Property>
					<Property Name="ws.includeNameInURL" Type="Bool">true</Property>
					<Property Name="ws.keepInMemory" Type="Bool">true</Property>
					<Property Name="ws.loadAtStartup" Type="Bool">true</Property>
					<Property Name="ws.method" Type="Int">1</Property>
					<Property Name="ws.outputFormat" Type="Int">1</Property>
					<Property Name="ws.outputType" Type="Int">1</Property>
					<Property Name="ws.permissions" Type="Str"></Property>
					<Property Name="ws.requireAPIKey" Type="Bool">false</Property>
					<Property Name="ws.type" Type="Int">1</Property>
					<Property Name="ws.uri" Type="Str"></Property>
					<Property Name="ws.useHeaders" Type="Bool">true</Property>
					<Property Name="ws.useStandardURL" Type="Bool">true</Property>
				</Item>
				<Item Name="PostRoom.vi" Type="VI" URL="../Methods/PostRoom.vi">
					<Property Name="ws.buffered" Type="Bool">true</Property>
					<Property Name="ws.includeNameInURL" Type="Bool">true</Property>
					<Property Name="ws.keepInMemory" Type="Bool">true</Property>
					<Property Name="ws.loadAtStartup" Type="Bool">true</Property>
					<Property Name="ws.method" Type="Int">3</Property>
					<Property Name="ws.outputFormat" Type="Int">1</Property>
					<Property Name="ws.outputType" Type="Int">1</Property>
					<Property Name="ws.permissions" Type="Str"></Property>
					<Property Name="ws.requireAPIKey" Type="Bool">false</Property>
					<Property Name="ws.type" Type="Int">1</Property>
					<Property Name="ws.uri" Type="Str"></Property>
					<Property Name="ws.useHeaders" Type="Bool">true</Property>
					<Property Name="ws.useStandardURL" Type="Bool">true</Property>
				</Item>
				<Item Name="GetPersonnel.vi" Type="VI" URL="../Methods/GetPersonnel.vi">
					<Property Name="ws.buffered" Type="Bool">true</Property>
					<Property Name="ws.includeNameInURL" Type="Bool">true</Property>
					<Property Name="ws.keepInMemory" Type="Bool">true</Property>
					<Property Name="ws.loadAtStartup" Type="Bool">true</Property>
					<Property Name="ws.method" Type="Int">1</Property>
					<Property Name="ws.outputFormat" Type="Int">2</Property>
					<Property Name="ws.outputType" Type="Int">0</Property>
					<Property Name="ws.permissions" Type="Str"></Property>
					<Property Name="ws.requireAPIKey" Type="Bool">false</Property>
					<Property Name="ws.type" Type="Int">1</Property>
					<Property Name="ws.uri" Type="Str"></Property>
					<Property Name="ws.useHeaders" Type="Bool">true</Property>
					<Property Name="ws.useStandardURL" Type="Bool">true</Property>
				</Item>
				<Item Name="PostPersonnel.vi" Type="VI" URL="../Methods/PostPersonnel.vi">
					<Property Name="ws.buffered" Type="Bool">true</Property>
					<Property Name="ws.includeNameInURL" Type="Bool">true</Property>
					<Property Name="ws.keepInMemory" Type="Bool">true</Property>
					<Property Name="ws.loadAtStartup" Type="Bool">true</Property>
					<Property Name="ws.method" Type="Int">3</Property>
					<Property Name="ws.outputFormat" Type="Int">2</Property>
					<Property Name="ws.outputType" Type="Int">0</Property>
					<Property Name="ws.permissions" Type="Str"></Property>
					<Property Name="ws.requireAPIKey" Type="Bool">false</Property>
					<Property Name="ws.type" Type="Int">1</Property>
					<Property Name="ws.uri" Type="Str"></Property>
					<Property Name="ws.useHeaders" Type="Bool">true</Property>
					<Property Name="ws.useStandardURL" Type="Bool">true</Property>
				</Item>
				<Item Name="UpdateFlagState.vi" Type="VI" URL="../Methods/UpdateFlagState.vi">
					<Property Name="ws.method" Type="Int">3</Property>
					<Property Name="ws.type" Type="Int">1</Property>
				</Item>
				<Item Name="ReadFlag.vi" Type="VI" URL="../Methods/ReadFlag.vi">
					<Property Name="ws.method" Type="Int">1</Property>
					<Property Name="ws.type" Type="Int">1</Property>
				</Item>
			</Item>
		</Item>
		<Item Name="RequestHandlerCommands.ctl" Type="VI" URL="../TypeDef/RequestHandlerCommands.ctl"/>
		<Item Name="RequestHandlerQueueCluster.ctl" Type="VI" URL="../TypeDef/RequestHandlerQueueCluster.ctl"/>
		<Item Name="SendCommnad.vi" Type="VI" URL="../Helpers/SendCommnad.vi"/>
		<Item Name="CheckAlarms.vi" Type="VI" URL="../Helpers/CheckAlarms.vi"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="vi.lib" Type="Folder">
				<Item Name="Error Cluster From Error Code.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Error Cluster From Error Code.vi"/>
				<Item Name="NI_WebServices.lvlib" Type="Library" URL="/&lt;vilib&gt;/wsapi/NI_WebServices.lvlib"/>
				<Item Name="NI_PackedLibraryUtility.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/LVLibp/NI_PackedLibraryUtility.lvlib"/>
				<Item Name="NI_FileType.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/lvfile.llb/NI_FileType.lvlib"/>
				<Item Name="Check if File or Folder Exists.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/libraryn.llb/Check if File or Folder Exists.vi"/>
				<Item Name="LabVIEWHTTPClient.lvlib" Type="Library" URL="/&lt;vilib&gt;/httpClient/LabVIEWHTTPClient.lvlib"/>
				<Item Name="Path To Command Line String.vi" Type="VI" URL="/&lt;vilib&gt;/AdvancedString/Path To Command Line String.vi"/>
				<Item Name="PathToUNIXPathString.vi" Type="VI" URL="/&lt;vilib&gt;/Platform/CFURL.llb/PathToUNIXPathString.vi"/>
				<Item Name="Clear Errors.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Clear Errors.vi"/>
			</Item>
			<Item Name="ws_runtime.dll" Type="Document" URL="ws_runtime.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
		</Item>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
