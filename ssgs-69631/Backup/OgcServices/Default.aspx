<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OgcWebServices._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <asp:HyperLink ID="HyperLink1" NavigateUrl="service.wms?SERVICE=WMS&REQUEST=GetCapabilities&VERSION=1.3.0"   runat="server">WMS GetCapabilities</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink7" NavigateUrl="service.wms?VERSION=1.3.0&REQUEST=GetMap&LAYERS=world_admin&STYLES=&CRS=EPSG:4326&BBOX=-180,-85,180,85&WIDTH=512&HEIGHT=512&FORMAT=image/png&BGCOLOR=0x0000FF"   runat="server">GetMap - World Layer on Blue</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink8" NavigateUrl="service.wms?VERSION=1.3.0&REQUEST=GetMap&LAYERS=world_admin&STYLES=region&CRS=EPSG:4326&BBOX=-180,-85,180,85&WIDTH=512&HEIGHT=512&FORMAT=image/png&BGCOLOR=0x0000FF"   runat="server">GetMap - World Layer styled by region on Blue</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink2" NavigateUrl="service.wms?VERSION=1.3.0&REQUEST=GetMap&LAYERS=world_admin&STYLES=&CRS=EPSG:4326&BBOX=157.0018,-57.500758,193,-24.000006&WIDTH=768&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=0xFFFFFF"   runat="server">GetMap - World Layer</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink6" NavigateUrl="service.wms?VERSION=1.3.0&REQUEST=GetMap&LAYERS=world_admin&STYLES=&CRS=EPSG:4326&BBOX=0,-85.051128779806547,180,0&WIDTH=256&HEIGHT=256&FORMAT=image/png&BGCOLOR=0x0000FF"   runat="server">GetMap - World Layer on Blue (VE tile 3)</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink3" NavigateUrl="service.wfs?SERVICE=WFS&REQUEST=GetCapabilities&VERSION=1.1.0"   runat="server">WFS GetCapabilities 1.1.0</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink4" NavigateUrl="service.wfs?SERVICE=WFS&REQUEST=GetCapabilities&VERSION=1.0.0"   runat="server">WFS GetCapabilities 1.0.0</asp:HyperLink><br />
             <asp:HyperLink ID="HyperLink5" NavigateUrl="service.wfs?SERVICE=WFS&VERSION=1.1.0&REQUEST=GetFeature&TYPENAME=world_admin"   runat="server">WFS GetFeatures TYPENAME=world_admin</asp:HyperLink><br />
             
    </div>
    </form>
</body>
</html>
