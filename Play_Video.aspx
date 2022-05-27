<%@ Page Title="" Language="C#" MasterPageFile="~/master_Home.Master" AutoEventWireup="true" CodeBehind="Play_Video.aspx.cs" Inherits="MusicWebOnline.Play_Video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="play_">
        <div class="left_playvideo">
            <div class="menu_play"><a href="#" target="_blank">
                <img border="0" src="img_QuangCao/dat-quang-cao.gif" width="100%" height="150px" /></a></div>
            <div id="Play__" runat="server"></div>
            <div class="menu_play">
                <table cellspacing="0" class="__ThongTinBH">
                    <tr>
                        <td class="TraiClear" align="right">Bạn đang xem video :</td>
                        <td class="PhaiClear">
                            <asp:Label ID="lblTenvideo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TraiClear" align="right">Ca sỹ trình bày :</td>
                        <td class="PhaiClear">
                            <asp:Label ID="lblCasy" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TraiClear" align="right">Thể loại :</td>
                        <td class="PhaiClear">
                            <asp:Label ID="lblTheLoai" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div>
                <p>
                    <div class="TieuDe__">
                        &nbsp;&nbsp;&nbsp;Những Video Của 
                    <asp:Label ID="Lab_casi" runat="server"></asp:Label>
                    </div>
                </p>
                <asp:DataList ID="Video__" runat="server" Width="100%" RepeatColumns="2">
                    <ItemTemplate>
                       
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="120px"
                            ImageUrl='<%# "~/img_video/"+Eval("Hinh") %>'
                            PostBackUrl='<%#Eval("MaVideo","~/Play_Video.aspx?V={0}") %>'
                            Width="250px" />
                        <br />
                        <asp:HyperLink ID="cl2" runat="server"
                            NavigateUrl='<%# Eval("MaVideo","~/Play.aspx?V={0}") %>'
                            Text='<%# Eval("TenVideo") %>'></asp:HyperLink>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenCaSi") %>'></asp:Label>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
