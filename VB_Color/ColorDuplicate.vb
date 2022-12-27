Sub ColorDuplicates()
'Updateby Extendoffice 20160704
    Dim xRg As Range
    Dim xTxt As String
    Dim xCell As Range
    Dim xChar As String
    Dim xCellPre As Range
    Dim xCIndex As Long
    Dim xCol As Collection
    Dim I As Long
    On Error Resume Next
    If ActiveWindow.RangeSelection.Count > 1 Then
      xTxt = ActiveWindow.RangeSelection.AddressLocal
    Else
      xTxt = ActiveSheet.UsedRange.AddressLocal
    End If
    Set xRg = Application.InputBox("please select the data range:", "Kutools for Excel", xTxt, , , , , 8)
    If xRg Is Nothing Then Exit Sub
    xCIndex = 2
    Set xCol = New Collection
    For Each xCell In xRg
      On Error Resume Next
          If xCell.Value <> vbNullString Then 'skip coloring empty cells

        xCol.Add xCell, xCell.Text
        If Err.Number = 457 Then
            xCIndex = xCIndex + 1
            If xCIndex > 56 Then xCIndex = 2 'start re-using colors
            Set xCellPre = xCol(xCell.Text)
            If xCellPre.Interior.ColorIndex = xlNone Then xCellPre.Interior.ColorIndex = xCIndex
            xCell.Interior.ColorIndex = xCellPre.Interior.ColorIndex
        ElseIf Err.Number = 9 Then
            MsgBox "Too many duplicate companies!", vbCritical, "Kutools for Excel"
            Exit Sub
        End If

    End If
      On Error GoTo 0
    Next
End Sub
