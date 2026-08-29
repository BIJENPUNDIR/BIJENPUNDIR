Dim master = Scene.FindContainer("Master")
Dim spd As Double

Sub OnInitParameters()

    RegisterParameterDouble("speed", "Speed:", 5, 1, 30)
    RegisterParameterContainer("target_con", "Master")

End Sub

Sub OnExecPerField()

    master = GetParameterContainer("target_con")
    spd = GetParameterDouble("speed")

    ' Smoothly follow the target position on the X axis.
    If master.Position.X < This.Position.X Then
        This.Position.X = This.Position.X - ((This.Position.X - master.Position.X) / spd)
    ElseIf master.Position.X > This.Position.X Then
        This.Position.X = This.Position.X + ((master.Position.X - This.Position.X) / spd)
    End If

    ' Smoothly follow the target position on the Y axis.
    If master.Position.Y < This.Position.Y Then
        This.Position.Y = This.Position.Y - ((This.Position.Y - master.Position.Y) / spd)
    ElseIf master.Position.Y > This.Position.Y Then
        This.Position.Y = This.Position.Y + ((master.Position.Y - This.Position.Y) / spd)
    End If

    ' Smoothly follow the target position on the Z axis.
    If master.Position.Z < This.Position.Z Then
        This.Position.Z = This.Position.Z - ((This.Position.Z - master.Position.Z) / spd)
    ElseIf master.Position.Z > This.Position.Z Then
        This.Position.Z = This.Position.Z + ((master.Position.Z - This.Position.Z) / spd)
    End If

    ' Smoothly follow the target X scale.
    If master.Scaling.X < This.Scaling.X Then
        This.Scaling.X = This.Scaling.X - ((This.Scaling.X - master.Scaling.X) / spd)
    ElseIf master.Scaling.X > This.Scaling.X Then
        This.Scaling.X = This.Scaling.X + ((master.Scaling.X - This.Scaling.X) / spd)
    End If

    ' Apply the target Y scale uniformly to XYZ.
    If master.Scaling.Y < This.Scaling.Y Then
        This.Scaling.XYZ = This.Scaling.Y - ((This.Scaling.Y - master.Scaling.Y) / spd)
    ElseIf master.Scaling.Y > This.Scaling.Y Then
        This.Scaling.XYZ = This.Scaling.Y + ((master.Scaling.Y - This.Scaling.Y) / spd)
    End If

    ' Smoothly follow the target Z rotation.
    If master.Rotation.Z < This.Rotation.Z Then
        This.Rotation.Z = This.Rotation.Z - ((This.Rotation.Z - master.Rotation.Z) / spd)
    ElseIf master.Rotation.Z > This.Rotation.Z Then
        This.Rotation.Z = This.Rotation.Z + ((master.Rotation.Z - This.Rotation.Z) / spd)
    End If

End Sub
