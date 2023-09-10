public class PlayerAdapter
{
    private readonly Player player;  
    private readonly PlayerUI playerUI;
 
    public PlayerAdapter(Player player, PlayerUI playerUI)
    {
        this.player = player;
        this.playerUI = playerUI;
    }

    public void SetListeners()
    {
        playerUI.AddListenerAttackButton(player.Attack);
        playerUI.AddListenerBuffButton(player.ApplyBuff);

        player.AddHealthListener(playerUI.SetHealthBar);
        player.AddArmorListener(playerUI.SetArmorBar);
        player.AddVampirismListener(playerUI.SetVampirirsmBar);

        player.AddBuffDurationListener(playerUI.UpdateBuffUI);
        player.AddBuffListener(playerUI.SetBuff);

        player.SetupStats();
    }

    public void RemoveListener()
    {
        playerUI.RemoveListenerAttackButton(player.Attack);
        playerUI.RemoveListenerBuffButton(player.ApplyBuff);

        player.RemoveHealthListener(playerUI.SetHealthBar);
        player.RemoveArmorListener(playerUI.SetArmorBar);
        player.RemoveVampirismListener(playerUI.SetVampirirsmBar);

        player.RemoveBuffDurationListener(playerUI.UpdateBuffUI);
        player.RemoveBuffListener(playerUI.SetBuff);
    }
}
