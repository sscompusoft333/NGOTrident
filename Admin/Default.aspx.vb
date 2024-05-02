Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim conn As String
    Dim cn As New SqlConnection

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = "Data Source=A2NWPLSK14SQL-v01.shr.prod.iad2.secureserver.net;Integrated Security=False; DATABASE=roomedo;  Password=roomedo#tiffin$1; User ID=roomedo; Connect Timeout=15;Encrypt=False;Packet Size=4096"
        cn.ConnectionString = conn
        cn.Open()
        Dim eoid As String = "0"

        If Not String.IsNullOrEmpty(Request.QueryString("eoid")) Then
            eoid = Request.QueryString("eoid").ToString()

            Dim queryr4 As String
            queryr4 = "select  * from  news where category = '" & Request.QueryString("eoid") & "' ORDER BY ID DESC "
            Dim daa2 As SqlDataAdapter = New SqlDataAdapter(queryr4, cn)
            Dim dtt2 As DataTable = New DataTable
            daa2.Fill(dtt2)
            Repeater1.DataSource = dtt2
            Repeater1.DataBind()

        Else

            ' Code to execute if eoid value is present
            Dim queryr As String
            queryr = "select * from  News  ORDER BY ID DESC "
            Dim daa As SqlDataAdapter = New SqlDataAdapter(queryr, cn)
            Dim dtt As DataTable = New DataTable
            daa.Fill(dtt)
            Repeater1.DataSource = dtt
            Repeater1.DataBind()

        End If




        Dim queryr1 As String
        queryr1 = "select top 12 * from  News order by Title asc  "
        Dim daa1 As SqlDataAdapter = New SqlDataAdapter(queryr1, cn)
        Dim dtt1 As DataTable = New DataTable
        daa1.Fill(dtt1)
        DataList1.DataSource = dtt1
        DataList1.DataBind()
        cn.Close()
    End Sub
    <System.Web.Script.Services.ScriptMethod()>
    <System.Web.Services.WebMethod>
    Public Shared Function GetItemList(ByVal prefixText As String) As List(Of String)
        Dim getitem As New List(Of String)()

        Dim conn As New SqlConnection("Data Source=A2NWPLSK14SQL-v01.shr.prod.iad2.secureserver.net;Integrated Security=False; DATABASE=roomedo;  Password=roomedo#tiffin$1; User ID=roomedo; Connect Timeout=15;Encrypt=False;Packet Size=4096")
        Using cmd As New SqlCommand()
            cmd.CommandText = "Select top 12 Title  from  News  WHERE Title like @Text + '%'"
            cmd.Parameters.AddWithValue("@Text", prefixText)

            cmd.Connection = conn
            conn.Open()
            Using r As SqlDataReader = cmd.ExecuteReader()
                While r.Read()
                    getitem.Add(r("Title").ToString())
                End While
            End Using
        End Using
        conn.Close()
        Return getitem
    End Function

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim labilid1 As Label = e.Item.FindControl("label5")
        Dim id2 As String = labilid1.Text
        Session.Item("eoid") = id2
        Dim labilid2 As Label = e.Item.FindControl("label14")
        Dim id1 As String = labilid2.Text
        Session.Item("eid") = id1
        Dim labilid3 As Label = e.Item.FindControl("label8")
        Dim id3 As String = labilid3.Text
        Session.Item("eid1") = id3
        Dim labilid4 As Label = e.Item.FindControl("label9")
        Dim id4 As String = labilid4.Text
        Session.Item("eid2") = id4
        Response.Redirect("view.aspx?eoid=" & labilid1.Text)
    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim labilid1 As Label = e.Item.FindControl("label5")
        Dim id2 As String = labilid1.Text
        Session.Item("eoid") = id2
        Response.Redirect("view.aspx?eoid=" & labilid1.Text)
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cn.Open()
        Dim queryr1 As String
        queryr1 = "select * from News  where Title like '" + TextBox1.Text + "%'"
        Dim daa1 As SqlDataAdapter = New SqlDataAdapter(queryr1, cn)
        Dim dtt1 As DataTable = New DataTable
        daa1.Fill(dtt1)
        Repeater1.DataSource = dtt1
        Repeater1.DataBind()
        cn.close()
    End Sub
End Class
