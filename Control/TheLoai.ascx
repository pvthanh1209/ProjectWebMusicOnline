<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TheLoai.ascx.cs" Inherits="MusicWebOnline.Control.TheLoai" %>

<div class="theloai">
<div class="tieude"><h2 class="aa">&nbsp; Chủ Đề</h2></div>
<div class="noidung" style="height:400px; overflow:scroll;">
<asp:DataList ID="ChuDe__" runat="server" Width="100%">
                <ItemTemplate>
                    <div class="menu1">
                        <asp:HyperLink ID="HyperNhac" Text='<%#Eval("TenTheLoai") %>' 
                                NavigateUrl='<%#Eval("MaTheLoai","~/ChuDe.aspx?L={0}") %>' 
                                runat="server">
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            
            </asp:DataList>
</div>
</div>
