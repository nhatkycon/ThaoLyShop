<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HHList.ascx.cs" Inherits="lib_ui_ThaoLy_Store_templates_HHList" %>
<%@ Register src="HHItem.ascx" tagname="HHItem" tagprefix="uc1" %>
<div class="hh-details-header">
    Tình trạng hàng<span class="pull-right muted">Cập nhật lúc: <%=DateTime.Now.ToString("HH:mm dd/MM/yyyy") %></span>
</div>
<div class="hh-details-body">
    <table class="table-striped table table-bordered">
        <thead>
            <tr>
                <th>
                    Size
                </th>
                <th>
                    Màu
                </th>
                <th>
                    Số lượng còn
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <uc1:HHItem ID="HHItem1" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>             
        </tbody>
    </table>
      
</div>

   