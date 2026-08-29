Dim textype As Integer
Dim mptype As Integer

Sub OnExecPerField()

    Select Case textype
        Case 0
            mptype = TX_MAP_VERTEX
        Case 1
            mptype = TX_MAP_LINEAR
        Case 2
            mptype = TX_MAP_REFLECT
        Case 3
            mptype = TX_MAP_SPHERICAL
    End Select

    This.Texture.MapPosition.X = This.Texture.MapPosition.X + GetParameterDouble("speed_X")
    This.Texture.MapPosition.Y = This.Texture.MapPosition.Y + GetParameterDouble("speed_Y")

    This.Texture.MapScaling.X = GetParameterDouble("scaling_X")
    This.Texture.MapScaling.Y = GetParameterDouble("scaling_Y")

    This.Texture.MapType = mptype

End Sub

Sub OnInitParameters()

    RegisterParameterDouble("speed_X", "Speed X:", 0, -3, 3)
    RegisterParameterDouble("speed_Y", "Speed Y:", 0, -3, 3)
    RegisterParameterDouble("scaling_X", "Scaling X:", 1, -100, 100)
    RegisterParameterDouble("scaling_Y", "Scaling Y:", 1, -100, 100)

    Dim mappingTypes As Array[String]
    mappingTypes.Push("VERTEX")
    mappingTypes.Push("LINEAR")
    mappingTypes.Push("REFLECT")
    mappingTypes.Push("SPHERICAL")

    RegisterRadioButton("type", "Texture Type:", 1, mappingTypes)

    ' Initialize the mapping type immediately.
    ReadValues()

End Sub

Sub ReadValues()

    textype = GetParameterInt("type")

End Sub

Sub OnParameterChanged(parameterName As String)

    ReadValues()

End Sub
