public static void SaveWaypoint(Character character)
{
    string Positions;
    MySqlCommand cmd = Database.Connection.CreateCommand();
    cmd.CommandText = "INSERT INTO checkpoints (position) VALUES (@position)";
    Positions = character.Position.X.ToString() + "," + character.Position.Y.ToString() + "," + character.Position.Z.ToString() + "," + character.Rotation.Yaw;
    cmd.Parameters.AddWithValue("@position", Positions);
    cmd.ExecuteNonQuery();
    character.SendChatMessage(character.Position + " sind die Koordinaten!");
}