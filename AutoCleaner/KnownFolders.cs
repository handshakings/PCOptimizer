﻿using System;
using System.Runtime.InteropServices;

namespace AutoCleaner
{
    internal class KnownFolders
    {
        public static string GetPath(KnownFolder knownFolder)
        {
            return GetPath(knownFolder, false);
        }
        public static string GetPath(KnownFolder knownFolder, bool defaultUser)
        {
            return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
        }
        public static string GetDefaultPath(KnownFolder knownFolder)
        {
            return GetDefaultPath(knownFolder, false);
        }
        public static string GetDefaultPath(KnownFolder knownFolder, bool defaultUser)
        {
            return GetPath(knownFolder, KnownFolderFlags.DefaultPath | KnownFolderFlags.DontVerify,
                defaultUser);
        }
        public static void Initialize(KnownFolder knownFolder)
        {
            Initialize(knownFolder, false);
        }
        public static void Initialize(KnownFolder knownFolder, bool defaultUser)
        {
            GetPath(knownFolder, KnownFolderFlags.Create | KnownFolderFlags.Init, defaultUser);
        }
        private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags, bool defaultUser)
        {
            try
            {
                Guid guid = new Guid(_knownFolderGuids[(int)knownFolder]);

                int result = SHGetKnownFolderPath(guid, (uint)flags, new IntPtr(defaultUser ? -1 : 0), out IntPtr outPath);
                if (result >= 0)
                {
                    string path = Marshal.PtrToStringUni(outPath);
                    Marshal.FreeCoTaskMem(outPath);
                    return path;
                }
                else
                {
                    throw new ExternalException("Unable to retrieve the known folder path. It may not "
                        + "be available on this system.", result);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }


      
        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken,out IntPtr ppszPath);
        public enum KnownFolder
        {
            Contacts,
            Desktop,
            Documents,
            Downloads,
            Favorites,
            Links,
            Music,
            Pictures,
            SavedGames,
            SavedSearches,
            Videos,
        }
        [Flags]
        private enum KnownFolderFlags : uint
        {
            SimpleIDList = 0x00000100,
            NotParentRelative = 0x00000200,
            DefaultPath = 0x00000400,
            Init = 0x00000800,
            NoAlias = 0x00001000,
            DontUnexpand = 0x00002000,
            DontVerify = 0x00004000,
            Create = 0x00008000,
            NoAppcontainerRedirection = 0x00010000,
            AliasOnly = 0x80000000
        }
        private static string[] _knownFolderGuids = new string[]
        {
            "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
            "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
            "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
            "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
            "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
            "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
            "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
            "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
            "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
            "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
            "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
        };

      





        public enum KnownFolderAll
        {
            AccountPictures,
            AdminTools,
            ApplicationShortcuts,
            CameraRoll,
            CDBurning,
            CommonAdminTools,
            CommonOemLinks,
            CommonPrograms,
            CommonStartMenu,
            CommonStartup,
            CommonTemplates,
            Contacts,
            Cookies,
            Desktop,
            DeviceMetadataStore,
            Documents,
            DocumentsLibrary,
            Downloads,
            Favorites,
            Fonts,
            GameTasks,
            History,
            ImplicitAppShortcuts,
            InternetCache,
            Libraries,
            Links,
            LocalAppData,
            LocalAppDataLow,
            LocalizedResourcesDir,
            Music,
            MusicLibrary,
            NetHood,
            OriginalImages,
            PhotoAlbums,
            PicturesLibrary,
            Pictures,
            Playlists,
            PrintHood,
            Profile,
            ProgramData,
            ProgramFiles,
            ProgramFilesX64,
            ProgramFilesX86,
            ProgramFilesCommon,
            ProgramFilesCommonX64,
            ProgramFilesCommonX86,
            Programs,
            Public,
            PublicDesktop,
            PublicDocuments,
            PublicDownloads,
            PublicGameTasks,
            PublicLibraries,
            PublicMusic,
            PublicPictures,
            PublicRingtones,
            PublicUserTiles,
            PublicVideos,
            QuickLaunch,
            Recent,
            RecordedTVLibrary,
            ResourceDir,
            Ringtones,
            RoamingAppData,
            RoamedTileImages,
            RoamingTiles,
            SampleMusic,
            SamplePictures,
            SamplePlaylists,
            SampleVideos,
            SavedGames,
            SavedSearches,
            Screenshots,
            SearchHistory,
            SearchTemplates,
            SendTo,
            SidebarDefaultParts,
            SidebarParts,
            SkyDrive,
            SkyDriveCameraRoll,
            SkyDriveDocuments,
            SkyDrivePictures,
            StartMenu,
            Startup,
            System,
            SystemX86,
            Templates,
            UserPinned,
            UserProfiles,
            UserProgramFiles,
            UserProgramFilesCommon,
            Videos,
            VideosLibrary,
            Windows
        }



    }
}
