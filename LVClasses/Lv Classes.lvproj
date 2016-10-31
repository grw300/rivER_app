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
			<Item Name="FlagJasonTest.vi" Type="VI" URL="../Tests/FlagJasonTest.vi"/>
			<Item Name="FlagStateToColorTest.vi" Type="VI" URL="../Tests/FlagStateToColorTest.vi"/>
		</Item>
		<Item Name="Flags.lvclass" Type="LVClass" URL="../Flags/Flags.lvclass"/>
		<Item Name="Personnel.lvclass" Type="LVClass" URL="../Personnel/Personnel.lvclass"/>
		<Item Name="Room.lvclass" Type="LVClass" URL="../Room/Room.lvclass"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
