[Command("judge")]
public void CMD_judge(Character character, Character target, string penalty) {
    if (character.Admin == "administrator")
    {
        if (target != null)
        {
            if (penalty != null)
            {
                if (penalty == "ban")
                {
                    MySqlCommand cmd = Database.Connection.CreateCommand();
                    cmd.CommandText = " UPDATE accounts SET banned = yes WHERE username='" + target.Name + "'";
                    cmd.ExecuteNonQuery();
                }else if(penalty == "removemoney")
                {
                    MySqlCommand cmd = Database.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE accounts SET money=0 WHERE username='"+target.Name+"'";
                    cmd.ExecuteNonQuery();
                }else if(penalty == "prison")
                {
                    MySqlCommand cmd = Database.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE accounts set dimension=6532 WHERE username='" + target.Name + "'";
                    cmd.ExecuteNonQuery();
                    Utilities.RefreshUser(target);
                    target.SendChatMessage("{0000ff} Ein Fehler ist aufgetreten, bitte neu einloggen!");
                }
            }
        }
    }
    else
    {
        character.SendChatMessage("{ff0000} Befehl judge nicht gefunden!");
    }
}