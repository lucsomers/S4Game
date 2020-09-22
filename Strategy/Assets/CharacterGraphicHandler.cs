public class CharacterGraphicHandler
{
    public void SelectCharacter(Character characterToSelect)
    {
        characterToSelect.Selected = true;
    }

    public void DeselectCharacter(Character characterToDeSelect)
    {
        characterToDeSelect.Selected = false;
    }
}