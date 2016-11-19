<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="15008000">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="Tests" Type="Folder">
			<Item Name="FlagJSONTest.lvtest" Type="TestItem" URL="../Tests/FlagJSONTest.lvtest">
				<Property Name="utf.test.bind" Type="Str">FlagJSONTest.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">D1EB9E98-650A-D4FD-1B11-96563C44772F</Property>
			</Item>
			<Item Name="FlagJSONTest.vi" Type="VI" URL="../Tests/FlagJSONTest.vi"/>
			<Item Name="FlagStateToColorTest.lvtest" Type="TestItem" URL="../Tests/FlagStateToColorTest.lvtest">
				<Property Name="utf.test.bind" Type="Str">FlagStateToColorTest.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">BBFD49C1-8F44-CDBB-F9EF-A4AC8EC68B83</Property>
			</Item>
			<Item Name="FlagStateToColorTest.vi" Type="VI" URL="../Tests/FlagStateToColorTest.vi"/>
			<Item Name="PersonnelJSONTest.lvtest" Type="TestItem" URL="../Tests/PersonnelJSONTest.lvtest">
				<Property Name="utf.test.bind" Type="Str">PersonnelJSONTest.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">0B011D4B-4FBB-2904-32E1-538BCDBD9E15</Property>
			</Item>
			<Item Name="PersonnelJSONTest.vi" Type="VI" URL="../Tests/PersonnelJSONTest.vi"/>
			<Item Name="RequestJSONTest.lvtest" Type="TestItem" URL="../Tests/RequestJSONTest.lvtest">
				<Property Name="utf.test.bind" Type="Str">RequestJSONTest.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">3B86D005-4EB9-29A6-A7FB-E2A72E0B1BE2</Property>
			</Item>
			<Item Name="RequestJSONTest.vi" Type="VI" URL="../Tests/RequestJSONTest.vi"/>
			<Item Name="RoomJSONTest.lvtest" Type="TestItem" URL="../Tests/RoomJSONTest.lvtest">
				<Property Name="utf.test.bind" Type="Str">RoomJSONTest.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">C8AF3F2E-E652-B58C-81BA-81EE8D3F286E</Property>
			</Item>
			<Item Name="RoomJSONTest.vi" Type="VI" URL="../Tests/RoomJSONTest.vi"/>
			<Item Name="TestTimetoString.lvtest" Type="TestItem" URL="../Tests/TestTimetoString.lvtest">
				<Property Name="utf.test.bind" Type="Str">TestTimetoString.vi</Property>
				<Property Name="utf.vector.test.bind" Type="Str">BA7704D4-CC96-D32D-481B-A47CF2434347</Property>
			</Item>
			<Item Name="TestTimetoString.vi" Type="VI" URL="../Tests/TestTimetoString.vi"/>
		</Item>
		<Item Name="Flags.lvclass" Type="LVClass" URL="../Flags/Flags.lvclass"/>
		<Item Name="Personnel.lvclass" Type="LVClass" URL="../Personnel/Personnel.lvclass"/>
		<Item Name="Request.lvclass" Type="LVClass" URL="../Request/Request.lvclass"/>
		<Item Name="Room.lvclass" Type="LVClass" URL="../Room/Room.lvclass"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
