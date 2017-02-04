<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="EditDirectorsTreatmentPanel.aspx.cs" Inherits="EditDirectorsTreatmentPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="one_wrap">
            <div class="widget">
                
                  <div class="widget_body">
            	<div class="project_sort">
                   <table cellpadding="2" border="0">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                     <tr>
                                    <td>File
                                    </td>
                                    <td><asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
                                    </td>
                                </tr>

                        <tr><td>VoiceOver:</td><td  style="width:100px"><asp:TextBox ID="txtVoiceOver" 
                                runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
                                runat="server" MaxLength="2147483647"  Width="400px" Height="200px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        </tr>
                        <tr><td>Rank:</td><td  style="width:100px"><asp:TextBox ID="txtRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                        </td>
                        </tr>




                        <tr><td>
                          <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>  
                          </td>
                          <td>
                                <asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /> 
                           <%-- <input type="button"   value="Cancel" onclick="top.test();"/>--%>
                            <%--
                               <asp:Button ID="btnCancel" runat="server" Text="Save" onclick="BtnCancel_Click" Width="64px" /> --%>
                           </td>
                           </tr></table>
                </div>
            </div>
           </div>
      </div>
</asp:Content>

