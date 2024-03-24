[ScriptEvent(ScriptEventType.PlayerSpawn)]
public static void PlayerSpawn(Character character, string reason)
{
    while (character.IsSpawned)
    {
        character.Gametime = 0;
        System.Threading.Thread.Sleep(3600000);
        character.Gametime = 1;
        Society.CalculateProgress(character);
        character.Gametime = 0;
        if (character.Dimension == 6531)
        {
            character.Dimension += 2;
        }
        else
        {
            character.Dimension += 1;
        }
    }
    while (character.IsDead)
    {
        if (character.IsSpawned)
        {
            character.Despawn();
            character.SendChatMessage("{f0ff00} Du wurdest despawned um nichts durcheinander zu bringen!");
            character.Gametime = 0;
        }
        else
        {
            character.SendChatMessage("{ff0000} Du musst zuerst spawnen, damit deine Zeit gezählt wird. Mit /respawn kannst du das erreichen!");
        }
    }
}
[ScriptEvent(ScriptEventType.PlayerDimensionChange)]
public static void PlayerProgressed(Character character, string reason)
{
    character.SendChatMessage("{00ff00} Gratulation, du bist ein Plateau höher gekommen!");
    character.SendChatMessage("{cdcdcd} Das bedeutet: {0000ff}Vielleicht {cdcdcd}wirst du {ff0000}niemanden {cdcdcd}sehen.");
    character.Spawn(new AltV.Net.Data.Position(-425, 1123, 325), 0);