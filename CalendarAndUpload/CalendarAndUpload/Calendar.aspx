<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <br />
    <br />
    <asp:Calendar ID="Calendar1" runat="server" Height="650px" Width="100%" BackColor="White" BorderColor="#00CCFF" BorderWidth="1px" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" NextPrevFormat="FullMonth" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="10px" HorizontalAlign="Center" VerticalAlign="Middle" />
        <DayStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
        <NextPrevStyle Font-Size="Medium" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#CCCCCC" />
        <SelectedDayStyle BackColor="#0066CC" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#0099FF" Font-Bold="True" Font-Size="Large" ForeColor="White" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <WeekendDayStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:Calendar>
</form>
</asp:Content>

