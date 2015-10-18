Public Class Form1
    Private _DBAccess As New DataBaseAccess
    Private _isLoading As Boolean = False
    Private Sub LoadDataOnComBoBox()
        Dim sqlQuery As String = "SELECT MaKH,TenKH FROM dbo.KhachHang"
        Dim dTable As DataTable = _DBAccess.GetDataTable(sqlQuery)
        Me.cmbClass.DataSource = dTable
        Me.cmbClass.ValueMember = "MaKH"
        Me.cmbClass.DisplayMember = "TenKH"



    End Sub

    Private Sub LoadDataOnGridView(MaKH As String)
        Dim sqlQuery As String = _
            String.Format("SELECT Email,DiaChi,SDT FROM dbo.KhachHang WHERE MaKH='{0}'", MaKH)
        Dim dTable As DataTable = _DBAccess.GetDataTable(sqlQuery)
        Me.khachhang.DataSource = dTable
        With Me.khachhang
            .Columns(0).HeaderText = "Email"
            .Columns(1).HeaderText = "DiaChi"
            .Columns(2).HeaderText = "SDT"

        End With
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _isLoading = True

        LoadDataOnComBoBox()
        LoadDataOnGridView(Me.cmbClass.SelectedValue)
        _isLoading = False
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged
        If Not _isLoading Then
            LoadDataOnGridView(Me.cmbClass.SelectedValue)
        End If
    End Sub
End Class
