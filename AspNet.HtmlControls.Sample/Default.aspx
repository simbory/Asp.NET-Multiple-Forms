<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNet.HtmlControls.Sample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function test(map, marker) {
            var pos = new google.maps.LatLng(marker.marker_data.lat, marker.marker_data.lng);
            map.setCenter(pos);
        }
        function setCenter(map, marker) {
            alert(marker.marker_data.title);
        }
    </script>
</head>
<body>
    <an:Form runat="server" MultiPartForm="False">
        <an:Img runat="server" Src="/img/logo.png" Alt="Logo"/>
        <an:Button runat="server" Type="button" Height="37px" Width="284px">Reset</an:Button>
        <an:Div runat="server">Test <asp:Label runat="server" Text="Label For:"></asp:Label></an:Div>
        <an:GoogleMap runat="server" Latitude="30.543764" Longitude="104.068045" Zoom="13" Width="600" Height="600" MaxZoom="15" MinZoom="10" ID="GoogleMap1" ShowStreetViewControl="False">
            <GoogleMakers>
                <an:GoogleMarker Latitude="30.543764" Longitude="104.068045" IconUrl="http://www.dfs.com/img/markers/marker-1.png" Title="Google Marker 1" OnClientClick="test"/>
                <an:GoogleMarker Latitude="30.542396" Longitude="104.067368" IconUrl="http://www.dfs.com/img/markers/marker-2.png" Title="'天府四街'东站" OnClientClick="setCenter"/>
            </GoogleMakers>
        </an:GoogleMap>
        <an:GoogleMap runat="server" Latitude="10" Longitude="10" Zoom="8" Width="1080" Height="600" MapType="SATELLITE">
            <GoogleMakers>
                <an:GoogleMarker Latitude="10" Longitude="10" OnClientClick="test"/>
            </GoogleMakers>
        </an:GoogleMap>
        <an:GoogleMap runat="server" Latitude="20" Longitude="20" Zoom="8" Width="500" Height="200" MapType="HYBRID" ID="Map3"
             ShowZoomControl="False" ShowOverviewMapControl="False" ShowPanControl="False" ShowRotateControl="False"
             ShowScaleControl="False" EnableScrollWheel="False"></an:GoogleMap>
        <an:CheckBox runat="server" Checked="True" Name="checkbox-1"/>
        <an:TextBox runat="server" Name="text-name"/>
        <an:FileUpload runat="server" Accept=".png" ID="FileSave"/>
        <an:ImageButton runat="server" ID="ImageBtn" Src="/Img/logo.png" Alt="sfsdsd"/><br/>
        <an:TextArea runat="server" Value="textarea" Name="SaveAs"/>
        <an:SubmitButton runat="server" Text="Submit" OnClick="Submit_Click"/>
        <an:SubmitButton runat="server" Text="Reset" OnClick="Reset_Click"/>
    </an:Form>
</body>
</html>
