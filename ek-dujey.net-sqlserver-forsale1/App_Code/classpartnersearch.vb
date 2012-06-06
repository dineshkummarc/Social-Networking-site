Imports Microsoft.VisualBasic
Imports partnersearchTableAdapters.partnersearchTableAdapter
<System.ComponentModel.DataObject()> _
Public Class classpartnersearch
    Private _productsAdapter As partnersearchTableAdapters.partnersearchTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As partnersearchTableAdapters.partnersearchTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New partnersearchTableAdapters.partnersearchTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal jointype As String, ByVal sq As String) As partnersearch.partnersearchDataTable
        Return Adapter.GetDatapartners(startRowIndex, TotalNumberOfProducts(jointype, sq), jointype, sq)
    End Function

    Public Function TotalNumberOfProducts(ByVal jointype As String, ByVal sq As String) As Integer
        Return Adapter.partnersearchcount(jointype, sq)
    End Function
    'Public Function returncvs(ByVal startRowIndex As Integer, ByVal maximumRows As Integer) As Data.DataTable
    '    Dim kk As New northwindTableAdapters.cvsearchpagingTableAdapter
    '    Return kk.GetDatacvsearchpaging(startRowIndex, maximumRows)

    'End Function

    'Public Function cvcount(ByVal startRowIndex As Integer, ByVal maximumRows As Integer) As Double
    '    Dim kk As New northwindTableAdapters.cvsearchpagingTableAdapter
    '    Return kk.cvcount





End Class
