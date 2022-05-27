<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MusicWebOnline.admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="QuyDinh"> 
    <br />
    Quy Định Của Admin Ban Quản Trị Web</div>
<div class="NoiDungQuyDinh">
    <br />
BQT chỉ nhận sửa bài / xóa bài / khoá chủ đề / chuyển... / thay đổi tên đăng nhập (ID) theo yêu cầu của thành viên nếu có ảnh hưởng đến bản thân của thành viên đó hoặc có ảnh hưởng đến người khác. 
    <br />
    <br />
    BQT không được tự ý xóa user khi user không bị khóa hơn 12 tháng hoặc vi phạm 
    điều lệ web quá 3 lần.<br />
    <br />
    Nếu BQT không tuân thủ quy định trên quá 3 lần sẽ bị đình chỉ công tác.</div>
</asp:Content>
