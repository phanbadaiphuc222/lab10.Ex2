<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfrStudent.aspx.cs" Inherits="Student.wfrStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sinh viên</title>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="CSS/student.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="d-flex justify-content-center">
            <form id="form1" runat="server">
                <div class="d-flex justify-content-center">
                    <div class="title-tbl">
                        <asp:Label ID="Label1" runat="server" Text="Danh Sách Sinh Viên" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                    </div>
                </div>
                <asp:GridView CssClass="griv"
                    DataKeyNames="masv"
                    ID="grvStudent"
                    runat="server"
                    Height="500px" Width="900px"
                    AutoGenerateColumns="false"
                    datakeyname="masv"
                    AllowPaging="true"
                    PageSize="10"
                    OnSelectedIndex="grvStudent_OnSelectedIndex"
                    OnPageIndexChanging="grvStudent_PageIndexChanging"
                    OnRowEditing="grvStudent_RowEditing"
                    OnRowUpdating="grvStudent_RowUpdating"
                    OnRowCancelingEdit="grvStudent_RowCancelingEdit"
                    OnRowDeleting="grvStudent_OnRowDeleting" OnSelectedIndexChanged="grvStudent_SelectedIndexChanged">

                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div class="action-header-name">
                                    Thao tác
                                </div>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="action-header">
                                    <asp:LinkButton CssClass="btn btn-warning btn-sm" ID="btn_Edit" runat="server" Text="Sửa" CommandName="Edit" />
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btn_Delete" runat="server" Text="Xóa" CommandName="Delete" />
                                    <asp:LinkButton CssClass="btn btn-success btn-sm" ID="btn_Select" runat="server" Text="Chọn" CommandName="Select" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="action-header">
                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btn_Update" runat="server" Text="Cập nhật" CommandName="Update" />
                                </div>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã Sinh Viên" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên Sinh Viên" />
                        <asp:CheckBoxField DataField="phai" HeaderText="Phái" />
                        <asp:BoundField DataField="lop" HeaderText="Lớp" />
                    </Columns>
                </asp:GridView>

               <asp:GridView ID="grvStudent2" runat="server">
                </asp:GridView>
            </form>
        </div>
    </div>

</body>
</html>
