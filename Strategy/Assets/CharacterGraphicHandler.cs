public class CharacterGraphicHandler
{
    public void SelectCharacter(Character characterToSelect)
    {
        if (characterToSelect != null)
        {
            characterToSelect.Selected = true;
        }
    }

    public void DeselectCharacter(Character characterToDeSelect)
    {
        if (characterToDeSelect != null)
        {
            characterToDeSelect.Selected = false ;
        }
    }
}