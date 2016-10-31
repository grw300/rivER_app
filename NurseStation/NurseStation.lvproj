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
		<Item Name="Classes" Type="Folder">
			<Item Name="Flags.lvclass" Type="LVClass" URL="../../LVClasses/Flags/Flags.lvclass"/>
			<Item Name="Personnel.lvclass" Type="LVClass" URL="../../LVClasses/Personnel/Personnel.lvclass"/>
			<Item Name="Room.lvclass" Type="LVClass" URL="../../LVClasses/Room/Room.lvclass"/>
		</Item>
		<Item Name="Helpers" Type="Folder">
			<Item Name="CreateEvents.vi" Type="VI" URL="../Helpers/CreateEvents.vi"/>
			<Item Name="Get Clicked Array Index.vi" Type="VI" URL="../Helpers/Get Clicked Array Index.vi"/>
			<Item Name="Refresh UI Event.vi" Type="VI" URL="../Helpers/Refresh UI Event.vi"/>
		</Item>
		<Item Name="Tests" Type="Folder"/>
		<Item Name="TypeDef" Type="Folder">
			<Item Name="EventsReference.ctl" Type="VI" URL="../TypeDef/EventsReference.ctl"/>
			<Item Name="SelectedRoom.ctl" Type="VI" URL="../TypeDef/SelectedRoom.ctl"/>
			<Item Name="State Cluster.ctl" Type="VI" URL="../TypeDef/State Cluster.ctl"/>
		</Item>
		<Item Name="NurseStationMain.vi" Type="VI" URL="../NurseStationMain.vi"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="vi.lib" Type="Folder">
				<Item Name="LVPoint32TypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVPoint32TypeDef.ctl"/>
			</Item>
		</Item>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
