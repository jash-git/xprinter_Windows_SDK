Module Utils

    Public Function PrinterStatusToText(status As Byte) As String
        Dim text

        If status = &H12 Then
            text = "Ready"
        ElseIf (status And &B100) > 0 Then
            text = "Cover opened"
        ElseIf (status And &B1000) > 0 Then
            text = "Feed button has been pressed"
        ElseIf (status And &B100000) > 0 Then
            text = "Printer is out of paper"
        ElseIf (status And &B1000000) > 0 Then
            text = "Error condition"
        Else
            text = "Error"
        End If

        Return text
    End Function

    Public Function CashDrawerStatusToText(status As Byte) As String
        Dim text

        If (status And &B100) > 0 Then
            text = "Cash Drawer Closed"
        Else
            text = "Cash Drawer Opened"
        End If
        Return text
    End Function


End Module
