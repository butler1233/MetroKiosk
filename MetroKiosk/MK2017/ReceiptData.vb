Public Class ReceiptData

    Public SizeText As String
    Public Amount As String
    Public PriceLevel As String

End Class

Public Module StaticReceiptData
    Friend OrderName as String
    Friend OrderData As List(Of ReceiptData)
    Friend OrderTime as DateTime
End Module


