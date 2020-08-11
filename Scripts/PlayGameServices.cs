using System;
using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using StaticData;
public class PlayGameServices : MonoBehaviour
{
    ISavedGameMetadata currentGame;

    void Start()
    {
        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder().EnableSavedGames()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            PlayGamesPlatform.Instance.SignOut();
        }
    }
    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log(" Signed in!");
            ReadCurrentLevelsUnlocked();
        }
        else
        {
            Debug.Log(" Sign-in failed...");
            
        }
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            SignIn();
        }
    }
    
    public void AddAchivement(string id)
    {
        // Only do achievements if the user is signed in
        if (Social.localUser.authenticated)
        {

            Debug.Log("Sign in successful");
            Debug.Log(id);
            PlayGamesPlatform.Instance.UnlockAchievement(id, (bool success) =>
            {
                Debug.Log("Achivement Unlocked:" +
                          success);
            });
        }
    }
    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            SignIn();
        }
    }

    public void ReadSavedGame(string filename,
                             Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
    {

        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.OpenWithAutomaticConflictResolution(
            filename,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            callback);
    }

    public void WriteSavedGame(ISavedGameMetadata game, byte[] savedData,
                               Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
    {

        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder()
            .WithUpdatedPlayedTime(TimeSpan.FromMinutes(game.TotalTimePlayed.Minutes + 1))
            .WithUpdatedDescription("Saved at: " + System.DateTime.Now);

        // You can add an image to saved game data (such as as screenshot)
        // byte[] pngData = <PNG AS BYTES>;
        // builder = builder.WithUpdatedPngCoverImage(pngData);

        SavedGameMetadataUpdate updatedMetadata = builder.Build();

        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.CommitUpdate(game, updatedMetadata, savedData, callback);
    }

    public void ReadCurrentLevelsUnlocked()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
            return;
        Action<SavedGameRequestStatus, byte[]> readBinaryCallback =
        (SavedGameRequestStatus status, byte[] data) =>
        {
            Debug.Log(" Saved Game Binary Read: " + status.ToString());
            if (status == SavedGameRequestStatus.Success)
            {
                int unlockedLevels = UnlockedLevels.DefaultMax;
                if (PlayerPrefs.HasKey(UnlockedLevels.MaxKeyName))
                    unlockedLevels = PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName);
                int unlockedOnlineLevels = 0;
                try
                {
                    string scoreString = System.Text.Encoding.UTF8.GetString(data);
                    unlockedOnlineLevels = Convert.ToInt32(scoreString);
                }
                catch 
                {
                    Debug.Log("Saved Game Read: convert exception");
                }
                if(unlockedOnlineLevels > unlockedLevels)
                {
                    unlockedLevels = unlockedOnlineLevels;
                }
                Debug.Log("Read levels from play game service");
                PlayerPrefs.SetInt(UnlockedLevels.MaxKeyName, unlockedLevels);
            }
        };
                // CALLBACK: Handle the result of a read, which should return metadata
                Action<SavedGameRequestStatus, ISavedGameMetadata> readCallback =
        (SavedGameRequestStatus status, ISavedGameMetadata game) => {
            Debug.Log(" Saved Game Read: " + status.ToString());
            if (status == SavedGameRequestStatus.Success)
            {
                // Read the binary game data
                currentGame = game;
                PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(game,
                                                    readBinaryCallback);
            }
        };
        ReadSavedGame("file_unlocked_levels", readCallback);
    }
    public void UpdateUnlockedLevel()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
            return;
        int unlockedLevel = LevelManagement.GetActiveLevel() + 1;
        int oldUnlockedMaxLevel = 0;
        if (PlayerPrefs.HasKey(UnlockedLevels.MaxKeyName))
            oldUnlockedMaxLevel = PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName);
        if (unlockedLevel < oldUnlockedMaxLevel)
            unlockedLevel = oldUnlockedMaxLevel;
        PlayerPrefs.SetInt(UnlockedLevels.MaxKeyName, unlockedLevel);
        WriteUnlockedLevels(unlockedLevel);
        
    }

    private void WriteUnlockedLevels(int level)
    {
        Action<SavedGameRequestStatus, ISavedGameMetadata> writeCallback =
        (SavedGameRequestStatus status, ISavedGameMetadata game) => {
            Debug.Log("Write resulted in " + status.ToString());
        };
        ISavedGameMetadata currentGame = null;
        Action<SavedGameRequestStatus, byte[]> readBinaryCallback =
        (SavedGameRequestStatus status, byte[] data) =>
        {
            if (status == SavedGameRequestStatus.Success)
            {
                string unlockedLevelString = Convert.ToString(level);
                byte[] newData = System.Text.Encoding.UTF8.GetBytes(unlockedLevelString);
                WriteSavedGame(currentGame, newData, writeCallback);
            }
            };
            Action<SavedGameRequestStatus, ISavedGameMetadata> readCallback =
        (SavedGameRequestStatus status, ISavedGameMetadata game) => {
            Debug.Log(" Saved Game Read: " + status.ToString());
            if (status == SavedGameRequestStatus.Success)
            {
                // Read the binary game data
                currentGame = game;
                PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(game,
                                                    readBinaryCallback);
            }
        };

        ReadSavedGame("file_unlocked_levels", readCallback);
    }

    public void CheckForAchivements()
    {
        LevelToAchivement(LevelManagement.GetActiveLevel());
    }

    private void LevelToAchivement(int level)
    {
        switch(level)
        {
            case AchivementUnlockCount.knowledge_unlocked:
                AddAchivement(GPGSIds.achievement_knowledge_unlocked);
                break;
            case AchivementUnlockCount.experimenter:
                AddAchivement(GPGSIds.achievement_experimentor);
                break;
            case AchivementUnlockCount.explorer:
                AddAchivement(GPGSIds.achievement_explorer);
                break;
            case AchivementUnlockCount.pioneer:
                AddAchivement(GPGSIds.achievement_pioneer);
                break;
            case AchivementUnlockCount.innovator:
                AddAchivement(GPGSIds.achievement_innovator);
                break;
        }
    }
}
