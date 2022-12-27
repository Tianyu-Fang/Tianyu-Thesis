
Sub GetAbsoluteUnique()
'Updateby Extendoffice 20160704
    Dim xRg As Range
    Dim xTxt As String
    Dim xCell As Range
    Dim xChar As String
    Dim xCellPre As Range
    Dim xCIndex As Long
    Dim xCol As Collection
    Dim I As Long
    Dim intResult1  As Integer
    Dim intResult2  As Integer
    Dim Result() As String
    Dim isAllHundred As Boolean
    Dim hasZero As Boolean
    
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
        
        ' table cell has to be separated by ", "
        Result = Split(xCell.Value, ", ")
        
        For Each res In Result
            If (CInt(res) = 100) Then
                isAllHundred = True
            Else
                isAllHundred = False
                Exit For
            End If
        Next res
            
        hasZero = False
        For Each res In Result
            If (CInt(res) = 0) Then
                hasZero = True
            End If
        Next res
        
        
        If isAllHundred = True Then
            xCol.Add xCell, xCell.Text
            Set xCellPre = xCol(xCell.Text)
            If xCellPre.Interior.ColorIndex = xlNone Then xCellPre.Interior.ColorIndex = 4
            xCell.Interior.ColorIndex = xCellPre.Interior.ColorIndex
        End If
    
        
        If hasZero = False Then
            xCol.Add xCell, xCell.Text
            Set xCellPre = xCol(xCell.Text)
            If xCellPre.Interior.ColorIndex = xlNone Then xCellPre.Interior.ColorIndex = 38
            xCell.Interior.ColorIndex = xCellPre.Interior.ColorIndex
        End If
    
    End If
      On Error GoTo 0
    Next
End Sub



