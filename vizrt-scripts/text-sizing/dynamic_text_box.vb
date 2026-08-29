dim LastText as String = ""

sub OnExecPerField()

    dim Data1Text as String
    dim CharacterCount as Integer
    dim ExtraCharacters as Integer
    dim BoxWidth as Integer
    dim BoxHeight as Integer
    dim TextPath as String

    TextPath = "MAIN_SCENE*TREE*$object$TEXT"

    ' Read the current Control Text value.
    Data1Text = This.Geometry.Text
    CharacterCount = Len(Data1Text)

    ' Run when the actual text changes, even if the new text has the same length.
    if Data1Text <> LastText then

        if CharacterCount <= 50 then
            BoxWidth = 500
            BoxHeight = 200
        else
            ExtraCharacters = CharacterCount - 50

            ' Grow gradually after 50 characters.
            BoxWidth = 500 + (ExtraCharacters * 4)
            BoxHeight = 200 + (ExtraCharacters * 2)
        end if

        ' Keep the text box within the design limits.
        if BoxWidth > 900 then BoxWidth = 900
        if BoxHeight > 500 then BoxHeight = 500

        System.SendCommand(TextPath & "*GEOM*TBOX*WIDTH SET " & BoxWidth)
        System.SendCommand(TextPath & "*GEOM*TBOX*HEIGHT SET " & BoxHeight)

        Println "DATA1 characters: " & CharacterCount
        Println "Text box width: " & BoxWidth
        Println "Text box height: " & BoxHeight

        LastText = Data1Text

    end if

end sub
